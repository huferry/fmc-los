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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();                        
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString(
                "Ladder of Success Administrator",
                new Font(FontFamily.GenericSansSerif, 30),
                new SolidBrush(Color.White),
                new PointF(20, 20));
            e.Graphics.DrawString(
                "db: " + DatabaseSettings.GetDatabase() + "@" + DatabaseSettings.GetHost(),
                new Font(FontFamily.GenericSansSerif, 12),
                new SolidBrush(Color.Silver),
                new PointF(30, 60)
                );
        }

        private void OpenWindow(Form form)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Width = 900;
            form.Height = 700;
            form.WindowState = FormWindowState.Normal;
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenWindow(new FormRelations());
        }

        private void buttonClasses_Click(object sender, EventArgs e)
        {
            OpenWindow(new FormClasses());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenWindow(new FormMeetings());
        }
    }
}
