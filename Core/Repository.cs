using System.ComponentModel;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Los.CoreCore;
using NHibernate;
using NHibernate.Linq;

namespace Core
{
    public class Repository
    {

        public Repository()
        {
            var cs = "Server=fmc-online.nl; Port=3306; Database = qb306340_los-d; Uid = qb306340_los-d; Pwd = dev-los;";
            SessionFactory = Fluently.Configure()
                .Database(MySQLConfiguration.Standard
                    .ConnectionString(cs))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RelationMapping>())
                .BuildSessionFactory();
        }

        public static readonly ISession Session = new Repository().SessionFactory.OpenSession();

        public ISessionFactory SessionFactory { get; }

        public static T Get<T>(object id) => Session.Get<T>(id);

        public static T[] GetAll<T>() => Session.Query<T>().ToArray();

        public static void Delete(object entity) => Session.Delete(entity);

        public static T Save<T>(T entity)
        {
            Session.Save(entity); 
            return entity;
        }

        public static IQueryable<T> Query<T>() => Session.Query<T>();
    }
}