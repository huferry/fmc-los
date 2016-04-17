using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;

namespace Los.Core
{
    public enum Gender { Male, Female }

    public class Relation : ISearchable
    {
        private string surname = "";
        private string firstname = "";
        private DateTime birthdate = new DateTime(1900, 1, 1);
        private string phone_home = "";
        private string phone_mobile = "";
        private string email = "";
        private string language = "";
        private IDictionary<string, string> info = new Dictionary<string, string>();
        private int id = -1;
        private bool isEmpty = false;
        private string gender;
        private bool approved;

        static public Relation CreateEmpty()
        {
            Relation r = new Relation();
            r.isEmpty = true;
            return r;
        }

        private Relation()
        {
            isEmpty = true;
        }

        private Relation(DataRow row)
        {
            id = row.Field<int>("relation_id");
            surname = row.Field<string>("lastname");
            firstname = row.Field<string>("firstname");
            if (!row.IsNull("birthday"))
                birthdate = row.Field<DateTime>("birthday");
            phone_home = row.Field<string>("phone_home");
            phone_mobile = row.Field<string>("phone_mobile");
            email = row.Field<string>("email");
            language = row.Field<string>("language");
            gender = row.Field<string>("gender");
            approved = row.Field<bool>("approved");
            SetInfo( row.Field<string>("info") );
        }

        public bool IsEmpty
        {
            get { return isEmpty; }
        }

        internal int Id { get { return id; } }

        #region properties

        public string Surname 
        { 
            get { return surname; } 
            set { surname = value; }
        }

        public string Firstname
        {
            get { return firstname; }
            set
            {
                firstname = value;
            }
        }

        public DateTime Birthday
        {
            get { return birthdate; }
            set
            {
                birthdate = value;
            }
        }

        public string PhoneHome
        {
            get { return phone_home; }
            set
            {
                phone_home = value;
            }
        }

        public string PhoneMobile
        {
            get { return phone_mobile; }
            set
            {
                phone_mobile = value;
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
            }
        }

        public string Language
        {
            get { return language; }
            set
            {
                language = value;
            }
        }

        public IDictionary<string, string> Info
        {
            get { return info; }
        }

        public Gender Gender
        {
            get
            {
                if (gender == "M")
                    return Gender.Male;
                else
                    return Gender.Female;
            }

            set
            {
                if (value == Gender.Male)
                    gender = "M";
                else
                    gender = "F";
            }
        }

        public bool Approved
        {
            get { return approved; }
        }

        #endregion        

        private void SetInfo(string info)
        {
            this.info.Clear();
            if (info != null)
            {
                string[] pairs = info.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string pair in pairs)
                {
                    string[] content = pair.Split(new char[] { '=' }, 2);

                    string value = content.Length > 1 ? content[1] : null;

                    this.info.Add(content[0], value);
                }
            }
        }

        private string GetInfoString()
        {
            List<string> pairs = new List<string>();

            foreach (string key in info.Keys)
                pairs.Add(key + '=' + info[key]);

            string str = "";
            foreach (string pair in pairs)
                str += pair + ";";

            return str;
            
        }

        public void ApproveData()
        {
            approved = true;
            Database.Execute("UPDATE relation rel SET rel.approved=@approved WHERE rel.relation_id=@id",
                new DbParameter[] { Database.CreateParameter("@approved", approved), Database.CreateParameter("@id", id) });
        }

        public override string ToString()
        {
            return firstname + " " + surname;
        }

        static private void SplitName(string fullname, out string surname, out string firstnames)
        {
            var splits = fullname.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (splits.Length == 1)
            {
                surname = fullname.Trim();
                firstnames = "";
                return;
            }

            surname = splits.Last();
            firstnames = "";

            foreach (string n in splits.Take(splits.Length - 1))
            {
                firstnames += n + " ";
            }

            firstnames = firstnames.Trim();

        }

        public override int GetHashCode()
        {
            return id;
        }

        public int ObjectCode
        {
            get { return Los.Core.ObjectCode.GetObjectCode(this); }
        }

