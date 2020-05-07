using Repository.models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class Controller : MarshalByRefObject, IObserver
    {
        public event EventHandler<UserEventArgs> updateEvent;
        IServices server;
        public Controller(IServices server)
        {
            this.server = server;
        }

        private void Update(UserEventArgs args)
        {
            if (updateEvent == null)
                return;
            updateEvent(this, args);
        }

        void IObserver.LoadTableView(Match match)
        {
            UserEventArgs userArgs = new UserEventArgs(UserEvent.LoadTable, match);
            Update(userArgs);
        }

        public void Login(Seller seller)
        {
            server.Login(seller, this);
        }

        public List<Match> GetAllMatches()
        {
            return server.GetAllMatches();
        }

        public void SaveClient(Client client)
        {
            server.SaveClient(client);
        }

        public List<Client> GetAllClients()
        {
            return server.GetAllClients();
        }

        public void UpdateMatch(Match match)
        {
            server.UpdateMatch(match);
        }

        public void LoadComboBox(Client client)
        {
            UserEventArgs userArgs = new UserEventArgs(UserEvent.LoadComboBox, client);
            Update(userArgs);
        }
    }
}
