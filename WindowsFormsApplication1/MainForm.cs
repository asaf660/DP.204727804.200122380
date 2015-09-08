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
using System.Threading;

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
            m_ConcreteBuilderOptions = new Dictionary<string, BuilderBirthdayList>();

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
                    this.listBox1_SelectedIndexChanged(); //todo
                }
                else
                {
                    MessageBox.Show(i_LoginResult.ErrorMessage);
                }
            }
        }

        private void buttonSetStatus_Click(object sender, EventArgs e)
        {
            Status postedStatus = m_LoggedInUser.PostStatus(textBoxStatus.Text);
            MessageBox.Show("Status Posted! ID: " + postedStatus.Id);

        }

        public void InitializeBirthdayBuilder()
        {
            m_BuildermonthAndFemale = new ConcreteBuilderBirthdayListByMonthFemaleOnly(m_LoggedInUser);
            m_BuilderYearAndAllGender = new ConcreteBuilderBirthdayListByYearAllGender(m_LoggedInUser);
            m_BuildermonthAndMale = new ConcreteBuilderBirthdayListByMonthMaleOnly(m_LoggedInUser);
            m_ConcreteBuilderOptions.Add("Friend birthdays by year all gender", m_BuilderYearAndAllGender);
            m_ConcreteBuilderOptions.Add("Friend birthdays by month Female only", m_BuildermonthAndFemale);
            m_ConcreteBuilderOptions.Add("Friend birthdays by month Male only", m_BuildermonthAndMale);
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
            this.Friends_year_list.Items.Clear();
            foreach (KeyValuePair<int, List<User>> entry in this.m_FriendsBornByMonthOrYearAndByGender)
            {
                string yearAndFriends = entry.Key.ToString() + " - " + entry.Value.Count.ToString();
                this.Friends_year_list.Items.Add(yearAndFriends);
            }
        }

        private void displaySelectedFriendsInYear(int i_year)
        {
            if (Friends_year_list.SelectedItems.Count == 1)
            {
                //listBoxNamesPerChosenYear.DisplayMember = "Name";
                List<User> selectedYearFriends = this.m_FriendsBornByMonthOrYearAndByGender[i_year] as List<User>;
                if (!listBoxNamesPerChosenYear.InvokeRequired)     
                {         
                    // binding the data source of the binding source, to our data source:         
                    userBindingSource.DataSource = selectedYearFriends;     
                }     
                else     
                {         
                    // In case of cross-thread operation, invoking the binding code on the listBox's thread:         
                    listBoxNamesPerChosenYear.Invoke(new Action(() => userBindingSource.DataSource = selectedYearFriends));     
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

                displaySelectedFriendsInYear(selectedYear);
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
            ListFriendsPresentShowOptions.Items.Add("Friend birthdays by year all gender");
            ListFriendsPresentShowOptions.Items.Add("Friend birthdays by month Female only");
            ListFriendsPresentShowOptions.Items.Add("Friend birthdays by month Male only");
            ListFriendsPresentShowOptions.Visible = true;
        }
        private void ListFriendsPresentShowOptions_SelectedIndexChanged(object sender, EventArgs e)
		{
            userBindingSource.Clear();

			if (ListFriendsPresentShowOptions.SelectedItems.Count == 1)
			{
				string selectedModule = ListFriendsPresentShowOptions.SelectedItem.ToString();

                DirectorBirthdayList.Instance.Construct(m_ConcreteBuilderOptions[selectedModule]);
                Dictionary<int, List<User>> birthdayList = m_ConcreteBuilderOptions[selectedModule].GetResult();
                m_FriendsBornByMonthOrYearAndByGender = birthdayList;
                this.Friends_year_list.Items.Clear();
                foreach (KeyValuePair<int, List<User>> entry in birthdayList)
                {
                    string yearOrMonthAndNumberFriends = entry.Key.ToString() + " - " + entry.Value.Count.ToString();
                    if (entry.Value.Count != 0)
                    { 
                        this.Friends_year_list.Items.Add(yearOrMonthAndNumberFriends);
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
    }
}