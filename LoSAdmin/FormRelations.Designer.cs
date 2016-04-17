namespace LoSAdmin
{
    partial class FormRelations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRelations));
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.checkBoxNeedApproval = new System.Windows.Forms.CheckBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewRelations = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.groupBoxRelation = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxNextPossible = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxLastCourse = new System.Windows.Forms.TextBox();
            this.textBoxCurrentCourse = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelMode = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxPhoneMobile = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxPhoneHome = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerBirthdate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonFemale = new System.Windows.Forms.RadioButton();
            this.radioButtonMale = new System.Windows.Forms.RadioButton();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.textBoxFirstname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonApprove = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonEnrollment = new System.Windows.Forms.Button();
            this.groupBoxSearch.SuspendLayout();
            this.groupBoxRelation.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.checkBoxNeedApproval);
            this.groupBoxSearch.Controls.Add(this.textBoxSearch);
            this.groupBoxSearch.Controls.Add(this.label1);
            this.groupBoxSearch.Location = new System.Drawing.Point(14, 13);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(316, 73);
            this.groupBoxSearch.TabIndex = 0;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Find";
            // 
            // checkBoxNeedApproval
            // 
            this.checkBoxNeedApproval.AutoSize = true;
            this.checkBoxNeedApproval.Location = new System.Drawing.Point(19, 48);
            this.checkBoxNeedApproval.Name = "checkBoxNeedApproval";
            this.checkBoxNeedApproval.Size = new System.Drawing.Size(118, 17);
            this.checkBoxNeedApproval.TabIndex = 2;
            this.checkBoxNeedApproval.Text = "Need approval only";
            this.checkBoxNeedApproval.UseVisualStyleBackColor = true;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.HideSelection = false;
            this.textBoxSearch.Location = new System.Drawing.Point(71, 20);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(227, 20);
            this.textBoxSearch.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Keywords";
            // 
            // listViewRelations
            // 
            this.listViewRelations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewRelations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewRelations.FullRowSelect = true;
            this.listViewRelations.HideSelection = false;
            this.listViewRelations.Location = new System.Drawing.Point(13, 92);
            this.listViewRelations.Name = "listViewRelations";
            this.listViewRelations.Size = new System.Drawing.Size(316, 559);
            this.listViewRelations.TabIndex = 1;
            this.listViewRelations.UseCompatibleStateImageBehavior = false;
            this.listViewRelations.View = System.Windows.Forms.View.Details;
            this.listViewRelations.SelectedIndexChanged += new System.EventHandler(this.listViewRelations_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 265;
            // 
            // groupBoxRelation
            // 
            this.groupBoxRelation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxRelation.Controls.Add(this.groupBox1);
            this.groupBoxRelation.Controls.Add(this.buttonCancel);
            this.groupBoxRelation.Controls.Add(this.buttonSave);
            this.groupBoxRelation.Controls.Add(this.labelMode);
            this.groupBoxRelation.Controls.Add(this.pictureBox1);
            this.groupBoxRelation.Controls.Add(this.groupBox5);
            this.groupBoxRelation.Controls.Add(this.groupBox4);
            this.groupBoxRelation.Controls.Add(this.dateTimePickerBirthdate);
            this.groupBoxRelation.Controls.Add(this.label4);
            this.groupBoxRelation.Controls.Add(this.groupBox3);
            this.groupBoxRelation.Controls.Add(this.textBoxSurname);
            this.groupBoxRelation.Controls.Add(this.textBoxFirstname);
            this.groupBoxRelation.Controls.Add(this.label3);
            this.groupBoxRelation.Controls.Add(this.label2);
            this.groupBoxRelation.Enabled = false;
            this.groupBoxRelation.Location = new System.Drawing.Point(344, 83);
            this.groupBoxRelation.Name = "groupBoxRelation";
            this.groupBoxRelation.Size = new System.Drawing.Size(474, 570);
            this.groupBoxRelation.TabIndex = 2;
            this.groupBoxRelation.TabStop = false;
            this.groupBoxRelation.Text = "Relation Detail";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxNextPossible);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.textBoxLastCourse);
            this.groupBox1.Controls.Add(this.textBoxCurrentCourse);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(163, 379);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 112);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Course";
            // 
            // textBoxNextPossible
            // 
            this.textBoxNextPossible.Location = new System.Drawing.Point(78, 78);
            this.textBoxNextPossible.Name = "textBoxNextPossible";
            this.textBoxNextPossible.ReadOnly = true;
            this.textBoxNextPossible.Size = new System.Drawing.Size(183, 20);
            this.textBoxNextPossible.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(2, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Next possible";
            // 
            // textBoxLastCourse
            // 
            this.textBoxLastCourse.Location = new System.Drawing.Point(78, 51);
            this.textBoxLastCourse.Name = "textBoxLastCourse";
            this.textBoxLastCourse.ReadOnly = true;
            this.textBoxLastCourse.Size = new System.Drawing.Size(183, 20);
            this.textBoxLastCourse.TabIndex = 3;
            // 
            // textBoxCurrentCourse
            // 
            this.textBoxCurrentCourse.Location = new System.Drawing.Point(78, 24);
            this.textBoxCurrentCourse.Name = "textBoxCurrentCourse";
            this.textBoxCurrentCourse.ReadOnly = true;
            this.textBoxCurrentCourse.Size = new System.Drawing.Size(183, 20);
            this.textBoxCurrentCourse.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Last finished";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(31, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Current";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
            this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonCancel.Location = new System.Drawing.Point(408, 497);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(60, 65);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonSave.Location = new System.Drawing.Point(342, 497);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(60, 65);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Save";
            this.buttonSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Visible = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelMode
            // 
            this.labelMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.labelMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMode.Location = new System.Drawing.Point(297, 16);
            this.labelMode.Name = "labelMode";
            this.labelMode.Size = new System.Drawing.Size(140, 26);
            this.labelMode.TabIndex = 10;
            this.labelMode.Text = "Edit mode";
            this.labelMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelMode.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 379);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 162);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBoxEmail);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.textBoxPhoneMobile);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.textBoxPhoneHome);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Location = new System.Drawing.Point(11, 253);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(426, 113);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Contact Information";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(83, 79);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(317, 20);
            this.textBoxEmail.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(41, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "E-Mail";
            // 
            // textBoxPhoneMobile
            // 
            this.textBoxPhoneMobile.Location = new System.Drawing.Point(83, 53);
            this.textBoxPhoneMobile.Name = "textBoxPhoneMobile";
            this.textBoxPhoneMobile.Size = new System.Drawing.Size(182, 20);
            this.textBoxPhoneMobile.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Phone mobile";
            // 
            // textBoxPhoneHome
            // 
            this.textBoxPhoneHome.Location = new System.Drawing.Point(83, 27);
            this.textBoxPhoneHome.Name = "textBoxPhoneHome";
            this.textBoxPhoneHome.Size = new System.Drawing.Size(182, 20);
            this.textBoxPhoneHome.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Phone home";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox6);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.textBox5);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.textBox4);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(11, 140);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(426, 93);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Address";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(83, 55);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(317, 20);
            this.textBox6.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Street";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(300, 25);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(214, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "House number";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(83, 25);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(108, 20);
            this.textBox4.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Postal code";
            // 
            // dateTimePickerBirthdate
            // 
            this.dateTimePickerBirthdate.Location = new System.Drawing.Point(66, 94);
            this.dateTimePickerBirthdate.MaxDate = new System.DateTime(3000, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerBirthdate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerBirthdate.Name = "dateTimePickerBirthdate";
            this.dateTimePickerBirthdate.Size = new System.Drawing.Size(210, 20);
            this.dateTimePickerBirthdate.TabIndex = 6;
            this.dateTimePickerBirthdate.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerBirthdate.Validating += new System.ComponentModel.CancelEventHandler(this.dateTimePickerBirthdate_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Birthdate";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonFemale);
            this.groupBox3.Controls.Add(this.radioButtonMale);
            this.groupBox3.Location = new System.Drawing.Point(297, 62);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(140, 51);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gender";
            // 
            // radioButtonFemale
            // 
            this.radioButtonFemale.AutoSize = true;
            this.radioButtonFemale.Location = new System.Drawing.Point(68, 19);
            this.radioButtonFemale.Name = "radioButtonFemale";
            this.radioButtonFemale.Size = new System.Drawing.Size(59, 17);
            this.radioButtonFemale.TabIndex = 1;
            this.radioButtonFemale.TabStop = true;
            this.radioButtonFemale.Text = "Female";
            this.radioButtonFemale.UseVisualStyleBackColor = true;
            // 
            // radioButtonMale
            // 
            this.radioButtonMale.AutoSize = true;
            this.radioButtonMale.Location = new System.Drawing.Point(14, 19);
            this.radioButtonMale.Name = "radioButtonMale";
            this.radioButtonMale.Size = new System.Drawing.Size(48, 17);
            this.radioButtonMale.TabIndex = 0;
            this.radioButtonMale.TabStop = true;
            this.radioButtonMale.Text = "Male";
            this.radioButtonMale.UseVisualStyleBackColor = true;
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Location = new System.Drawing.Point(66, 62);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(210, 20);
            this.textBoxSurname.TabIndex = 3;
            this.textBoxSurname.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxSurname_Validating);
            // 
            // textBoxFirstname
            // 
            this.textBoxFirstname.Location = new System.Drawing.Point(66, 32);
            this.textBoxFirstname.Name = "textBoxFirstname";
            this.textBoxFirstname.Size = new System.Drawing.Size(210, 20);
            this.textBoxFirstname.TabIndex = 2;
            this.textBoxFirstname.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxFirstname_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Firstname";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Surname";
            // 
            // buttonNew
            // 
            this.buttonNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNew.Image = ((System.Drawing.Image)(resources.GetObject("buttonNew.Image")));
            this.buttonNew.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonNew.Location = new System.Drawing.Point(8, 10);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(60, 65);
            this.buttonNew.TabIndex = 3;
            this.buttonNew.Text = "New";
            this.buttonNew.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEdit.Image = ((System.Drawing.Image)(resources.GetObject("buttonEdit.Image")));
            this.buttonEdit.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonEdit.Location = new System.Drawing.Point(74, 10);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(60, 66);
            this.buttonEdit.TabIndex = 4;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonApprove
            // 
            this.buttonApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonApprove.Image = ((System.Drawing.Image)(resources.GetObject("buttonApprove.Image")));
            this.buttonApprove.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonApprove.Location = new System.Drawing.Point(140, 10);
            this.buttonApprove.Name = "buttonApprove";
            this.buttonApprove.Size = new System.Drawing.Size(60, 66);
            this.buttonApprove.TabIndex = 5;
            this.buttonApprove.Text = "Approve";
            this.buttonApprove.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonApprove.UseVisualStyleBackColor = true;
            this.buttonApprove.Click += new System.EventHandler(this.buttonApprove_Click);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.Location = new System.Drawing.Point(284, 10);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(60, 66);
            this.button4.TabIndex = 6;
            this.button4.Text = "Print";
            this.button4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.Location = new System.Drawing.Point(350, 10);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(60, 66);
            this.button5.TabIndex = 7;
            this.button5.Text = "Send e-mail";
            this.button5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // buttonRemove
            // 
            this.buttonRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemove.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemove.Image")));
            this.buttonRemove.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonRemove.Location = new System.Drawing.Point(206, 10);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(60, 66);
            this.buttonRemove.TabIndex = 8;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.buttonEnrollment);
            this.panelButtons.Controls.Add(this.buttonNew);
            this.panelButtons.Controls.Add(this.button5);
            this.panelButtons.Controls.Add(this.buttonRemove);
            this.panelButtons.Controls.Add(this.button4);
            this.panelButtons.Controls.Add(this.buttonEdit);
            this.panelButtons.Controls.Add(this.buttonApprove);
            this.panelButtons.Location = new System.Drawing.Point(344, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(508, 78);
            this.panelButtons.TabIndex = 9;
            // 
            // buttonEnrollment
            // 
            this.buttonEnrollment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEnrollment.Image = ((System.Drawing.Image)(resources.GetObject("buttonEnrollment.Image")));
            this.buttonEnrollment.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonEnrollment.Location = new System.Drawing.Point(427, 10);
            this.buttonEnrollment.Name = "buttonEnrollment";
            this.buttonEnrollment.Size = new System.Drawing.Size(60, 66);
            this.buttonEnrollment.TabIndex = 9;
            this.buttonEnrollment.Text = "Enroll A Class";
            this.buttonEnrollment.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonEnrollment.UseVisualStyleBackColor = true;
            this.buttonEnrollment.Click += new System.EventHandler(this.buttonEnrollment_Click);
            // 
            // FormRelations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 664);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.groupBoxRelation);
            this.Controls.Add(this.listViewRelations);
            this.Controls.Add(this.groupBoxSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRelations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relations";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.FormRelations_Shown);
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.groupBoxRelation.ResumeLayout(false);
            this.groupBoxRelation.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.ListView listViewRelations;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxRelation;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.TextBox textBoxFirstname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonFemale;
        private System.Windows.Forms.RadioButton radioButtonMale;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerBirthdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxPhoneMobile;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxPhoneHome;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonApprove;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.CheckBox checkBoxNeedApproval;
        private System.Windows.Forms.Label labelMode;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxLastCourse;
        private System.Windows.Forms.TextBox textBoxCurrentCourse;
        private System.Windows.Forms.Button buttonEnrollment;
        private System.Windows.Forms.TextBox textBoxNextPossible;
        private System.Windows.Forms.Label label13;
    }
}