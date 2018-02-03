using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Forms;
using Core;
using Los.Core;

namespace LoSAdmin
{
    internal enum Mode
    {
        View,
        Edit
    }

    public partial class FormRelations : Form
    {
        private Relation edit_relation;

        private string[] last_update_keys;

        private Mode mode = Mode.View;
        private List<Relation> relations;

        private bool updating;
        private string[] wordSeparator = {" "};


        public FormRelations()
        {
            FormWaiting.ShowMessage("Downloading relations..");
            try
            {
                FormWaiting.SetProgress(80);
                InitializeComponent();
                relations = Repository.GetAll<Relation>().OrderBy(x => x.Firstname + x.Surname).ToList();
                FormWaiting.SetProgress(90);
                UpdateList(null);

                comboBoxCareLeader.Items.AddRange(relations.Where(r => r.IsCareLeader).ToArray());

                // filter check event
                var need_approval_event = Observable.FromEventPattern<EventArgs>(checkBoxNeedApproval, "CheckedChanged")
                    .Select(x => textBoxSearch.Text.Trim());
                // setting up the events
                try
                {
                    var search_event = Observable.FromEventPattern<EventArgs>(textBoxSearch, "TextChanged")
                        .Throttle(TimeSpan.FromMilliseconds(200))
                        .Select(x => ((TextBox) x.Sender).Text.Trim())
                        .DistinctUntilChanged()
                        .Merge(need_approval_event)
                        .Select(x => x.Split(wordSeparator, StringSplitOptions.RemoveEmptyEntries));

                    search_event.Subscribe(UpdateList);
                }
                catch (NotImplementedException)
                {
                    // anticipate Linux
                    textBoxSearch.TextChanged += HandleTextSearchChanged;
                }

                Mode = Mode.View;
            }
            finally
            {
                FormWaiting.Finished();
            }
        }

        private Mode Mode
        {
            get => mode;
            set
            {
                switch (value)
                {
                    case Mode.Edit:
                        panelButtons.Enabled = false;
                        groupBoxSearch.Enabled = false;
                        listViewRelations.Enabled = false;
                        labelMode.Visible = true;
                        groupBoxRelation.Enabled = true;
                        buttonSave.Visible = true;
                        buttonCancel.Visible = true;
                        break;

                    case Mode.View:
                        panelButtons.Enabled = true;
                        groupBoxSearch.Enabled = true;
                        listViewRelations.Enabled = true;
                        labelMode.Visible = false;
                        groupBoxRelation.Enabled = false;
                        buttonSave.Visible = false;
                        buttonCancel.Visible = false;
                        break;
                }

                mode = value;
            }
        }

        private void HandleTextSearchChanged(object sender, EventArgs args)
        {
            if (!updating)
            {
                updating = true;
                var keys = (sender as TextBox).Text.Split(wordSeparator, StringSplitOptions.RemoveEmptyEntries);
                UpdateList(keys);
                updating = false;
            }
        }

        private void UpdateList(string[] keys)
        {
            listViewRelations.BeginUpdate();
            try
            {
                var selected = relations
                    .Where(x => (!checkBoxNeedApproval.Checked || !x.Approved))
                    .ToArray();

                if ((keys != null) && (keys.Length > 0))
                {
                    selected = selected
                        .Select(x => new {Rel = x, Score = x.CalcSearchScore(keys)})
                        .Where(x => x.Score > 0)
                        .OrderBy(x => -x.Score)
                        .Select(x => x.Rel)
                        .ToArray();
                }

                listViewRelations.Items.Clear();
                foreach (var rel in selected)
                {
                    listViewRelations.Items.Add(rel.ToString()).Tag = rel;
                }

                UpdateSelectedRelation();
            }
            finally
            {
                last_update_keys = keys;
                listViewRelations.EndUpdate();
            }
        }

        private void UpdateListLast()
        {
            UpdateList(last_update_keys);
        }

        private Relation GetSelected()
        {
            if (listViewRelations.SelectedItems.Count > 0)
            {
                return (Relation) listViewRelations.SelectedItems[0].Tag;
            }

            return null;
        }

        private void listViewRelations_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectedRelation();
        }

