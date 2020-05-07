using System;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using System.Data.SqlClient;


namespace Repository.Connection
{
	public class SqliteConnectionFactory : ConnectionFactory
	{
		public override IDbConnection createConnection()
		{
			//Windows Sqlite Connection, fisierul.db ar trebuie sa fie in directorul debug/ bin
			String connectionString = "Data Source=C:\\sqlite\\basketball.db; FailIfMissing=True";
			return new SqliteConnection(connectionString);
		}
	}
}
