using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace Los.Core
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Relation : ISearchable
    {
        private readonly DateTime birthdate = new DateTime(1900, 1, 1);
        private string gender;

        private Relation()
        {
            IsEmpty = true;
        }

        private Relation(DataRow row)
        {
            Id = row.Field<int>("relation_id");
            Surname = row.Field<string>("lastname");
            Firstname = row.Field<string>("firstname");
            if (!row.IsNull("birthday"))
                Birthday = row.Field<DateTime>("birthday");
            PhoneHome = row.Field<string>("phone_home");
            PhoneMobile = row.Field<string>("phone_mobile");
            Email = row.Field<string>("email");
            Language = row.Field<string>("language");
            gender = row.Field<string>("gender");
            Approved = row.Field<bool>("approved");
            IsCareLeader = row.Field<bool>("is_leader");
            CareLeaderId = row.Field<int?>("leader_relation_id");
            SetInfo(row.Field<string>("info"));
        }

        public bool IsEmpty { get; private set; } = true;

        public int Id { get; private set; } = -1;

        public int ObjectCode => Core.ObjectCode.GetObjectCode(this);

        public static Relation CreateEmpty()
        {
            var r = new Relation();
            r.IsEmpty = true;
            return r;
        }

        private void SetInfo(string info)
        {
            Info.Clear();
            if (info != null)
            {
                var pairs = info.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);

                foreach (var pair in pairs)
                {
                    var content = pair.Split(new[] {'='}, 2);

                    var value = content.Length > 1 ? content[1] : null;

                    Info.Add(content[0], value);
                }
            }
        }

        private string GetInfoString()
        {
            var pairs = new List<string>();

            foreach (var key in Info.Keys)
                pairs.Add(key + '=' + Info[key]);

            var str = "";
            foreach (var pair in pairs)
                str += pair + ";";

            return str;
        }

        public void ApproveData()
        {
            Approved = true;
            Database.Execute("UPDATE relation rel SET rel.approved=@approved WHERE rel.relation_id=@id",
                new[] {Database.CreateParameter("@approved", Approved), Database.CreateParameter("@id", Id)});
        }

        public override string ToString()
        {
            return Firstname + " " + Surname;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            return obj is Relation && (obj as Relation).Id == Id;
        }

        #region properties

        public string Surname { get; set; }

        public string Firstname { get; set; }

        public DateTime Birthday { get; set; }

        public string PhoneHome { get; set; }

        public string PhoneMobile { get; set; }

        public string Email { get; set; }

        public string Language { get; set; }

        public IDictionary<string, string> Info { get; } = new Dictionary<string, string>();

        public Gender Gender
        {
            get => gender == "M" ? Gender.Male : Gender.Female;
            set => gender = value == Gender.Male ? "M" : "F";
        }

        public bool IsCareLeader { get; set; }

        public int? CareLeaderId { get; set; }

        public bool Approved { get; private set; }

        #endregion

        #region database methods        

        private IEnumerable<DbParameter> GetParameters()
        {
            return new[]
            {
                Database.CreateParameter("@surname", Surname),
                Database.CreateParameter("@firstname", Firstname),
                Database.CreateParameter("@birthdate", birthdate),
                Database.CreateParameter("@phone_home", PhoneHome),
                Database.CreateParameter("@phone_mobile", PhoneMobile),
                Database.CreateParameter("@email", Email),
                Database.CreateParameter("@language", Language),
                Database.CreateParameter("@info", GetInfoString()),
                Database.CreateParameter("@id", Id),
                Database.CreateParameter("@gender", gender),
                Database.CreateParameter("@approved", Approved),
                Database.CreateParameter("@is_leader", IsCareLeader),
                Database.CreateParameter("@care_leader", CareLeaderId)
            };
        }

        public void InsertApproved()
        {
            Approved = true;
            Insert();
        }

        public void Insert()
        {
            Database.Execute(
                "INSERT INTO relation (lastname,firstname,gender,birthday,phone_home,phone_mobile,email,language,info,approved,is_leader,leader_relation_id) VALUES " +
                "(@surname,@firstname,@gender,@birthdate,@phone_home,@phone_mobile,@email,@language,@info,@approved,@is_leader,@care_leader)",
                GetParameters()
            );

            var last = Database.Select("SELECT MAX(rel.relation_id) FROM relation rel");
            Id = last.First().Field<int>(0);
            IsEmpty = false;
        }

        public void Update()
        {
            if (Id == -1)
                Insert();
            else
                Database.Execute(
                    "UPDATE relation SET lastname=@surname, firstname=@firstname,gender=@gender,birthday=@birthdate," +
                    "phone_home=@phone_home,phone_mobile=@phone_mobile,email=@email,language=@language,info=@info,is_leader=@is_leader,leader_relation_id=@care_leader " +
                    "WHERE relation_id=@id",
                    GetParameters()
                );
        }

        public void Delete()
        {
            if (Id != -1)
                Database.Execute(
                    "DELETE FROM relation WHERE relation_id=" + Id, null
                );
        }

        public static IEnumerable<Relation> GetAll()
        {
            var rows = Database.Select("SELECT * FROM relation");
            foreach (var row in rows)
                yield return new Relation(row);
        }

        public static IEnumerable<Relation> GetByCourse(Course course)
        {
            var rows = Database.Select(
                "SELECT rel.* FROM relation rel JOIN class_relation clr ON clr.rel_relation_id = rel.relation_id WHERE clr.cla_class_id=" +
                course.Id);
            foreach (var r in rows)
                yield return new Relation(r);
        }

        #endregion

        #region ISearchable Members

        public double CalcSearchScore(string key)
        {
            if (Firstname.StartsWith(key, StringComparison.OrdinalIgnoreCase))
                return 1;

            if (Surname.StartsWith(key, StringComparison.OrdinalIgnoreCase))
                return 0.99;

            if ((Firstname + Surname).ToUpper().Contains(key.ToUpper()))
                return 0.6;

            if (Email != null && Email.ToUpper().Contains(key.ToUpper()))
                return 0.6;

            if (PhoneHome != null && PhoneHome.Contains(key))
                return 0.3;

            if (PhoneMobile != null && PhoneMobile.Contains(key))
                return 0.3;

            return 0;
        }

        public double CalcSearchScore(string[] keys)
        {
            if (keys.Length == 0)
                return 0;

            double score = 0;
            foreach (var key in keys)
                score += CalcSearchScore(key);

            return score / keys.Length;
        }

        #endregion
    }
}