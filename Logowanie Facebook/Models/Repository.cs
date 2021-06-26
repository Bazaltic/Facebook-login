
using System;
using System.Collections.Generic;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
namespace Logowanie_Facebook.Models

{
    public sealed class Repository
    {
        ISessionFactory _sessionFactory;
        ISession _session;

        private static readonly Repository _instance = new Repository();

        private Repository()
        {
            InitializeSession();
        }

        public static Repository Instance
        {
            get
            {
                return _instance;
            }
        }

        void InitializeSession()
        {
            try
            {
                _sessionFactory = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString("Server=.\\sqlexpress; Database=FacebookData; Integrated Security=SSPI;"))
                    .Mappings(m => m
                    .FluentMappings.AddFromAssemblyOf<Repository>())
                    .BuildSessionFactory();
                _session = _sessionFactory.OpenSession();
            }
            catch (Exception ex)
            {
                throw ex;
            }
      

        }
        
    }
}

