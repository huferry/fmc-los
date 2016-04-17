using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Los.Core;

namespace LoSAdmin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // set the database connection
            DatabaseSettings.SetSettings(Settings.Current.DatabaseConnection);
            if (Database.Check())
            {
                Application.Run(new Form1());
            }
            else
            {
                MessageBox.Show("Unable to established connection to database.\r\nEnsure the host and credentials are correctly set.", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
