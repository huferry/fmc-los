using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reactive.Linq;
using System.Windows.Forms;
using Core;
using Los.Core;

namespace LoSAdmin
{
    public partial class FormAbsentDialog : Form
    {
        static private HashSet<Relation> relations = null;
        static private IDictionary<Relation, Course> rel_course = new Dictionary<Relation, Course>();

        private ListBox selection = new ListBox();

        private Relation selected_relation;
        private Course selected_course;
        private HashSet<DayMeeting> day_meettings;
        private DayMeeting selected_day_meeting;

        public FormAbsentDialog()
        {
            InitializeComponent();
            selection.Visible = false;
            selection.Parent = this;
        }

        static public bool Execute(Course course, DayMeeting meeting, Relation student, AttendanceStatus status, out string note)
        {
            var form = new FormAbsentDialog();
            form.textBoxName.Text = student.ToString();
            form.textBoxCourse.Text = course.Name;
            form.textBoxDate.Text = meeting.MeetingDate.ToLongDateString();
            form.comboBoxStatus.Text = status.ToString();

            if (form.ShowDialog() == DialogResult.OK)
            {
                note = form.textBoxReason.Text;
                return true;
            }
            note = "";
            return false;
        }

        private void textBoxReason_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = textBoxReason.Text.Length > 4;
        }

        private void PrepareToUseUserData()
        {
            // cache all relations
            if (relations == null)
            {
                relations = new HashSet<Relation>();
                rel_course.Clear();
                var all = Repository.GetAll<Relation>().ToList();
                FormWaiting.ShowMessage("Retrieve students");
                try
                {
                    int i = 0;
                    foreach (Relation r in all)
                    {
                        Course c = Course.GetActiveByRelation(r);
                        if (c != null)
                        {
                            relations.Add(r);
                            rel_course.Add(r, c);
                        }
                        FormWaiting.SetProgress(i++ * 100 / all.Count);
                    }
                }
                finally
                {
                    FormWaiting.Finished();
                }
            }

            // catch the event
            textBoxName.Enabled = true;
            textBoxName.ReadOnly = false;

			var text_observer = Observable.FromEventPattern<EventArgs> (textBoxName, "TextChanged")
                                    .Select (x => textBoxName.Text)
                                    .DistinctUntilChanged ()
				.Throttle (TimeSpan.FromMilliseconds (150));
			
            text_observer.Subscribe(NameChanged);

			var selection_click = Observable.FromEventPattern<EventArgs> (selection, "Click")
				.Select (x => selection.SelectedItem);

            selection_click.Subscribe(SelectionClick);
            
        }

        private void NameChanged(string input)
        {
            selection.Items.Clear();

            var choices = relations
                            .Where(x => x.ToString().ToUpper().Contains(input.ToUpper()))
                            .OrderBy(x => x.Firstname)
                            .ToList();

            selected_relation = SetSelection<Relation>(textBoxName, choices);

            if (selected_relation != null)
                StudentSelected();
        }

        private void SelectionClick(object item)
        {
            selection.Hide();
            if (item is Relation)
            {
                Relation rel = (item as Relation);
                textBoxName.Text = rel.ToString();
                textBoxName.SelectAll();
                selected_relation = rel;
                StudentSelected();
            }

            if (item is DayMeeting)
            {
                selected_day_meeting = (item as DayMeeting);
                textBoxDate.Text = selected_day_meeting.ToString();
                textBoxDate.SelectAll();
                DateSelected();
            }
        }

        private void StudentSelected()
        {
            selected_course = rel_course[selected_relation];

            if (selected_course == null)
            {
                MessageBox.Show("The selected person does not enrolled to any course", "Enrollement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogResult = DialogResult.Cancel;
                return;
            }

            textBoxCourse.Text = selected_course.Name;
            CourseSelected();
        }

        private void CourseSelected()
        {
            textBoxDate.Enabled = true;
            textBoxDate.ReadOnly = false;
            textBoxDate.Focus();

            try
            {
                FormWaiting.ShowMessage("Checking dates..");
                day_meettings = new HashSet<DayMeeting>();
                var entered_status = DayAttendance.GetByCourse(selected_course)
                                        .Where(x => x.Student.Equals(selected_relation))
                                        .Select(x => x.MeetingDate)
                                        .ToList();
                var meetings = DayMeeting.GetByCourse(selected_course).ToList();
                int i = 0;
                foreach (DayMeeting m in meetings)
                {
                    if (!entered_status.Contains(m.MeetingDate))
                        day_meettings.Add(m);
                    FormWaiting.SetProgress(i++  *100 / meetings.Count);
                }
            }
            finally
            {
                FormWaiting.Finished();
            }

			Observable.FromEventPattern<EventArgs>(textBoxDate, "TextChanged")
                .Select(x => textBoxDate.Text)
                .DistinctUntilChanged()
                .Throttle(TimeSpan.FromMilliseconds(150))
                .ObserveOnDispatcher()
                .Subscribe(DateChanged);
        }

        private void DateChanged(string input)
        {
            var choices = day_meettings
                            .Where(x => x.ToString().ToUpper().Contains(input.ToUpper()))
                            .ToList();
            selected_day_meeting = SetSelection<DayMeeting>(textBoxDate, choices);

            if (selected_day_meeting != null)
            {
                textBoxDate.Text = selected_day_meeting.ToString();
                textBoxDate.SelectAll();
                DateSelected();
            }
        }

        private void DateSelected()
        {
            /*
            var check = DayAttendance.GetByCourse(selected_course)
                            .Where(x => x.Student.Equals(selected_relation) && x.MeetingDate == selected_day_meeting.MeetingDate);
            if (check.Count() > 0)
            {
                textBoxDate.Text = "";
                selected_day_meeting = null;
                MessageBox.Show("Status of this student is already entered.", "Status entered", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxDate.Focus();
            }
            */
        }

        private T SetSelection<T>(TextBox in_control, List<T> choices)
        {
            if (choices.Count == 1)
            {
                selection.Hide();
                in_control.Text = choices[0].ToString();
                in_control.SelectAll();
                return choices[0];
            } 
            else if (choices.Count > 1)
            {
                // showing selections
                selection.Top = in_control.Top + in_control.Height + 2;
                selection.Left = in_control.Left;
                selection.Width = in_control.Width;
                selection.Height = in_control.Height * 10;
                selection.BringToFront();
                selection.Items.Clear();
                foreach (T i in choices)
                    selection.Items.Add(i);
                if (!selection.Visible)
                    selection.Visible = true;                
            }
            else
            {
                selection.Hide();
            }
            return default(T);
        }

        static public bool ExecuteEnterAbsence()
        {
            var form = new FormAbsentDialog();
            form.PrepareToUseUserData();
            form.comboBoxStatus.Enabled = true;
            form.comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            form.comboBoxStatus.Items.Add(AttendanceStatus.Leave);
            form.comboBoxStatus.Items.Add(AttendanceStatus.Ill);
            form.comboBoxStatus.SelectedIndex = 0;            

            if (form.ShowDialog() == DialogResult.OK)
            {
                DayAttendance day_att = new DayAttendance(form.selected_course, form.selected_relation, form.selected_day_meeting.MeetingDate);
                day_att.AttendanceStatus = (AttendanceStatus)form.comboBoxStatus.SelectedItem;
                day_att.Update();
                return true;
            }
            return false;
        }

        private void FormAbsentDialog_Shown(object sender, EventArgs e)
        {
            if (!textBoxName.ReadOnly)
                textBoxName.Focus();
            else
                textBoxReason.Focus();
        }
    }
}
