namespace ADHE_Reporting
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rdbInstructor = new System.Windows.Forms.RadioButton();
            this.rdbStudent = new System.Windows.Forms.RadioButton();
            this.rdbCourse = new System.Windows.Forms.RadioButton();
            this.rdbRegistration = new System.Windows.Forms.RadioButton();
            this.rdbTerm = new System.Windows.Forms.RadioButton();
            this.rdbEOT = new System.Windows.Forms.RadioButton();
            this.btnGo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdbGraduate = new System.Windows.Forms.RadioButton();
            this.rdbPerkinsII = new System.Windows.Forms.RadioButton();
            this.rdbAnnualInstructor = new System.Windows.Forms.RadioButton();
            this.rdbPerkinsI = new System.Windows.Forms.RadioButton();
            this.tbxMessage = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.ofdRegistration = new System.Windows.Forms.OpenFileDialog();
            this.ofdGrades = new System.Windows.Forms.OpenFileDialog();
            this.ofdGPAs = new System.Windows.Forms.OpenFileDialog();
            this.cmbxAcadYear = new System.Windows.Forms.ComboBox();
            this.lblAcadYear = new System.Windows.Forms.Label();
            this.ofdStudents = new System.Windows.Forms.OpenFileDialog();
            this.ofdInstructor = new System.Windows.Forms.OpenFileDialog();
            this.ofdCourse = new System.Windows.Forms.OpenFileDialog();
            this.ofdAnnualInstructors = new System.Windows.Forms.OpenFileDialog();
            this.ofdPerkinsI = new System.Windows.Forms.OpenFileDialog();
            this.ofdPerkinsII = new System.Windows.Forms.OpenFileDialog();
            this.ofdGraduate = new System.Windows.Forms.OpenFileDialog();
            this.ofdTestGrades = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rdbInstructor
            // 
            this.rdbInstructor.AutoSize = true;
            this.rdbInstructor.Location = new System.Drawing.Point(22, 36);
            this.rdbInstructor.Name = "rdbInstructor";
            this.rdbInstructor.Size = new System.Drawing.Size(96, 17);
            this.rdbInstructor.TabIndex = 0;
            this.rdbInstructor.TabStop = true;
            this.rdbInstructor.Text = "Instructor (014)";
            this.rdbInstructor.UseVisualStyleBackColor = true;
            // 
            // rdbStudent
            // 
            this.rdbStudent.AutoSize = true;
            this.rdbStudent.Location = new System.Drawing.Point(22, 13);
            this.rdbStudent.Name = "rdbStudent";
            this.rdbStudent.Size = new System.Drawing.Size(89, 17);
            this.rdbStudent.TabIndex = 1;
            this.rdbStudent.TabStop = true;
            this.rdbStudent.Text = "Student (011)";
            this.rdbStudent.UseVisualStyleBackColor = true;
            this.rdbStudent.CheckedChanged += new System.EventHandler(this.rdbStudent_CheckedChanged);
            // 
            // rdbCourse
            // 
            this.rdbCourse.AutoSize = true;
            this.rdbCourse.Location = new System.Drawing.Point(22, 59);
            this.rdbCourse.Name = "rdbCourse";
            this.rdbCourse.Size = new System.Drawing.Size(85, 17);
            this.rdbCourse.TabIndex = 2;
            this.rdbCourse.TabStop = true;
            this.rdbCourse.Text = "Course (015)";
            this.rdbCourse.UseVisualStyleBackColor = true;
            // 
            // rdbRegistration
            // 
            this.rdbRegistration.AutoSize = true;
            this.rdbRegistration.Location = new System.Drawing.Point(22, 82);
            this.rdbRegistration.Name = "rdbRegistration";
            this.rdbRegistration.Size = new System.Drawing.Size(108, 17);
            this.rdbRegistration.TabIndex = 3;
            this.rdbRegistration.TabStop = true;
            this.rdbRegistration.Text = "Registration (016)";
            this.rdbRegistration.UseVisualStyleBackColor = true;
            // 
            // rdbTerm
            // 
            this.rdbTerm.AutoSize = true;
            this.rdbTerm.Location = new System.Drawing.Point(22, 105);
            this.rdbTerm.Name = "rdbTerm";
            this.rdbTerm.Size = new System.Drawing.Size(73, 17);
            this.rdbTerm.TabIndex = 4;
            this.rdbTerm.TabStop = true;
            this.rdbTerm.Text = "Term (xxx)";
            this.rdbTerm.UseVisualStyleBackColor = true;
            // 
            // rdbEOT
            // 
            this.rdbEOT.AutoSize = true;
            this.rdbEOT.Location = new System.Drawing.Point(22, 128);
            this.rdbEOT.Name = "rdbEOT";
            this.rdbEOT.Size = new System.Drawing.Size(112, 17);
            this.rdbEOT.TabIndex = 5;
            this.rdbEOT.TabStop = true;
            this.rdbEOT.Text = "End Of Term (019)";
            this.rdbEOT.UseVisualStyleBackColor = true;
            this.rdbEOT.CheckedChanged += new System.EventHandler(this.rdbEOT_CheckedChanged);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(388, 353);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(58, 23);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rdbGraduate);
            this.panel1.Controls.Add(this.rdbPerkinsII);
            this.panel1.Controls.Add(this.rdbAnnualInstructor);
            this.panel1.Controls.Add(this.rdbPerkinsI);
            this.panel1.Controls.Add(this.rdbInstructor);
            this.panel1.Controls.Add(this.rdbStudent);
            this.panel1.Controls.Add(this.rdbEOT);
            this.panel1.Controls.Add(this.rdbCourse);
            this.panel1.Controls.Add(this.rdbTerm);
            this.panel1.Controls.Add(this.rdbRegistration);
            this.panel1.Location = new System.Drawing.Point(12, 204);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 180);
            this.panel1.TabIndex = 7;
            // 
            // rdbGraduate
            // 
            this.rdbGraduate.AutoSize = true;
            this.rdbGraduate.Location = new System.Drawing.Point(209, 59);
            this.rdbGraduate.Name = "rdbGraduate";
            this.rdbGraduate.Size = new System.Drawing.Size(96, 17);
            this.rdbGraduate.TabIndex = 16;
            this.rdbGraduate.TabStop = true;
            this.rdbGraduate.Text = "Graduate (012)";
            this.rdbGraduate.UseVisualStyleBackColor = true;
            // 
            // rdbPerkinsII
            // 
            this.rdbPerkinsII.AutoSize = true;
            this.rdbPerkinsII.Location = new System.Drawing.Point(209, 36);
            this.rdbPerkinsII.Name = "rdbPerkinsII";
            this.rdbPerkinsII.Size = new System.Drawing.Size(98, 17);
            this.rdbPerkinsII.TabIndex = 15;
            this.rdbPerkinsII.TabStop = true;
            this.rdbPerkinsII.Text = "Perkins II (02Q)";
            this.rdbPerkinsII.UseVisualStyleBackColor = true;
            // 
            // rdbAnnualInstructor
            // 
            this.rdbAnnualInstructor.AutoSize = true;
            this.rdbAnnualInstructor.Location = new System.Drawing.Point(22, 151);
            this.rdbAnnualInstructor.Name = "rdbAnnualInstructor";
            this.rdbAnnualInstructor.Size = new System.Drawing.Size(132, 17);
            this.rdbAnnualInstructor.TabIndex = 6;
            this.rdbAnnualInstructor.TabStop = true;
            this.rdbAnnualInstructor.Text = "Annual Instructor (017)";
            this.rdbAnnualInstructor.UseVisualStyleBackColor = true;
            // 
            // rdbPerkinsI
            // 
            this.rdbPerkinsI.AutoSize = true;
            this.rdbPerkinsI.Location = new System.Drawing.Point(209, 13);
            this.rdbPerkinsI.Name = "rdbPerkinsI";
            this.rdbPerkinsI.Size = new System.Drawing.Size(94, 17);
            this.rdbPerkinsI.TabIndex = 7;
            this.rdbPerkinsI.TabStop = true;
            this.rdbPerkinsI.Text = "Perkins I (02V)";
            this.rdbPerkinsI.UseVisualStyleBackColor = true;
            // 
            // tbxMessage
            // 
            this.tbxMessage.Location = new System.Drawing.Point(388, 259);
            this.tbxMessage.Multiline = true;
            this.tbxMessage.Name = "tbxMessage";
            this.tbxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxMessage.Size = new System.Drawing.Size(237, 91);
            this.tbxMessage.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(60, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(358, 117);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(385, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Messages:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Red;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(172, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(335, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "ADHE Reporting System--ONEOFFVERSION";
            this.label2.UseMnemonic = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(550, 353);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ofdRegistration
            // 
            this.ofdRegistration.InitialDirectory = "c:\\adhe";
            // 
            // cmbxAcadYear
            // 
            this.cmbxAcadYear.FormattingEnabled = true;
            this.cmbxAcadYear.Items.AddRange(new object[] {
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.cmbxAcadYear.Location = new System.Drawing.Point(555, 218);
            this.cmbxAcadYear.Name = "cmbxAcadYear";
            this.cmbxAcadYear.Size = new System.Drawing.Size(70, 21);
            this.cmbxAcadYear.TabIndex = 13;
            this.cmbxAcadYear.Visible = false;
            // 
            // lblAcadYear
            // 
            this.lblAcadYear.AutoSize = true;
            this.lblAcadYear.Location = new System.Drawing.Point(434, 226);
            this.lblAcadYear.Name = "lblAcadYear";
            this.lblAcadYear.Size = new System.Drawing.Size(115, 13);
            this.lblAcadYear.TabIndex = 14;
            this.lblAcadYear.Text = "Select Academic Year:";
            this.lblAcadYear.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 396);
            this.Controls.Add(this.lblAcadYear);
            this.Controls.Add(this.cmbxAcadYear);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbxMessage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGo);
            this.Name = "Form1";
            this.Text = "NPC ADHE Reports";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbInstructor;
        private System.Windows.Forms.RadioButton rdbStudent;
        private System.Windows.Forms.RadioButton rdbCourse;
        private System.Windows.Forms.RadioButton rdbRegistration;
        private System.Windows.Forms.RadioButton rdbTerm;
        private System.Windows.Forms.RadioButton rdbEOT;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbxMessage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdbAnnualInstructor;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.OpenFileDialog ofdRegistration;
        private System.Windows.Forms.OpenFileDialog ofdGrades;
        private System.Windows.Forms.OpenFileDialog ofdGPAs;
        private System.Windows.Forms.ComboBox cmbxAcadYear;
        private System.Windows.Forms.Label lblAcadYear;
        private System.Windows.Forms.OpenFileDialog ofdStudents;
        private System.Windows.Forms.OpenFileDialog ofdInstructor;
        private System.Windows.Forms.OpenFileDialog ofdCourse;
        private System.Windows.Forms.OpenFileDialog ofdAnnualInstructors;
        private System.Windows.Forms.OpenFileDialog ofdPerkinsI;
        private System.Windows.Forms.RadioButton rdbPerkinsI;
        private System.Windows.Forms.RadioButton rdbPerkinsII;
        private System.Windows.Forms.OpenFileDialog ofdPerkinsII;
        private System.Windows.Forms.OpenFileDialog ofdGraduate;
        private System.Windows.Forms.RadioButton rdbGraduate;
        private System.Windows.Forms.OpenFileDialog ofdTestGrades;
    }
}

