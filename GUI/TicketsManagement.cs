using Repository.models;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class TicketsManagementForm : Form
    {
        private Controller controller;
        private List<Match> matches;
        private List<Client> clients;
        public TicketsManagementForm(Controller controller)
        {
            this.controller = controller;
            controller.updateEvent += Update;
            InitializeComponent();
        }

        public void Update(object sender, UserEventArgs e)
        {
            if(e.UserEventType == UserEvent.LoadTable) 
            {
                Match updatedMatch = (Match)e.Data;
                var matchId = matches.IndexOf(matches.FirstOrDefault(m => m.Id == updatedMatch.Id));
                matches[matchId] = updatedMatch;
                listBoxMatches.BeginInvoke(new UpdateListViewCallback(UpdateTableView), new object[] { listBoxMatches, matches });
            }
            else
            {
                Client client = (Client) e.Data;


                clientsComboBox.BeginInvoke(new UpdateComboBoxCallback(UpdateComboBox), new object[] { clientsComboBox, client });
            }
        }

        public delegate void UpdateListViewCallback(ListBox list, List<Match> data);

        public delegate void UpdateComboBoxCallback(ComboBox list, Client data);

        private void UpdateComboBox(ComboBox list, Client client)
        {
            list.Items.Add(client.Name);
            Application.DoEvents();
        }

        private void UpdateTableView(ListBox list, List<Match> matches)
        {
            listBoxMatches.DataSource = null;
            List<String> listOfMatchStrings = matches.Select(x => x.ToString()).ToList();
            listBoxMatches.DataSource = listOfMatchStrings;
            Application.DoEvents();
        }

        private void LoadTableView()
        {
            listBoxMatches.DataSource = null;
            List<String> listOfMatchStrings = matches.Select(x => x.ToString()).ToList();
            listBoxMatches.DataSource = listOfMatchStrings;
        }

        private void ticketsManagementForm_Load(object sender, EventArgs e)
        {
            matches = controller.GetAllMatches().OrderByDescending(x => x.PlacesRemaining).ToList();
            LoadTableView();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            clients = controller.GetAllClients().ToList();
            foreach (var client in clients)
                clientsComboBox.Items.Add(client.Name);
        }

        private void addClientButton_Click(object sender, EventArgs e)
        {
            var clientSelected = new Client() { Name = client.Text };
            controller.SaveClient(clientSelected);
        }

        private void butATicketButton_Click(object sender, EventArgs e)
        {
            var clientSelected = clients[clientsComboBox.SelectedIndex];
            var matchSelected = matches[listBoxMatches.SelectedIndex];
            var numberOfPlaces = Int32.Parse(places.Text);
            var ticket = new Ticket()
            {
                Id = Tuple.Create(clientSelected.Id, matchSelected.Id),
                PlacesTaken = numberOfPlaces
            };

            matchSelected.PlacesRemaining -= numberOfPlaces;
            controller.UpdateMatch(matchSelected);
        }   
    }
}
