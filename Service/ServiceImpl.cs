using Repository;
using Repository.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceImpl : MarshalByRefObject, IServices
    {
        private ClientRepository _clientRepository;
        private MatchRepository _matchRepository;
        private SellerRepository _sellerRepository;
        private TicketRepository _ticketRepository;
        private List<IObserver> loggedSellers;

        public ServiceImpl(ClientRepository clientRepository, MatchRepository matchRepository, SellerRepository sellerRepository, TicketRepository ticketRepository)
        {
            _clientRepository = clientRepository;
            _matchRepository = matchRepository;
            _sellerRepository = sellerRepository;
            _ticketRepository = ticketRepository;
            loggedSellers = new List<IObserver>();
        }

        public List<Client> GetAllClients()
        {
            return _clientRepository.GetAll().ToList();
        }

        public List<Match> GetAllMatches()
        {
            return _matchRepository.GetAll().ToList();
        }

        public void Login(Seller seller, IObserver loginSeller)
        {
            Seller dbSeller = _sellerRepository.GetAll().FirstOrDefault(s => seller.Name == s.Name && seller.Password == s.Password);
            if (dbSeller == null)
                throw new Exception("Authentication failed.");
            loggedSellers.Add(loginSeller);
        }

        public void SaveClient(Client client)
        {
            _clientRepository.Save(client);

            foreach (var seller in loggedSellers)
            {
                seller.LoadComboBox(client);
            }
        }

        public void UpdateMatch(Match match)
        {
            _matchRepository.Update(match);
            NotifyObserver(match);
        }

        private void NotifyObserver(Match match)
        {
            foreach(var seller in loggedSellers)
            {
                seller.LoadTableView(match);
            }
        }
    }
}
