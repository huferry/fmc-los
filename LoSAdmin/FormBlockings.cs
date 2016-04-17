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
    public partial class FormBlockings : Form
    {
        private List<Calendar> blockings = new List<Calendar>();

        public FormBlockings()
        {
            InitializeComponent();
            var dates = Calendar.GetByDates(DateTime.Today.AddYears(-1), DateTime.Today.AddYears(2));
            blockings.AddRange(dates.ToArray());
            ShowBlockings();
        }

        private void DisplayCalendars(DateTime firstBlock)
        {
            
        }

        private void ShowBlockings()
        {
            listViewBlockings.BeginUpdate();
            try
            {
                blockings.Sort();
                var current = listViewBlockings.SelectedItems.Count > 0 ? listViewBlockings.SelectedItems[0].Tag : null;
                listViewBlockings.Items.Clear();
                foreach (Calendar block in blockings)
                {
                    var item = listViewBlockings.Items.Add(block.Name);
                    item.SubItems.Add(block.DateStart.ToShortDateString());
                    item.SubItems.Add(block.DateEnd.ToShortDateString());
                    item.Tag = block;
                }

                var selection = listViewBlockings.Items.Cast<ListViewItem>().Where(x => x.Tag == current);

                if (selection.Count() > 0)
                {                    
                }                                
            }
            finally
            {
                listViewBlockings.EndUpdate();
            }

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var block = FormEditBlockings.NewBlocking();
            if (block != null)
            {
                blockings.Add(block);
                ShowBlockings();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewBlockings.SelectedItems.Count > 0)
            {
                Calendar blocking = (Calendar)listViewBlockings.SelectedItems[0].Tag;
                FormEditBlockings.EditBlocking(blocking);
            }
        }

        private void listViewBlockings_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonEdit.Enabled = listViewBlockings.SelectedItems.Count == 1;
            buttonDelete.Enabled = listViewBlockings.SelectedItems.Count > 0;
        }
    }
}
