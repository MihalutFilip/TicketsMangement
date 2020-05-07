using Repository.Connection;
using Repository.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Repository
{
    public class TicketRepository : IRepository<Ticket>
    {
        public void Delete(object id)
        {
            IDbConnection connection = DbConnection.getConnection();
            using (var command = connection.CreateCommand())
            {
                Tuple<int, int> pair = (Tuple<int, int>) id;

                command.CommandText = "delete from Ticket where client_id = @client_id and match_id = @match_id";
                IDbDataParameter clientIdParameter = command.CreateParameter();
                clientIdParameter.ParameterName = "@client_id";
                clientIdParameter.Value = pair.Item1;
                command.Parameters.Add(clientIdParameter);

                IDbDataParameter matchIdParameter = command.CreateParameter();
                matchIdParameter.ParameterName = "@match_id";
                matchIdParameter.Value = pair.Item2;
                command.Parameters.Add(matchIdParameter);

                var dataReader = command.ExecuteNonQuery();

                if (dataReader == 0)
                    throw new Exception("No ticket deleted!");
            }
        }

        public ICollection<Ticket> GetAll()
        {
            IDbConnection connection = DbConnection.getConnection();
            IList<Ticket> tickets = new List<Ticket>();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from Ticket";

                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        int clientId = dataReader.GetInt32(0);
                        int matchId = dataReader.GetInt32(1);
                        int places = dataReader.GetInt32(2);
                        Ticket ticket = new Ticket() { Id = Tuple.Create(clientId, matchId) , PlacesTaken = places };
                        tickets.Add(ticket);
                    }
                }
            }

            return tickets;
        }

        public Ticket GetById(object id)
        {
            IDbConnection connection = DbConnection.getConnection();

            using (var command = connection.CreateCommand())
            {
                Tuple<int, int> pair = (Tuple<int, int>)id; 

                command.CommandText = "select * from Ticket where client_id = @client_id and match_id = @match_id";
                IDbDataParameter clientIdParameter = command.CreateParameter();
                clientIdParameter.ParameterName = "@client_id";
                clientIdParameter.Value = pair.Item1;
                command.Parameters.Add(clientIdParameter);

                IDbDataParameter matchIdParameter = command.CreateParameter();
                matchIdParameter.ParameterName = "@match_id";
                matchIdParameter.Value = pair.Item2;
                command.Parameters.Add(matchIdParameter);

                using (var dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        int places = dataReader.GetInt32(2);
                        return new Ticket() { Id = pair, PlacesTaken = places };
                    }
                }
            }
            return null;
        }

        public void Save(Ticket entity)
        {
            var connection = DbConnection.getConnection();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "insert into Ticket(client_id, match_id, places) values (@client_id, @match_id, @places)";
                var clientIdParameter = command.CreateParameter();
                clientIdParameter.ParameterName = "@client_id";
                clientIdParameter.Value = entity.Id.Item1;
                command.Parameters.Add(clientIdParameter);

                var matchIdParameter = command.CreateParameter();
                matchIdParameter.ParameterName = "@match_id";
                matchIdParameter.Value = entity.Id.Item2;
                command.Parameters.Add(matchIdParameter);

                var placesParameter = command.CreateParameter();
                placesParameter.ParameterName = "@places";
                placesParameter.Value = entity.PlacesTaken;
                command.Parameters.Add(placesParameter);

                var result = command.ExecuteNonQuery();
                if (result == 0)
                    throw new Exception("No ticket added !");
            }
        }

        public void Update(Ticket entity)
        {
            IDbConnection connection = DbConnection.getConnection();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "Update Ticket set places = @places where client_id=@client_id and match_id=@match_id";
                var clientIdParameter = command.CreateParameter();
                clientIdParameter.ParameterName = "@client_id";
                clientIdParameter.Value = entity.Id.Item1;
                command.Parameters.Add(clientIdParameter);

                var matchIdParameter = command.CreateParameter();
                matchIdParameter.ParameterName = "@match_id";
                matchIdParameter.Value = entity.Id.Item2;
                command.Parameters.Add(matchIdParameter);

                var placesParameter = command.CreateParameter();
                placesParameter.ParameterName = "@places";
                placesParameter.Value = entity.PlacesTaken;
                command.Parameters.Add(placesParameter);

                var dataReader = command.ExecuteNonQuery();
                if (dataReader == 0)
                    throw new Exception("No ticket updated!");
            }
        }
    }
}
