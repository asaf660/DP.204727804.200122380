using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace WindowsFormsApplication1
{
    public class DirectorBirthdayList
    {
        private static DirectorBirthdayList s_Instance = null;
        private static object s_LockObj = new Object();
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

        protected void BuildBirthdayListByMonthOrYear(ref Dictionary<int, List<User>> io_BirthdayList, string GetMonthOrGetYear)
        {
            Dictionary<int, List<User>> o_FriendsBornPerMonth = new Dictionary<int, List<User>>();
            int friendMonthOrYearBorn;
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
                            friendMonthOrYearBorn = GetMonthOrGetYear == "Month" ? getMonth(friend.Birthday) : getYear(friend.Birthday);
                            if (friendMonthOrYearBorn != 0)
                            {
                                if (o_FriendsBornPerMonth.ContainsKey(friendMonthOrYearBorn) == true)
                                {
                                    o_FriendsBornPerMonth[friendMonthOrYearBorn].Add(friend);
                                }
                                else
                                {
                                    List<User> initialList = new List<User>();
                                    initialList.Add(friend);
                                    o_FriendsBornPerMonth.Add(friendMonthOrYearBorn, initialList);
                                }
                            }
                        }
                    }

                    io_BirthdayList = o_FriendsBornPerMonth;
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

            this.m_BirthdayList = io_BirthdayList;
        }
    }

    public class ConcreteBuilderBirthdayListByMonthFemaleOnly : BuilderBirthdayList
    {
        public ConcreteBuilderBirthdayListByMonthFemaleOnly(User i_LoggedInUser) : base(i_LoggedInUser)
        {
        }

        public override void BuildBirthdayListByMonthOrYear(ref Dictionary<int, List<User>> io_BirthdayList)
        {
            base.BuildBirthdayListByMonthOrYear(ref io_BirthdayList, "Month");
        }

        public override void BuildByGender(ref Dictionary<int, List<User>> io_BirthdayList)
        {
            this.BuilderBirthdayListByGender(ref io_BirthdayList, User.eGender.female);
            this.m_BirthdayList = io_BirthdayList;
        }

        public override Dictionary<int, List<User>> GetResult()
        {
            return this.m_BirthdayList;
        }
    }

    public class ConcreteBuilderBirthdayListByMonthMaleOnly : BuilderBirthdayList
    {
        public ConcreteBuilderBirthdayListByMonthMaleOnly(User i_LoggedInUser)
            : base(i_LoggedInUser)
        {
        }

        public override void BuildBirthdayListByMonthOrYear(ref Dictionary<int, List<User>> io_BirthdayList)
        {
            base.BuildBirthdayListByMonthOrYear(ref io_BirthdayList, "Month");
        }
        
        public override void BuildByGender(ref Dictionary<int, List<User>> io_BirthdayList)
        {
            this.BuilderBirthdayListByGender(ref io_BirthdayList, User.eGender.male);
            this.m_BirthdayList = io_BirthdayList;
        }

        public override Dictionary<int, List<User>> GetResult()
        {
            return this.m_BirthdayList;
        }
    }

    public class ConcreteBuilderBirthdayListByYearAllGender : BuilderBirthdayList
    {
        public ConcreteBuilderBirthdayListByYearAllGender(User i_LoggedInUser) : base(i_LoggedInUser)
        {
        }

        public override void BuildBirthdayListByMonthOrYear(ref Dictionary<int, List<User>> io_BirthdayList)
        {
            base.BuildBirthdayListByMonthOrYear(ref io_BirthdayList, "Year");
        }

        public override void BuildByGender(ref Dictionary<int, List<User>> io_BirthdayList)
        {
            this.m_BirthdayList = io_BirthdayList;
        }

        public override Dictionary<int, List<User>> GetResult()
        {
            return this.m_BirthdayList;
        }
    }
}
