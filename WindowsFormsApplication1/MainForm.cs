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
    public partial class Design_Patterns_App : Form
    {
        public Design_Patterns_App()
        {
            this.InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 1000;
        }

        public User m_LoggedInUser;
        public Dictionary<int, List<User>> m_FriendsBornPerYear = new Dictionary<int, List<User>>();

        private void loginAndInit()
        {
            /// Owner: design.patterns

            /// Use the FacebookService.Login method to display the login form to any user who wish to use this application.
            /// You can then save the result.AccessToken for future auto-connect to this user:       
            LoginResult result = FacebookService.Login("511256585691702", "user_status", "user_birthday", "user_about_me", "user_friends", "publish_actions", "user_events", "user_posts", "user_photos" );  /// (desig patter's "Design Patterns Course App 2.4" app)
            ///  These are NOT the complete list of permissions. Other permissions for example:
            /// "user_birthday", "user_education_history", "user_hometown", "user_likes","user_location","user_relationships","user_relationship_details","user_religion_politics", "user_videos", "user_website", "user_work_history", "email","read_insights","rsvp_event","manage_pages"
            /// The documentation regarding facebook login and permissions can be found here: 
            /// v2.4: https://developers.facebook.com/docs/facebook-login/permissions/v2.4
            if (!string.IsNullOrEmpty(result.AccessToken))
            {
                this.m_LoggedInUser = result.LoggedInUser;
                this.fetchUserInfo();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage);
            }
        }

        private void fetchUserInfo()
        {
            this.UserPictureBox.LoadAsync(this.m_LoggedInUser.PictureNormalURL);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dictionary<int, List<User>> o_FriendsBornPerYear = new Dictionary<int, List<User>>();
            int friendYearBorn;
            FacebookObjectCollection<User> myFriends = this.m_LoggedInUser.Friends;
            if (myFriends.Count == 0)
            {
                MessageBox.Show("No Friends Birthday's to retrieve :(");
            }
            else
            {
                foreach (var friend in myFriends)
                {
                    friendYearBorn = this.getYear(friend.Birthday);
                    if (friendYearBorn != 0)
                    {
                        if (o_FriendsBornPerYear.ContainsKey(friendYearBorn) == true)
                        {
                            o_FriendsBornPerYear[friendYearBorn].Add(friend);
                        }
                        else
                        {
                            List<User> initialList = new List<User>();
                            initialList.Add(friend);
                            o_FriendsBornPerYear.Add(friendYearBorn, initialList);
                        }
                    }

                    this.m_FriendsBornPerYear = o_FriendsBornPerYear;
                }
                if (o_FriendsBornPerYear.Count != 0)
                {
                    this.Friend_list_SelectedIndexChanged();
                }
                else
                {
                    MessageBox.Show("No Friends Birthday's to retrieve :(");
                }
            }
        }

        private int getYear(string i_Birthday)
        {
            int o_year = 0;
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', '/' };
            string[] words = i_Birthday.Split(delimiterChars);
            if (words.Length == 3)
            {
                o_year = int.Parse(words[2]);
            }

            return o_year;
        }

        private void Friend_list_SelectedIndexChanged()
        {
            foreach (KeyValuePair<int, List<User>> entry in this.m_FriendsBornPerYear)
            {
                this.Friends_year_list.Items.Add(entry.Key.ToString());
            }
        }

        private void displaySelectedFriendsInYear(int i_year)
        {
            if (Friends_year_list.SelectedItems.Count == 1)
             {
                 this.NamesPerChosenYear.DisplayMember = "Name";
                 List<User> selectedYearFriends = this.m_FriendsBornPerYear[i_year] as List<User>;
                 foreach (var friend in selectedYearFriends)
                 {
                     this.NamesPerChosenYear.Items.Add(friend);
                 }
             }
        }

        private void GetCongtatulatingFriends()
        {
            List<string> congratulatingFriends = new List<string>();
        }

        private void buttonLogin_Click_1(object sender, EventArgs e)
        {
            this.loginAndInit();
        }

        private void NamesPerChosenYear_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Friends_year_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Friends_year_list.SelectedItems.Count == 1)
            {
                int selectedYear = int.Parse(Friends_year_list.SelectedItem.ToString());
                this.displaySelectedFriendsInYear(selectedYear);
            }
        }
    }
}