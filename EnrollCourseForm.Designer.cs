
namespace myproject
{
    partial class EnrollCourseForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
           
            this.ComboBox1_SelectStudent = new System.Windows.Forms.ComboBox();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.ComboBox2_SelectCourse = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
           
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 51);
            this.panel1.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(409, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(183, 32);
            this.label7.TabIndex = 0;
            this.label7.Text = "Enroll Course";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(39, 181);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(165, 31);
            this.guna2HtmlLabel1.TabIndex = 21;
            this.guna2HtmlLabel1.Text = "Select Student:";
            this.guna2HtmlLabel1.Click += new System.EventHandler(this.guna2HtmlLabel1_Click);
            // 
          
            // 
            
            // 
            // ComboBox1_SelectStudent
            // 
         
            this.ComboBox1_SelectStudent.FormattingEnabled = true;
            this.ComboBox1_SelectStudent.Location = new System.Drawing.Point(220, 181);
            this.ComboBox1_SelectStudent.Name = "ComboBox1_SelectStudent";
            this.ComboBox1_SelectStudent.Size = new System.Drawing.Size(193, 24);
            this.ComboBox1_SelectStudent.TabIndex = 22;
            this.ComboBox1_SelectStudent.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(458, 181);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(161, 31);
            this.guna2HtmlLabel2.TabIndex = 23;
            this.guna2HtmlLabel2.Text = "Select Course:";
            // 
            // ComboBox2_SelectCourse
            // 
           
            this.ComboBox2_SelectCourse.FormattingEnabled = true;
            this.ComboBox2_SelectCourse.Location = new System.Drawing.Point(649, 188);
            this.ComboBox2_SelectCourse.Name = "ComboBox2_SelectCourse";
            this.ComboBox2_SelectCourse.Size = new System.Drawing.Size(219, 24);
            this.ComboBox2_SelectCourse.TabIndex = 24;
            this.ComboBox2_SelectCourse.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // EnrollCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1012, 613);
            this.Controls.Add(this.ComboBox2_SelectCourse);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.ComboBox1_SelectStudent);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.panel1);
            this.Name = "EnrollCourseForm";
            this.Text = "Enroll Course";
            this.Load += new System.EventHandler(this.EnrollCourseFom_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
         
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.BindingSource studentdbDataSetBindingSource;
        private System.Windows.Forms.ComboBox ComboBox1_SelectStudent;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private System.Windows.Forms.ComboBox ComboBox2_SelectCourse;
    }
}