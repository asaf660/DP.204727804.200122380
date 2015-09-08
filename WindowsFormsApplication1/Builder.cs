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
        // Builder uses a complex series of steps
        private Dictionary<int, List<User>> m_BirthdayList;

        public Dictionary<int, List<User>> Construct(BuilderBirthdayList builder)
        {
            m_BirthdayList = new Dictionary<int, List<User>>();
            builder.BuildBirthdayListByMonthOrYear(ref m_BirthdayList);
            builder.BuildByGender(ref m_BirthdayList);
            return m_BirthdayList;
        }
    }
		
		public class BithdayListByGender
        { /// this is the Product
            public Dictionary<int, List<User>> BirthdayList
            {
                get;
                set;
            }
        }

    public abstract class BuilderBirthdayList
    {
        protected Dictionary<string, List<User>> m_BirthdayList;
        public FacebookObjectCollection<User> myFriends;
        public abstract void BuildBirthdayListByMonthOrYear(ref Dictionary<int, List<User>> io_BirthdayList);
        public abstract void BuildByGender(ref Dictionary<int, List<User>> io_BirthdayList);
        public abstract BithdayListByGender GetResult();
        public BithdayListByGender BirthdayList;
    }

    public class ConcreteBuilderBirthdayListByMonthFemaleOnly : BuilderBirthdayList
    {
        private User m_LoggedinUser;
        private List<string> m_MonthFemaleOnlyList;
        private FacebookObjectCollection<User> m_Friends;
        private Dictionary<int, List<User>> m_FemaleFriendsBornPerMonth;
        public ConcreteBuilderBirthdayListByMonthFemaleOnly(User i_LoggedInUser)
        {
            m_LoggedinUser = i_LoggedInUser;
            m_Friends = i_LoggedInUser.Friends;
        }

        public override void BuildBirthdayListByMonthOrYear(ref Dictionary<int, List<User>> io_BirthdayList)
        {
            Dictionary<int, List<User>> o_FriendsBornPerMonth = new Dictionary<int, List<User>>();
            int friendMonthBorn;
            BirthdayList = new BithdayListByGender();
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
        public override void BuildByGender(ref Dictionary<int, List<User>> io_BirthdayList)
        {
            foreach (KeyValuePair<int, List<User>> pair in io_BirthdayList.ToList())
            {
                foreach (User friend in pair.Value.ToList())
                {
                    if (friend.Gender == User.eGender.male)
                    {
                        pair.Value.Remove(friend);
                    }
                }
            }
            m_FemaleFriendsBornPerMonth = io_BirthdayList;
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
                o_month = int.Parse(words[0]);
            }
            return o_month;
        }
    }

    public class ConcreteBuilderBirthdayListByYearAllGender : BuilderBirthdayList
    {
        private User m_LoggedinUser;
        private BithdayListByGender BirthdayListByYearAllGender = new BithdayListByGender();
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

        public ConcreteBuilderBirthdayListByYearAllGender(User i_LoggedInUser)
        {
            m_LoggedinUser = i_LoggedInUser;
            m_Friends = i_LoggedInUser.Friends;
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
        public override BithdayListByGender GetResult()
        {
            BirthdayListByYearAllGender.BirthdayList = m_FriendsBornPerYear;
            return BirthdayListByYearAllGender;
        }
    }
}
