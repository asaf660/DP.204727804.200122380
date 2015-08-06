namespace WindowsFormsApplication1
{
    partial class mainForm
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
            this.checkBoxAutomaticLogin = new System.Windows.Forms.CheckBox();
            this.UserPictureBox = new System.Windows.Forms.PictureBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonActivityData = new System.Windows.Forms.Button();
            this.panelUserDataPanel = new System.Windows.Forms.Panel();
            this.mainFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.UserPictureBox)).BeginInit();
            this.panelUserDataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxAutomaticLogin
            // 
            this.checkBoxAutomaticLogin.AutoSize = true;
            this.checkBoxAutomaticLogin.Location = new System.Drawing.Point(12, 52);
            this.checkBoxAutomaticLogin.Name = "checkBoxAutomaticLogin";
            this.checkBoxAutomaticLogin.Size = new System.Drawing.Size(98, 17);
            this.checkBoxAutomaticLogin.TabIndex = 0;
            this.checkBoxAutomaticLogin.Text = "Automatic login";
            this.checkBoxAutomaticLogin.UseVisualStyleBackColor = true;
            this.checkBoxAutomaticLogin.CheckedChanged += new System.EventHandler(this.checkBoxAutomaticLogin_CheckedChanged);
            // 
            // UserPictureBox
            // 
            this.UserPictureBox.Location = new System.Drawing.Point(3, 3);
            this.UserPictureBox.Name = "UserPictureBox";
            this.UserPictureBox.Size = new System.Drawing.Size(109, 94);
            this.UserPictureBox.TabIndex = 1;
            this.UserPictureBox.TabStop = false;
            this.UserPictureBox.Tag = "";
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(12, 12);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(82, 34);
            this.buttonLogin.TabIndex = 5;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonActivityData
            // 
            this.buttonActivityData.Location = new System.Drawing.Point(118, 3);
            this.buttonActivityData.Name = "buttonActivityData";
            this.buttonActivityData.Size = new System.Drawing.Size(124, 29);
            this.buttonActivityData.TabIndex = 6;
            this.buttonActivityData.Text = "View Posts Activity";
            this.buttonActivityData.UseVisualStyleBackColor = true;
            // 
            // panelUserDataPanel
            // 
            this.panelUserDataPanel.Controls.Add(this.UserPictureBox);
            this.panelUserDataPanel.Controls.Add(this.buttonActivityData);
            this.panelUserDataPanel.Location = new System.Drawing.Point(12, 91);
            this.panelUserDataPanel.Name = "panelUserDataPanel";
            this.panelUserDataPanel.Size = new System.Drawing.Size(492, 217);
            this.panelUserDataPanel.TabIndex = 7;
            this.panelUserDataPanel.Visible = false;
            // 
            // mainFormBindingSource
            // 
            this.mainFormBindingSource.DataSource = typeof(WindowsFormsApplication1.mainForm);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 320);
            this.Controls.Add(this.checkBoxAutomaticLogin);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.panelUserDataPanel);
            this.Name = "mainForm";
            this.Text = "Facebook App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.LocationChanged += new System.EventHandler(this.mainForm_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.mainForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.UserPictureBox)).EndInit();
            this.panelUserDataPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxAutomaticLogin;
        private System.Windows.Forms.PictureBox UserPictureBox;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonActivityData;
        private System.Windows.Forms.Panel panelUserDataPanel;
        private System.Windows.Forms.BindingSource mainFormBindingSource;
    }
}

