using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using StudIS.DAL.Mappings;

namespace StudIS.DAL
{

    public class NHibernateService : INHibernateService
    {
        private static ISessionFactory _sessionFactory;


        public ISession OpenSession()
        {
            try
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = OpenSessionFactory();
                }
                ISession session = _sessionFactory.OpenSession();
                return session;
            }
            catch (Exception e)
            {
                throw e.InnerException ?? e;
            }
        }

        private ISessionFactory OpenSessionFactory()
        {
            var nhConfig = Fluently.Configure()
                .Diagnostics(diag => diag.Enable().OutputToConsole())
                .Database(SQLiteConfiguration.Standard
                    .ConnectionString("Data Source=TestNHibernate_fluent.db;Version=3")
                    .AdoNetBatchSize(100))
                //.Mappings(mappings => mappings.FluentMappings.AddFromAssemblyOf<AdministratorMap>())
                //.Mappings(mappings => mappings.FluentMappings.AddFromAssemblyOf<LecturerMap>())
                //.Mappings(mappings => mappings.FluentMappings.AddFromAssemblyOf<StudentMap>())
                .Mappings(mappings => mappings.FluentMappings.AddFromAssemblyOf<CourseMap>())
                .Mappings(mappings => mappings.FluentMappings.AddFromAssemblyOf<ComponentMap>())
                .Mappings(mappings => mappings.FluentMappings.AddFromAssemblyOf<ScoreMap>())
                .BuildConfiguration();

            var sessionFactory = nhConfig.BuildSessionFactory();

            return sessionFactory;
        }
        /*
         *    //public IDatabase Database { private get; set; }
                //public NhibernateService(IDatabase database)
                //{
                //    Database = database;
                //}

                public void CreateDatabaseAndSchema()
                {
                    _sessionFactory = null; //obriše se eventualni prošli session
                    if (Database == null)
                    {
                        return;
                    }
                    Database.CreateDatabase(Database.DBInfo);
                    CreateSchema();
                }

                private void CreateSchema()
                {
                    var configuration = Database.GetFluentConfiguration();
                    configuration.Mappings(m => m.FluentMappings.AddFromAssemblyOf<InspectionMapping>()).
                                  ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true)).
                                  BuildSessionFactory();
                }

                public ISession CreateSchemaOpenSession(IDatabaseInfo inDB)
                {
                    _sessionFactory = null; //obriše se eventualni prošli session
                    if (Database == null)
                    {
                        return null;
                    }
                    CreateSchema();
                    return OpenSession();
                }
                */
    }
}
