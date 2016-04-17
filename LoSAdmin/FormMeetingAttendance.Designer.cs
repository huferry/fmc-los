namespace LoSAdmin
{
    partial class FormMeetingAttendance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMeetingAttendance));
            this.listViewAttendance = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.comboBoxShowMeetings = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelSystem2 = new System.Windows.Forms.Label();
            this.labelUnknown = new System.Windows.Forms.Label();
            this.labelLeave = new System.Windows.Forms.Label();
            this.labelIll = new System.Windows.Forms.Label();
            this.labelPresent = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.presentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.illToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unknownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTipNotes = new System.Windows.Forms.ToolTip(this.components);
            this.labelCourse = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxQuickCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxQuickDate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewAttendance
            // 
            this.listViewAttendance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewAttendance.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewAttendance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewAttendance.FullRowSelect = true;
            this.listViewAttendance.GridLines = true;
            this.listViewAttendance.LargeImageList = this.imageList1;
            this.listViewAttendance.Location = new System.Drawing.Point(30, 87);
            this.listViewAttendance.Name = "listViewAttendance";
            this.listViewAttendance.OwnerDraw = true;
            this.listViewAttendance.ShowItemToolTips = true;
            this.listViewAttendance.Size = new System.Drawing.Size(913, 402);
            this.listViewAttendance.SmallImageList = this.imageList1;
            this.listViewAttendance.TabIndex = 0;
            this.listViewAttendance.UseCompatibleStateImageBehavior = false;
            this.listViewAttendance.View = System.Windows.Forms.View.Details;
            this.listViewAttendance.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listViewAttendance_DrawColumnHeader);
            this.listViewAttendance.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewAttendance_MouseClick);
            this.listViewAttendance.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listViewAttendance_DrawItem);
            this.listViewAttendance.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listViewAttendance_MouseMove);
            this.listViewAttendance.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listViewAttendance_DrawSubItem);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Member";
            this.columnHeader1.Width = 200;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "laughter-icon.png");
            this.imageList1.Images.SetKeyName(1, "I-am-tired-icon.png");
            this.imageList1.Images.SetKeyName(2, "feel-sick-icon.png");
            // 
            // comboBoxShowMeetings
            // 
            this.comboBoxShowMeetings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShowMeetings.FormattingEnabled = true;
            this.comboBoxShowMeetings.Items.AddRange(new object[] {
            "past meetings",
            "last meeting",
            "last and future meetings",
            "all meetings"});
            this.comboBoxShowMeetings.Location = new System.Drawing.Point(112, 46);
            this.comboBoxShowMeetings.Name = "comboBoxShowMeetings";
            this.comboBoxShowMeetings.Size = new System.Drawing.Size(260, 21);
            this.comboBoxShowMeetings.TabIndex = 1;
            this.comboBoxShowMeetings.SelectedIndexChanged += new System.EventHandler(this.comboBoxShowMeetings_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Show meetings";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.labelSystem2);
            this.groupBox1.Controls.Add(this.labelUnknown);
            this.groupBox1.Controls.Add(this.labelLeave);
            this.groupBox1.Controls.Add(this.labelIll);
            this.groupBox1.Controls.Add(this.labelPresent);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(631, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 69);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Legends";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(257, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "system 2";
            // 
            // labelSystem2
            // 
            this.labelSystem2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(219)))), ((int)(((byte)(239)))));
            this.labelSystem2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSystem2.Location = new System.Drawing.Point(221, 27);
            this.labelSystem2.Name = "labelSystem2";
            this.labelSystem2.Size = new System.Drawing.Size(30, 12);
            this.labelSystem2.TabIndex = 8;
            // 
            // labelUnknown
            // 
            this.labelUnknown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelUnknown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelUnknown.Location = new System.Drawing.Point(121, 44);
            this.labelUnknown.Name = "labelUnknown";
            this.labelUnknown.Size = new System.Drawing.Size(30, 12);
            this.labelUnknown.TabIndex = 7;
            // 
            // labelLeave
            // 
            this.labelLeave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelLeave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelLeave.Location = new System.Drawing.Point(121, 25);
            this.labelLeave.Name = "labelLeave";
            this.labelLeave.Size = new System.Drawing.Size(30, 12);
            this.labelLeave.TabIndex = 6;
            // 
            // labelIll
            // 
            this.labelIll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelIll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelIll.Location = new System.Drawing.Point(11, 45);
            this.labelIll.Name = "labelIll";
            this.labelIll.Size = new System.Drawing.Size(30, 12);
            this.labelIll.TabIndex = 5;
            // 
            // labelPresent
            // 
            this.labelPresent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelPresent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPresent.Location = new System.Drawing.Point(11, 26);
            this.labelPresent.Name = "labelPresent";
            this.labelPresent.Size = new System.Drawing.Size(30, 12);
            this.labelPresent.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(162, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "unknown";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(162, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "leave";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "ill";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "present";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.presentToolStripMenuItem,
            this.illToolStripMenuItem,
            this.leaveToolStripMenuItem,
            this.unknownToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(126, 92);
            // 
            // presentToolStripMenuItem
            // 
            this.presentToolStripMenuItem.Name = "presentToolStripMenuItem";
            this.presentToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.presentToolStripMenuItem.Text = "Present";
            this.presentToolStripMenuItem.Click += new System.EventHandler(this.ChangeStatus);
            // 
            // illToolStripMenuItem
            // 
            this.illToolStripMenuItem.Name = "illToolStripMenuItem";
            this.illToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.illToolStripMenuItem.Text = "Ill";
            this.illToolStripMenuItem.Click += new System.EventHandler(this.ChangeStatus);
            // 
            // leaveToolStripMenuItem
            // 
            this.leaveToolStripMenuItem.Name = "leaveToolStripMenuItem";
            this.leaveToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.leaveToolStripMenuItem.Text = "Leave";
            this.leaveToolStripMenuItem.Click += new System.EventHandler(this.ChangeStatus);
            // 
            // unknownToolStripMenuItem
            // 
            this.unknownToolStripMenuItem.Name = "unknownToolStripMenuItem";
            this.unknownToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.unknownToolStripMenuItem.Text = "Unknown";
            this.unknownToolStripMenuItem.Click += new System.EventHandler(this.ChangeStatus);
            // 
            // toolTipNotes
            // 
            this.toolTipNotes.ShowAlways = true;
            // 
            // labelCourse
            // 
            this.labelCourse.AutoSize = true;
            this.labelCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCourse.Location = new System.Drawing.Point(26, 9);
            this.labelCourse.Name = "labelCourse";
            this.labelCourse.Size = new System.Drawing.Size(83, 24);
            this.labelCourse.TabIndex = 4;
            this.labelCourse.Text = "Course:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.textBoxQuickCode);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.comboBoxQuickDate);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(31, 495);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 62);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Quick Present Add";
            // 
            // textBoxQuickCode
            // 
            this.textBoxQuickCode.Location = new System.Drawing.Point(318, 26);
            this.textBoxQuickCode.Name = "textBoxQuickCode";
            this.textBoxQuickCode.Size = new System.Drawing.Size(56, 20);
            this.textBoxQuickCode.TabIndex = 3;
            this.textBoxQuickCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxQuickCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxQuickCode_KeyDown);
            this.textBoxQuickCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxQuickCode_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(241, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Student code";
            // 
            // comboBoxQuickDate
            // 
            this.comboBoxQuickDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxQuickDate.FormattingEnabled = true;
            this.comboBoxQuickDate.Location = new System.Drawing.Point(52, 25);
            this.comboBoxQuickDate.Name = "comboBoxQuickDate";
            this.comboBoxQuickDate.Size = new System.Drawing.Size(168, 21);
            this.comboBoxQuickDate.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Date";
            // 
            // FormMeetingAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 572);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.labelCourse);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxShowMeetings);
            this.Controls.Add(this.listViewAttendance);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMeetingAttendance";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attendance";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewAttendance;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ComboBox comboBoxShowMeetings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelUnknown;
        private System.Windows.Forms.Label labelLeave;
        private System.Windows.Forms.Label labelIll;
        private System.Windows.Forms.Label labelPresent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem presentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem illToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unknownToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTipNotes;
        private System.Windows.Forms.Label labelCourse;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelSystem2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxQuickDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxQuickCode;
    }
}