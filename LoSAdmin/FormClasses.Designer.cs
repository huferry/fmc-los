namespace LoSAdmin
{
    partial class FormClasses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClasses));
            this.panelSelection = new System.Windows.Forms.Panel();
            this.textBoxContainStudent = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxActive = new System.Windows.Forms.GroupBox();
            this.radioButtonAllCourses = new System.Windows.Forms.RadioButton();
            this.radioButtonRunning = new System.Windows.Forms.RadioButton();
            this.radioButtonClosed = new System.Windows.Forms.RadioButton();
            this.comboBoxLevel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.treeViewCourses = new System.Windows.Forms.TreeView();
            this.imageListTree = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonUpdateDesc = new System.Windows.Forms.Button();
            this.labelCourseName = new System.Windows.Forms.Label();
            this.checkBoxOpenEnrollment = new System.Windows.Forms.CheckBox();
            this.textBoxLevel = new System.Windows.Forms.TextBox();
            this.labelLevel = new System.Windows.Forms.Label();
            this.textBoxEnrollments = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listViewStudents = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStripStudent = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.markFinishedCourseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unmarkFinishedCourseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.system2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelFunctions = new System.Windows.Forms.Panel();
            this.buttonDeleteCourse = new System.Windows.Forms.Button();
            this.buttonNewClass = new System.Windows.Forms.Button();
            this.buttonReportInvitations = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelSelection.SuspendLayout();
            this.groupBoxActive.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStripStudent.SuspendLayout();
            this.panelFunctions.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSelection
            // 
            this.panelSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSelection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSelection.Controls.Add(this.textBoxContainStudent);
            this.panelSelection.Controls.Add(this.label6);
            this.panelSelection.Controls.Add(this.groupBoxActive);
            this.panelSelection.Controls.Add(this.comboBoxLevel);
            this.panelSelection.Controls.Add(this.label1);
            this.panelSelection.Location = new System.Drawing.Point(10, 12);
            this.panelSelection.Name = "panelSelection";
            this.panelSelection.Size = new System.Drawing.Size(340, 111);
            this.panelSelection.TabIndex = 0;
            // 
            // textBoxContainStudent
            // 
            this.textBoxContainStudent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxContainStudent.Location = new System.Drawing.Point(153, 69);
            this.textBoxContainStudent.Name = "textBoxContainStudent";
            this.textBoxContainStudent.Size = new System.Drawing.Size(168, 20);
            this.textBoxContainStudent.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(150, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Contains Student";
            // 
            // groupBoxActive
            // 
            this.groupBoxActive.Controls.Add(this.radioButtonAllCourses);
            this.groupBoxActive.Controls.Add(this.radioButtonRunning);
            this.groupBoxActive.Controls.Add(this.radioButtonClosed);
            this.groupBoxActive.Location = new System.Drawing.Point(15, 11);
            this.groupBoxActive.Name = "groupBoxActive";
            this.groupBoxActive.Size = new System.Drawing.Size(132, 86);
            this.groupBoxActive.TabIndex = 2;
            this.groupBoxActive.TabStop = false;
            this.groupBoxActive.Text = "Closed/Running";
            // 
            // radioButtonAllCourses
            // 
            this.radioButtonAllCourses.AutoSize = true;
            this.radioButtonAllCourses.Location = new System.Drawing.Point(6, 58);
            this.radioButtonAllCourses.Name = "radioButtonAllCourses";
            this.radioButtonAllCourses.Size = new System.Drawing.Size(36, 17);
            this.radioButtonAllCourses.TabIndex = 2;
            this.radioButtonAllCourses.Text = "All";
            this.radioButtonAllCourses.UseVisualStyleBackColor = true;
            this.radioButtonAllCourses.CheckedChanged += new System.EventHandler(this.radioButtonClosed_CheckedChanged);
            // 
            // radioButtonRunning
            // 
            this.radioButtonRunning.AutoSize = true;
            this.radioButtonRunning.Checked = true;
            this.radioButtonRunning.Location = new System.Drawing.Point(6, 39);
            this.radioButtonRunning.Name = "radioButtonRunning";
            this.radioButtonRunning.Size = new System.Drawing.Size(105, 17);
            this.radioButtonRunning.TabIndex = 1;
            this.radioButtonRunning.TabStop = true;
            this.radioButtonRunning.Text = "Running courses";
            this.radioButtonRunning.UseVisualStyleBackColor = true;
            this.radioButtonRunning.CheckedChanged += new System.EventHandler(this.radioButtonClosed_CheckedChanged);
            // 
            // radioButtonClosed
            // 
            this.radioButtonClosed.AutoSize = true;
            this.radioButtonClosed.Location = new System.Drawing.Point(6, 19);
            this.radioButtonClosed.Name = "radioButtonClosed";
            this.radioButtonClosed.Size = new System.Drawing.Size(97, 17);
            this.radioButtonClosed.TabIndex = 0;
            this.radioButtonClosed.Text = "Closed courses";
            this.radioButtonClosed.UseVisualStyleBackColor = true;
            this.radioButtonClosed.CheckedChanged += new System.EventHandler(this.radioButtonClosed_CheckedChanged);
            // 
            // comboBoxLevel
            // 
            this.comboBoxLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLevel.FormattingEnabled = true;
            this.comboBoxLevel.Location = new System.Drawing.Point(153, 26);
            this.comboBoxLevel.Name = "comboBoxLevel";
            this.comboBoxLevel.Size = new System.Drawing.Size(168, 21);
            this.comboBoxLevel.TabIndex = 1;
            this.comboBoxLevel.SelectedIndexChanged += new System.EventHandler(this.comboBoxLevel_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Level";
            // 
            // treeViewCourses
            // 
            this.treeViewCourses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewCourses.ImageIndex = 0;
            this.treeViewCourses.ImageList = this.imageListTree;
            this.treeViewCourses.Location = new System.Drawing.Point(10, 129);
            this.treeViewCourses.Name = "treeViewCourses";
            this.treeViewCourses.SelectedImageIndex = 0;
            this.treeViewCourses.Size = new System.Drawing.Size(350, 425);
            this.treeViewCourses.TabIndex = 1;
            this.treeViewCourses.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewCourses_NodeMouseClick);
            // 
            // imageListTree
            // 
            this.imageListTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTree.ImageStream")));
            this.imageListTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTree.Images.SetKeyName(0, "folder.png");
            this.imageListTree.Images.SetKeyName(1, "users.png");
            this.imageListTree.Images.SetKeyName(2, "home.png");
            this.imageListTree.Images.SetKeyName(3, "calendar_empty.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonUpdateDesc);
            this.groupBox1.Controls.Add(this.labelCourseName);
            this.groupBox1.Controls.Add(this.checkBoxOpenEnrollment);
            this.groupBox1.Controls.Add(this.textBoxLevel);
            this.groupBox1.Controls.Add(this.labelLevel);
            this.groupBox1.Controls.Add(this.textBoxEnrollments);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.textBoxDescription);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(366, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 155);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Course Data";
            // 
            // buttonUpdateDesc
            // 
            this.buttonUpdateDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdateDesc.Enabled = false;
            this.buttonUpdateDesc.Location = new System.Drawing.Point(363, 65);
            this.buttonUpdateDesc.Name = "buttonUpdateDesc";
            this.buttonUpdateDesc.Size = new System.Drawing.Size(72, 29);
            this.buttonUpdateDesc.TabIndex = 17;
            this.buttonUpdateDesc.Text = "Save";
            this.buttonUpdateDesc.UseVisualStyleBackColor = true;
            this.buttonUpdateDesc.Click += new System.EventHandler(this.buttonUpdateDesc_Click);
            // 
            // labelCourseName
            // 
            this.labelCourseName.AutoSize = true;
            this.labelCourseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCourseName.Location = new System.Drawing.Point(78, 16);
            this.labelCourseName.Name = "labelCourseName";
            this.labelCourseName.Size = new System.Drawing.Size(75, 18);
            this.labelCourseName.TabIndex = 16;
            this.labelCourseName.Text = "(Course)";
            // 
            // checkBoxOpenEnrollment
            // 
            this.checkBoxOpenEnrollment.AutoSize = true;
            this.checkBoxOpenEnrollment.Enabled = false;
            this.checkBoxOpenEnrollment.Location = new System.Drawing.Point(152, 126);
            this.checkBoxOpenEnrollment.Name = "checkBoxOpenEnrollment";
            this.checkBoxOpenEnrollment.Size = new System.Drawing.Size(118, 17);
            this.checkBoxOpenEnrollment.TabIndex = 15;
            this.checkBoxOpenEnrollment.Text = "Open for enrollment";
            this.checkBoxOpenEnrollment.UseVisualStyleBackColor = true;
            // 
            // textBoxLevel
            // 
            this.textBoxLevel.Location = new System.Drawing.Point(81, 45);
            this.textBoxLevel.Name = "textBoxLevel";
            this.textBoxLevel.ReadOnly = true;
            this.textBoxLevel.Size = new System.Drawing.Size(186, 20);
            this.textBoxLevel.TabIndex = 14;
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Location = new System.Drawing.Point(42, 48);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(33, 13);
            this.labelLevel.TabIndex = 13;
            this.labelLevel.Text = "Level";
            // 
            // textBoxEnrollments
            // 
            this.textBoxEnrollments.Location = new System.Drawing.Point(81, 124);
            this.textBoxEnrollments.Name = "textBoxEnrollments";
            this.textBoxEnrollments.ReadOnly = true;
            this.textBoxEnrollments.Size = new System.Drawing.Size(54, 20);
            this.textBoxEnrollments.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Enrollments";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "until";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(226, 97);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(107, 20);
            this.dateTimePicker2.TabIndex = 9;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(81, 97);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(107, 20);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescription.Location = new System.Drawing.Point(81, 70);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(276, 20);
            this.textBoxDescription.TabIndex = 7;
            this.textBoxDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDescription_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Period";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description";
            // 
            // listViewStudents
            // 
            this.listViewStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewStudents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewStudents.ContextMenuStrip = this.contextMenuStripStudent;
            this.listViewStudents.FullRowSelect = true;
            this.listViewStudents.GridLines = true;
            this.listViewStudents.Location = new System.Drawing.Point(366, 290);
            this.listViewStudents.Name = "listViewStudents";
            this.listViewStudents.Size = new System.Drawing.Size(440, 263);
            this.listViewStudents.TabIndex = 3;
            this.listViewStudents.UseCompatibleStateImageBehavior = false;
            this.listViewStudents.View = System.Windows.Forms.View.Details;
            this.listViewStudents.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewStudents_MouseDown);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "No";
            this.columnHeader2.Width = 50;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "System";
            // 
            // contextMenuStripStudent
            // 
            this.contextMenuStripStudent.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.markFinishedCourseToolStripMenuItem,
            this.unmarkFinishedCourseToolStripMenuItem,
            this.removeStudentToolStripMenuItem,
            this.changeSystemToolStripMenuItem});
            this.contextMenuStripStudent.Name = "contextMenuStripStudent";
            this.contextMenuStripStudent.Size = new System.Drawing.Size(204, 92);
            // 
            // markFinishedCourseToolStripMenuItem
            // 
            this.markFinishedCourseToolStripMenuItem.Name = "markFinishedCourseToolStripMenuItem";
            this.markFinishedCourseToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.markFinishedCourseToolStripMenuItem.Text = "Mark Finished Course";
            this.markFinishedCourseToolStripMenuItem.Click += new System.EventHandler(this.markFinishedCourseToolStripMenuItem_Click);
            // 
            // unmarkFinishedCourseToolStripMenuItem
            // 
            this.unmarkFinishedCourseToolStripMenuItem.Name = "unmarkFinishedCourseToolStripMenuItem";
            this.unmarkFinishedCourseToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.unmarkFinishedCourseToolStripMenuItem.Text = "Unmark Finished Course";
            this.unmarkFinishedCourseToolStripMenuItem.Click += new System.EventHandler(this.unmarkFinishedCourseToolStripMenuItem_Click);
            // 
            // removeStudentToolStripMenuItem
            // 
            this.removeStudentToolStripMenuItem.Name = "removeStudentToolStripMenuItem";
            this.removeStudentToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.removeStudentToolStripMenuItem.Text = "Remove Student";
            this.removeStudentToolStripMenuItem.Visible = false;
            this.removeStudentToolStripMenuItem.Click += new System.EventHandler(this.removeStudentToolStripMenuItem_Click);
            // 
            // changeSystemToolStripMenuItem
            // 
            this.changeSystemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.standardToolStripMenuItem,
            this.system2ToolStripMenuItem});
            this.changeSystemToolStripMenuItem.Name = "changeSystemToolStripMenuItem";
            this.changeSystemToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.changeSystemToolStripMenuItem.Text = "Change System";
            // 
            // standardToolStripMenuItem
            // 
            this.standardToolStripMenuItem.Name = "standardToolStripMenuItem";
            this.standardToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.standardToolStripMenuItem.Text = "Standard";
            this.standardToolStripMenuItem.Click += new System.EventHandler(this.standardToolStripMenuItem_Click);
            // 
            // system2ToolStripMenuItem
            // 
            this.system2ToolStripMenuItem.Name = "system2ToolStripMenuItem";
            this.system2ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.system2ToolStripMenuItem.Text = "System 2";
            this.system2ToolStripMenuItem.Click += new System.EventHandler(this.system2ToolStripMenuItem_Click);
            // 
            // panelFunctions
            // 
            this.panelFunctions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFunctions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFunctions.Controls.Add(this.buttonDeleteCourse);
            this.panelFunctions.Controls.Add(this.buttonNewClass);
            this.panelFunctions.Controls.Add(this.buttonReportInvitations);
            this.panelFunctions.Controls.Add(this.button1);
            this.panelFunctions.Location = new System.Drawing.Point(356, 13);
            this.panelFunctions.Name = "panelFunctions";
            this.panelFunctions.Size = new System.Drawing.Size(450, 109);
            this.panelFunctions.TabIndex = 4;
            // 
            // buttonDeleteCourse
            // 
            this.buttonDeleteCourse.Image = global::LoSAdmin.Properties.Resources.application_remove;
            this.buttonDeleteCourse.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonDeleteCourse.Location = new System.Drawing.Point(89, 13);
            this.buttonDeleteCourse.Name = "buttonDeleteCourse";
            this.buttonDeleteCourse.Size = new System.Drawing.Size(75, 56);
            this.buttonDeleteCourse.TabIndex = 7;
            this.buttonDeleteCourse.Text = "Delete Course";
            this.buttonDeleteCourse.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonDeleteCourse.UseVisualStyleBackColor = true;
            this.buttonDeleteCourse.Click += new System.EventHandler(this.buttonDeleteCourse_Click);
            // 
            // buttonNewClass
            // 
            this.buttonNewClass.Image = global::LoSAdmin.Properties.Resources.application_add;
            this.buttonNewClass.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonNewClass.Location = new System.Drawing.Point(10, 12);
            this.buttonNewClass.Name = "buttonNewClass";
            this.buttonNewClass.Size = new System.Drawing.Size(73, 56);
            this.buttonNewClass.TabIndex = 5;
            this.buttonNewClass.Text = "Create New Course";
            this.buttonNewClass.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonNewClass.UseVisualStyleBackColor = true;
            this.buttonNewClass.Click += new System.EventHandler(this.buttonNewClass_Click);
            // 
            // buttonReportInvitations
            // 
            this.buttonReportInvitations.Image = global::LoSAdmin.Properties.Resources.mail;
            this.buttonReportInvitations.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonReportInvitations.Location = new System.Drawing.Point(170, 13);
            this.buttonReportInvitations.Name = "buttonReportInvitations";
            this.buttonReportInvitations.Size = new System.Drawing.Size(76, 56);
            this.buttonReportInvitations.TabIndex = 6;
            this.buttonReportInvitations.Text = "Enrollment Invitations";
            this.buttonReportInvitations.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonReportInvitations.UseVisualStyleBackColor = true;
            this.buttonReportInvitations.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = global::LoSAdmin.Properties.Resources.community_users;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(252, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 56);
            this.button1.TabIndex = 3;
            this.button1.Text = "Attendance List";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormClasses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 564);
            this.Controls.Add(this.panelFunctions);
            this.Controls.Add(this.listViewStudents);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.treeViewCourses);
            this.Controls.Add(this.panelSelection);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormClasses";
            this.Text = "Classes";
            this.panelSelection.ResumeLayout(false);
            this.panelSelection.PerformLayout();
            this.groupBoxActive.ResumeLayout(false);
            this.groupBoxActive.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStripStudent.ResumeLayout(false);
            this.panelFunctions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSelection;
        private System.Windows.Forms.GroupBox groupBoxActive;
        private System.Windows.Forms.RadioButton radioButtonAllCourses;
        private System.Windows.Forms.RadioButton radioButtonRunning;
        private System.Windows.Forms.RadioButton radioButtonClosed;
        private System.Windows.Forms.ComboBox comboBoxLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeViewCourses;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listViewStudents;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxEnrollments;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.TextBox textBoxLevel;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.CheckBox checkBoxOpenEnrollment;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageListTree;
        private System.Windows.Forms.Label labelCourseName;
        private System.Windows.Forms.Button buttonNewClass;
        private System.Windows.Forms.Button buttonReportInvitations;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripStudent;
        private System.Windows.Forms.ToolStripMenuItem markFinishedCourseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unmarkFinishedCourseToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxContainStudent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelFunctions;
        private System.Windows.Forms.Button buttonDeleteCourse;
        private System.Windows.Forms.ToolStripMenuItem removeStudentToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStripMenuItem changeSystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem system2ToolStripMenuItem;
        private System.Windows.Forms.Button buttonUpdateDesc;
    }
}