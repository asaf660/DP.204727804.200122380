namespace WindowsFormsApplication1
{
    public partial class Design_Patterns_App
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.UserPictureBox = new System.Windows.Forms.PictureBox();
            this.Friends_year_list = new System.Windows.Forms.ListBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.NamesPerChosenYear = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.UserPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(117, 28);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // UserPictureBox
            // 
            this.UserPictureBox.Location = new System.Drawing.Point(29, 51);
            this.UserPictureBox.Name = "UserPictureBox";
            this.UserPictureBox.Size = new System.Drawing.Size(133, 110);
            this.UserPictureBox.TabIndex = 1;
            this.UserPictureBox.TabStop = false;
            // 
            // Friends_year_list
            // 
            this.Friends_year_list.FormattingEnabled = true;
            this.Friends_year_list.Location = new System.Drawing.Point(298, 56);
            this.Friends_year_list.Name = "Friends_year_list";
            this.Friends_year_list.Size = new System.Drawing.Size(173, 147);
            this.Friends_year_list.TabIndex = 2;
            this.Friends_year_list.SelectedIndexChanged += new System.EventHandler(this.Friends_year_list_SelectedIndexChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(295, 40);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(124, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Get friends Born per year";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(29, 11);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(82, 34);
            this.buttonLogin.TabIndex = 5;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click_1);
            // 
            // NamesPerChosenYear
            // 
            this.NamesPerChosenYear.FormattingEnabled = true;
            this.NamesPerChosenYear.Location = new System.Drawing.Point(194, 136);
            this.NamesPerChosenYear.Name = "NamesPerChosenYear";
            this.NamesPerChosenYear.Size = new System.Drawing.Size(93, 56);
            this.NamesPerChosenYear.TabIndex = 6;
            this.NamesPerChosenYear.SelectedIndexChanged += new System.EventHandler(this.NamesPerChosenYear_SelectedIndexChanged);
            // 
            // Design_Patterns_App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 320);
            this.Controls.Add(this.NamesPerChosenYear);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.Friends_year_list);
            this.Controls.Add(this.UserPictureBox);
            this.Controls.Add(this.checkBox1);
            this.Name = "Design_Patterns_App";
            this.Text = "Design Patterns Facebook app";
            ((System.ComponentModel.ISupportInitialize)(this.UserPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox UserPictureBox;
        private System.Windows.Forms.ListBox Friends_year_list;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.ListBox NamesPerChosenYear;
    }
}