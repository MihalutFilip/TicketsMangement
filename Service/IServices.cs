using Repository.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IServices
    {
        void Login(Seller seller, IObserver client);

        List<Match> GetAllMatches();

        List<Client> GetAllClients();

        void SaveClient(Client client);

        void UpdateMatch(Match match);
    }
}
