using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetShopForms.Vistas.Ventas
{
    public partial class Ticket : Form
    {
        string ticketBody;
        public string TicketBody
        {
            get
            {
                return this.ticketBody;
            }
            set
            {
                this.ticketBody = value;
            }
        }
        public Ticket(string ticketBody)
        {
            InitializeComponent();
            this.TicketBody = ticketBody;
        }

        private void Ticket_Load(object sender, EventArgs e)
        {
            this.lblTicket.Text = this.TicketBody;
        }
    }
}
