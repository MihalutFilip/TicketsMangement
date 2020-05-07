using Repository.Connection;
using Repository.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Repository
{
    public class ClientRepository : IRepository<Client>
    {
        public void Delete(object id)
        {
			IDbConnection connection = DbConnection.getConnection();
			using (var command = connection.CreateCommand())
			{
				command.CommandText = "delete from Client where id=@id";
				IDbDataParameter parameter = command.CreateParameter();
				parameter.ParameterName = "@id";
				parameter.Value = id;
				command.Parameters.Add(parameter);
				var dataReader = command.ExecuteNonQuery();

				if (dataReader == 0)
					throw new Exception("No client deleted!");
			}
		}

        public ICollection<Client> GetAll()
        {
			IDbConnection connection = DbConnection.getConnection();
			IList<Client> clients = new List<Client>();
			using (var command = connection.CreateCommand())
			{
				command.CommandText = "select * from Client";

				using (var dataReader = command.ExecuteReader())
				{
					while (dataReader.Read())
					{
						int id = dataReader.GetInt32(0);
						String name = dataReader.GetString(1);
						Client client = new Client() { Id = id, Name = name };
						clients.Add(client);
					}
				}
			}

			return clients;
		}

        public Client GetById(object id)
        {
			IDbConnection connection = DbConnection.getConnection();

			using (var command = connection.CreateCommand())
			{
				command.CommandText = "select * from Client where id=@id";
				IDbDataParameter parameters = command.CreateParameter();
				parameters.ParameterName = "@id";
				parameters.Value = id;
				command.Parameters.Add(parameters);

				using (var dataReader = command.ExecuteReader())
				{
					if (dataReader.Read())
					{
						String name = dataReader.GetString(1);
						return new Client { Id = (int) id, Name = name };
					}
				}
			}
			return null;
		}

        public void Save(Client entity)
        {
			var connection = DbConnection.getConnection();

			using (var command = connection.CreateCommand())
			{
				command.CommandText = "insert into Client(name) values (@name)";
				var parameter = command.CreateParameter();
				parameter.ParameterName = "@name";
				parameter.Value = entity.Name;
				command.Parameters.Add(parameter);

				var result = command.ExecuteNonQuery();
				if (result == 0)
					throw new Exception("No client added !");
			}
		}

        public void Update(Client entity)
        {
			IDbConnection connection = DbConnection.getConnection();
			using (var command = connection.CreateCommand())
			{
				command.CommandText = "Update Client set name = @name where id=@id";
				IDbDataParameter idParameter = command.CreateParameter();
				idParameter.ParameterName = "@id";
				idParameter.Value = entity.Id;
				command.Parameters.Add(idParameter);

				IDbDataParameter nameParameter = command.CreateParameter();
				nameParameter.ParameterName = "@name";
				nameParameter.Value = entity.Name;
				command.Parameters.Add(nameParameter);

				var dataReader = command.ExecuteNonQuery();
				if (dataReader == 0)
					throw new Exception("No client updated!");
			}
		}
    }
}
