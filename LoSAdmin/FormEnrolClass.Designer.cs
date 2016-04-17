namespace LoSAdmin
{
    partial class FormEnrolClass
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLastClass = new System.Windows.Forms.TextBox();
            this.checkBoxFinished = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxClasses = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxAll = new System.Windows.Forms.CheckBox();
            this.checkBoxActiveOnly = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(9, 32);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(260, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Last Class";
            // 
            // textBoxLastClass
            // 
            this.textBoxLastClass.Location = new System.Drawing.Point(9, 81);
            this.textBoxLastClass.Name = "textBoxLastClass";
            this.textBoxLastClass.ReadOnly = true;
            this.textBoxLastClass.Size = new System.Drawing.Size(260, 20);
            this.textBoxLastClass.TabIndex = 3;
            // 
            // checkBoxFinished
            // 
            this.checkBoxFinished.AutoSize = true;
            this.checkBoxFinished.Enabled = false;
            this.checkBoxFinished.Location = new System.Drawing.Point(204, 107);
            this.checkBoxFinished.Name = "checkBoxFinished";
            this.checkBoxFinished.Size = new System.Drawing.Size(65, 17);
            this.checkBoxFinished.TabIndex = 4;
            this.checkBoxFinished.Text = "Finished";
            this.checkBoxFinished.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Enrol to class";
            // 
            // comboBoxClasses
            // 
            this.comboBoxClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClasses.FormattingEnabled = true;
            this.comboBoxClasses.Location = new System.Drawing.Point(12, 185);
            this.comboBoxClasses.Name = "comboBoxClasses";
            this.comboBoxClasses.Size = new System.Drawing.Size(269, 21);
            this.comboBoxClasses.TabIndex = 6;
            this.comboBoxClasses.SelectedIndexChanged += new System.EventHandler(this.comboBoxClasses_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(125, 259);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(206, 259);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxLastClass);
            this.groupBox1.Controls.Add(this.checkBoxFinished);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 138);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.AutoSize = true;
            this.checkBoxAll.Location = new System.Drawing.Point(12, 212);
            this.checkBoxAll.Name = "checkBoxAll";
            this.checkBoxAll.Size = new System.Drawing.Size(104, 17);
            this.checkBoxAll.TabIndex = 10;
            this.checkBoxAll.Text = "Show all classes";
            this.checkBoxAll.UseVisualStyleBackColor = true;
            this.checkBoxAll.Click += new System.EventHandler(this.checkBoxAll_Click);
            // 
            // checkBoxActiveOnly
            // 
            this.checkBoxActiveOnly.AutoSize = true;
            this.checkBoxActiveOnly.Checked = true;
            this.checkBoxActiveOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActiveOnly.Location = new System.Drawing.Point(137, 212);
            this.checkBoxActiveOnly.Name = "checkBoxActiveOnly";
            this.checkBoxActiveOnly.Size = new System.Drawing.Size(105, 17);
            this.checkBoxActiveOnly.TabIndex = 11;
            this.checkBoxActiveOnly.Text = "Active class only";
            this.checkBoxActiveOnly.UseVisualStyleBackColor = true;
            this.checkBoxActiveOnly.CheckedChanged += new System.EventHandler(this.checkBoxAll_Click);
            // 
            // FormEnrolClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 294);
            this.Controls.Add(this.checkBoxActiveOnly);
            this.Controls.Add(this.checkBoxAll);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxClasses);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEnrolClass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enrol Student to A Class";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLastClass;
        private System.Windows.Forms.CheckBox checkBoxFinished;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxClasses;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxAll;
        private System.Windows.Forms.CheckBox checkBoxActiveOnly;
    }
}