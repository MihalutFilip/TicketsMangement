namespace GUI
{
    partial class TicketsManagementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.butATicketButton = new System.Windows.Forms.Button();
            this.addClientButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxMatches = new System.Windows.Forms.ListBox();
            this.clientsComboBox = new System.Windows.Forms.ComboBox();
            this.places = new System.Windows.Forms.TextBox();
            this.client = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // butATicketButton
            // 
            this.butATicketButton.Location = new System.Drawing.Point(58, 135);
            this.butATicketButton.Name = "butATicketButton";
            this.butATicketButton.Size = new System.Drawing.Size(75, 23);
            this.butATicketButton.TabIndex = 1;
            this.butATicketButton.Text = "Buy a ticket";
            this.butATicketButton.UseVisualStyleBackColor = true;
            this.butATicketButton.Click += new System.EventHandler(this.butATicketButton_Click);
            // 
            // addClientButton
            // 
            this.addClientButton.Location = new System.Drawing.Point(525, 97);
            this.addClientButton.Name = "addClientButton";
            this.addClientButton.Size = new System.Drawing.Size(75, 23);
            this.addClientButton.TabIndex = 2;
            this.addClientButton.Text = "Add a client";
            this.addClientButton.UseVisualStyleBackColor = true;
            this.addClientButton.Click += new System.EventHandler(this.addClientButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(243, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "List of matches";
            // 
            // listBoxMatches
            // 
            this.listBoxMatches.FormattingEnabled = true;
            this.listBoxMatches.Location = new System.Drawing.Point(143, 59);
            this.listBoxMatches.Name = "listBoxMatches";
            this.listBoxMatches.Size = new System.Drawing.Size(344, 381);
            this.listBoxMatches.TabIndex = 4;
            // 
            // clientsComboBox
            // 
            this.clientsComboBox.FormattingEnabled = true;
            this.clientsComboBox.Location = new System.Drawing.Point(12, 62);
            this.clientsComboBox.Name = "clientsComboBox";
            this.clientsComboBox.Size = new System.Drawing.Size(121, 21);
            this.clientsComboBox.TabIndex = 6;
            // 
            // places
            // 
            this.places.Location = new System.Drawing.Point(12, 100);
            this.places.Name = "places";
            this.places.Size = new System.Drawing.Size(121, 20);
            this.places.TabIndex = 7;
            // 
            // client
            // 
            this.client.Location = new System.Drawing.Point(500, 59);
            this.client.Name = "client";
            this.client.Size = new System.Drawing.Size(100, 20);
            this.client.TabIndex = 8;
            // 
            // TicketsManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 460);
            this.Controls.Add(this.client);
            this.Controls.Add(this.places);
            this.Controls.Add(this.clientsComboBox);
            this.Controls.Add(this.listBoxMatches);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addClientButton);
            this.Controls.Add(this.butATicketButton);
            this.Name = "TicketsManagementForm";
            this.Text = "Tickets Management";
            this.Load += new System.EventHandler(this.ticketsManagementForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button butATicketButton;
        private System.Windows.Forms.Button addClientButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxMatches;
        private System.Windows.Forms.ComboBox clientsComboBox;
        private System.Windows.Forms.TextBox places;
        private System.Windows.Forms.TextBox client;
    }
}