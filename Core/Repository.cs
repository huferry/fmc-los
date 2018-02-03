using System.Configuration;
using System.Linq;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Los.CoreCore;
using NHibernate;
using NHibernate.Linq;

namespace Core
{
    public class Repository
    {
        public static readonly ISession Session = new Repository().SessionFactory.OpenSession();

        public Repository()
        {
            var host = ConfigurationManager.AppSettings["host"];
            var db = ConfigurationManager.AppSettings["database"];
            var user = ConfigurationManager.AppSettings["user"];
            var pwd = ConfigurationManager.AppSettings["password"];
            var cs = $"Server={host}; Port=3306; Database={db};" +
                     $"Uid={user};" +
                     $"Pwd={pwd};";

            SessionFactory = Fluently.Configure()
                .Database(MySQLConfiguration.Standard
                    .ConnectionString(cs))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RelationMapping>())
                .BuildSessionFactory();
        }

        public ISessionFactory SessionFactory { get; }

        public static T Get<T>(object id)
        {
            return Session.Get<T>(id);
        }

        public static T[] GetAll<T>()
        {
            return Session.Query<T>().ToArray();
        }

        public static void Delete(object entity)
        {
            Session.Delete(entity);
        }

        public static T Save<T>(T entity)
        {
            Session.Save(entity);
            return entity;
        }

        public static IQueryable<T> Query<T>()
        {
            return Session.Query<T>();
        }
    }
}