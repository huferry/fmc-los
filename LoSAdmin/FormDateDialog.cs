using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoSAdmin
{
    public partial class FormDateDialog : Form
    {
        public FormDateDialog()
        {
            InitializeComponent();
        }

        public bool Execute(DateTime init)
        {            
            monthCalendar1.SelectionStart = init;
            return ShowDialog() == DialogResult.OK;
        }

        public DateTime Date
        {
            get { return monthCalendar1.SelectionStart.Date; }
        }
    }
}
