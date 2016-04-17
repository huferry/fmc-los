using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using Los.Core;

namespace LoSAdmin
{
    public partial class FormEditBlockings : Form
    {
        private List<object> locked = new List<object>();
        private FormEditBlockings()
        {
            InitializeComponent();
            dateTimePickerFrom.Value = DateTime.Today;
            dateTimePickerUntil.Value = DateTime.Today;
            labelCount.Text = "";
        }       

        static public Calendar NewBlocking()
        {
            var form = new FormEditBlockings();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Calendar cal = new Calendar(form.textBoxName.Text,
                    form.dateTimePickerFrom.Value.Date,
                    form.dateTimePickerUntil.Value.Date);
                cal.Blocking = true;
                cal.Insert();
                return cal;
            }
            return null;
        }

        static public void EditBlocking(Calendar blocking)
        {
            var form = new FormEditBlockings();
            form.textBoxName.Text = blocking.Name;
            form.dateTimePickerFrom.Value = blocking.DateStart;
            form.dateTimePickerUntil.Value = blocking.DateEnd;
            if (form.ShowDialog() == DialogResult.OK)
            {
                blocking.Name = form.textBoxName.Text;
                blocking.DateStart = form.dateTimePickerFrom.Value;
                blocking.DateEnd = form.dateTimePickerUntil.Value;
                blocking.Update();
            }
        }

        private void ValidateControls()
        {
            button1.Enabled = false;
            if (!locked.Contains(dateTimePickerFrom))
            {
                if (dateTimePickerFrom.Value.Date > dateTimePickerUntil.Value.Date)
                {
                    MessageBox.Show("End date should be later than the start date.", "Invalid Input",MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                    return;
                }
            }

            if (textBoxName.Text == "")
                return;

            button1.Enabled = true;
        }

        private void monthCalendarSelection_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (!locked.Contains(monthCalendarSelection))
            {
                locked.Add(monthCalendarSelection);
                locked.Add(dateTimePickerFrom);
                try
                {
                    if (monthCalendarSelection.SelectionStart < monthCalendarSelection.SelectionEnd)
                    {
                        dateTimePickerFrom.Value = monthCalendarSelection.SelectionStart;
                        dateTimePickerUntil.Value = monthCalendarSelection.SelectionEnd;
                    }
                    else
                    {
                        dateTimePickerFrom.Value = monthCalendarSelection.SelectionEnd;
                        dateTimePickerUntil.Value = monthCalendarSelection.SelectionStart;
                    }
                    TimeSpan span = monthCalendarSelection.SelectionEnd - monthCalendarSelection.SelectionStart;
                    labelCount.Text = (span.Days +1).ToString() + " day(s) selected";
                    ValidateControls();
                }
                finally
                {
                    locked.Remove(monthCalendarSelection);
                    locked.Remove(dateTimePickerFrom);
                }
            }
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            if (!locked.Contains(dateTimePickerFrom))
            {
                locked.Add(dateTimePickerFrom);
                try
                {
                    monthCalendarSelection.SelectionStart = dateTimePickerFrom.Value;
                    monthCalendarSelection.SelectionEnd = dateTimePickerUntil.Value;
                    ValidateControls();
                }
                finally
                {
                    locked.Remove(dateTimePickerFrom);
                }
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            ValidateControls();
        }


    }
}
