using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.Attributes;
using NHibernate.Tool.hbm2ddl;
using PostgreSQLforOtus.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
					.AddInputStream(HbmSerializer.Default.Serialize(Assembly.GetExecutingAssembly()))
					.SetInterceptor(new SqlDebugOutputInterceptorc());
				sessionFactory = configuration.BuildSessionFactory();

				new SchemaUpdate(configuration).Execute(true, true);
			}
			catch (Exception ex)
			{
				throw;
			}
			
		}

		public void InsertOrUpdateEntity<T>(IEnumerable<T> locations) where T : IDataBaseEntity
		{
			foreach (var item in locations)
			{
				using (ISession session = sessionFactory.OpenSession())
				{
					using (ITransaction transaction = session.BeginTransaction())
					{
						session.SaveOrUpdate(item);
						transaction.Commit();
					}
				}
			}
		}

		public List<Location> GetAllLocations()
		{
			using (ISession session = sessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					return session.Query<Location>().ToList();
				}
			}
		}
		public List<Teacher> GetAllTeachers()
		{
			using (ISession session = sessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					return session.Query<Teacher>().ToList();
				}
			}
		}
		public List<Сourse> GetAllСourses()
		{
			using (ISession session = sessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					return session.Query<Сourse>().ToList();
				}
			}
		}
	}
}
