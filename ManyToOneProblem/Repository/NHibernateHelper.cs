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

        private static string ConfigurationFile => Path.Combine(GetPath(), "nhibernate.cfg.xml");
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
                configuration = new Configuration().Configure(ConfigurationFile);
                return configuration;
            }
        }


        public static string GetPath()
        {
            if (_path != null) return _path;
            var x = new Uri(Assembly.GetExecutingAssembly().CodeBase);
            _path = Path.GetDirectoryName(x.LocalPath);
            return _path;
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
