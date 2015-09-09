﻿// MainForm.Designer.cs
namespace WindowsFormsApplication1
{
    public partial class MainForm
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
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label lastNameLabel;
            System.Windows.Forms.Label firstNameLabel;
            System.Windows.Forms.Label birthdayLabel;
            this.checkBoxAutomaticLogin = new System.Windows.Forms.CheckBox();
            this.UserPictureBox = new System.Windows.Forms.PictureBox();
            this.Friends_year_list = new System.Windows.Forms.ListBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.panelUserDataPanel = new System.Windows.Forms.Panel();
            this.ListFriendsPresentShowOptions = new System.Windows.Forms.ListBox();
            this.PanelChosenFriendExtendedDetails = new System.Windows.Forms.Panel();
            this.imageNormalPictureBox = new System.Windows.Forms.PictureBox();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameLabel1 = new System.Windows.Forms.Label();
            this.birthdayLabel1 = new System.Windows.Forms.Label();
            this.lastNameLabel1 = new System.Windows.Forms.Label();
            this.firstNameLabel1 = new System.Windows.Forms.Label();
            this.linkActivityData = new System.Windows.Forms.LinkLabel();
            this.labelUserEmail = new System.Windows.Forms.Label();
            this.labelUserFullName = new System.Windows.Forms.Label();
            this.panelPostActivityData = new System.Windows.Forms.Panel();
            this.labelLastVideoValue = new System.Windows.Forms.Label();
            this.labelLastVideo = new System.Windows.Forms.Label();
            this.labelLastPhotoValue = new System.Windows.Forms.Label();
            this.labelLastPhoto = new System.Windows.Forms.Label();
            this.labelLastStatusValue = new System.Windows.Forms.Label();
            this.labelLastStatus = new System.Windows.Forms.Label();
            this.listBoxFriemdsPerChosenYearOrMonth = new System.Windows.Forms.ListBox();
            this.progressBarPostsActivity = new System.Windows.Forms.ProgressBar();
            this.mainFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.buttonSetStatus = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panelPostStatus = new System.Windows.Forms.Panel();
            nameLabel = new System.Windows.Forms.Label();
            lastNameLabel = new System.Windows.Forms.Label();
            firstNameLabel = new System.Windows.Forms.Label();
            birthdayLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UserPictureBox)).BeginInit();
            this.panelUserDataPanel.SuspendLayout();
            this.PanelChosenFriendExtendedDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageNormalPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.panelPostActivityData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).BeginInit();
            this.panelPostStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(141, 169);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 8;
            nameLabel.Text = "Name:";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new System.Drawing.Point(141, 146);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new System.Drawing.Size(61, 13);
            lastNameLabel.TabIndex = 6;
            lastNameLabel.Text = "Last Name:";
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new System.Drawing.Point(141, 115);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new System.Drawing.Size(60, 13);
            firstNameLabel.TabIndex = 2;
            firstNameLabel.Text = "First Name:";
            // 
            // birthdayLabel
            // 
            birthdayLabel.AutoSize = true;
            birthdayLabel.Location = new System.Drawing.Point(141, 92);
            birthdayLabel.Name = "birthdayLabel";
            birthdayLabel.Size = new System.Drawing.Size(48, 13);
            birthdayLabel.TabIndex = 0;
            birthdayLabel.Text = "Birthday:";
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
            this.UserPictureBox.Size = new System.Drawing.Size(106, 95);
            this.UserPictureBox.TabIndex = 1;
            this.UserPictureBox.TabStop = false;
            // 
            // Friends_year_list
            // 
            this.Friends_year_list.FormattingEnabled = true;
            this.Friends_year_list.Location = new System.Drawing.Point(6, 223);
            this.Friends_year_list.Name = "Friends_year_list";
            this.Friends_year_list.Size = new System.Drawing.Size(71, 82);
            this.Friends_year_list.TabIndex = 2;
            this.Friends_year_list.SelectedIndexChanged += new System.EventHandler(this.Friends_year_list_SelectedIndexChanged);
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
            // panelUserDataPanel
            // 
            this.panelUserDataPanel.Controls.Add(this.ListFriendsPresentShowOptions);
            this.panelUserDataPanel.Controls.Add(this.progressBarPostsActivity);
            this.panelUserDataPanel.Controls.Add(this.PanelChosenFriendExtendedDetails);
            this.panelUserDataPanel.Controls.Add(this.linkActivityData);
            this.panelUserDataPanel.Controls.Add(this.labelUserEmail);
            this.panelUserDataPanel.Controls.Add(this.labelUserFullName);
            this.panelUserDataPanel.Controls.Add(this.panelPostActivityData);
            this.panelUserDataPanel.Controls.Add(this.UserPictureBox);
            this.panelUserDataPanel.Controls.Add(this.listBoxFriemdsPerChosenYearOrMonth);
            this.panelUserDataPanel.Controls.Add(this.Friends_year_list);
            this.panelUserDataPanel.Location = new System.Drawing.Point(12, 75);
            this.panelUserDataPanel.Name = "panelUserDataPanel";
            this.panelUserDataPanel.Size = new System.Drawing.Size(557, 441);
            this.panelUserDataPanel.TabIndex = 7;
            this.panelUserDataPanel.Visible = false;
            // 
            // ListFriendsPresentShowOptions
            // 
            this.ListFriendsPresentShowOptions.FormattingEnabled = true;
            this.ListFriendsPresentShowOptions.Location = new System.Drawing.Point(6, 146);
            this.ListFriendsPresentShowOptions.Name = "ListFriendsPresentShowOptions";
            this.ListFriendsPresentShowOptions.Size = new System.Drawing.Size(200, 56);
            this.ListFriendsPresentShowOptions.TabIndex = 15;
            this.ListFriendsPresentShowOptions.SelectedIndexChanged += new System.EventHandler(this.ListFriendsPresentShowOptions_SelectedIndexChanged);
            // 
            // PanelChosenFriendExtendedDetails
            // 
            this.PanelChosenFriendExtendedDetails.Controls.Add(birthdayLabel);
            this.PanelChosenFriendExtendedDetails.Controls.Add(this.imageNormalPictureBox);
            this.PanelChosenFriendExtendedDetails.Controls.Add(this.nameLabel1);
            this.PanelChosenFriendExtendedDetails.Controls.Add(this.birthdayLabel1);
            this.PanelChosenFriendExtendedDetails.Controls.Add(nameLabel);
            this.PanelChosenFriendExtendedDetails.Controls.Add(this.lastNameLabel1);
            this.PanelChosenFriendExtendedDetails.Controls.Add(firstNameLabel);
            this.PanelChosenFriendExtendedDetails.Controls.Add(lastNameLabel);
            this.PanelChosenFriendExtendedDetails.Controls.Add(this.firstNameLabel1);
            this.PanelChosenFriendExtendedDetails.Location = new System.Drawing.Point(222, 146);
            this.PanelChosenFriendExtendedDetails.Name = "PanelChosenFriendExtendedDetails";
            this.PanelChosenFriendExtendedDetails.Size = new System.Drawing.Size(332, 194);
            this.PanelChosenFriendExtendedDetails.TabIndex = 14;
            // 
            // imageNormalPictureBox
            // 
            this.imageNormalPictureBox.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.userBindingSource, "ImageNormal", true));
            this.imageNormalPictureBox.Location = new System.Drawing.Point(13, 3);
            this.imageNormalPictureBox.Name = "imageNormalPictureBox";
            this.imageNormalPictureBox.Size = new System.Drawing.Size(106, 102);
            this.imageNormalPictureBox.TabIndex = 5;
            this.imageNormalPictureBox.TabStop = false;
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.User);
            // 
            // nameLabel1
            // 
            this.nameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userBindingSource, "Name", true));
            this.nameLabel1.Location = new System.Drawing.Point(224, 159);
            this.nameLabel1.Name = "nameLabel1";
            this.nameLabel1.Size = new System.Drawing.Size(100, 23);
            this.nameLabel1.TabIndex = 9;
            // 
            // birthdayLabel1
            // 
            this.birthdayLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userBindingSource, "Birthday", true));
            this.birthdayLabel1.Location = new System.Drawing.Point(224, 82);
            this.birthdayLabel1.Name = "birthdayLabel1";
            this.birthdayLabel1.Size = new System.Drawing.Size(120, 23);
            this.birthdayLabel1.TabIndex = 1;
            // 
            // lastNameLabel1
            // 
            this.lastNameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userBindingSource, "LastName", true));
            this.lastNameLabel1.Location = new System.Drawing.Point(224, 136);
            this.lastNameLabel1.Name = "lastNameLabel1";
            this.lastNameLabel1.Size = new System.Drawing.Size(100, 23);
            this.lastNameLabel1.TabIndex = 7;
            // 
            // firstNameLabel1
            // 
            this.firstNameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userBindingSource, "FirstName", true));
            this.firstNameLabel1.Location = new System.Drawing.Point(224, 105);
            this.firstNameLabel1.Name = "firstNameLabel1";
            this.firstNameLabel1.Size = new System.Drawing.Size(100, 23);
            this.firstNameLabel1.TabIndex = 3;
            // 
            // linkActivityData
            // 
            this.linkActivityData.AutoSize = true;
            this.linkActivityData.Location = new System.Drawing.Point(128, 19);
            this.linkActivityData.Name = "linkActivityData";
            this.linkActivityData.Size = new System.Drawing.Size(96, 13);
            this.linkActivityData.TabIndex = 13;
            this.linkActivityData.TabStop = true;
            this.linkActivityData.Text = "View Posts Activity";
            this.linkActivityData.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkActivityData_LinkClicked);
            // 
            // labelUserEmail
            // 
            this.labelUserEmail.AutoSize = true;
            this.labelUserEmail.Location = new System.Drawing.Point(3, 114);
            this.labelUserEmail.Name = "labelUserEmail";
            this.labelUserEmail.Size = new System.Drawing.Size(37, 13);
            this.labelUserEmail.TabIndex = 11;
            this.labelUserEmail.Text = "(email)";
            // 
            // labelUserFullName
            // 
            this.labelUserFullName.AutoSize = true;
            this.labelUserFullName.Location = new System.Drawing.Point(3, 101);
            this.labelUserFullName.Name = "labelUserFullName";
            this.labelUserFullName.Size = new System.Drawing.Size(55, 13);
            this.labelUserFullName.TabIndex = 10;
            this.labelUserFullName.Text = "(full name)";
            // 
            // panelPostActivityData
            // 
            this.panelPostActivityData.Controls.Add(this.labelLastVideoValue);
            this.panelPostActivityData.Controls.Add(this.labelLastVideo);
            this.panelPostActivityData.Controls.Add(this.labelLastPhotoValue);
            this.panelPostActivityData.Controls.Add(this.labelLastPhoto);
            this.panelPostActivityData.Controls.Add(this.labelLastStatusValue);
            this.panelPostActivityData.Controls.Add(this.labelLastStatus);
            this.panelPostActivityData.Location = new System.Drawing.Point(240, 19);
            this.panelPostActivityData.Name = "panelPostActivityData";
            this.panelPostActivityData.Size = new System.Drawing.Size(199, 60);
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
            // listBoxFriemdsPerChosenYearOrMonth
            // 
            this.listBoxFriemdsPerChosenYearOrMonth.DataSource = this.userBindingSource;
            this.listBoxFriemdsPerChosenYearOrMonth.DisplayMember = "Name";
            this.listBoxFriemdsPerChosenYearOrMonth.FormattingEnabled = true;
            this.listBoxFriemdsPerChosenYearOrMonth.Location = new System.Drawing.Point(83, 223);
            this.listBoxFriemdsPerChosenYearOrMonth.Name = "listBoxFriemdsPerChosenYearOrMonth";
            this.listBoxFriemdsPerChosenYearOrMonth.Size = new System.Drawing.Size(123, 147);
            this.listBoxFriemdsPerChosenYearOrMonth.TabIndex = 6;
            // 
            // progressBarPostsActivity
            // 
            this.progressBarPostsActivity.Location = new System.Drawing.Point(239, 85);
            this.progressBarPostsActivity.MarqueeAnimationSpeed = 50;
            this.progressBarPostsActivity.Name = "progressBarPostsActivity";
            this.progressBarPostsActivity.Size = new System.Drawing.Size(202, 29);
            this.progressBarPostsActivity.Step = 5;
            this.progressBarPostsActivity.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarPostsActivity.TabIndex = 8;
            this.progressBarPostsActivity.Visible = false;
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStatus.Location = new System.Drawing.Point(67, 3);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(287, 20);
            this.textBoxStatus.TabIndex = 46;
            // 
            // buttonSetStatus
            // 
            this.buttonSetStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetStatus.Location = new System.Drawing.Point(360, 1);
            this.buttonSetStatus.Name = "buttonSetStatus";
            this.buttonSetStatus.Size = new System.Drawing.Size(65, 23);
            this.buttonSetStatus.TabIndex = 47;
            this.buttonSetStatus.Text = "Post";
            this.buttonSetStatus.UseVisualStyleBackColor = true;
            this.buttonSetStatus.Click += new System.EventHandler(this.buttonSetStatus_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Post Status:";
            // 
            // panelPostStatus
            // 
            this.panelPostStatus.Controls.Add(this.label3);
            this.panelPostStatus.Controls.Add(this.buttonSetStatus);
            this.panelPostStatus.Controls.Add(this.textBoxStatus);
            this.panelPostStatus.Location = new System.Drawing.Point(131, 24);
            this.panelPostStatus.Name = "panelPostStatus";
            this.panelPostStatus.Size = new System.Drawing.Size(428, 26);
            this.panelPostStatus.TabIndex = 49;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(574, 451);
            this.Controls.Add(this.panelPostStatus);
            this.Controls.Add(this.checkBoxAutomaticLogin);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.panelUserDataPanel);
            this.Name = "MainForm";
            this.Text = "Design Patterns Facebook app";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.LocationChanged += new System.EventHandler(this.mainForm_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.mainForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.UserPictureBox)).EndInit();
            this.panelUserDataPanel.ResumeLayout(false);
            this.panelUserDataPanel.PerformLayout();
            this.PanelChosenFriendExtendedDetails.ResumeLayout(false);
            this.PanelChosenFriendExtendedDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageNormalPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.panelPostActivityData.ResumeLayout(false);
            this.panelPostActivityData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).EndInit();
            this.panelPostStatus.ResumeLayout(false);
            this.panelPostStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxAutomaticLogin;
        private System.Windows.Forms.PictureBox UserPictureBox;
        private System.Windows.Forms.ListBox Friends_year_list;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.ListBox listBoxFriemdsPerChosenYearOrMonth;
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
        private System.Windows.Forms.Label labelUserEmail;
        private System.Windows.Forms.Label labelUserFullName;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Button buttonSetStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelPostStatus;
        private System.Windows.Forms.LinkLabel linkActivityData;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.Panel PanelChosenFriendExtendedDetails;
        private System.Windows.Forms.PictureBox imageNormalPictureBox;
        private System.Windows.Forms.Label nameLabel1;
        private System.Windows.Forms.Label birthdayLabel1;
        private System.Windows.Forms.Label lastNameLabel1;
        private System.Windows.Forms.Label firstNameLabel1;
        private System.Windows.Forms.ListBox ListFriendsPresentShowOptions;
    }
}