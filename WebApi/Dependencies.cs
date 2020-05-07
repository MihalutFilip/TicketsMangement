using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi
{
    public static class DependenciesFactory
    {
        public static IServices GetService()
        {
            ClientRepository clientRepository = new ClientRepository();
            MatchRepository matchRepository = new MatchRepository();
            SellerRepository sellerRepository = new SellerRepository();
            TicketRepository ticketRepository = new TicketRepository();
            return new ServiceImpl(clientRepository, matchRepository, sellerRepository, ticketRepository);
        }
    }
}