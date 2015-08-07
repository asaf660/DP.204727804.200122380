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
            this.panelPostActivityData = new System.Windows.Forms.Panel();
            this.labelLastVideoValue = new System.Windows.Forms.Label();
            this.labelLastVideo = new System.Windows.Forms.Label();
            this.labelLastPhotoValue = new System.Windows.Forms.Label();
            this.labelLastPhoto = new System.Windows.Forms.Label();
            this.labelLastStatusValue = new System.Windows.Forms.Label();
            this.labelLastStatus = new System.Windows.Forms.Label();
            this.progressBarPostsActivity = new System.Windows.Forms.ProgressBar();
            this.mainFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.UserPictureBox)).BeginInit();
            this.panelUserDataPanel.SuspendLayout();
            this.panelPostActivityData.SuspendLayout();
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
            this.buttonActivityData.Click += new System.EventHandler(this.buttonActivityData_Click);
            // 
            // panelUserDataPanel
            // 
            this.panelUserDataPanel.Controls.Add(this.progressBarPostsActivity);
            this.panelUserDataPanel.Controls.Add(this.panelPostActivityData);
            this.panelUserDataPanel.Controls.Add(this.UserPictureBox);
            this.panelUserDataPanel.Controls.Add(this.buttonActivityData);
            this.panelUserDataPanel.Location = new System.Drawing.Point(12, 91);
            this.panelUserDataPanel.Name = "panelUserDataPanel";
            this.panelUserDataPanel.Size = new System.Drawing.Size(492, 217);
            this.panelUserDataPanel.TabIndex = 7;
            this.panelUserDataPanel.Visible = false;
            // 
            // panelPostActivityData
            // 
            this.panelPostActivityData.Controls.Add(this.labelLastVideoValue);
            this.panelPostActivityData.Controls.Add(this.labelLastVideo);
            this.panelPostActivityData.Controls.Add(this.labelLastPhotoValue);
            this.panelPostActivityData.Controls.Add(this.labelLastPhoto);
            this.panelPostActivityData.Controls.Add(this.labelLastStatusValue);
            this.panelPostActivityData.Controls.Add(this.labelLastStatus);
            this.panelPostActivityData.Location = new System.Drawing.Point(119, 39);
            this.panelPostActivityData.Name = "panelPostActivityData";
            this.panelPostActivityData.Size = new System.Drawing.Size(199, 100);
            this.panelPostActivityData.TabIndex = 7;
            this.panelPostActivityData.Visible = false;
            // 
            // labelLastVideoValue
            // 
            this.labelLastVideoValue.AutoSize = true;
            this.labelLastVideoValue.Location = new System.Drawing.Point(108, 41);
            this.labelLastVideoValue.Name = "labelLastVideoValue";
            this.labelLastVideoValue.Size = new System.Drawing.Size(58, 13);
            this.labelLastVideoValue.TabIndex = 5;
            this.labelLastVideoValue.Text = "(last-video)";
            // 
            // labelLastVideo
            // 
            this.labelLastVideo.AutoSize = true;
            this.labelLastVideo.Location = new System.Drawing.Point(4, 41);
            this.labelLastVideo.Name = "labelLastVideo";
            this.labelLastVideo.Size = new System.Drawing.Size(60, 13);
            this.labelLastVideo.TabIndex = 4;
            this.labelLastVideo.Text = "Last Video:";
            // 
            // labelLastPhotoValue
            // 
            this.labelLastPhotoValue.AutoSize = true;
            this.labelLastPhotoValue.Location = new System.Drawing.Point(108, 24);
            this.labelLastPhotoValue.Name = "labelLastPhotoValue";
            this.labelLastPhotoValue.Size = new System.Drawing.Size(59, 13);
            this.labelLastPhotoValue.TabIndex = 3;
            this.labelLastPhotoValue.Text = "(last-photo)";
            // 
            // labelLastPhoto
            // 
            this.labelLastPhoto.AutoSize = true;
            this.labelLastPhoto.Location = new System.Drawing.Point(4, 24);
            this.labelLastPhoto.Name = "labelLastPhoto";
            this.labelLastPhoto.Size = new System.Drawing.Size(98, 13);
            this.labelLastPhoto.TabIndex = 2;
            this.labelLastPhoto.Text = "Last Photo Upload:";
            // 
            // labelLastStatusValue
            // 
            this.labelLastStatusValue.AutoSize = true;
            this.labelLastStatusValue.Location = new System.Drawing.Point(108, 6);
            this.labelLastStatusValue.Name = "labelLastStatusValue";
            this.labelLastStatusValue.Size = new System.Drawing.Size(60, 13);
            this.labelLastStatusValue.TabIndex = 1;
            this.labelLastStatusValue.Text = "(last-status)";
            // 
            // labelLastStatus
            // 
            this.labelLastStatus.AutoSize = true;
            this.labelLastStatus.Location = new System.Drawing.Point(4, 6);
            this.labelLastStatus.Name = "labelLastStatus";
            this.labelLastStatus.Size = new System.Drawing.Size(63, 13);
            this.labelLastStatus.TabIndex = 0;
            this.labelLastStatus.Text = "Last Status:";
            // 
            // progressBarPostsActivity
            // 
            this.progressBarPostsActivity.Location = new System.Drawing.Point(248, 3);
            this.progressBarPostsActivity.MarqueeAnimationSpeed = 50;
            this.progressBarPostsActivity.Name = "progressBarPostsActivity";
            this.progressBarPostsActivity.Size = new System.Drawing.Size(111, 29);
            this.progressBarPostsActivity.Step = 5;
            this.progressBarPostsActivity.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarPostsActivity.TabIndex = 8;
            this.progressBarPostsActivity.Visible = false;
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
            this.panelPostActivityData.ResumeLayout(false);
            this.panelPostActivityData.PerformLayout();
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
        private System.Windows.Forms.Panel panelPostActivityData;
        private System.Windows.Forms.Label labelLastVideoValue;
        private System.Windows.Forms.Label labelLastVideo;
        private System.Windows.Forms.Label labelLastPhotoValue;
        private System.Windows.Forms.Label labelLastPhoto;
        private System.Windows.Forms.Label labelLastStatusValue;
        private System.Windows.Forms.Label labelLastStatus;
        private System.Windows.Forms.ProgressBar progressBarPostsActivity;
    }
}

