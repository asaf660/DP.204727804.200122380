using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class DirectorBirthdayList
    {
        private static DirectorBirthdayList s_Instance = null;
        private static object s_LockObj = new Object();
        // Builder uses a complex series of steps
        private Dictionary<int, List<User>> m_BirthdayList;

        private DirectorBirthdayList() 
        { 
        }

        public static DirectorBirthdayList Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (s_LockObj)
                    {
                        if (s_Instance == null)
                        {
                            s_Instance = new DirectorBirthdayList();
                        }
                    }
                }

                return s_Instance;
            }
        }

        public Dictionary<int, List<User>> Construct(BuilderBirthdayList builder)
        {
            m_BirthdayList = new Dictionary<int, List<User>>();
            builder.BuildBirthdayListByMonthOrYear(ref m_BirthdayList);
            builder.BuildByGender(ref m_BirthdayList);
            return m_BirthdayList;
        }
    }

    public abstract class BuilderBirthdayList
    {
        protected FacebookObjectCollection<User> m_Friends;
        protected User m_LoggedinUser;
        protected Dictionary<int, List<User>> m_BirthdayList;

        public abstract void BuildBirthdayListByMonthOrYear(ref Dictionary<int, List<User>> io_BirthdayList);
        public abstract void BuildByGender(ref Dictionary<int, List<User>> io_BirthdayList);
        public abstract Dictionary<int, List<User>> GetResult();

        public BuilderBirthdayList(User i_LoggedInUser)
        {
            m_LoggedinUser = i_LoggedInUser;
            m_Friends = i_LoggedInUser.Friends;
        }

        protected void BuildBirthdayListByMonth(ref Dictionary<int, List<User>> io_BirthdayList)
        {
            Dictionary<int, List<User>> o_FriendsBornPerMonth = new Dictionary<int, List<User>>();
            int friendMonthBorn;
            m_BirthdayList = new Dictionary<int, List<User>>();
            if (m_Friends.Count == 0)
            {
                MessageBox.Show("No Friends Birthday's to retrieve :(");
            }
            else
            {
                foreach (var friend in m_Friends)
                {
                    if (friend.Birthday != null)
                    {
                        friendMonthBorn = getMonth(friend.Birthday);
                        if (friendMonthBorn != 0)
                        {
                            if (o_FriendsBornPerMonth.ContainsKey(friendMonthBorn) == true)
                            {
                                o_FriendsBornPerMonth[friendMonthBorn].Add(friend);
                            }
                            else
                            {
                                List<User> initialList = new List<User>();
                                initialList.Add(friend);
                                o_FriendsBornPerMonth.Add(friendMonthBorn, initialList);
                            }
                        }
                    }

                    io_BirthdayList = o_FriendsBornPerMonth;
                }
            }
        }
        


        private int getMonth(string i_Birthday)
        {
            int o_month = 0;
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', '/' };
            string[] words = i_Birthday.Split(delimiterChars);
            if (words.Length == 3)
            {
                o_month = int.Parse(words[0]);
            }
            return o_month;
        }


        protected void BuilderBirthdayListByGender(ref Dictionary<int, List<User>> io_BirthdayList, User.eGender i_GenderToInclude)
        {
            foreach (KeyValuePair<int, List<User>> pair in io_BirthdayList.ToList())
            {
                foreach (User friend in pair.Value.ToList())
                {
                    if (friend.Gender != i_GenderToInclude)
                    {
                        pair.Value.Remove(friend);
                    }
                }
            }
            //m_FemaleFriendsBornPerMonth = io_BirthdayList;
            m_BirthdayList = io_BirthdayList;
        }
    }

    public class ConcreteBuilderBirthdayListByMonthFemaleOnly : BuilderBirthdayList
    {
        
        public ConcreteBuilderBirthdayListByMonthFemaleOnly(User i_LoggedInUser) : base(i_LoggedInUser)
        {
        }

        public override void BuildBirthdayListByMonthOrYear(ref Dictionary<int, List<User>> io_BirthdayList)
        {
            BuildBirthdayListByMonth(ref io_BirthdayList);
        }


        public override Dictionary<int, List<User>> GetResult()
        {
            //m_BirthdayList = m_FemaleFriendsBornPerMonth;
            return m_BirthdayList;
        }

        public override void BuildByGender(ref Dictionary<int, List<User>> io_BirthdayList)
        {
            BuilderBirthdayListByGender(ref io_BirthdayList, User.eGender.female);
            m_BirthdayList = io_BirthdayList;
        }
    }

    public class ConcreteBuilderBirthdayListByMonthMaleOnly : BuilderBirthdayList
    {
        Dictionary<int, List<User>> m_MaleFriendsBornPerMonth;

        public ConcreteBuilderBirthdayListByMonthMaleOnly(User i_LoggedInUser)
            : base(i_LoggedInUser)
        {
        }

        public override void BuildBirthdayListByMonthOrYear(ref Dictionary<int, List<User>> io_BirthdayList)
        {
            Dictionary<int, List<User>> o_FriendsBornPerMonth = new Dictionary<int, List<User>>();
            int friendMonthBorn;
            m_BirthdayList = new Dictionary<int, List<User>>();
            if (m_Friends.Count == 0)
            {
                MessageBox.Show("No Friends Birthday's to retrieve :(");
            }
            else
            {
                foreach (var friend in m_Friends)
                {
                    if (friend.Birthday != null)
                    {
                        friendMonthBorn = getMonth(friend.Birthday);
                        if (friendMonthBorn != 0)
                        {
                            if (o_FriendsBornPerMonth.ContainsKey(friendMonthBorn) == true)
                            {
                                o_FriendsBornPerMonth[friendMonthBorn].Add(friend);
                            }
                            else
                            {
                                List<User> initialList = new List<User>();
                                initialList.Add(friend);
                                o_FriendsBornPerMonth.Add(friendMonthBorn, initialList);
                            }
                        }
                    }

                    io_BirthdayList = o_FriendsBornPerMonth;
                }
            }
        }

        private int getMonth(string i_Birthday)
        {
            int o_month = 0;
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', '/' };
            string[] words = i_Birthday.Split(delimiterChars);
            if (words.Length == 3)
            {
                o_month = int.Parse(words[0]);
            }
            return o_month;
        }
        
        public override void BuildByGender(ref Dictionary<int, List<User>> io_BirthdayList)
        {
            foreach (KeyValuePair<int, List<User>> pair in io_BirthdayList.ToList())
            {
                foreach (User friend in pair.Value.ToList())
                {
                    if (friend.Gender == User.eGender.female)
                    {
                        pair.Value.Remove(friend);
                    }
                }
            }
            m_MaleFriendsBornPerMonth = io_BirthdayList;
        }


        public override Dictionary<int, List<User>> GetResult()
        {
            m_BirthdayList = m_MaleFriendsBornPerMonth;
            return m_BirthdayList;
        }


    }


    public class ConcreteBuilderBirthdayListByYearAllGender : BuilderBirthdayList
    {
        private Dictionary<int, List<User>> BirthdayListByYearAllGender = new Dictionary<int, List<User>>();
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

        public ConcreteBuilderBirthdayListByYearAllGender(User i_LoggedInUser) : base(i_LoggedInUser)
        {
        }

        public override void BuildBirthdayListByMonthOrYear(ref Dictionary<int, List<User>> io_BirthdayList)
        {
            Dictionary<int, List<User>> o_FriendsBornPerYear = new Dictionary<int, List<User>>();
            int friendYearBorn;
            if (m_Friends.Count == 0)
            {
                MessageBox.Show("No Friends Birthday's to retrieve :(");
            }
            else
            {
                foreach (var friend in m_Friends)
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
        public override void BuildByGender(ref Dictionary<int, List<User>> io_BirthdayList)
        {
            /// Do nothing, all the genders.
        }
        public override Dictionary<int, List<User>> GetResult()
        {
            BirthdayListByYearAllGender = m_FriendsBornPerYear;
            return BirthdayListByYearAllGender;
        }
    }
}
