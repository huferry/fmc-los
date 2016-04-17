namespace LoSAdmin
{
    partial class FormMeetings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMeetings));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listViewBlockings = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.buttonAbsent = new System.Windows.Forms.Button();
            this.buttonReport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonPlanner = new System.Windows.Forms.Button();
            this.buttonBlockings = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(12, 91);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(811, 277);
            this.treeView1.TabIndex = 2;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "warning.png");
            this.imageList1.Images.SetKeyName(1, "accept.png");
            this.imageList1.Images.SetKeyName(2, "user_remove.png");
            this.imageList1.Images.SetKeyName(3, "user_accept.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.listViewBlockings);
            this.groupBox1.Location = new System.Drawing.Point(13, 374);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(810, 179);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Blocked dates";
            // 
            // listViewBlockings
            // 
            this.listViewBlockings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewBlockings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewBlockings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewBlockings.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewBlockings.Location = new System.Drawing.Point(18, 19);
            this.listViewBlockings.Name = "listViewBlockings";
            this.listViewBlockings.Size = new System.Drawing.Size(773, 143);
            this.listViewBlockings.TabIndex = 0;
            this.listViewBlockings.UseCompatibleStateImageBehavior = false;
            this.listViewBlockings.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Event";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "From";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Until";
            this.columnHeader3.Width = 200;
            // 
            // buttonAbsent
            // 
            this.buttonAbsent.Image = global::LoSAdmin.Properties.Resources.feel_sick_icon;
            this.buttonAbsent.Location = new System.Drawing.Point(267, 12);
            this.buttonAbsent.Name = "buttonAbsent";
            this.buttonAbsent.Size = new System.Drawing.Size(75, 73);
            this.buttonAbsent.TabIndex = 7;
            this.buttonAbsent.Text = "Absence";
            this.buttonAbsent.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonAbsent.UseVisualStyleBackColor = true;
            this.buttonAbsent.Click += new System.EventHandler(this.buttonAbsent_Click);
            // 
            // buttonReport
            // 
            this.buttonReport.Image = global::LoSAdmin.Properties.Resources.printer1;
            this.buttonReport.Location = new System.Drawing.Point(348, 12);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(75, 73);
            this.buttonReport.TabIndex = 6;
            this.buttonReport.Text = "Report";
            this.buttonReport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // button1
            // 
            this.button1.Image = global::LoSAdmin.Properties.Resources.user_accept;
            this.button1.Location = new System.Drawing.Point(182, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 73);
            this.button1.TabIndex = 5;
            this.button1.Text = "Attendance";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonPlanner
            // 
            this.buttonPlanner.Image = global::LoSAdmin.Properties.Resources.calculator;
            this.buttonPlanner.Location = new System.Drawing.Point(97, 12);
            this.buttonPlanner.Name = "buttonPlanner";
            this.buttonPlanner.Size = new System.Drawing.Size(79, 73);
            this.buttonPlanner.TabIndex = 3;
            this.buttonPlanner.Text = "Planner";
            this.buttonPlanner.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonPlanner.UseVisualStyleBackColor = true;
            this.buttonPlanner.Click += new System.EventHandler(this.buttonPlanner_Click);
            // 
            // buttonBlockings
            // 
            this.buttonBlockings.Image = global::LoSAdmin.Properties.Resources.calendar_date;
            this.buttonBlockings.Location = new System.Drawing.Point(12, 12);
            this.buttonBlockings.Name = "buttonBlockings";
            this.buttonBlockings.Size = new System.Drawing.Size(79, 73);
            this.buttonBlockings.TabIndex = 0;
            this.buttonBlockings.Text = "Blockings";
            this.buttonBlockings.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonBlockings.UseVisualStyleBackColor = true;
            this.buttonBlockings.Click += new System.EventHandler(this.buttonBlockings_Click);
            // 
            // FormMeetings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 569);
            this.Controls.Add(this.buttonAbsent);
            this.Controls.Add(this.buttonReport);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonPlanner);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.buttonBlockings);
            this.Name = "FormMeetings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meeting Administration";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBlockings;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button buttonPlanner;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listViewBlockings;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.Button buttonAbsent;
    }
}