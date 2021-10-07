using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetShopForms.Vistas.Menu
{
    public partial class MenuEmpleado : Form
    {
        Inicio inicioForm;
        Inicio InicioForm
        {
            get { return this.inicioForm; }
            set { this.inicioForm = value; }
        }
        public MenuEmpleado(Inicio inicioForm)
        {
            InitializeComponent();
            this.InicioForm = inicioForm;
        }
       
        private void btnClientes_Click(object sender, EventArgs e)
        {
            InicioForm.ChangeBody(new Clientes.Listado());
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            InicioForm.ChangeBody(new Ventas.Listado());
        }
       
    }
}