        public override bool Equals(object obj)
        {
            return (obj is Relation) && ((obj as Relation).id == id);
        }

        #region database methods        

        private IEnumerable<DbParameter> GetParameters()
        {
            return new DbParameter[]
            {
                Database.CreateParameter("@surname", surname),
                Database.CreateParameter("@firstname", firstname),
                Database.CreateParameter("@birthdate", birthdate),
                Database.CreateParameter("@phone_home", phone_home),
                Database.CreateParameter("@phone_mobile", phone_mobile),
                Database.CreateParameter("@email", email),
                Database.CreateParameter("@language", language),
                Database.CreateParameter("@info", GetInfoString()),
                Database.CreateParameter("@id", id),
                Database.CreateParameter("@gender", gender),
                Database.CreateParameter("@approved", approved)
            };
        }

        public void InsertApproved()
        {
            approved = true;
            Insert();
        }

        public void Insert()
        {
            Database.Execute(
                 "INSERT INTO relation (lastname,firstname,gender,birthday,phone_home,phone_mobile,email,language,info,approved) VALUES " +
                 "(@surname,@firstname,@gender,@birthdate,@phone_home,@phone_mobile,@email,@language,@info,@approved)",
                 GetParameters()
                );

            var last = Database.Select("SELECT MAX(rel.relation_id) FROM relation rel");
            this.id = last.First().Field<int>(0);
            isEmpty = false;
        }

        public void Update()
        {
            if (id == -1)
                Insert();
            else
            {
                Database.Execute(
                    "UPDATE relation SET lastname=@surname, firstname=@firstname,gender=@gender,birthday=@birthdate," +
                    "phone_home=@phone_home,phone_mobile=@phone_mobile,email=@email,language=@language,info=@info " +
                    "WHERE relation_id=@id",
                    GetParameters()
                    );
                    
            }

        }

        public void Delete()
        {
            if (id != -1)
            {
                Database.Execute(
                       "DELETE FROM relation WHERE relation_id=" + id.ToString(), null
                    );
            }
        }

        static public IEnumerable<Relation> GetAll()
        {
            var rows = Database.Select("SELECT * FROM relation");
            foreach (DataRow row in rows)
                yield return new Relation(row);
        }

        static public IEnumerable<Relation> GetByCourse(Course course)
        {
            var rows = Database.Select("SELECT rel.* FROM relation rel JOIN class_relation clr ON clr.rel_relation_id = rel.relation_id WHERE clr.cla_class_id=" + course.Id.ToString());
            foreach (DataRow r in rows)
                yield return new Relation(r);
        }

        #endregion

        static public Relation Import(string[] row, string info)
        {
            Relation rel = new Relation();

            SplitName(row[1], out rel.surname, out rel.firstname);
            rel.language = row[2];
            rel.birthdate = row[3] != "" ? DateTime.FromOADate(double.Parse(row[3])) : new DateTime(0);
            rel.email = row[4];
            rel.phone_mobile = row[5];
            rel.phone_home = row[6];
            rel.SetInfo(string.Format("Care Leader={0};Net={1};Church={2};{3}", row[7], row[8], row[9], info));

            return rel;

        }

        #region ISearchable Members

        public double CalcSearchScore(string key)
        {
            if (firstname.StartsWith(key, StringComparison.OrdinalIgnoreCase))
                return 1;

            if (surname.StartsWith(key, StringComparison.OrdinalIgnoreCase))
                return 0.99;

            if ((firstname + surname).ToUpper().Contains(key.ToUpper()))
                return 0.6;

            if ((email != null) && (email.ToUpper().Contains(key.ToUpper())))
                return 0.6;

            if ((phone_home != null) && (phone_home.Contains(key)))
                return 0.3;

            if ((phone_mobile != null) && (phone_mobile.Contains(key)))
                return 0.3;

            return 0;
        }

        public double CalcSearchScore(string[] keys)
        {
            if (keys.Length == 0)
                return 0;

            double score = 0;
            foreach (string key in keys)
                score += CalcSearchScore(key);

            return score / keys.Length;
        }

        #endregion
    }

    
}
