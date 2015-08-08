using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public static class PeriodOfTime
    {
        public static string GetPeriodToNowString(DateTime i_SinceDate)
        {
            return GetPeriodString(i_SinceDate, DateTime.Now);
        }

        public static string GetPeriodString(DateTime i_SinceDate, DateTime i_ToDate)
        {
            TimeSpan timeSpan = DateTime.Now.Subtract(i_SinceDate);
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
                            periodString = "over a year ago";
                            break;
                        default:
                            periodString = string.Format("over {0} months ago", monthsPast);
                            break;
                    }
            }
            else if (timeSpan.Days >= 1)
            {
                switch (timeSpan.Days)
                {
                    case 1:
                        periodString = string.Format("yesterday on {0}:{1}", i_SinceDate.Hour, i_SinceDate.Minute);
                        break;
                    case 2:
                    case 3:
                    case 4:
                        periodString = string.Format("on {0}", i_SinceDate.DayOfWeek.ToString());
                        break;
                    default:
                        periodString = string.Format("{0} days ago", timeSpan.Days);
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

            return periodString;
        }
    }
}
