using Repository.models;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Login : Form
    {
        private Controller controller;

        public Login(Controller controller)
        {
            InitializeComponent();

            this.controller = controller;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                var seller = new Seller() { Name = user.Text, Password = password.Text };
                var ticketsMangement = new TicketsManagementForm(controller);
                controller.Login(seller);
                this.Hide();
                errorMessage.Visible = false;   
                ticketsMangement.Show();
            }
            catch (Exception)
            {
                errorMessage.Visible = true;
            }
        }
    }
}
