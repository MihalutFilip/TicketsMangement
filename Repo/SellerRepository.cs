using Repository.Connection;
using Repository.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Repository
{
    public class SellerRepository : IRepository<Seller>
    {
        public void Delete(object id)
        {
            IDbConnection connection = DbConnection.getConnection();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "delete from Seller where id=@id";
                IDbDataParameter parameter = command.CreateParameter();
                parameter.ParameterName = "@id";
                parameter.Value = id;
                command.Parameters.Add(parameter);
                var dataReader = command.ExecuteNonQuery();

                if (dataReader == 0)
                    throw new Exception("No seller deleted!");
            }
        }

        public ICollection<Seller> GetAll()
         {
            IDbConnection connection = DbConnection.getConnection();
            IList<Seller> sellers = new List<Seller>();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from Seller";

                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        int id = dataReader.GetInt32(0);
                        String name = dataReader.GetString(1);
                        String password = dataReader.GetString(2);
                        Seller seller = new Seller() { Id = id, Name = name, Password = password };
                        sellers.Add(seller);
                    }
                }
            }

            return sellers;
        }

        public Seller GetById(object id)
        {
            IDbConnection connection = DbConnection.getConnection();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from Seller where id=@id";
                IDbDataParameter parameters = command.CreateParameter();
                parameters.ParameterName = "@id";
                parameters.Value = id;
                command.Parameters.Add(parameters);

                using (var dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        String name = dataReader.GetString(1);
                        String password = dataReader.GetString(1);
                        return new Seller { Id = (int)id, Name = name, Password = password };
                    }
                }
            }
            return null;
        }

        public void Save(Seller entity)
        {
            var connection = DbConnection.getConnection();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "insert into Seller(name, password) values (@name, @password)";
                var nameParameter = command.CreateParameter();
                nameParameter.ParameterName = "@name";
                nameParameter.Value = entity.Name;
                command.Parameters.Add(nameParameter);

                var passwordParameter = command.CreateParameter();
                passwordParameter.ParameterName = "@password";
                passwordParameter.Value = entity.Password;
                command.Parameters.Add(passwordParameter);

                var result = command.ExecuteNonQuery();
                if (result == 0)
                    throw new Exception("No seller added !");
            }
        }

        public void Update(Seller entity)
        {
            IDbConnection connection = DbConnection.getConnection();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "Update Seller set name = @name, password = @password where id=@id";
                IDbDataParameter idParameter = command.CreateParameter();
                idParameter.ParameterName = "@id";
                idParameter.Value = entity.Id;
                command.Parameters.Add(idParameter);

                IDbDataParameter nameParameter = command.CreateParameter();
                nameParameter.ParameterName = "@name";
                nameParameter.Value = entity.Name;
                command.Parameters.Add(nameParameter);

                IDbDataParameter passwordParameter = command.CreateParameter();
                passwordParameter.ParameterName = "@password";
                passwordParameter.Value = entity.Password;
                command.Parameters.Add(passwordParameter);

                var dataReader = command.ExecuteNonQuery();
                if (dataReader == 0)
                    throw new Exception("No seller updated!");
            }
        }
    }
}
