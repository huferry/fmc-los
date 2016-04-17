namespace LoSAdmin
{
    partial class FormMeetingPlanner
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMeetingPlanner));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelCourseName = new System.Windows.Forms.Label();
            this.listViewMeetings = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonGoAuto = new System.Windows.Forms.Button();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveOneWeekAheadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveOneWeekLaterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromPlanningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelCourseName);
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Course";
            // 
            // labelCourseName
            // 
            this.labelCourseName.AutoSize = true;
            this.labelCourseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCourseName.Location = new System.Drawing.Point(6, 23);
            this.labelCourseName.Name = "labelCourseName";
            this.labelCourseName.Size = new System.Drawing.Size(57, 20);
            this.labelCourseName.TabIndex = 0;
            this.labelCourseName.Text = "label1";
            // 
            // listViewMeetings
            // 
            this.listViewMeetings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewMeetings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewMeetings.FullRowSelect = true;
            this.listViewMeetings.HideSelection = false;
            this.listViewMeetings.Location = new System.Drawing.Point(16, 81);
            this.listViewMeetings.Name = "listViewMeetings";
            this.listViewMeetings.Size = new System.Drawing.Size(856, 442);
            this.listViewMeetings.TabIndex = 1;
            this.listViewMeetings.UseCompatibleStateImageBehavior = false;
            this.listViewMeetings.View = System.Windows.Forms.View.Details;
            this.listViewMeetings.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewMeetings_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Chapter";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Title";
            this.columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Date";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Validation";
            this.columnHeader4.Width = 250;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(716, 529);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(797, 529);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 27);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.buttonGoAuto);
            this.groupBox2.Controls.Add(this.dateTimePickerStart);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(657, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 59);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Auto Generation";
            // 
            // buttonGoAuto
            // 
            this.buttonGoAuto.Image = global::LoSAdmin.Properties.Resources.play;
            this.buttonGoAuto.Location = new System.Drawing.Point(162, 19);
            this.buttonGoAuto.Name = "buttonGoAuto";
            this.buttonGoAuto.Size = new System.Drawing.Size(46, 27);
            this.buttonGoAuto.TabIndex = 2;
            this.buttonGoAuto.UseVisualStyleBackColor = true;
            this.buttonGoAuto.Click += new System.EventHandler(this.buttonGoAuto_Click);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStart.Location = new System.Drawing.Point(65, 22);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(91, 20);
            this.dateTimePickerStart.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start date";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeDateToolStripMenuItem,
            this.moveOneWeekAheadToolStripMenuItem,
            this.moveOneWeekLaterToolStripMenuItem,
            this.removeFromPlanningToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(193, 114);
            // 
            // changeDateToolStripMenuItem
            // 
            this.changeDateToolStripMenuItem.Name = "changeDateToolStripMenuItem";
            this.changeDateToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.changeDateToolStripMenuItem.Text = "Change date";
            this.changeDateToolStripMenuItem.Click += new System.EventHandler(this.changeDateToolStripMenuItem_Click);
            // 
            // moveOneWeekAheadToolStripMenuItem
            // 
            this.moveOneWeekAheadToolStripMenuItem.Name = "moveOneWeekAheadToolStripMenuItem";
            this.moveOneWeekAheadToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.moveOneWeekAheadToolStripMenuItem.Text = "Move one week earlier";
            this.moveOneWeekAheadToolStripMenuItem.Click += new System.EventHandler(this.moveOneWeekAheadToolStripMenuItem_Click);
            // 
            // moveOneWeekLaterToolStripMenuItem
            // 
            this.moveOneWeekLaterToolStripMenuItem.Name = "moveOneWeekLaterToolStripMenuItem";
            this.moveOneWeekLaterToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.moveOneWeekLaterToolStripMenuItem.Text = "Move one week later";
            this.moveOneWeekLaterToolStripMenuItem.Click += new System.EventHandler(this.moveOneWeekLaterToolStripMenuItem_Click);
            // 
            // removeFromPlanningToolStripMenuItem
            // 
            this.removeFromPlanningToolStripMenuItem.Name = "removeFromPlanningToolStripMenuItem";
            this.removeFromPlanningToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.removeFromPlanningToolStripMenuItem.Text = "Remove date";
            this.removeFromPlanningToolStripMenuItem.Click += new System.EventHandler(this.removeFromPlanningToolStripMenuItem_Click);
            // 
            // FormMeetingPlanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 568);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listViewMeetings);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMeetingPlanner";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meeting Planner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMeetingPlanner_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelCourseName;
        private System.Windows.Forms.ListView listViewMeetings;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonGoAuto;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem changeDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveOneWeekAheadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveOneWeekLaterToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStripMenuItem removeFromPlanningToolStripMenuItem;
    }
}