using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace LoSAdmin
{
    public partial class FormWaiting : Form
    {
        static private FormWaiting instance = new FormWaiting();                

        public FormWaiting()
        {
            InitializeComponent();
        }

        static public void ShowMessage(string msg)
        {
            instance.labelMessage.Text = msg;
            instance.progressBar1.Value = 0;
            instance.Show();
            Application.DoEvents();
        }

        static public void SetProgress(int value)
        {
            instance.progressBar1.Value = value;
            instance.Refresh();
            Application.DoEvents();
        }

        static public void Finished()
        {
            instance.Hide();
        }
    }
}
