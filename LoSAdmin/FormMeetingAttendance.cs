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
    enum ShowMode { Past, Last, LastFuture, All };

    public partial class FormMeetingAttendance : Form
    {
        private Course course;
        private IEnumerable<DayAttendance> day_attendances;
        private IEnumerable<DayMeeting> day_meetings;
        private DayMeeting sel_meeting;
        private Relation sel_student;
        private DayAttendance sel_dayattendance;
        private HashSet<Relation> system2students = new HashSet<Relation>();

        public FormMeetingAttendance()
        {
            InitializeComponent();
            comboBoxShowMeetings.SelectedIndex = 0;
            labelPresent.BackColor = StatusColor(AttendanceStatus.Present);
            labelIll.BackColor = StatusColor(AttendanceStatus.Ill);
            labelLeave.BackColor = StatusColor(AttendanceStatus.Leave);
            labelUnknown.BackColor = StatusColor(AttendanceStatus.Unknown);
            toolTipNotes.SetToolTip(comboBoxShowMeetings, "Select the scope of the meetings.");
        }

        private void Init()
        {
            day_attendances = DayAttendance.GetByCourse(course);
            day_meetings = DayMeeting.GetByCourse(course);

            listViewAttendance.BeginUpdate();
            try
            {
                listViewAttendance.Items.Clear();
                foreach (ColumnHeader col in listViewAttendance.Columns.Cast<ColumnHeader>().Skip(1).ToArray())
                {
                    listViewAttendance.Columns.Remove(col);
                }
                FillMeetingDates();
                FillMembers();
                labelCourse.Text = "Course: " + course.Name;

            }
            finally
            {
                listViewAttendance.EndUpdate();
            }
        }

        private void FillMembers()
        {
            var lookup = day_attendances.ToList();
            var students = course.GetStudents().ToArray();
            var day_meetings = listViewAttendance.Columns.Cast<ColumnHeader>().Skip(1).Select(x => x.Tag as DayMeeting);
            system2students.Clear();
            foreach (Relation rel in students.OrderBy(x => x.Firstname))
            {
                var item = listViewAttendance.Items.Add(rel.ToString());
                item.Tag = rel;

                if (course.GetStudentStatus(rel).System == 2)
                    system2students.Add(rel);

                // filling the report
                foreach (DayMeeting meeting in day_meetings)
                {
                    DayAttendance att = lookup.Count > 0 ? DayAttendance.Find(lookup, rel, meeting) : null;
                    lookup.Remove(att);
                    item.SubItems.Add("").Tag = att;
                }
            }
            comboBoxQuickDate.Items.Clear();
            comboBoxQuickDate.Items.AddRange(
                day_meetings
                .Where(x => x.MeetingDate.Ticks <= DateTime.Now.Ticks)
                .OrderBy(x => -x.MeetingDate.Ticks).ToArray());
            if (comboBoxQuickDate.Items.Count > 0)
                comboBoxQuickDate.SelectedIndex = 0;
        }

        private void FillMeetingDates()
        {
            ShowMode mode = (ShowMode)comboBoxShowMeetings.SelectedIndex;

            DayMeeting[] meetings;

            switch (mode)
            {
                case ShowMode.Past:
                    meetings = day_meetings.Where(x => x.MeetingDate <= DateTime.Today).OrderBy(x => x.MeetingDate.Ticks).ToArray();
                    break;
                case ShowMode.All:
                    meetings = day_meetings.ToArray();
                    break;
                case ShowMode.Last:
                    meetings = day_meetings.Where(x => x.MeetingDate <= DateTime.Today).OrderBy(x => -x.MeetingDate.Ticks).Take(1).ToArray();
                    break;
                case ShowMode.LastFuture:
                    var last = day_meetings.Where(x => x.MeetingDate <= DateTime.Today).OrderBy(x => x.MeetingDate.Ticks).Last();
                    meetings = day_meetings.Where(x => x.MeetingDate >= last.MeetingDate.Date).ToArray();
                    break;
                default:
                    throw new Exception("Unknown ShowMode");
            }

            foreach (DayMeeting mee in meetings)
            {
                var col = listViewAttendance.Columns.Add(mee.MeetingDate.ToString("d/MMM").ToLower());
                col.Width = 60;
                col.Tag = mee;               
            }
        }

        private Color StatusColor(DayAttendance attendance)
        {
            if (attendance == null)
                return StatusColor(AttendanceStatus.Unknown);
            return StatusColor(attendance.AttendanceStatus);
        }

        private Color StatusColor(AttendanceStatus status)
        {
            switch (status)
            {
                case AttendanceStatus.Ill:
                    return Color.Yellow;
                case AttendanceStatus.Leave:
                    return Color.Orange;
                case AttendanceStatus.Present:
                    return Color.LightGreen;
                case AttendanceStatus.Unknown:
                    return Color.FromArgb(245, 245, 245);
                default:
                    throw new Exception("Unknown color for the status " + status.ToString());
            }
        }

        private Rectangle Narrow(Rectangle rect)
        {
            return new Rectangle(rect.X + 4, rect.Y + 4, rect.Width - 8, rect.Height - 8);
        }

        private void DrawStatus(DayAttendance attendance, Graphics graphics, Rectangle bound)
        {
            Rectangle rect = Narrow(bound);
            graphics.FillRectangle(new SolidBrush(StatusColor(attendance)), rect);
            graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black)), rect);
        }

        private void DrawStatusSystem2(Graphics graphics, Rectangle bound)
        {
            Rectangle rect = Narrow(bound);
            graphics.FillRectangle(new SolidBrush(labelSystem2.BackColor), rect);
            graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black)), rect);
        }

        static public void Execute(Course course)
        {
            FormMeetingAttendance form = new FormMeetingAttendance();
            form.course = course;
            form.Init();
            form.ShowDialog();
        }

        private void listViewAttendance_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
        }

        private void listViewAttendance_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                DayMeeting meeting = (DayMeeting)listViewAttendance.Columns[e.ColumnIndex].Tag;
                DayAttendance att = (DayAttendance)e.SubItem.Tag;
                Relation rel = (Relation)e.Item.Tag;

                if (meeting.MeetingDate <= DateTime.Now)
                {
                    Color bg = system2students.Contains(rel) ? labelSystem2.BackColor : Color.Silver;
                    e.Graphics.FillRectangle(new SolidBrush(bg), e.Bounds);
                }


                DrawStatus(att, e.Graphics, e.Bounds);
                return;
            }
            e.DrawDefault = true;
        }

        private void listViewAttendance_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void comboBoxShowMeetings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (course != null)
                Init();
        }

        private void listViewAttendance_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewHitTestInfo info = listViewAttendance.HitTest(e.Location);
                Relation rel = (Relation)info.Item.Tag;
                DayMeeting meeting = (DayMeeting)listViewAttendance.Columns[info.Item.SubItems.IndexOf(info.SubItem)].Tag;

                if ((rel != null) && (meeting != null))
                {
                    sel_meeting = meeting;
                    sel_student = rel;
                    sel_dayattendance = (DayAttendance)info.SubItem.Tag;
                    if (sel_dayattendance == null)
                    {
                        sel_dayattendance = new DayAttendance(this.course, sel_student, sel_meeting.MeetingDate);
                        info.SubItem.Tag = sel_dayattendance;
                    }

                    contextMenuStrip1.Show(listViewAttendance, e.Location);
                }
            }
        }

        private void ChangeStatus(object sender, EventArgs e)
        {
            AttendanceStatus status = AttendanceStatus.Unknown;
            if (sender == presentToolStripMenuItem)
                status = AttendanceStatus.Present;
            if (sender == illToolStripMenuItem)
                status = AttendanceStatus.Ill;
            if (sender == leaveToolStripMenuItem)
                status = AttendanceStatus.Leave;


            // should give a reason 
            if (status != AttendanceStatus.Present)
            {
                string note;
                if (FormAbsentDialog.Execute(this.course, sel_meeting, sel_student, status, out note))
                {
                    sel_dayattendance.Note = note;
                }
                else
                    return;
            }

            sel_dayattendance.AttendanceStatus = status;
            sel_dayattendance.Update();
            listViewAttendance.Refresh();
            
        }

        private void listViewAttendance_MouseMove(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listViewAttendance.HitTest(e.Location);
            if ((info.SubItem != null) && (info.SubItem.Tag != null) && (info.SubItem.Tag is DayAttendance))
            {
                string note =            
                    (info.SubItem.Tag as DayAttendance).Note;
                toolTipNotes.Show(note, listViewAttendance, 4000);
            }
            else
                toolTipNotes.SetToolTip(listViewAttendance, "");
        }

        private void textBoxQuickCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                int code = int.Parse(textBoxQuickCode.Text);
                textBoxQuickCode.Text = "";

                var search_relation = course.GetStudents().Where(x => x.ObjectCode == code);

                if (search_relation.Count() > 0)
                {
                    Relation student = search_relation.First();
                    DayMeeting meeting = (DayMeeting)comboBoxQuickDate.SelectedItem;

                    var att = day_attendances.Where(x => x.Student.Equals(student) && x.MeetingDate == meeting.MeetingDate);
                    if (att.Count() > 0)
                    {
                        MessageBox.Show("Status has been entered.");
                    }
                    else
                    {
                        var d_att = new DayAttendance(course, student, meeting.MeetingDate);
                        d_att.AttendanceStatus = AttendanceStatus.Present;
                        d_att.Update();

                        try
                        {
                            var item = listViewAttendance.Items.Cast<ListViewItem>().Where(x => x.Tag.Equals(student)).First();
                            var column = listViewAttendance.Columns.Cast<ColumnHeader>()
                                .Where(x => (x.Tag != null) && (x.Tag as DayMeeting).MeetingDate == meeting.MeetingDate).First();

                            item.SubItems[column.Index].Tag = d_att;
                        }
                        finally
                        {
                            e.SuppressKeyPress = true;
                            listViewAttendance.Invalidate();
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Student not found for the given code.");
                }

                e.SuppressKeyPress = true;
            }
        }

        private void textBoxQuickCode_KeyPress(object sender, KeyPressEventArgs e)
        {            
            e.Handled = !Char.IsNumber(e.KeyChar);
        }

 
    }

 }
