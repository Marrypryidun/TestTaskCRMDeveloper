using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            DateTime check=startDate;
            if (dayCount < 0)
                throw new Exception("Duration cannot be a negative number.");
            else
            {
                startDate = startDate.AddDays(dayCount - 1);
                if (weekEnds != null)
                {
                    foreach (WeekEnd period in weekEnds)
                    {
                        if ((period.StartDate<=startDate)&&!(check>period.StartDate&&check>period.EndDate))
                        {
                            TimeSpan wDays = period.EndDate - period.StartDate;
                            startDate = startDate.AddDays(wDays.Days + 1);
                        }
                    }
                }
                return startDate;
                //throw new NotImplementedException();
            }
        }
    }
}
