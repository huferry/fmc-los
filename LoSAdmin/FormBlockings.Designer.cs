namespace LoSAdmin
{
    partial class FormBlockings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewBlockings = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewBlockings
            // 
            this.listViewBlockings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewBlockings.FullRowSelect = true;
            this.listViewBlockings.Location = new System.Drawing.Point(10, 78);
            this.listViewBlockings.MultiSelect = false;
            this.listViewBlockings.Name = "listViewBlockings";
            this.listViewBlockings.Size = new System.Drawing.Size(359, 262);
            this.listViewBlockings.TabIndex = 0;
            this.listViewBlockings.UseCompatibleStateImageBehavior = false;
            this.listViewBlockings.View = System.Windows.Forms.View.Details;
            this.listViewBlockings.SelectedIndexChanged += new System.EventHandler(this.listViewBlockings_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Description";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "From";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Until";
            this.columnHeader3.Width = 100;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(2, 2);
            this.monthCalendar1.Location = new System.Drawing.Point(381, 38);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.SelectionRange = new System.Windows.Forms.SelectionRange(new System.DateTime(2011, 6, 17, 0, 0, 0, 0), new System.DateTime(2011, 6, 23, 0, 0, 0, 0));
            this.monthCalendar1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Year";
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(255, 38);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(114, 21);
            this.comboBoxYear.TabIndex = 6;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Image = global::LoSAdmin.Properties.Resources.remove;
            this.buttonDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonDelete.Location = new System.Drawing.Point(174, 18);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 54);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Enabled = false;
            this.buttonEdit.Image = global::LoSAdmin.Properties.Resources.blog_post_edit;
            this.buttonEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonEdit.Location = new System.Drawing.Point(93, 18);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 54);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Image = global::LoSAdmin.Properties.Resources.add;
            this.buttonAdd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAdd.Location = new System.Drawing.Point(12, 18);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 54);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // FormBlockings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 356);
            this.Controls.Add(this.comboBoxYear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.listViewBlockings);
            this.Name = "FormBlockings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calendar Blockings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewBlockings;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxYear;
    }
}