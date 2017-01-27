using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using StudIS.DAL.Mappings;
using System.Data.SqlClient;
using System.IO;
using NHibernate.Cfg;

namespace StudIS.DAL.Tests
{

    public class NHibernateService2 : INHibernateService
    {
        private static ISessionFactory _sessionFactory;
        private ISession _session;
        Configuration confg;

        public NHibernateService2()
        {
            OpenSessionFactory();
        }
        public ISession OpenSession()
        {
            try
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = OpenSessionFactory();
                }
                ISession session = _session;//_sessionFactory.OpenSession(_session.Connection);
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
                //.Database(SQLiteConfiguration.Standard
                //    .ConnectionString("Data Source=TestNHibernate_fluent.db;Version=3")
                //    .AdoNetBatchSize(100))
                .Database(SQLiteConfiguration.Standard
                        .InMemory()
                        // .UsingFile("C:\\Users\\Zlatko\\Source\\Repos\\OO-projekt\\StudIS\\SQLliteConfig\\bin\\Debug\\firstProject.db")
                         )  
                .Mappings(mappings => mappings.FluentMappings.Add<AdministratorMap>())
                .Mappings(mappings => mappings.FluentMappings.Add<LecturerMap>())
                .Mappings(mappings => mappings.FluentMappings.Add<UserMap>())
                .Mappings(mappings => mappings.FluentMappings.Add<CourseMap>())
                .Mappings(mappings => mappings.FluentMappings.Add<ComponentMap>())
                .Mappings(mappings => mappings.FluentMappings.Add<ScoreMap>())
                .Mappings(mappings => mappings.FluentMappings.Add<StudentMap>())
                .ExposeConfiguration(cfg =>confg=cfg)
                .BuildConfiguration();


            var sessionFactory = nhConfig.BuildSessionFactory();
            _sessionFactory = sessionFactory;
            _session = sessionFactory.OpenSession();

            new NHibernate.Tool.hbm2ddl.SchemaExport(confg).Execute(true, true, false,_session.Connection,null);

            
    


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
