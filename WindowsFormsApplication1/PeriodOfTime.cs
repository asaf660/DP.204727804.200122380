// PeriodOfTime.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public static class PeriodFactory
    {
        public static Period GetPeriodUntilNow(DateTime i_SinceDate)
        {
            return GetPeriod(i_SinceDate, DateTime.Now);
        }

        public static Period GetPeriod(DateTime i_SinceDate, DateTime i_ToDate)
        {
            TimeSpan timeSpan = i_ToDate.Subtract(i_SinceDate);
            if (timeSpan.Days > 6)
            {
                return new DistantPeriod(i_SinceDate, i_ToDate);
            }
            else
            {
                return new RecentPeriod(i_SinceDate, i_ToDate);
            }
        }
    }

    public abstract class Period
    {
        public abstract string PrintPeriod();

        protected DateTime SinceDate { get; set; }
        
        protected DateTime ToDate { get; set; }
    }

    public class RecentPeriod : Period 
    {
        public RecentPeriod(DateTime i_SinceDate, DateTime i_ToDate)
        {
            this.SinceDate = i_SinceDate;
            this.ToDate = i_ToDate;
        }

        public override string PrintPeriod()
        {
            TimeSpan timeSpan = ToDate.Subtract(this.SinceDate);
            string periodString = string.Empty;

            if (timeSpan.Days > 6)
            {
                periodString = string.Format("{0} days ago, on {1:dd/MM/yy}", timeSpan.Days, this.SinceDate);
            }
            else
            {
                if (timeSpan.Days >= 1)
                {
                    switch (timeSpan.Days)
                    {
                        case 1:
                            periodString = string.Format("yesterday on {0:H:mm}", this.SinceDate);
                            break;
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                            periodString = string.Format("on {0:dddd H:mm}", this.SinceDate);
                            break;
                    }
                }
                else
                {
                    switch (timeSpan.Minutes)
                    {
                        case 0:
                            periodString = "less than a minute ago";
                            break;
                        case 1:
                            periodString = "1 minute ago";
                            break;
                        default:
                            periodString = string.Format("{0} minutes ago", timeSpan.Minutes);
                            break;
                    }
                }
            }

            return periodString;
        }
    }

    public class DistantPeriod : Period
    {
        public DistantPeriod(DateTime i_SinceDate, DateTime i_ToDate)
        {
            this.SinceDate = i_SinceDate;
            this.ToDate = i_ToDate;
        }

        public override string PrintPeriod()
        {
            TimeSpan timeSpan = ToDate.Subtract(this.SinceDate);
            string periodString = string.Empty;

            if (timeSpan.TotalDays >= 365)
            {
                int yearsPast = (int)(timeSpan.TotalDays / 365);
                switch (yearsPast)
                {
                    case 1:
                        periodString = "over a year ago";
                        break;
                    default:
                        periodString = string.Format("over {0} years ago", yearsPast);
                        break;
                }
            }
            else if (timeSpan.TotalDays >= 31)
            {
                int monthsPast = (int)(timeSpan.TotalDays / 31);
                switch (monthsPast)
                {
                    case 1:
                        periodString = "over a month ago";
                        break;
                    default:
                        periodString = string.Format("over {0} months ago", monthsPast);
                        break;
                }
            }
            else
            {
                periodString = string.Format("{0} days ago", timeSpan.Days);
            }

            return periodString;
        }
    }
}
