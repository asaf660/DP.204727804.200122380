using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class mainForm : Form
    {
        public delegate void LoginButtonActionDelegate();
        private User m_LoggedInUser;
        private LoginButtonActionDelegate m_linkAction;

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
            /// Use the FacebookService.Login method to display the login form to any user who wish to use this application.
            /// You can then save the result.AccessToken for future auto-connect to this user:
            LoginResult result = FacebookService.Login("511256585691702", /// (Asaf Haim & Asaf Bartov app)
                                                       "user_about_me", "user_friends", "publish_actions", "user_events", "user_posts", 
                                                       "user_photos", "user_status", "user_birthday", "user_likes", "rsvp_event", "read_stream");

            // These are NOT the complete list of permissions. Other permissions for example:
            // "user_birthday", "user_education_history", "user_hometown", "user_likes","user_location","user_relationships","user_relationship_details","user_religion_politics", "user_videos", "user_website", "user_work_history", "email","read_insights","rsvp_event","manage_pages"
            // The documentation regarding facebook login and permissions can be found here: 
            // v2.4: https://developers.facebook.com/docs/facebook-login/permissions/v2.4

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void friend_list_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    }
}
