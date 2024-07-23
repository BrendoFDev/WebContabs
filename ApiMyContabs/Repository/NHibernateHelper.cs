using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using ApiMyContabs.Repository.Entity;
using NHibernate.Tool.hbm2ddl;

namespace ApiMyContabs.Repository
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(PostgreSQLConfiguration.Standard.ConnectionString("Username=postgres; Password=softlog; Host=localhost; Port=5432; Database=MyContabs;"))
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<MappingMaker>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                .BuildSessionFactory();
        }

        private ISessionFactory SessionFactory
        {
            get 
            {
               if(_sessionFactory == null)
                    _sessionFactory = CreateSessionFactory();

                return _sessionFactory;
            }
        }

        public NHibernate.ISession OpenSession()
        {
            if (_sessionFactory == null)
            {
                _sessionFactory = CreateSessionFactory();
                return _sessionFactory.OpenSession();
            }
            return _sessionFactory.OpenSession();
        }
    }
}
