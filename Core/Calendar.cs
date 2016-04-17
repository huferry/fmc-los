using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Los.Core
{
    public class Calendar : IComparable
    {
        private int id = -1;
        private string name = "";
        private bool blocking = true;
        private DateTime start = new DateTime(0);
        private DateTime end = new DateTime(0);


        private Calendar(DataRow row)
        {
            id = row.Field<int>("calendar_id");
            name = row.Field<string>("name");
            start = row.Field<DateTime>("date_start");
            end = row.Field<DateTime>("date_end");
            blocking = row.Field<bool>("blocking");
        }

        public Calendar(string name, DateTime start, DateTime end)
        {
            this.name = name;
            this.start = start;
            this.end = end;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime DateStart
        {
            get { return start.Date; }
            set
            {
                this.start = value.Date;
            }
        }

        public DateTime DateEnd
        {
            get { return end.Date; }
            set
            {
                this.end = value.Date;
            }
        }

        public bool IsBlocked(DateTime date)
        {
            return blocking && (date >= DateStart) && (date <= DateEnd);
        }

        public bool Blocking
        {
            get { return blocking; }
            set { blocking = value; }
        }

        private IEnumerable<DbParameter> GetParams()
        {
            return new DbParameter[]
            {
                Database.CreateParameter("@name", name),
                Database.CreateParameter("@start", start),
                Database.CreateParameter("@end", end),
                Database.CreateParameter("@blocking", blocking),
                Database.CreateParameter("@id", id)
            };
        }

        public void Insert()
        {
            if (id == -1)
            {
                Database.Execute(
                    "INSERT INTO calendar (name,date_start,date_end,blocking) VALUES (@name,@start,@end,@blocking)",                    
                    GetParams());
                var rows = Database.Select("SELECT MAX(calendar_id) as newid FROM calendar");

                id = rows.First().Field<int>("newid");
            }
            else
                throw new Exception("Cannot Insert an existing item.");
        }

        public void Update()
        {
            if (id > 0)
            {
                Database.Execute(
                    "UPDATE calendar SET name=@name, date_start=@start, date_end=@end, blocking=@blocking WHERE calendar_id=@id",
                    GetParams());
            }
        }

        static internal IEnumerable<Calendar> GetAll()
        {
            var rows = Database.Select("SELECT * FROM calendar");
            foreach (DataRow r in rows)
                yield return new Calendar(r);
        }

        static public IEnumerable<Calendar> GetByDates(DateTime start_date, DateTime end_date)
        {
            var items = GetAll();
            return items
                .Where(x => (x.DateStart >= start_date.Date) && (x.DateStart <= end_date.Date));
        }

        static public IDictionary<DateTime, Calendar> GetBlockingDates(DateTime start, DateTime end)
        {
            Dictionary<DateTime, Calendar> dates = new Dictionary<DateTime, Calendar>();

            var items = GetByDates(start, end);

            DateTime iter = start;
            while (iter <= end)
            {
                var cal_items = items.Where(x => x.Blocking && (iter >= x.DateStart) && (iter <= x.DateEnd));
                if (cal_items.Count() > 0)
                {
                    dates.Add(iter, cal_items.First());
                }
                iter = iter.AddDays(1);
            }
            return dates;
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            if (obj is Calendar)
            {
                return this.start.CompareTo((obj as Calendar).start);
            }
            return -1;
        }

        #endregion
    }
}
