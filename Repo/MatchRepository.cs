using Repository.Connection;
using Repository.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Repository
{
    public class MatchRepository : IRepository<Match>
    {
        public void Delete(object id)
        {
            IDbConnection connection = DbConnection.getConnection();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "delete from Match where id=@id";
                IDbDataParameter parameter = command.CreateParameter();
                parameter.ParameterName = "@id";
                parameter.Value = id;
                command.Parameters.Add(parameter);
                var dataReader = command.ExecuteNonQuery();

                if (dataReader == 0)
                    throw new Exception("No match deleted!");
            }
        }

        public ICollection<Match> GetAll()
        {
            IDbConnection connection = DbConnection.getConnection();
            IList<Match> matches = new List<Match>();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from Match";

                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        int id = dataReader.GetInt32(0);
                        String name = dataReader.GetString(1);
                        int price = dataReader.GetInt32(2);
                        int places = dataReader.GetInt32(3);
                        Match match = new Match() { Id = id, Name = name, Price = price, PlacesRemaining = places };
                        matches.Add(match);
                    }
                }
            }

            return matches;
        }

        public Match GetById(object id)
        {
            IDbConnection connection = DbConnection.getConnection();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from Match where id=@id";
                IDbDataParameter parameters = command.CreateParameter();
                parameters.ParameterName = "@id";
                parameters.Value = id;
                command.Parameters.Add(parameters);

                using (var dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        String name = dataReader.GetString(1);
                        int price = dataReader.GetInt32(2);
                        int places = dataReader.GetInt32(3);
                        return new Match { Id = (int)id, Name = name, Price = price, PlacesRemaining = places };
                    }
                }
            }
            return null;
        }

        public void Save(Match entity)
        {
            var connection = DbConnection.getConnection();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "insert into Match(name, price, places) values (@name, @price, @places)";
                var nameParameter = command.CreateParameter();
                nameParameter.ParameterName = "@name";
                nameParameter.Value = entity.Name;
                command.Parameters.Add(nameParameter);

                var priceParameter = command.CreateParameter();
                priceParameter.ParameterName = "@price";
                priceParameter.Value = entity.Price;
                command.Parameters.Add(priceParameter);

                var placesParameter = command.CreateParameter();
                placesParameter.ParameterName = "@places";
                placesParameter.Value = entity.PlacesRemaining;
                command.Parameters.Add(placesParameter);

                var result = command.ExecuteNonQuery();
                if (result == 0)
                    throw new Exception("No match added !");
            }
        }

        public void Update(Match entity)
        {
            IDbConnection connection = DbConnection.getConnection();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "Update Match set name = @name, price = @price, places = @places where id=@id";
                IDbDataParameter idParameter = command.CreateParameter();
                idParameter.ParameterName = "@id";
                idParameter.Value = entity.Id;
                command.Parameters.Add(idParameter);

                IDbDataParameter nameParameter = command.CreateParameter();
                nameParameter.ParameterName = "@name";
                nameParameter.Value = entity.Name;
                command.Parameters.Add(nameParameter);

                var priceParameter = command.CreateParameter();
                priceParameter.ParameterName = "@price";
                priceParameter.Value = entity.Price;
                command.Parameters.Add(priceParameter);

                var placesParameter = command.CreateParameter();
                placesParameter.ParameterName = "@places";
                placesParameter.Value = entity.PlacesRemaining;
                command.Parameters.Add(placesParameter);

                var dataReader = command.ExecuteNonQuery();
                if (dataReader == 0)
                    throw new Exception("No client updated!");
            }
        }
    }
}
