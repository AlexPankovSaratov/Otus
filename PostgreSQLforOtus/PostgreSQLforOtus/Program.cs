using PostgreSQLforOtus.Config;
using System;

namespace PostgreSQLforOtus
{
	class Program
	{
		static void Main(string[] args)
		{
			DbManager dbManager = new DbManager("Server=localhost;Port=5432;Database=Otus;User Id=postgres;Password=123;");

		}
	}
}
 