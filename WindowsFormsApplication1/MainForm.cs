// MainForm.cs
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
    // $G$ CSS-016 (-5) Bad class name - The name of classes derived from Form should begin with Form.
    public partial class MainForm : Form
    {
        private User m_LoggedInUser;
        private LoginButtonActionDelegate m_linkAction;
        private Dictionary<int, List<User>> m_FriendsBornPerYear = new Dictionary<int, List<User>>();
        
        /// <summary>
        /// create director and builder
        /// </summary>
        DirectorBirthdayList m_DirectorBirthdayList;

        //TODO
        private BuilderBirthdayList m_BuildermonthAndFemale;
        private BuilderBirthdayList m_BuilderYearAndAllGender;
        private Dictionary<string, BuilderBirthdayList> m_ConcreteBuilderOptions;


        public delegate void LoginButtonActionDelegate();

        public MainForm()
        {
            this.InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.WindowState = FormWindowState.Normal;
            this.hideUserData();
            FacebookWrapper.FacebookService.s_CollectionLimit = 10000;
            this.m_linkAction = new LoginButtonActionDelegate(this.tryLogin);
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
                        this.loginWithLoginResult(FacebookService.Connect(accessToken));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            m_DirectorBirthdayList = new DirectorBirthdayList();
            m_BuildermonthAndFemale = new ConcreteBuilderBirthdayListByMonthFemaleOnly(m_LoggedInUser);
            m_BuilderYearAndAllGender = new ConcreteBuilderBirthdayListByYearAllGender(m_LoggedInUser);
            m_ConcreteBuilderOptions = new Dictionary<string, BuilderBirthdayList>();
            m_ConcreteBuilderOptions.Add("friend birthdays by year all gender", m_BuilderYearAndAllGender);
            m_ConcreteBuilderOptions.Add("friend birthdays by month Female only", m_BuildermonthAndFemale);
        }

        public class BithdayListByGender
        { /// this is the Product
            public Dictionary<int, List<User>> BirthdayList
            {
                get;
                set;
            }
        }

        public class DirectorBirthdayList
        {
            // Builder uses a complex series of steps
            public void Construct(BuilderBirthdayList builder)
            {
                builder.BuildBirthdayListTimeDivision();
                builder.BuildByGender();
            }
        }


        public abstract class BuilderBirthdayList
        {
            public FacebookObjectCollection<User> myFriends;
            public abstract void BuildBirthdayListTimeDivision();
            public abstract void BuildByGender();
            public abstract BithdayListByGender GetResult();
            public BithdayListByGender BirthdayList;
        }

        public class ConcreteBuilderBirthdayListByMonthFemaleOnly : BuilderBirthdayList
        {
            private User m_LoggedinUser;

            private FacebookObjectCollection<User> m_Friends;
            private Dictionary<int, List<User>> m_FemaleFriendsBornPerMonth;

            public ConcreteBuilderBirthdayListByMonthFemaleOnly(User i_LoggedInUser)
            {
                m_LoggedinUser = i_LoggedInUser;
                m_Friends = i_LoggedInUser.Friends;
                Dictionary<int, List<User>> o_FemaleFriendsBornPerMonth = new Dictionary<int, List<User>>();
                int friendMonthBorn;
                BirthdayList = new BithdayListByGender();

                if (m_Friends.Count == 0)
                {
                    MessageBox.Show("No Friends Birthday's to retrieve :(");
                }
                else
                {
                    foreach (var friend in myFriends)
                    {
                        if (friend.Birthday != null)
                        {
                            friendMonthBorn = getMonth(friend.Birthday);
                            if (friendMonthBorn != 0)
                            {
                                if (o_FemaleFriendsBornPerMonth.ContainsKey(friendMonthBorn) == true)
                                {
                                    o_FemaleFriendsBornPerMonth[friendMonthBorn].Add(friend);
                                }
                                else
                                {
                                    List<User> initialList = new List<User>();
                                    initialList.Add(friend);
                                    o_FemaleFriendsBornPerMonth.Add(friendMonthBorn, initialList);
                                }
                            }
                        }

                        this.m_FemaleFriendsBornPerMonth = o_FemaleFriendsBornPerMonth;
                    }
                }
            }

            public override void BuildBirthdayListTimeDivision()
            {
                /*foreach (KeyValuePair<int, List<User>> entry in m_Friends)
                {
                    this.Friends_year_list.Items.Clear();
                    foreach (KeyValuePair<int, List<User>> entry in this.m_FriendsBornPerYear)
                    {
                        string yearAndFriends = entry.Key.ToString() + " - " + entry.Value.Count.ToString();
                        this.Friends_year_list.Items.Add(yearAndFriends);
                    }
                }*/
            }

            public override void BuildByGender()
            {
                /// make the list only for girls
            }

            public override BithdayListByGender GetResult()
            {
                BirthdayList.BirthdayList = m_FemaleFriendsBornPerMonth;
                return BirthdayList;
            }
            
            public int getMonth(string i_Birthday)
            {
                int o_month = 0;
                char[] delimiterChars = { ' ', ',', '.', ':', '\t', '/' };
                string[] words = i_Birthday.Split(delimiterChars);
                if (words.Length == 3)
                {
                    o_month = int.Parse(words[3]);
                }

                return o_month;
            }
        }

        public class ConcreteBuilderBirthdayListByYearAllGender : BuilderBirthdayList
        {
            private User m_LoggedinUser;
            public BithdayListByGender BirthdayListByYearAllGender = new BithdayListByGender();
            FacebookObjectCollection<User> m_Friends;
            Dictionary<int, List<User>> m_FriendsBornPerYear;
        
            public int getYear(string i_Birthday)
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

            public override void BuildBirthdayListTimeDivision()
            {
                /// make a of friends born by month
            }

            public ConcreteBuilderBirthdayListByYearAllGender(User i_LoggedInUser)
            {
                m_LoggedinUser = i_LoggedInUser;
                m_Friends = i_LoggedInUser.Friends;
                Dictionary<int, List<User>> o_FriendsBornPerYear = new Dictionary<int, List<User>>();
                int friendYearBorn;
                if (m_Friends.Count == 0)
                {
                    MessageBox.Show("No Friends Birthday's to retrieve :(");
                }
                else
                {
                    foreach (var friend in myFriends)
                    {
                        if (friend.Birthday != null)
                        {
                            friendYearBorn = getYear(friend.Birthday);
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
                        }

                        this.m_FriendsBornPerYear = o_FriendsBornPerYear;
                    }
                }
            }

            public override void BuildByGender()
            {
                /// Do nothing, all the genders.
            }

            public override BithdayListByGender GetResult()
            {
                BirthdayListByYearAllGender.BirthdayList = m_FriendsBornPerYear;
                return BirthdayListByYearAllGender;
            }
        }


        private void tryLogin()
        {
            LoginResult result = FacebookService.Login(
                                                        "511256585691702",
                                                       "user_status",
                                                       "user_birthday",
                                                       "user_about_me",
                                                       "user_friends",
                                                       "publish_actions",
                                                       "user_events",
                                                       "user_posts",
                                                       "user_photos");
            this.loginWithLoginResult(result);
        }

        private void loginWithLoginResult(LoginResult i_LoginResult)
        {
            if (i_LoginResult != null)
            {
                if (!string.IsNullOrEmpty(i_LoginResult.AccessToken))
                {
                    AppConfig.Instance.LastAccessToken = i_LoginResult.AccessToken;
                    checkBoxAutomaticLogin.Visible = false;
                    this.m_LoggedInUser = i_LoginResult.LoggedInUser;
                    this.fetchUserInfo();
                    this.switchToLogoutButton();
                }
                else
                {
                    MessageBox.Show(i_LoginResult.ErrorMessage);
                }
            }
        }

        private void logout()
        {
            this.clearUserData();
            this.hideUserData();
            FacebookService.Logout(null);
            this.checkBoxAutomaticLogin.Visible = true;
            this.switchToLoginButton();
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
            this.showUserData();
            this.labelUserFullName.Text = string.Format("{0} {1}", this.m_LoggedInUser.FirstName, this.m_LoggedInUser.LastName);
            this.labelUserEmail.Text = string.Format("{0}", this.m_LoggedInUser.Email);
            this.UserPictureBox.LoadAsync(this.m_LoggedInUser.PictureNormalURL);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            this.m_linkAction();
        }

        private void switchToLoginButton()
        {
            this.m_linkAction = this.tryLogin;
            buttonLogin.Text = "Login";
        }

        private void switchToLogoutButton()
        {
            this.m_linkAction = this.logout;
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
            fetchActivitiesBackgroundWorker.DoWork += this.fetchPostActivityBackgroundWorkerDoWork;
            fetchActivitiesBackgroundWorker.RunWorkerCompleted += this.fetchPostActivityBackgroundWorkerRunWorkerCompleted;
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
            this.fetchPostActivity();
        }

        private void fetchPostActivity()
        {
            Func<Post, bool> statusPredicate = new Func<Post, bool>(this.statusPostPredicate);
            Post lastPhotoUploadPost = this.m_LoggedInUser.Posts.First<Post>(this.photoPostPredicate);
            Post lastVideoPost = this.m_LoggedInUser.Posts.First<Post>(this.videoPostPredicate);
            Post lastStatusPost = this.m_LoggedInUser.Posts.First<Post>(statusPredicate);
            this.BeginInvoke((MethodInvoker)delegate
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

        public int getYear(string i_Birthday)
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
            this.Friends_year_list.Items.Clear();
            foreach (KeyValuePair<int, List<User>> entry in this.m_FriendsBornPerYear)
            {
                string yearAndFriends = entry.Key.ToString() + " - " + entry.Value.Count.ToString();
                this.Friends_year_list.Items.Add(yearAndFriends);
            }
        }

        private void displaySelectedFriendsInYear(int i_year)
        {
            if (Friends_year_list.SelectedItems.Count == 1)
            {
                this.listBoxNamesPerChosenYear.Items.Clear();
                this.listBoxNamesPerChosenYear.DisplayMember = "Name";
                List<User> selectedYearFriends = this.m_FriendsBornPerYear[i_year] as List<User>;
                foreach (var friend in selectedYearFriends)
                {
                    this.listBoxNamesPerChosenYear.Items.Add(friend);
                }
            }
        }

        private void GetCongtatulatingFriends()
        {
            List<string> congratulatingFriends = new List<string>();
        }

        private void Friends_year_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Friends_year_list.SelectedItems.Count == 1)
            {
                listBoxNamesPerChosenYear.Visible = true;
                char delimiterChars = ' ';
                string[] words = Friends_year_list.SelectedItem.ToString().Split(delimiterChars);
                int selectedYear = int.Parse(words[0]);
                this.displaySelectedFriendsInYear(selectedYear);
            }
        }

        private void buttonGetFriendsYears_Click(object sender, EventArgs e)
        {
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
                        if (friend.Birthday != null)
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
                        }

                        this.m_FriendsBornPerYear = o_FriendsBornPerYear;
                    }

                    if (o_FriendsBornPerYear.Count != 0)
                    {
                        this.Friend_list_SelectedIndexChanged();
                        this.listBox1_SelectedIndexChanged();
                        //this.ListFriendsPresentShowOptions_SelectedIndexChanged();
                    }
                    else
                    {
                        MessageBox.Show("No Friends Birthdays to retrieve :(");
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged()
        {
            BuilderBirthdayList m_BuildermonthAndFemale = new ConcreteBuilderBirthdayListByMonthFemaleOnly(m_LoggedInUser);
            BuilderBirthdayList m_BuilderYearAndAllGender = new ConcreteBuilderBirthdayListByYearAllGender(m_LoggedInUser);

           // Dictionary<string, BuilderBirthdayList> m_ConcreteBuilderOptions = new Dictionary<string, BuilderBirthdayList>();
            //m_ConcreteBuilderOptions.Add("friend birthdays by year all gender", m_BuilderYearAndAllGender);
            //m_ConcreteBuilderOptions.Add("friend birthdays by month Female only", m_BuildermonthAndFemale);

            ListFriendsPresentShowOptions.Items.Add("friend birthdays by year all gender");
            ListFriendsPresentShowOptions.Items.Add("friend birthdays by month Female only");
            ListFriendsPresentShowOptions.Visible = true;


        }
        private void ListFriendsPresentShowOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListFriendsPresentShowOptions.SelectedItems.Count == 1)
            {
                string selectedModule = ListFriendsPresentShowOptions.SelectedItem.ToString();
                m_DirectorBirthdayList.Construct(m_ConcreteBuilderOptions[selectedModule]);
                BithdayListByGender birthdayList = m_ConcreteBuilderOptions[selectedModule].GetResult();
            }
        }

    }
}