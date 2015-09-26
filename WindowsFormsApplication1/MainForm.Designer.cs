// MainForm.Designer.cs
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
            System.Windows.Forms.Label createdTimeLabel;
            System.Windows.Forms.Label linkLabel;
            System.Windows.Forms.Label messageLabel;
            System.Windows.Forms.Label pictureURLLabel;
            this.checkBoxAutomaticLogin = new System.Windows.Forms.CheckBox();
            this.UserPictureBox = new System.Windows.Forms.PictureBox();
            this.ListYearOrMonthNumOfFriends = new System.Windows.Forms.ListBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.panelUserDataPanel = new System.Windows.Forms.Panel();
            this.groupBoxLikes = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.imageSquarePictureBox = new System.Windows.Forms.PictureBox();
            this.likersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameLabel3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.linkByGenderFemale = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.linkByGenderMale = new System.Windows.Forms.LinkLabel();
            this.labelSlash = new System.Windows.Forms.Label();
            this.linkAllGenders = new System.Windows.Forms.LinkLabel();
            this.listLikers = new System.Windows.Forms.ListBox();
            this.groupBoxStatusInfo = new System.Windows.Forms.GroupBox();
            this.panelChosenPost = new System.Windows.Forms.Panel();
            this.pictureURLLinkLabel = new System.Windows.Forms.LinkLabel();
            this.statusesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.createdTimeLabel1 = new System.Windows.Forms.Label();
            this.messageLabel1 = new System.Windows.Forms.Label();
            this.linkLinkLabel = new System.Windows.Forms.LinkLabel();
            this.listStatuses = new System.Windows.Forms.ListBox();
            this.linkFetchStatuses = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.RadioButtonMonthMaleOnly = new System.Windows.Forms.RadioButton();
            this.RadioButtonMonthFemaleOnly = new System.Windows.Forms.RadioButton();
            this.radioRadioButtonYearAllGender = new System.Windows.Forms.RadioButton();
            this.progressBarPostsActivity = new System.Windows.Forms.ProgressBar();
            this.panelChosenFriendExtendedDetails = new System.Windows.Forms.Panel();
            this.imageNormalPictureBox = new System.Windows.Forms.PictureBox();
            this.friendsBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.buttonSetStatus = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panelPostStatus = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imageSquarePictureBox1 = new System.Windows.Forms.PictureBox();
            this.nameLabel4 = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            lastNameLabel = new System.Windows.Forms.Label();
            firstNameLabel = new System.Windows.Forms.Label();
            birthdayLabel = new System.Windows.Forms.Label();
            createdTimeLabel = new System.Windows.Forms.Label();
            linkLabel = new System.Windows.Forms.Label();
            messageLabel = new System.Windows.Forms.Label();
            pictureURLLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UserPictureBox)).BeginInit();
            this.panelUserDataPanel.SuspendLayout();
            this.groupBoxLikes.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageSquarePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.likersBindingSource)).BeginInit();
            this.groupBoxStatusInfo.SuspendLayout();
            this.panelChosenPost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusesBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelChosenFriendExtendedDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageNormalPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendsBindingSource)).BeginInit();
            this.panelPostActivityData.SuspendLayout();
            this.panelPostStatus.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageSquarePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(91, 81);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 8;
            nameLabel.Text = "Name:";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new System.Drawing.Point(91, 51);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new System.Drawing.Size(61, 13);
            lastNameLabel.TabIndex = 6;
            lastNameLabel.Text = "Last Name:";
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new System.Drawing.Point(91, 26);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new System.Drawing.Size(60, 13);
            firstNameLabel.TabIndex = 2;
            firstNameLabel.Text = "First Name:";
            // 
            // birthdayLabel
            // 
            birthdayLabel.AutoSize = true;
            birthdayLabel.Location = new System.Drawing.Point(91, 2);
            birthdayLabel.Name = "birthdayLabel";
            birthdayLabel.Size = new System.Drawing.Size(48, 13);
            birthdayLabel.TabIndex = 0;
            birthdayLabel.Text = "Birthday:";
            // 
            // createdTimeLabel
            // 
            createdTimeLabel.AutoSize = true;
            createdTimeLabel.Location = new System.Drawing.Point(3, 11);
            createdTimeLabel.Name = "createdTimeLabel";
            createdTimeLabel.Size = new System.Drawing.Size(73, 13);
            createdTimeLabel.TabIndex = 20;
            createdTimeLabel.Text = "Created Time:";
            // 
            // linkLabel
            // 
            linkLabel.AutoSize = true;
            linkLabel.Location = new System.Drawing.Point(3, 34);
            linkLabel.Name = "linkLabel";
            linkLabel.Size = new System.Drawing.Size(30, 13);
            linkLabel.TabIndex = 26;
            linkLabel.Text = "Link:";
            // 
            // messageLabel
            // 
            messageLabel.AutoSize = true;
            messageLabel.Location = new System.Drawing.Point(3, 80);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new System.Drawing.Size(53, 13);
            messageLabel.TabIndex = 28;
            messageLabel.Text = "Message:";
            // 
            // pictureURLLabel
            // 
            pictureURLLabel.AutoSize = true;
            pictureURLLabel.Location = new System.Drawing.Point(3, 57);
            pictureURLLabel.Name = "pictureURLLabel";
            pictureURLLabel.Size = new System.Drawing.Size(68, 13);
            pictureURLLabel.TabIndex = 32;
            pictureURLLabel.Text = "Picture URL:";
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
            this.UserPictureBox.Location = new System.Drawing.Point(6, 5);
            this.UserPictureBox.Name = "UserPictureBox";
            this.UserPictureBox.Size = new System.Drawing.Size(106, 95);
            this.UserPictureBox.TabIndex = 1;
            this.UserPictureBox.TabStop = false;
            // 
            // ListYearOrMonthNumOfFriends
            // 
            this.ListYearOrMonthNumOfFriends.FormattingEnabled = true;
            this.ListYearOrMonthNumOfFriends.Location = new System.Drawing.Point(360, 6);
            this.ListYearOrMonthNumOfFriends.Name = "ListYearOrMonthNumOfFriends";
            this.ListYearOrMonthNumOfFriends.Size = new System.Drawing.Size(75, 121);
            this.ListYearOrMonthNumOfFriends.TabIndex = 2;
            this.ListYearOrMonthNumOfFriends.SelectedIndexChanged += new System.EventHandler(this.Friends_year_list_SelectedIndexChanged);
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
            this.panelUserDataPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.panelUserDataPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUserDataPanel.Controls.Add(this.panel3);
            this.panelUserDataPanel.Controls.Add(this.groupBoxLikes);
            this.panelUserDataPanel.Controls.Add(this.groupBoxStatusInfo);
            this.panelUserDataPanel.Controls.Add(this.listStatuses);
            this.panelUserDataPanel.Controls.Add(this.linkFetchStatuses);
            this.panelUserDataPanel.Controls.Add(this.panel1);
            this.panelUserDataPanel.Controls.Add(this.progressBarPostsActivity);
            this.panelUserDataPanel.Controls.Add(this.panelChosenFriendExtendedDetails);
            this.panelUserDataPanel.Controls.Add(this.linkActivityData);
            this.panelUserDataPanel.Controls.Add(this.labelUserEmail);
            this.panelUserDataPanel.Controls.Add(this.labelUserFullName);
            this.panelUserDataPanel.Controls.Add(this.panelPostActivityData);
            this.panelUserDataPanel.Controls.Add(this.UserPictureBox);
            this.panelUserDataPanel.Controls.Add(this.listBoxFriemdsPerChosenYearOrMonth);
            this.panelUserDataPanel.Controls.Add(this.ListYearOrMonthNumOfFriends);
            this.panelUserDataPanel.Location = new System.Drawing.Point(12, 75);
            this.panelUserDataPanel.Name = "panelUserDataPanel";
            this.panelUserDataPanel.Size = new System.Drawing.Size(871, 560);
            this.panelUserDataPanel.TabIndex = 7;
            this.panelUserDataPanel.Visible = false;
            // 
            // groupBoxLikes
            // 
            this.groupBoxLikes.Controls.Add(this.textBox1);
            this.groupBoxLikes.Controls.Add(this.label5);
            this.groupBoxLikes.Controls.Add(this.panel2);
            this.groupBoxLikes.Controls.Add(this.label4);
            this.groupBoxLikes.Controls.Add(this.linkByGenderFemale);
            this.groupBoxLikes.Controls.Add(this.label2);
            this.groupBoxLikes.Controls.Add(this.linkByGenderMale);
            this.groupBoxLikes.Controls.Add(this.labelSlash);
            this.groupBoxLikes.Controls.Add(this.linkAllGenders);
            this.groupBoxLikes.Controls.Add(this.listLikers);
            this.groupBoxLikes.Location = new System.Drawing.Point(370, 315);
            this.groupBoxLikes.Name = "groupBoxLikes";
            this.groupBoxLikes.Size = new System.Drawing.Size(200, 205);
            this.groupBoxLikes.TabIndex = 39;
            this.groupBoxLikes.TabStop = false;
            this.groupBoxLikes.Text = "Likes";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(57, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(113, 20);
            this.textBox1.TabIndex = 44;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Name:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.imageSquarePictureBox);
            this.panel2.Controls.Add(this.nameLabel3);
            this.panel2.Location = new System.Drawing.Point(204, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(195, 147);
            this.panel2.TabIndex = 36;
            // 
            // imageSquarePictureBox
            // 
            this.imageSquarePictureBox.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.likersBindingSource, "ImageSquare", true));
            this.imageSquarePictureBox.Location = new System.Drawing.Point(3, 21);
            this.imageSquarePictureBox.Name = "imageSquarePictureBox";
            this.imageSquarePictureBox.Size = new System.Drawing.Size(64, 56);
            this.imageSquarePictureBox.TabIndex = 7;
            this.imageSquarePictureBox.TabStop = false;
            // 
            // likersBindingSource
            // 
            this.likersBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.User);
            // 
            // nameLabel3
            // 
            this.nameLabel3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.likersBindingSource, "Name", true));
            this.nameLabel3.Location = new System.Drawing.Point(73, 64);
            this.nameLabel3.Name = "nameLabel3";
            this.nameLabel3.Size = new System.Drawing.Size(100, 23);
            this.nameLabel3.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "Gender:";
            // 
            // linkByGenderFemale
            // 
            this.linkByGenderFemale.AutoSize = true;
            this.linkByGenderFemale.Location = new System.Drawing.Point(119, 19);
            this.linkByGenderFemale.Name = "linkByGenderFemale";
            this.linkByGenderFemale.Size = new System.Drawing.Size(41, 13);
            this.linkByGenderFemale.TabIndex = 40;
            this.linkByGenderFemale.TabStop = true;
            this.linkByGenderFemale.Text = "Female";
            this.linkByGenderFemale.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkByGenderFemale_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "/";
            // 
            // linkByGenderMale
            // 
            this.linkByGenderMale.AutoSize = true;
            this.linkByGenderMale.Location = new System.Drawing.Point(80, 19);
            this.linkByGenderMale.Name = "linkByGenderMale";
            this.linkByGenderMale.Size = new System.Drawing.Size(30, 13);
            this.linkByGenderMale.TabIndex = 38;
            this.linkByGenderMale.TabStop = true;
            this.linkByGenderMale.Text = "Male";
            this.linkByGenderMale.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkByGenderMale_LinkClicked);
            // 
            // labelSlash
            // 
            this.labelSlash.AutoSize = true;
            this.labelSlash.Location = new System.Drawing.Point(71, 19);
            this.labelSlash.Name = "labelSlash";
            this.labelSlash.Size = new System.Drawing.Size(12, 13);
            this.labelSlash.TabIndex = 37;
            this.labelSlash.Text = "/";
            // 
            // linkAllGenders
            // 
            this.linkAllGenders.AutoSize = true;
            this.linkAllGenders.Location = new System.Drawing.Point(54, 19);
            this.linkAllGenders.Name = "linkAllGenders";
            this.linkAllGenders.Size = new System.Drawing.Size(18, 13);
            this.linkAllGenders.TabIndex = 36;
            this.linkAllGenders.TabStop = true;
            this.linkAllGenders.Text = "All";
            this.linkAllGenders.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAllGenders_LinkClicked);
            // 
            // listLikers
            // 
            this.listLikers.DataSource = this.likersBindingSource;
            this.listLikers.FormattingEnabled = true;
            this.listLikers.Location = new System.Drawing.Point(6, 65);
            this.listLikers.Name = "listLikers";
            this.listLikers.Size = new System.Drawing.Size(164, 134);
            this.listLikers.TabIndex = 35;
            // 
            // groupBoxStatusInfo
            // 
            this.groupBoxStatusInfo.Controls.Add(this.panelChosenPost);
            this.groupBoxStatusInfo.Location = new System.Drawing.Point(10, 315);
            this.groupBoxStatusInfo.Name = "groupBoxStatusInfo";
            this.groupBoxStatusInfo.Size = new System.Drawing.Size(354, 205);
            this.groupBoxStatusInfo.TabIndex = 38;
            this.groupBoxStatusInfo.TabStop = false;
            this.groupBoxStatusInfo.Text = "Status Info";
            // 
            // panelChosenPost
            // 
            this.panelChosenPost.Controls.Add(this.pictureURLLinkLabel);
            this.panelChosenPost.Controls.Add(pictureURLLabel);
            this.panelChosenPost.Controls.Add(createdTimeLabel);
            this.panelChosenPost.Controls.Add(this.createdTimeLabel1);
            this.panelChosenPost.Controls.Add(this.messageLabel1);
            this.panelChosenPost.Controls.Add(messageLabel);
            this.panelChosenPost.Controls.Add(this.linkLinkLabel);
            this.panelChosenPost.Controls.Add(linkLabel);
            this.panelChosenPost.Location = new System.Drawing.Point(6, 19);
            this.panelChosenPost.Name = "panelChosenPost";
            this.panelChosenPost.Size = new System.Drawing.Size(340, 176);
            this.panelChosenPost.TabIndex = 34;
            // 
            // pictureURLLinkLabel
            // 
            this.pictureURLLinkLabel.AutoEllipsis = true;
            this.pictureURLLinkLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.statusesBindingSource, "Post.PictureURL", true));
            this.pictureURLLinkLabel.Location = new System.Drawing.Point(82, 57);
            this.pictureURLLinkLabel.Name = "pictureURLLinkLabel";
            this.pictureURLLinkLabel.Size = new System.Drawing.Size(255, 23);
            this.pictureURLLinkLabel.TabIndex = 33;
            // 
            // statusesBindingSource
            // 
            this.statusesBindingSource.DataSource = typeof(WindowsFormsApplication1.PostProxy);
            // 
            // createdTimeLabel1
            // 
            this.createdTimeLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.statusesBindingSource, "Post.CreatedTime", true));
            this.createdTimeLabel1.Location = new System.Drawing.Point(82, 11);
            this.createdTimeLabel1.Name = "createdTimeLabel1";
            this.createdTimeLabel1.Size = new System.Drawing.Size(100, 23);
            this.createdTimeLabel1.TabIndex = 21;
            // 
            // messageLabel1
            // 
            this.messageLabel1.AutoEllipsis = true;
            this.messageLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.statusesBindingSource, "Post.Message", true));
            this.messageLabel1.Location = new System.Drawing.Point(82, 80);
            this.messageLabel1.Name = "messageLabel1";
            this.messageLabel1.Size = new System.Drawing.Size(180, 85);
            this.messageLabel1.TabIndex = 29;
            // 
            // linkLinkLabel
            // 
            this.linkLinkLabel.AutoEllipsis = true;
            this.linkLinkLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.statusesBindingSource, "Post.Link", true));
            this.linkLinkLabel.Location = new System.Drawing.Point(82, 34);
            this.linkLinkLabel.Name = "linkLinkLabel";
            this.linkLinkLabel.Size = new System.Drawing.Size(255, 23);
            this.linkLinkLabel.TabIndex = 27;
            // 
            // listStatuses
            // 
            this.listStatuses.DataSource = this.statusesBindingSource;
            this.listStatuses.FormattingEnabled = true;
            this.listStatuses.Location = new System.Drawing.Point(10, 172);
            this.listStatuses.Name = "listStatuses";
            this.listStatuses.Size = new System.Drawing.Size(560, 134);
            this.listStatuses.TabIndex = 18;
            this.listStatuses.SelectedIndexChanged += new System.EventHandler(this.listStatuses_SelectedIndexChanged);
            // 
            // linkFetchStatuses
            // 
            this.linkFetchStatuses.AutoSize = true;
            this.linkFetchStatuses.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.linkFetchStatuses.Location = new System.Drawing.Point(7, 156);
            this.linkFetchStatuses.Name = "linkFetchStatuses";
            this.linkFetchStatuses.Size = new System.Drawing.Size(92, 13);
            this.linkFetchStatuses.TabIndex = 17;
            this.linkFetchStatuses.TabStop = true;
            this.linkFetchStatuses.Text = "Fetch Statuses";
            this.linkFetchStatuses.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFetchStatuses_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.RadioButtonMonthMaleOnly);
            this.panel1.Controls.Add(this.RadioButtonMonthFemaleOnly);
            this.panel1.Controls.Add(this.radioRadioButtonYearAllGender);
            this.panel1.Location = new System.Drawing.Point(137, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(213, 121);
            this.panel1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "Choose which list to construct!";
            // 
            // RadioButtonMonthMaleOnly
            // 
            this.RadioButtonMonthMaleOnly.AutoSize = true;
            this.RadioButtonMonthMaleOnly.Location = new System.Drawing.Point(7, 66);
            this.RadioButtonMonthMaleOnly.Name = "RadioButtonMonthMaleOnly";
            this.RadioButtonMonthMaleOnly.Size = new System.Drawing.Size(193, 17);
            this.RadioButtonMonthMaleOnly.TabIndex = 2;
            this.RadioButtonMonthMaleOnly.TabStop = true;
            this.RadioButtonMonthMaleOnly.Text = "Friend birthdays by month Male only";
            this.RadioButtonMonthMaleOnly.UseVisualStyleBackColor = true;
            this.RadioButtonMonthMaleOnly.CheckedChanged += new System.EventHandler(this.RadioButtonMonthMaleOnly_CheckedChanged);
            // 
            // RadioButtonMonthFemaleOnly
            // 
            this.RadioButtonMonthFemaleOnly.AutoSize = true;
            this.RadioButtonMonthFemaleOnly.Location = new System.Drawing.Point(7, 46);
            this.RadioButtonMonthFemaleOnly.Name = "RadioButtonMonthFemaleOnly";
            this.RadioButtonMonthFemaleOnly.Size = new System.Drawing.Size(204, 17);
            this.RadioButtonMonthFemaleOnly.TabIndex = 1;
            this.RadioButtonMonthFemaleOnly.TabStop = true;
            this.RadioButtonMonthFemaleOnly.Text = "Friend birthdays by month Female only";
            this.RadioButtonMonthFemaleOnly.UseVisualStyleBackColor = true;
            this.RadioButtonMonthFemaleOnly.CheckedChanged += new System.EventHandler(this.RadioButtonMonthFemaleOnly_CheckedChanged);
            // 
            // radioRadioButtonYearAllGender
            // 
            this.radioRadioButtonYearAllGender.AutoSize = true;
            this.radioRadioButtonYearAllGender.Location = new System.Drawing.Point(7, 26);
            this.radioRadioButtonYearAllGender.Name = "radioRadioButtonYearAllGender";
            this.radioRadioButtonYearAllGender.Size = new System.Drawing.Size(185, 17);
            this.radioRadioButtonYearAllGender.TabIndex = 0;
            this.radioRadioButtonYearAllGender.TabStop = true;
            this.radioRadioButtonYearAllGender.Text = "Friend birthdays by year all gender";
            this.radioRadioButtonYearAllGender.UseVisualStyleBackColor = true;
            this.radioRadioButtonYearAllGender.CheckedChanged += new System.EventHandler(this.RadioRadioButtonYearAllGender_CheckedChanged);
            // 
            // progressBarPostsActivity
            // 
            this.progressBarPostsActivity.Location = new System.Drawing.Point(589, 249);
            this.progressBarPostsActivity.MarqueeAnimationSpeed = 50;
            this.progressBarPostsActivity.Name = "progressBarPostsActivity";
            this.progressBarPostsActivity.Size = new System.Drawing.Size(180, 27);
            this.progressBarPostsActivity.Step = 5;
            this.progressBarPostsActivity.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarPostsActivity.TabIndex = 8;
            this.progressBarPostsActivity.Visible = false;
            // 
            // panelChosenFriendExtendedDetails
            // 
            this.panelChosenFriendExtendedDetails.Controls.Add(birthdayLabel);
            this.panelChosenFriendExtendedDetails.Controls.Add(this.imageNormalPictureBox);
            this.panelChosenFriendExtendedDetails.Controls.Add(this.nameLabel1);
            this.panelChosenFriendExtendedDetails.Controls.Add(this.birthdayLabel1);
            this.panelChosenFriendExtendedDetails.Controls.Add(nameLabel);
            this.panelChosenFriendExtendedDetails.Controls.Add(this.lastNameLabel1);
            this.panelChosenFriendExtendedDetails.Controls.Add(firstNameLabel);
            this.panelChosenFriendExtendedDetails.Controls.Add(lastNameLabel);
            this.panelChosenFriendExtendedDetails.Controls.Add(this.firstNameLabel1);
            this.panelChosenFriendExtendedDetails.Location = new System.Drawing.Point(589, 6);
            this.panelChosenFriendExtendedDetails.Name = "panelChosenFriendExtendedDetails";
            this.panelChosenFriendExtendedDetails.Size = new System.Drawing.Size(268, 121);
            this.panelChosenFriendExtendedDetails.TabIndex = 14;
            // 
            // imageNormalPictureBox
            // 
            this.imageNormalPictureBox.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.friendsBindingSource, "ImageNormal", true));
            this.imageNormalPictureBox.Location = new System.Drawing.Point(5, 2);
            this.imageNormalPictureBox.Name = "imageNormalPictureBox";
            this.imageNormalPictureBox.Size = new System.Drawing.Size(73, 68);
            this.imageNormalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageNormalPictureBox.TabIndex = 5;
            this.imageNormalPictureBox.TabStop = false;
            // 
            // friendsBindingSource
            // 
            this.friendsBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.User);
            // 
            // nameLabel1
            // 
            this.nameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.friendsBindingSource, "Name", true));
            this.nameLabel1.Location = new System.Drawing.Point(147, 80);
            this.nameLabel1.Name = "nameLabel1";
            this.nameLabel1.Size = new System.Drawing.Size(100, 23);
            this.nameLabel1.TabIndex = 9;
            // 
            // birthdayLabel1
            // 
            this.birthdayLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.friendsBindingSource, "Birthday", true));
            this.birthdayLabel1.Location = new System.Drawing.Point(147, 0);
            this.birthdayLabel1.Name = "birthdayLabel1";
            this.birthdayLabel1.Size = new System.Drawing.Size(120, 23);
            this.birthdayLabel1.TabIndex = 1;
            // 
            // lastNameLabel1
            // 
            this.lastNameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.friendsBindingSource, "LastName", true));
            this.lastNameLabel1.Location = new System.Drawing.Point(146, 51);
            this.lastNameLabel1.Name = "lastNameLabel1";
            this.lastNameLabel1.Size = new System.Drawing.Size(100, 23);
            this.lastNameLabel1.TabIndex = 7;
            // 
            // firstNameLabel1
            // 
            this.firstNameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.friendsBindingSource, "FirstName", true));
            this.firstNameLabel1.Location = new System.Drawing.Point(147, 26);
            this.firstNameLabel1.Name = "firstNameLabel1";
            this.firstNameLabel1.Size = new System.Drawing.Size(100, 23);
            this.firstNameLabel1.TabIndex = 3;
            // 
            // linkActivityData
            // 
            this.linkActivityData.AutoSize = true;
            this.linkActivityData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.linkActivityData.Location = new System.Drawing.Point(591, 156);
            this.linkActivityData.Name = "linkActivityData";
            this.linkActivityData.Size = new System.Drawing.Size(115, 13);
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
            this.panelPostActivityData.Location = new System.Drawing.Point(589, 173);
            this.panelPostActivityData.Name = "panelPostActivityData";
            this.panelPostActivityData.Size = new System.Drawing.Size(264, 60);
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
            this.listBoxFriemdsPerChosenYearOrMonth.DataSource = this.friendsBindingSource;
            this.listBoxFriemdsPerChosenYearOrMonth.DisplayMember = "Name";
            this.listBoxFriemdsPerChosenYearOrMonth.FormattingEnabled = true;
            this.listBoxFriemdsPerChosenYearOrMonth.Location = new System.Drawing.Point(447, 6);
            this.listBoxFriemdsPerChosenYearOrMonth.Name = "listBoxFriemdsPerChosenYearOrMonth";
            this.listBoxFriemdsPerChosenYearOrMonth.Size = new System.Drawing.Size(123, 121);
            this.listBoxFriemdsPerChosenYearOrMonth.TabIndex = 6;
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
            // panel3
            // 
            this.panel3.Controls.Add(this.imageSquarePictureBox1);
            this.panel3.Controls.Add(this.nameLabel4);
            this.panel3.Location = new System.Drawing.Point(574, 315);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(225, 243);
            this.panel3.TabIndex = 40;
            // 
            // imageSquarePictureBox1
            // 
            this.imageSquarePictureBox1.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.likersBindingSource, "ImageSquare", true));
            this.imageSquarePictureBox1.Location = new System.Drawing.Point(3, 65);
            this.imageSquarePictureBox1.Name = "imageSquarePictureBox1";
            this.imageSquarePictureBox1.Size = new System.Drawing.Size(100, 50);
            this.imageSquarePictureBox1.TabIndex = 7;
            this.imageSquarePictureBox1.TabStop = false;
            // 
            // nameLabel4
            // 
            this.nameLabel4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.likersBindingSource, "Name", true));
            this.nameLabel4.Location = new System.Drawing.Point(3, 141);
            this.nameLabel4.Name = "nameLabel4";
            this.nameLabel4.Size = new System.Drawing.Size(100, 23);
            this.nameLabel4.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(890, 635);
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
            this.groupBoxLikes.ResumeLayout(false);
            this.groupBoxLikes.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageSquarePictureBox)).EndInit();
            this.groupBoxStatusInfo.ResumeLayout(false);
            this.panelChosenPost.ResumeLayout(false);
            this.panelChosenPost.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusesBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelChosenFriendExtendedDetails.ResumeLayout(false);
            this.panelChosenFriendExtendedDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageNormalPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendsBindingSource)).EndInit();
            this.panelPostActivityData.ResumeLayout(false);
            this.panelPostActivityData.PerformLayout();
            this.panelPostStatus.ResumeLayout(false);
            this.panelPostStatus.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageSquarePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.likersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxAutomaticLogin;
        private System.Windows.Forms.PictureBox UserPictureBox;
        private System.Windows.Forms.ListBox ListYearOrMonthNumOfFriends;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.ListBox listBoxFriemdsPerChosenYearOrMonth;
        private System.Windows.Forms.Panel panelUserDataPanel;
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
        private System.Windows.Forms.BindingSource friendsBindingSource;
        private System.Windows.Forms.Panel panelChosenFriendExtendedDetails;
        private System.Windows.Forms.PictureBox imageNormalPictureBox;
        private System.Windows.Forms.Label nameLabel1;
        private System.Windows.Forms.Label birthdayLabel1;
        private System.Windows.Forms.Label lastNameLabel1;
        private System.Windows.Forms.Label firstNameLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RadioButtonMonthMaleOnly;
        private System.Windows.Forms.RadioButton RadioButtonMonthFemaleOnly;
        private System.Windows.Forms.RadioButton radioRadioButtonYearAllGender;
        private System.Windows.Forms.ListBox listStatuses;
        private System.Windows.Forms.LinkLabel linkFetchStatuses;
        private System.Windows.Forms.BindingSource statusesBindingSource;
        private System.Windows.Forms.Label createdTimeLabel1;
        private System.Windows.Forms.LinkLabel linkLinkLabel;
        private System.Windows.Forms.Label messageLabel1;
        private System.Windows.Forms.LinkLabel pictureURLLinkLabel;
        private System.Windows.Forms.Panel panelChosenPost;
        private System.Windows.Forms.ListBox listLikers;
        private System.Windows.Forms.BindingSource likersBindingSource;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBoxLikes;
        private System.Windows.Forms.GroupBox groupBoxStatusInfo;
        private System.Windows.Forms.PictureBox imageSquarePictureBox;
        private System.Windows.Forms.Label nameLabel3;
        private System.Windows.Forms.LinkLabel linkByGenderFemale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkByGenderMale;
        private System.Windows.Forms.Label labelSlash;
        private System.Windows.Forms.LinkLabel linkAllGenders;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imageSquarePictureBox1;
        private System.Windows.Forms.Label nameLabel4;
    }
}