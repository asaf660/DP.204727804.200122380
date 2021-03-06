﻿// MainForm.cs
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
using System.Threading;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        private User m_LoggedInUser;
        private Action m_LinkAction;
        private Dictionary<int, List<User>> m_FriendsBornByMonthOrYearAndByGender = new Dictionary<int, List<User>>();

		/// <summary>
        /// create builder
        /// </summary>
        private BuilderBirthdayList m_BuildermonthAndFemale;
        private BuilderBirthdayList m_BuilderYearAndAllGender;
        private BuilderBirthdayList m_BuildermonthAndMale;
        private Dictionary<string, BuilderBirthdayList> m_ConcreteBuilderOptions;
        private Dictionary<string, Filter<User>> m_LikersFilters;
		
        public MainForm()
        {
            this.InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.WindowState = FormWindowState.Normal;
            this.hideUserData();
            FacebookWrapper.FacebookService.s_CollectionLimit = 10000;
            this.m_LinkAction = this.tryLogin;
            this.Size = AppConfig.Instance.LastWindowSize;
            this.Location = AppConfig.Instance.LastWindowLocation;
            checkBoxAutomaticLogin.Checked = AppConfig.Instance.AutoConnect;
            this.m_ConcreteBuilderOptions = new Dictionary<string, BuilderBirthdayList>();

            m_LikersFilters = new Dictionary<string, Filter<User>>()
            {
                {"Gender", new Filter<User>()},
                {"Name", new Filter<User>()}
            };

            string[] filtersKeys = m_LikersFilters.Keys.ToArray();
            for (int i = 0; i < filtersKeys.Length - 1; i++)
            {
                m_LikersFilters[filtersKeys[i]].SetNextFilter(m_LikersFilters[filtersKeys[i + 1]]);
            }

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
                    new Thread(() => this.InitializeBirthdayBuilder()).Start();
                    this.Friend_list_SelectedIndexChanged();
                }
                else
                {
                    MessageBox.Show(i_LoginResult.ErrorMessage);
                }
            }
        }

        private void buttonSetStatus_Click(object sender, EventArgs e)
        {
            Status postedStatus = this.m_LoggedInUser.PostStatus(textBoxStatus.Text);
            MessageBox.Show("Status Posted! ID: " + postedStatus.Id);
        }

        public void InitializeBirthdayBuilder()
        {
            this.m_BuildermonthAndFemale = new ConcreteBuilderBirthdayListByMonthFemaleOnly(this.m_LoggedInUser);
            this.m_BuilderYearAndAllGender = new ConcreteBuilderBirthdayListByYearAllGender(this.m_LoggedInUser);
            this.m_BuildermonthAndMale = new ConcreteBuilderBirthdayListByMonthMaleOnly(this.m_LoggedInUser);
            this.m_ConcreteBuilderOptions.Clear();
            this.m_ConcreteBuilderOptions.Add("Friend birthdays by year all gender", this.m_BuilderYearAndAllGender);
            this.m_ConcreteBuilderOptions.Add("Friend birthdays by month Female only", this.m_BuildermonthAndFemale);
            this.m_ConcreteBuilderOptions.Add("Friend birthdays by month Male only", this.m_BuildermonthAndMale);
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
            labelLastStatusValue.Text = string.Empty;
            labelLastPhotoValue.Text = string.Empty;
            labelLastVideoValue.Text = string.Empty;
            likersBindingSource.Clear();
            statusesBindingSource.Clear();
        }

        private void showUserData()
        {
            panelPostStatus.Show();
            panelUserDataPanel.Show();
        }

        private void hideUserData()
        {
            panelPostStatus.Hide();
            panelPostActivityData.Hide();
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
            this.m_LinkAction();
        }

        private void switchToLoginButton()
        {
            this.m_LinkAction = this.tryLogin;
            buttonLogin.Text = "Login";
        }

        private void switchToLogoutButton()
        {
            this.m_LinkAction = this.logout;
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
            Post lastPhotoUploadPost = this.m_LoggedInUser.Posts.First<Post>((Post i_Post) => i_Post.Type == Post.eType.photo);
            Post lastVideoPost = this.m_LoggedInUser.Posts.First<Post>((Post i_Post) => i_Post.Type == Post.eType.video);
            Post lastStatusPost = this.m_LoggedInUser.Posts.First<Post>((Post i_Post) => !string.IsNullOrEmpty(i_Post.Message));
            this.BeginInvoke((MethodInvoker)delegate
            {
                labelLastStatusValue.Text = PeriodFactory.GetPeriodUntilNow((DateTime)lastStatusPost.CreatedTime).PrintPeriod();
                labelLastPhotoValue.Text = PeriodFactory.GetPeriodUntilNow((DateTime)lastPhotoUploadPost.CreatedTime).PrintPeriod();
                labelLastVideoValue.Text = PeriodFactory.GetPeriodUntilNow((DateTime)lastVideoPost.CreatedTime).PrintPeriod();
            });
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
            this.ListYearOrMonthNumOfFriends.Items.Clear();
            foreach (KeyValuePair<int, List<User>> entry in this.m_FriendsBornByMonthOrYearAndByGender)
            {
                string yearAndFriends = entry.Key.ToString() + " - " + entry.Value.Count.ToString();
                this.ListYearOrMonthNumOfFriends.Items.Add(yearAndFriends);
            }
        }

        private void displaySelectedFriendsInYear(int i_year)
        {
            if (ListYearOrMonthNumOfFriends.SelectedItems.Count == 1)
            {
                List<User> selectedYearFriends = this.m_FriendsBornByMonthOrYearAndByGender[i_year] as List<User>;
                if (!listBoxFriemdsPerChosenYearOrMonth.InvokeRequired)     
                {         
                    // binding the data source of the binding source, to our data source:         
                    friendsBindingSource.DataSource = selectedYearFriends;     
                }     
                else     
                {         
                    // In case of cross-thread operation, invoking the binding code on the listBox's thread:         
                    listBoxFriemdsPerChosenYearOrMonth.Invoke(new Action(() => friendsBindingSource.DataSource = selectedYearFriends));     
                }
            }
        }

        private void GetCongtatulatingFriends()
        {
            List<string> congratulatingFriends = new List<string>();
        }

        private void Friends_year_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListYearOrMonthNumOfFriends.SelectedItems.Count == 1)
            {
                listBoxFriemdsPerChosenYearOrMonth.Visible = true;
                char delimiterChars = ' ';
                string[] words = ListYearOrMonthNumOfFriends.SelectedItem.ToString().Split(delimiterChars);
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

                        this.m_FriendsBornByMonthOrYearAndByGender = o_FriendsBornPerYear;
                    }

                    if (o_FriendsBornPerYear.Count != 0)
                    {
                        this.Friend_list_SelectedIndexChanged();
                    }
                    else
                    {
                        MessageBox.Show("No Friends Birthdays to retrieve :(");
                    }
                }
            }
        }

        private void linkActivityData_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BackgroundWorker fetchActivitiesBackgroundWorker = new BackgroundWorker();
            fetchActivitiesBackgroundWorker.DoWork += this.fetchPostActivityBackgroundWorkerDoWork;
            fetchActivitiesBackgroundWorker.RunWorkerCompleted += this.fetchPostActivityBackgroundWorkerRunWorkerCompleted;
            progressBarPostsActivity.Visible = true;
            fetchActivitiesBackgroundWorker.RunWorkerAsync();
        }

        private void ConstructList(string i_SelectedModule)
        {
            friendsBindingSource.Clear();
            try
            {
                DirectorBirthdayList.Instance.Construct(this.m_ConcreteBuilderOptions[i_SelectedModule]);
                this.m_FriendsBornByMonthOrYearAndByGender = this.m_ConcreteBuilderOptions[i_SelectedModule].GetResult();
                this.ListYearOrMonthNumOfFriends.Items.Clear();
                foreach (KeyValuePair<int, List<User>> entry in this.m_FriendsBornByMonthOrYearAndByGender)
                {
                    string yearOrMonthAndNumberFriends = entry.Key.ToString() + " - " + entry.Value.Count.ToString();
                    if (entry.Value.Count != 0)
                    {
                        this.ListYearOrMonthNumOfFriends.Items.Add(yearOrMonthAndNumberFriends);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void RadioRadioButtonYearAllGender_CheckedChanged(object sender, EventArgs e)
        {
            string selectedModule = radioRadioButtonYearAllGender.Text;
            ConstructList(selectedModule);
        }

        private void RadioButtonMonthFemaleOnly_CheckedChanged(object sender, EventArgs e)
        {
            string selectedModule = RadioButtonMonthFemaleOnly.Text;
            this.ConstructList(selectedModule);
        }

        private void RadioButtonMonthMaleOnly_CheckedChanged(object sender, EventArgs e)
        {
            string selectedModule = RadioButtonMonthMaleOnly.Text;
            ConstructList(selectedModule);
        }

        private void linkFetchStatuses_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            IEnumerable<Post> posts = null;
            listStatuses.DisplayMember = "DisplayText";
            BackgroundWorker fetchStatusesBackgroundWorker = new BackgroundWorker();
            fetchStatusesBackgroundWorker.DoWork += (senderObject, args) => posts = m_LoggedInUser.Posts.Where((post) => post.From.Id == m_LoggedInUser.Id);
            fetchStatusesBackgroundWorker.RunWorkerCompleted += delegate(object senderObject, RunWorkerCompletedEventArgs args)
            {
                List<PostProxy> postsForList = new List<PostProxy>();
                foreach (Post post in posts)
                {
                    postsForList.Add(new PostProxy(post));
                    //listStatuses.Items.Add(new PostProxy(post));
                }

                statusesBindingSource.DataSource = postsForList;
                progressBarPostsActivity.Visible = false;
                loadLikers();
            };

            progressBarPostsActivity.Visible = true;
            fetchStatusesBackgroundWorker.RunWorkerAsync();   
        }

        private void listStatuses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (statusesBindingSource.Count > 0)
            {
                loadLikers();
            }
        }

        private void loadLikers()
        {
            listLikers.DisplayMember = "Name";
            likersBindingSource.DataSource = getAllFriendLikers();
        }

        private List<User> getAllFriendLikers()
        {
            List<User> likers = (statusesBindingSource.Current as PostProxy).Post.LikedBy.ToList();
            List<User> friendLikers = new List<User>();

            foreach (User liker in likers)
            {
                User friend = this.m_LoggedInUser.Friends.Find((user) => user.Id.Equals(liker.Id));
                if (friend != null)
                {
                    friendLikers.Add(friend);
                }
            }

            return friendLikers;
        }

        private void changeFilter(string i_FilterKey, Func<User, bool> i_FilterCondition)
        {
            ICollection<User> likers = (ICollection<User>)getAllFriendLikers();
            m_LikersFilters[i_FilterKey].Condition = i_FilterCondition;
            m_LikersFilters[m_LikersFilters.Keys.First()].ProcessFilters(ref likers);
            likersBindingSource.DataSource = likers;
        }

        private void linkAllGenders_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            changeFilter("Gender", (user) => true);
        }

        private void linkByGenderMale_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            changeFilter("Gender", (user) => user.Gender == User.eGender.male);
        }

        private void linkByGenderFemale_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            changeFilter("Gender", (user) => user.Gender == User.eGender.female);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            changeFilter("Name", (user) => user.Name.Contains((sender as TextBox).Text));
        }

        //private void fetchStatusesBackgroundWorkerRunWorkerCompleted
        //{
        //    progressBarPostsActivity.Visible = false;
        //    panelPostActivityData.Visible = true;
        //}
    }
}