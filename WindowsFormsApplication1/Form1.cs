using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public delegate void LoginButtonActionDelegate();
        private User m_LoggedInUser;
        private LoginButtonActionDelegate m_linkAction;


        public Form1()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 10000;
            m_linkAction = new LoginButtonActionDelegate(loginAndInit);
        }

        private void loginAndInit()
        {
            /// Use the FacebookService.Login method to display the login form to any user who wish to use this application.
            /// You can then save the result.AccessToken for future auto-connect to this user:
            LoginResult result = FacebookService.Login("511256585691702", /// (Asaf Haim & Asaf Bartov app)
                                                       "user_about_me", "user_friends", "publish_actions", "user_events", "user_posts", 
                                                       "user_photos", "user_status", "user_birthday", "user_likes", "rsvp_event");

            // These are NOT the complete list of permissions. Other permissions for example:
            // "user_birthday", "user_education_history", "user_hometown", "user_likes","user_location","user_relationships","user_relationship_details","user_religion_politics", "user_videos", "user_website", "user_work_history", "email","read_insights","rsvp_event","manage_pages"
            // The documentation regarding facebook login and permissions can be found here: 
            // v2.4: https://developers.facebook.com/docs/facebook-login/permissions/v2.4
            if (!string.IsNullOrEmpty(result.AccessToken))
            {
                m_LoggedInUser = result.LoggedInUser;
                fetchUserInfo();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage);
            }
        }

        private void logout()
        {
            clearUserData();
            FacebookService.Logout(null);
        }

        private void clearUserData()
        {
            UserPictureBox.Image = null;
        }

        private void fetchUserInfo()
        {
            UserPictureBox.LoadAsync(m_LoggedInUser.PictureNormalURL);
            /*if (m_LoggedInUser.Statuses.Count > 0)
            {
                textBoxStatus.Text = m_LoggedInUser.Statuses[0].Message; 
            }*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            getCongtatulatingFriends();
        }

        private void friend_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void getCongtatulatingFriends()
        {
            List<String> congratulatingFriends = new List<String>();

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            m_linkAction();

            // In case we logged in
            if (m_linkAction == loginAndInit)
            {
                m_linkAction = logout;
                buttonLogin.Text = "Logout";
            }
            // In case we logged out
            else
            {
                m_linkAction = loginAndInit;
                buttonLogin.Text = "Login";
            }
        }
    }
}
