using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Los.Core;

namespace LoSAdmin
{
    public partial class FormMeetingPlanner : Form
    {
        private IEnumerable<Calendar> blockings = Calendar.GetByDates(DateTime.Now.AddDays(-200), DateTime.Now.AddDays(400));

        static public bool Execute(Course course)
        {
            FormMeetingPlanner form = new FormMeetingPlanner();
            form.course = course;
            form.InitCourse();

            return (form.ShowDialog() == DialogResult.OK);
        }

        private Course course;
        private List<Meeting> meetings;

        public FormMeetingPlanner()
        {
            InitializeComponent();
            dateTimePickerStart.Value = DateTime.Today;
        }

        private void InitCourse()
        {
            labelCourseName.Text = course.Name;
            meetings = course.Meetings.ToList();
            FillMeetings();
        }

        private void FillMeetings()
        {
            listViewMeetings.Items.Clear();
            foreach (Lesson les in course.Level.Lessons)
            {
                var item = listViewMeetings.Items.Add(les.Chapter);
                item.SubItems.Add(les.Name);
                item.Tag = les;
                var meeting = meetings.Where(x => x.Lesson.Equals(les));
                if (meeting.Count() > 0)
                {
                    item.SubItems.Add(meeting.First().MeetingDate.ToLongDateString());
                    var blocks = blockings.Where(x => x.IsBlocked(meeting.First().MeetingDate));
                    if (blocks.Count() > 0)
                        item.SubItems.Add("Warning: " + blocks.First().Name);
                    else
                        item.SubItems.Add("");
                }
                else
                {
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                }

            }
            groupBox2.Enabled = meetings.Count() == 0;            
        }

        private void buttonGoAuto_Click(object sender, EventArgs e)
        {
            meetings = course.InitiateWeeklyMeetings(dateTimePickerStart.Value.Date).ToList();
            FillMeetings();
        }

        private void moveOneWeekAheadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selected_meetings = GetSelectedMeetings();
            foreach (Meeting m in selected_meetings)
            {
                m.MeetingDate = m.MeetingDate.Subtract(TimeSpan.FromDays(7));
            }
            FillMeetings();
        }

        private void listViewMeetings_MouseClick(object sender, MouseEventArgs e)
        {
            Lesson les = GetSelectedLesson();
            Meeting meeting = GetSelectedMeeting();
            if (les != null)
            {
                moveOneWeekAheadToolStripMenuItem.Enabled = meeting != null;
                moveOneWeekLaterToolStripMenuItem.Enabled = meeting != null;
                changeDateToolStripMenuItem.Enabled = true;

                if (e.Button == MouseButtons.Right)
                {
                    contextMenuStrip1.Show(listViewMeetings, e.Location);
                }
            }
        }

        private Lesson GetSelectedLesson()
        {
            if (listViewMeetings.SelectedItems.Count > 0)
            {
                return (Lesson)listViewMeetings.SelectedItems[0].Tag;
            }
            return null;
        }

        private Meeting GetSelectedMeeting()
        {
            Lesson les = GetSelectedLesson();
            if (les != null)
            {
                var find_meeting = meetings.Where(x => x.Lesson.Equals(les));
                return find_meeting.Count() > 0 ? find_meeting.First() : null;
            }
            return null;
        }

        private IEnumerable<Meeting> GetSelectedMeetings()
        {
            if (listViewMeetings.SelectedItems.Count > 0)
            {
                var local_meetings = meetings.ToList();
                foreach (ListViewItem item in listViewMeetings.SelectedItems)
                {
                    var m = local_meetings.Where(x => x.Lesson.Equals(item.Tag));
                    if (m.Any())
                        yield return m.First();
                }
            }            
        }

        private void moveOneWeekLaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selected_meeting = GetSelectedMeetings();

            foreach (Meeting m in selected_meeting)
            {
                m.MeetingDate = m.MeetingDate.Add(TimeSpan.FromDays(7));
            }
            FillMeetings();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            foreach (Meeting m in meetings)
                m.Update();
        }

        private bool ValidateMeetings(out List<string> errors)
        {

            errors = new List<string>();
            return true;
            /*
            bool result = true;
            var unscheduled_lesson = course.Level.Lessons.Where(x => meetings.Where(m => m.Lesson.Equals(x)).Count() == 0);            
            if (unscheduled_lesson.Count() > 0)
            {
                result = false;
                string list = "";
                foreach(var l in unscheduled_lesson)
                    list += "  - " + l.Name + "\r\n";
                errors.Add("Unscheduled lessons: \r\n" + list);
            }

            var blocked_meetings = course.Meetings
                                    .Where(m => blockings.Where(b => b.IsBlocked(m.MeetingDate)).Count() > 0);
            if (blocked_meetings.Count() > 0)
            {
                result = false;
                string list = "\r\nShedule with conflict:\r\n";
                foreach (Meeting m in blocked_meetings)
                {
                    list += "  - " + m.Lesson.Name + " (" + m.MeetingDate.ToShortDateString() + ")";
                }
                errors.Add(list);
            }

            return result;
            */
        }

        private void FormMeetingPlanner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                List<string> errors;
                if (!ValidateMeetings(out errors))
                {
                    string err_text = "";
                    foreach (string er in errors) err_text += er + "\r\n";
                    if (MessageBox.Show("Meeting planner is not yet complete: " + err_text +
                        "Do you still want to leave planner?", "Planner not complete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void changeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var meetings = GetSelectedMeetings();

            if (meetings.Count() > 0)
            {
                var form = new FormDateDialog();
                if (form.Execute(meetings.First().MeetingDate))
                {
                    foreach (var m in meetings)
                    {
                        m.MeetingDate = form.Date;
                    }
                }

                FillMeetings();
            }
        }

        private void removeFromPlanningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sel_meetings = GetSelectedMeetings().ToArray();

            foreach (var m in sel_meetings)
            {
                if (m.TryDelete())
                {
                    meetings.Remove(m);
                }
            }

            FillMeetings();
        }     

  
    }
}
