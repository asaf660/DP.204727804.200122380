using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using System.Collections;
using System.Linq;

namespace WindowsFormsApplication1
{
    public class DirectorBirthdayList
    {
        private static DirectorBirthdayList s_Instance = null;
        private static object s_LockObj = new Object();
        private BirthdayListWrapper m_BirthdayList;

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

        public void Construct(BuilderBirthdayList builder)
        {
            m_BirthdayList = new BirthdayListWrapper();
            builder.BuildBirthdayListByMonthOrYear(ref m_BirthdayList);
            builder.BuildByGender(ref m_BirthdayList);
        }
    }

    public class BirthdayListWrapper : IEnumerable<IEnumerable<User>>
    {
        public Dictionary<int, List<User>> m_BirthdayList;
        
        public BirthdayListWrapper()
        {
            m_BirthdayList = new Dictionary<int, List<User>>();
        }

        public void Remove(Dictionary<int, List<User>> m_FriendsToRemove)
        {
            foreach (KeyValuePair<int,List<User>> KeyValue in m_FriendsToRemove)
            {
                int Currkey = KeyValue.Key;
                foreach (User user in m_FriendsToRemove[Currkey])
                {
                        m_BirthdayList[Currkey].Remove(user);
                }
            }
        }

        IEnumerator<IEnumerable<User>> IEnumerable<IEnumerable<User>>.GetEnumerator()
        {
            foreach (int key in m_BirthdayList.Keys)
            {
                yield return m_BirthdayList[key];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<IEnumerable<User>>)this).GetEnumerator();
        }
    }

    public abstract class BuilderBirthdayList
    {
        protected FacebookObjectCollection<User> m_Friends;
        protected User m_LoggedinUser;
        protected BirthdayListWrapper m_BirthdayList;

        public abstract void BuildBirthdayListByMonthOrYear(ref BirthdayListWrapper io_BirthdayList);

        public abstract void BuildByGender(ref BirthdayListWrapper io_BirthdayList);

        public abstract Dictionary<int, List<User>> GetResult();

        public BuilderBirthdayList(User i_LoggedInUser)
        {
            m_LoggedinUser = i_LoggedInUser;
            m_Friends = i_LoggedInUser.Friends;
        }

        protected void BuildBirthdayListByMonthOrYear(ref BirthdayListWrapper io_BirthdayList, string GetMonthOrGetYear)
        {
            Dictionary<int, List<User>> o_FriendsBornPerMonth = new Dictionary<int, List<User>>();
            int friendMonthOrYearBorn;
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

                    io_BirthdayList.m_BirthdayList = o_FriendsBornPerMonth;
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

        protected void BuilderBirthdayListByGender(ref BirthdayListWrapper io_BirthdayList, User.eGender i_GenderToInclude)
        {
            Dictionary<int, List<User>> FriendToRemoveByCondition = new Dictionary<int, List<User>>();
            
            foreach (var listOfFriendsPerYearOrMonth in io_BirthdayList)
            {
                int i;
                foreach (User friend in listOfFriendsPerYearOrMonth)
                {
                    if (friend.Gender != i_GenderToInclude)
                    {
                        List<User> existing = new List<User>();
                        int Currkey = io_BirthdayList.m_BirthdayList.FirstOrDefault(x => x.Value == listOfFriendsPerYearOrMonth).Key;
                        if (!FriendToRemoveByCondition.TryGetValue(Currkey, out existing))
                        {
                            existing = new List<User>();
                            existing.Add(friend);
                            FriendToRemoveByCondition[Currkey] = existing;
                        }
                        else
                        {
                            FriendToRemoveByCondition[Currkey].Add(friend);
                        }
                    }
                }
            }

            io_BirthdayList.Remove(FriendToRemoveByCondition);
            this.m_BirthdayList = io_BirthdayList;
        }
    }

    public class ConcreteBuilderBirthdayListByMonthFemaleOnly : BuilderBirthdayList
    {
        public ConcreteBuilderBirthdayListByMonthFemaleOnly(User i_LoggedInUser) : base(i_LoggedInUser)
        {
        }

        public override void BuildBirthdayListByMonthOrYear(ref BirthdayListWrapper io_BirthdayList)
        {
            base.BuildBirthdayListByMonthOrYear(ref io_BirthdayList, "Month");
        }

        public override void BuildByGender(ref BirthdayListWrapper io_BirthdayList)
        {
            this.BuilderBirthdayListByGender(ref io_BirthdayList, User.eGender.female);
            this.m_BirthdayList = io_BirthdayList;
        }

        public override Dictionary<int, List<User>> GetResult()
        {
            return this.m_BirthdayList.m_BirthdayList;
        }
    }

    public class ConcreteBuilderBirthdayListByMonthMaleOnly : BuilderBirthdayList
    {
        public ConcreteBuilderBirthdayListByMonthMaleOnly(User i_LoggedInUser)
            : base(i_LoggedInUser)
        {
        }

        public override void BuildBirthdayListByMonthOrYear(ref BirthdayListWrapper io_BirthdayList)
        {
            base.BuildBirthdayListByMonthOrYear(ref io_BirthdayList, "Month");
        }

        public override void BuildByGender(ref BirthdayListWrapper io_BirthdayList)
        {
            this.BuilderBirthdayListByGender(ref io_BirthdayList, User.eGender.male);
            this.m_BirthdayList = io_BirthdayList;
        }

        public override Dictionary<int, List<User>> GetResult()
        {
            return this.m_BirthdayList.m_BirthdayList;
        }
    }

    public class ConcreteBuilderBirthdayListByYearAllGender : BuilderBirthdayList
    {
        public ConcreteBuilderBirthdayListByYearAllGender(User i_LoggedInUser) : base(i_LoggedInUser)
        {
        }

        public override void BuildBirthdayListByMonthOrYear(ref BirthdayListWrapper io_BirthdayList)
        {
            base.BuildBirthdayListByMonthOrYear(ref io_BirthdayList, "Year");
        }

        public override void BuildByGender(ref BirthdayListWrapper io_BirthdayList)
        {
            this.m_BirthdayList = io_BirthdayList;
        }

        public override Dictionary<int, List<User>> GetResult()
        {
            return this.m_BirthdayList.m_BirthdayList;
        }
    }
}
