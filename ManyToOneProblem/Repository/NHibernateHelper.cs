using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.IO;
using System.Reflection;

namespace ManyToOneProblem.Repository
{
    public static class NHibernateHelper
    {
        private static ISessionFactory sessionFactory;
        private static string _path;

        private static ISessionFactory SessionFactory()
        {
            if (sessionFactory != null) return sessionFactory;
            sessionFactory = Config.BuildSessionFactory();
            return sessionFactory;
        }

        private static Configuration configuration = null;

        public static Configuration Config
        {
            get
            {
                if (configuration != null) return configuration;
                configuration = new Configuration().Configure();
                return configuration;
            }
        }

        public static void CreateDb()
        {
            var schemaExport = new SchemaExport(Config);
            schemaExport.Create(true, true);
        }

        public static ISession OpenSession()
        {
            return SessionFactory().OpenSession();
        }

    }
}
