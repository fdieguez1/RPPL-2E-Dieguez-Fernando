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
        Cliente clienteSeleccionado;
        Producto productoSeleccionado;
        int unidades;

        public Cliente ClienteSeleccionado
        {
            get
            {
                return this.clienteSeleccionado;
            }
            set
            {
                this.clienteSeleccionado = value;
            }
        }

        public Producto ProductoSeleccionado
        {
            get
            {
                return this.productoSeleccionado;
            }
            set
            {
                this.productoSeleccionado = value;
            }
        }
        public int Unidades
        {
            get
            {
                return this.unidades;
            }
            set
            {
                this.unidades = value;
            }
        }

        public VentaData()
        {
            InitializeComponent();
        }

        private void VentaData_Load(object sender, EventArgs e)
        {
            dgvProductos.DataSource = Producto.ListaProductos;
            dgvClientes.DataSource = Core.ListaClientes;
            this.txtUnidades.Text = "0";
            this.dgvProductos.ClearSelection();
            this.dgvClientes.ClearSelection();
        }

        private void btnAddUnit_Click(object sender, EventArgs e)
        {
            if (this.txtUnidades.Text.Length > 0)
            {
                int value = int.Parse(this.txtUnidades.Text);
                value++;
                this.txtUnidades.Text = value.ToString();
            }
        }

        private void txtUnidades_TextChanged(object sender, EventArgs e)
        {
            if (this.txtUnidades.Text.Length > 0)
            {
                if (Validaciones.ValidarDouble(this.txtUnidades.Text))
                    this.Unidades = int.Parse(this.txtUnidades.Text);
                else
                {
                    this.txtUnidades.Text = "0";
                    MessageBox.Show("Solo estan permitidos numeros",
                                         "Error",
                                         MessageBoxButtons.OK);
                }
            }
        }

        private void btnRemoveUnit_Click(object sender, EventArgs e)
        {
            if (this.txtUnidades.Text.Length > 0)
            {
                int value = int.Parse(this.txtUnidades.Text);
                if (value > 0)
                {
                    value--;
                    this.txtUnidades.Text = value.ToString();
                }
            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductoSeleccionado = (Producto)dgvProductos.CurrentRow.DataBoundItem;

        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ClienteSeleccionado = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
        }
    }
}
