using Entidades;
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
    public partial class VentaData : Form
    {
        public VentaData()
        {
            InitializeComponent();
        }

        private void VentaData_Load(object sender, EventArgs e)
        {
            dgvProductos.DataSource = Producto.ListaProductos;
            dgvClientes.DataSource = Core.ListaClientes;
        }
    }
}
