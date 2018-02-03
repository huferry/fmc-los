using System;
using System.ComponentModel.DataAnnotations;

namespace Los.Core
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Relation : ISearchable
    {
        public virtual int Id { get; set; }

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

        public virtual string Surname { get; set; }

        public virtual string Firstname { get; set; }

        public virtual DateTime? Birthday { get; set; }

        public virtual string PhoneHome { get; set; }

        public virtual string PhoneMobile { get; set; }

        public virtual string Email { get; set; }

        public virtual string Language { get; set; }

        public virtual Gender Gender
        {
            get => GenderValue == "M" ? Gender.Male : Gender.Female;
            set => GenderValue = value == Gender.Female ? "F" : "M";
        }

        public virtual string GenderValue { get; set; }

        public virtual bool IsCareLeader { get; set; }

        public virtual int? CareLeaderId { get; set; }

        public virtual Relation CareLeader { get; set; }

        public virtual bool Approved { get; set; }

        #endregion

        #region ISearchable Members

        public virtual double CalcSearchScore(string key)
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

        public virtual double CalcSearchScore(string[] keys)
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