        private void UpdateSelectedRelation()
        {
            var rel = GetSelected();

            var last_course = rel == null ? null : Course.GetLastClosedCourseByRelation(rel);
            var current_course = rel == null ? null : Course.GetActiveByRelation(rel);
            var next_course = rel == null ? null : Course.GetNextPossibleCoursesByRelation(rel)?.ToArray();

            textBoxFirstname.Text = rel?.Firstname;
            textBoxSurname.Text = rel?.Surname;
            textBoxPhoneHome.Text = rel?.PhoneHome;
            textBoxPhoneMobile.Text = rel?.PhoneMobile;
            textBoxEmail.Text = rel?.Email;

            dateTimePickerBirthdate.Value = rel?.Birthday ?? DateTime.Today;

            radioButtonMale.Checked = rel?.Gender == Gender.Male;

            buttonApprove.Visible = !rel?.Approved ?? false;
            buttonEnrollment.Enabled = current_course == null;

            textBoxCurrentCourse.Text = current_course == null ? "" : current_course.Name;
            textBoxLastCourse.Text = last_course == null
                ? ""
                : last_course.Name + " (" + last_course.DateEnd.ToString("MMM/yyyy") + ")";
            textBoxNextPossible.Text = next_course?.Count() == 0 ? "" : next_course?.First().Name;

            checkBoxIsCareLeader.Checked = rel?.IsCareLeader ?? false;
            comboBoxCareLeader.SelectedItem = relations.SingleOrDefault(r => r.Id == rel?.CareLeaderId);
        }

        private void FormRelations_Shown(object sender, EventArgs e)
        {
            var need_approvals = relations.Where(x => !x.Approved).Count();

            if (need_approvals > 0)
            {
                if (MessageBox.Show(
                        string.Format("{0} relation(s) need(s) approval.\r\nTurn on filter to show these relations?",
                            need_approvals),
                        "Approvals",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    checkBoxNeedApproval.Checked = true;
            }
        }

        private void buttonApprove_Click(object sender, EventArgs e)
        {
            var rel = GetSelected();
            if (rel?.Id > 0)
            {
                rel.Approved = true;
                Repository.Save(rel);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            edit_relation = GetSelected();
            if (edit_relation != null)
            {
                Mode = Mode.Edit;
            }
        }

        private void SetRelationValues(Relation rel)
        {
            rel.Firstname = textBoxFirstname.Text;
            rel.Surname = textBoxSurname.Text;
            rel.Gender = radioButtonMale.Checked ? Gender.Male : Gender.Female;
            rel.Birthday = dateTimePickerBirthdate.Value;
            rel.PhoneHome = textBoxPhoneHome.Text;
            rel.PhoneMobile = textBoxPhoneMobile.Text;
            rel.Email = textBoxEmail.Text;
            rel.IsCareLeader = checkBoxIsCareLeader.Checked;
            rel.CareLeaderId = (comboBoxCareLeader.SelectedItem as Relation)?.Id;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var rel = GetSelected();
            SetRelationValues(rel);
            if (rel.Id == 0)
            {
                rel.Approved = true;
                relations.Add(rel);
            }
            else
            {
                Repository.Save(rel);
            }

            Mode = Mode.View;
            UpdateListLast();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            UpdateSelectedRelation();
            Mode = Mode.View;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            listViewRelations.SelectedItems.Clear();
            UpdateSelectedRelation();
            edit_relation = GetSelected();
            Mode = Mode.Edit;
        }

        private void textBoxFirstname_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxFirstname.Text == "")
                e.Cancel = true;
        }

        private void textBoxSurname_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxSurname.Text == "")
                e.Cancel = true;
        }

        private void dateTimePickerBirthdate_Validating(object sender, CancelEventArgs e)
        {
            if (dateTimePickerBirthdate.Value.Year <= 1900)
                e.Cancel = true;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            var rel = GetSelected();
            if (MessageBox.Show("Are you sure you want to delete " + rel,
                    "Delete relation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // remove from local list
                relations.Remove(rel);

                // remove from list view
                var item = listViewRelations.Items.Cast<ListViewItem>().FirstOrDefault(x => x.Tag == rel);
                if (item != null)
                    listViewRelations.Items.Remove(item);

                Repository.Delete(rel);
            }
        }

        private void buttonEnrollment_Click(object sender, EventArgs e)
        {
            var rel = GetSelected();
            if (rel != null)
            {
                if (FormEnrolClass.Execute(rel))
                    UpdateSelectedRelation();
            }
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {
        }
    }
}