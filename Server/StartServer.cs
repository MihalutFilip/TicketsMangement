using Repository;
using Service;
using System;
using System.Collections;
using System.Net.Sockets;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading;

namespace Server
{
    class StartServer
    {
        static void Main(string[] args)
        {
            BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
            serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            BinaryClientFormatterSinkProvider clientProv = new BinaryClientFormatterSinkProvider();
            IDictionary props = new Hashtable();

            props["port"] = 55555;
            TcpChannel channel = new TcpChannel(props, clientProv, serverProv);
            ChannelServices.RegisterChannel(channel, false);

            ClientRepository clientRepository = new ClientRepository();
            MatchRepository matchRepository = new MatchRepository();
            SellerRepository sellerRepository = new SellerRepository();
            TicketRepository ticketRepository = new TicketRepository();
            var server = new ServiceImpl(clientRepository, matchRepository, sellerRepository, ticketRepository);
            //var server = new ChatServerImpl();
            RemotingServices.Marshal(server, "Chat");
            //RemotingConfiguration.RegisterWellKnownServiceType(typeof(ChatServerImpl), "Chat",
            //    WellKnownObjectMode.Singleton);

            // the server will keep running until keypress.
            Console.WriteLine("Server started ...");
            Console.WriteLine("Press <enter> to exit...");
            Console.ReadLine();

        }
    }

}
