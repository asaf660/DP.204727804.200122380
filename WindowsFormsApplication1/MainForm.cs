using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace WindowsFormsApplication1
{
    public partial class mainForm : Form
    {
        private User m_LoggedInUser;
        private LoginButtonActionDelegate m_linkAction;

        public delegate void LoginButtonActionDelegate();
        
        public mainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.WindowState = FormWindowState.Normal;
            hideUserData();
            FacebookWrapper.FacebookService.s_CollectionLimit = 10000;
            m_linkAction = new LoginButtonActionDelegate(tryLogin);
            this.Size = AppConfig.Instance.LastWindowSize;
            this.Location = AppConfig.Instance.LastWindowLocation;
            checkBoxAutomaticLogin.Checked = AppConfig.Instance.AutoConnect;
            if (checkBoxAutomaticLogin.Checked)
            {
                string accessToken = AppConfig.Instance.LastAccessToken;
                if (!string.IsNullOrEmpty(accessToken))
                {
                    try
                    {
                        loginWithLoginResult(FacebookService.Connect(accessToken));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        private void tryLogin()
        {
            LoginResult result = FacebookService.Login("511256585691702", /// (Asaf Haim & Asaf Bartov app)
                                                       "user_about_me",
                                                       "user_friends",
                                                       "user_events",
                                                       "user_posts",
                                                       "user_photos",
                                                       "user_status",
                                                       "user_likes");
            loginWithLoginResult(result);
        }

        private void loginWithLoginResult(LoginResult i_LoginResult)
        {
            if (i_LoginResult != null)
            {
                if (!string.IsNullOrEmpty(i_LoginResult.AccessToken))
                {
                    AppConfig.Instance.LastAccessToken = i_LoginResult.AccessToken;
                    checkBoxAutomaticLogin.Visible = false;
                    m_LoggedInUser = i_LoginResult.LoggedInUser;
                    fetchUserInfo();
                    switchToLogoutButton();
                }
                else
                {
                    MessageBox.Show(i_LoginResult.ErrorMessage);
                }
            }
        }

        private void logout()
        {
            clearUserData();
            hideUserData();
            FacebookService.Logout(null);
            checkBoxAutomaticLogin.Visible = true;
            switchToLoginButton();
        }

        private void clearUserData()
        {
            UserPictureBox.Image = null;
        }

        private void showUserData()
        {
            panelUserDataPanel.Show();
        }

        private void hideUserData()
        {
            panelUserDataPanel.Hide();
        }

        private void fetchUserInfo()
        {
            showUserData();
            UserPictureBox.LoadAsync(m_LoggedInUser.PictureNormalURL);
            /*if (m_LoggedInUser.Statuses.Count > 0)
            {
                textBoxStatus.Text = m_LoggedInUser.Statuses[0].Message; 
            }*/
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            m_linkAction();
        }

        private void switchToLoginButton()
        {
            m_linkAction = tryLogin;
            buttonLogin.Text = "Login";
        }

        private void switchToLogoutButton()
        {
            m_linkAction = logout;
            buttonLogin.Text = "Logout";
        }

        private void checkBoxAutomaticLogin_CheckedChanged(object sender, EventArgs e)
        {
            AppConfig.Instance.AutoConnect = checkBoxAutomaticLogin.Checked;
        }

        private void mainForm_LocationChanged(object sender, EventArgs e)
        {
            AppConfig.Instance.LastWindowLocation = this.Location;
        }

        private void mainForm_SizeChanged(object sender, EventArgs e)
        {
            AppConfig.Instance.LastWindowSize = this.Size;
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppConfig.SaveToFile();
        }

        private void buttonActivityData_Click(object sender, EventArgs e)
        {
            BackgroundWorker fetchActivitiesBackgroundWorker = new BackgroundWorker();
            fetchActivitiesBackgroundWorker.DoWork += fetchPostActivityBackgroundWorkerDoWork;
            fetchActivitiesBackgroundWorker.RunWorkerCompleted += fetchPostActivityBackgroundWorkerRunWorkerCompleted;
            progressBarPostsActivity.Visible = true;
            fetchActivitiesBackgroundWorker.RunWorkerAsync();
        }

        private void fetchPostActivityBackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarPostsActivity.Visible = false;
            panelPostActivityData.Visible = true;
        }

        private void fetchPostActivityBackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            fetchPostActivity();
        }

        private void fetchPostActivity()
        {
            Func<Post, bool> statusPredicate = new Func<Post, bool>(statusPostPredicate);
            Post lastPhotoUploadPost = m_LoggedInUser.Posts.First<Post>(photoPostPredicate);
            Post lastVideoPost = m_LoggedInUser.Posts.First<Post>(videoPostPredicate);
            Post lastStatusPost = m_LoggedInUser.Posts.First<Post>(statusPredicate);
            BeginInvoke((MethodInvoker)delegate
            {
                labelLastStatusValue.Text = PeriodOfTime.GetPeriodToNowString((DateTime)lastStatusPost.CreatedTime);
                labelLastPhotoValue.Text = PeriodOfTime.GetPeriodToNowString((DateTime)lastPhotoUploadPost.CreatedTime);
                labelLastVideoValue.Text = PeriodOfTime.GetPeriodToNowString((DateTime)lastVideoPost.CreatedTime);
            });
        }

        private bool statusPostPredicate(Post i_Post)
        {
            return !string.IsNullOrEmpty(i_Post.Message);
        }

        private bool photoPostPredicate(Post i_Post)
        {
            return i_Post.Type == Post.eType.photo;
        }

        private bool videoPostPredicate(Post i_Post)
        {
            return i_Post.Type == Post.eType.video;
        }
    }
}
