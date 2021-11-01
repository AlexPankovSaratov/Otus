using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PostgreSQLforOtus.Config
{
	public class DbManager
	{
		private string connectionString;
		private Configuration configuration;
		private Dictionary<string, string> configProperties;
		private ISessionFactory sessionFactory;

		public DbManager(string conString)
		{
			try
			{
				this.connectionString = conString;
				configProperties = new Dictionary<string, string>
			{
				{
					NHibernate.Cfg.Environment.ConnectionDriver,
					typeof(NHibernate.Driver.NpgsqlDriver).FullName
				},
				{
					NHibernate.Cfg.Environment.Dialect,
					typeof(NHibernate.Dialect.PostgreSQL82Dialect).FullName
				},
				{
					NHibernate.Cfg.Environment.ConnectionString,
					connectionString
				}
			};
				configuration = new Configuration()
					.SetProperties(configProperties)
					//.AddInputStream(HbmSerializer.Default.Serialize(Assembly.GetExecutingAssembly()))
					.SetInterceptor(new SqlDebugOutputInterceptorc());
				sessionFactory = configuration.BuildSessionFactory();
			}
			catch (Exception ex)
			{
				throw;
			}
			
		}
	}
}
