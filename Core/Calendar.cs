using System;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace Los.Core
{
    public class Calendar : IComparable
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; } = "";

        public virtual DateTime DateStart { get; set; } = new DateTime(0);

        public virtual DateTime DateEnd { get; set; } = new DateTime(0);

        public virtual bool Blocking { get; set; } = true;

        #region IComparable Members

        public virtual int CompareTo(object obj)
        {
            if (obj is Calendar)
            {
                return DateStart.CompareTo((obj as Calendar).DateStart);
            }

            return -1;
        }

        #endregion

        public virtual bool IsBlocked(DateTime date)
        {
            return Blocking && (date >= DateStart) && (date <= DateEnd);
        }

        public static IEnumerable<Calendar> GetByDates(DateTime startDate, DateTime endDate)
        {
            var items = Repository.GetAll<Calendar>().ToArray();
            return items
                .Where(x => (x.DateStart >= startDate.Date) && (x.DateStart <= endDate.Date));
        }

        public static IDictionary<DateTime, Calendar> GetBlockingDates(DateTime start, DateTime end)
        {
            var dates = new Dictionary<DateTime, Calendar>();

            var items = GetByDates(start, end).ToArray();

            var iter = start;
            while (iter <= end)
            {
                var calItem = items
                    .FirstOrDefault(x => x.Blocking && (iter >= x.DateStart) && (iter <= x.DateEnd));
                if (calItem != null)
                {
                    dates.Add(iter, calItem);
                }

                iter = iter.AddDays(1);
            }

            return dates;
        }
    }
}