using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;
using Los.Core;

namespace LoSAdmin
{
    public partial class FormNewCourse : Form
    {
        static DateTime CreateNewStartDate()
        {
            DateTime result = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            return result.AddMonths(1);
        }

        static DateTime lastStartDate = CreateNewStartDate();
        static DateTime lastEndDate = new DateTime(DateTime.Today.Year, 12, 31);
        static Level lastLevel = null;

        private bool updating = false;

        public FormNewCourse()
        {
            InitializeComponent();
            textBoxName.Tag = false;

            comboBoxLevel.Items.AddRange(Level.All.ToArray());
            if (lastLevel == null)
            {
                comboBoxLevel.SelectedIndex = 0;
            }
            else
            {
                int idx = comboBoxLevel.Items.IndexOf(lastLevel) + 1;
                if (idx < comboBoxLevel.Items.Count)
                    comboBoxLevel.SelectedIndex = idx;
                else
                    comboBoxLevel.SelectedIndex = 0;
            }

            dateTimePickerStart.Value = lastStartDate;
            dateTimePickerFinish.Value = lastEndDate;
        }

        private void SetAutoName()
        {
            // text box not yet changed by user
            if (!(bool)textBoxName.Tag)
            {
                updating = true;
                try
                {
                    textBoxName.Text = comboBoxLevel.Text + " " + dateTimePickerStart.Value.Year.ToString();
                }
                finally
                {
                    updating = false;
                }
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (!updating)
            {
                textBoxName.Tag = true;
            }
        }

        private void comboBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetAutoName();
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            SetAutoName();
            if (dateTimePickerFinish.Value < dateTimePickerStart.Value)
            {
                dateTimePickerFinish.Value = dateTimePickerStart.Value.AddMonths(6);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lastStartDate = dateTimePickerStart.Value;
            lastEndDate = dateTimePickerFinish.Value;
            lastLevel = (Level)comboBoxLevel.SelectedItem;
        }

        static public Course CreateNew()
        {
            var form = new FormNewCourse();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var course = new Course
                {
                    LevelId = (form.comboBoxLevel.SelectedItem as Level)?.Id ?? 1,
                    Name = form.textBoxName.Text,
                    Description = form.textBoxDesc.Text,
                    DateStart = form.dateTimePickerStart.Value,
                    DateEnd = form.dateTimePickerFinish.Value
                };

                return Repository.Save(course);
            }
            return null;
        }
    }
}
