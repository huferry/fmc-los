using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Los.Core
{
    enum ObjectType
    {
        Unknown = 0,
        Relation = 1
    }

    class ObjectCode
    {
        private ObjectType otype = ObjectType.Unknown;
        private int id;

        public ObjectCode(object obj)
        {
            foreach (ObjectType ot in Enum.GetValues(typeof(ObjectType)))
            {
                if (obj.GetType().Name == ot.ToString())
                    this.otype = ot;
            }

            try
            {                
                this.id = (int)obj.GetType().InvokeMember("id",
                    BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, obj, null);
            }
            catch
            {
                this.id = -1;
            }
        }

        public int Code
        {
            get
            {
                if (id > 0)
                {
                    return AddCheck(id * 11 + (int)otype);
                }
                return 0;
            }
        }

        static private int AddCheck(int code)
        {
            int total = 0;
            int c = code;
            int m = 2;
            while (c > 0)
            {
                total += (c % 10) * m++;
                c /= 10;
            }

            int rest = total % 7;

            return rest == 0 ? code * 10 : code * 10 + (7 - rest);
        }

        static public int GetObjectCode(object o)
        {
            return (new ObjectCode(o)).Code;
        }

        static public int GetId(int code, out ObjectType otype)
        {
            if (AddCheck(code / 10) == code)
            {
                try
                {
                    otype = (ObjectType)((code / 10) % 11);
                }
                catch
                {
                    otype = ObjectType.Unknown;
                    return 0;
                }
                return (code / 10) / 11;
            }
            otype = ObjectType.Unknown;
            return 0;           
        }

    }
}
