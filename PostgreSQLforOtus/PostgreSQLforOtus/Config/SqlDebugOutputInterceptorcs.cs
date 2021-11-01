using NHibernate;
using NHibernate.SqlCommand;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PostgreSQLforOtus.Config
{
	class SqlDebugOutputInterceptorc : EmptyInterceptor
	{
		public override SqlString OnPrepareStatement(SqlString sql)
		{
			Debug.Write("NHibernate: ");
			Debug.WriteLine(sql);
			return base.OnPrepareStatement(sql);
		}
	}
}
