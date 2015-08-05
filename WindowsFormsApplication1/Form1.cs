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
    public partial class Form1 : Form
    {
        public delegate void LoginButtonActionDelegate();
        private User m_LoggedInUser;
        private LoginButtonActionDelegate m_linkAction;
        private static readonly string sr_SessionFileName = "session.cfg";
        private FileStream m_AccessTokenFileStream;
        private XmlSerializer m_AccessTokenXmlSerializer;

        public Form1()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 10000;
            m_AccessTokenXmlSerializer = new XmlSerializer(typeof(string));
            m_linkAction = new LoginButtonActionDelegate(tryLogin);

            // If there is an access token file
            if (File.Exists(sr_SessionFileName))
            {
                string accessToken = loadAccessToken();
                if (!string.IsNullOrEmpty(accessToken))
                {
                    try
                    {
                        loginWithLoginResult(FacebookService.Connect(accessToken));
                        checkBoxAutomaticLogin.Checked = true;
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
                                                       "user_photos", "user_status", "user_birthday", "user_likes", "rsvp_event", "user_groups");

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
                    if (checkBoxAutomaticLogin.Checked)
                    {
                        saveAccessToken(i_LoginResult.AccessToken);
                    }

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

        private void saveAccessToken(string i_AccessToken)
        {
            using (m_AccessTokenFileStream = new FileStream(sr_SessionFileName, FileMode.OpenOrCreate))
            {
                m_AccessTokenXmlSerializer.Serialize(m_AccessTokenFileStream, i_AccessToken);
            }
        }

        private string loadAccessToken()
        {
            string accesToken = "";

            try
            {
                using (m_AccessTokenFileStream = new FileStream(sr_SessionFileName, FileMode.OpenOrCreate))
                {
                    accesToken = m_AccessTokenXmlSerializer.Deserialize(m_AccessTokenFileStream) as string;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return accesToken;
        }

        private void logout()
        {
            clearUserData();
            FacebookService.Logout(null);
            checkBoxAutomaticLogin.Visible = true;
            switchToLoginButton();
            File.Delete(sr_SessionFileName);
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
            FacebookObjectCollection<User> myFriends = m_LoggedInUser.Friends;
            foreach (User friend in myFriends)
            {
                int friendSimilarityNum = 0;
                try
                {
                    FacebookObjectCollection<Group> friendGroups = friend.Groups;
                FacebookObjectCollection<Group> myGroups = m_LoggedInUser.Groups;
                foreach (Group myGroup in myGroups)
                {
                    foreach (Group friendGroup in friendGroups)
                    {
                        if (friendGroup == myGroup)
                        {
                            friendSimilarityNum++;
                        }
                    }
                }
                string friendSimilarity = friend.FirstName;
                friendSimilarity += friendSimilarityNum.ToString();
                Friend_list.Items.Add(friendSimilarity);
                }
                catch (Exception exs)
                {
                  
                }
            }
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
    }
}
