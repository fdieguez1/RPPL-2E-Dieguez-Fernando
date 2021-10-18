using Entidades;
using Entidades.Enums;
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

        double totalUnidades;
        float costoEnvio;
        double costoEnvioTotal;
        double costoTotal;

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
        ETipoEnvio tipoEnvio;
        public ETipoEnvio TipoEnvio
        {
            get
            {
                return this.tipoEnvio;
            }
            set
            {
                this.cmbTipoEnvio.SelectedIndex = (int)value;
                this.tipoEnvio = value;
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
            ProductoSeleccionado = (Producto)this.dgvProductos.CurrentRow.DataBoundItem;
            ClienteSeleccionado = (Cliente)this.dgvClientes.CurrentRow.DataBoundItem;
            Array enums = Enum.GetValues(typeof(ETipoEnvio));
            foreach (var item in enums)
            {
                this.cmbTipoEnvio.Items.Add(item);
            }
            this.cmbTipoEnvio.SelectedItem = this.cmbTipoEnvio.Items[0];
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
                {
                    this.Unidades = int.Parse(this.txtUnidades.Text);
                    this.CargarCostos();
                }
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
            this.CargarCostos();
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ClienteSeleccionado = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
            this.CargarCostos();
        }

        private void cmbTipoEnvio_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.TipoEnvio = (ETipoEnvio)this.cmbTipoEnvio.SelectedItem;
            this.CargarCostos();
        }
        void CargarCostos()
        {
            totalUnidades = ProductoSeleccionado.Precio * this.Unidades;
            costoEnvio = Core.CostoTipoEnvio[TipoEnvio.ToString()];
            costoEnvioTotal = Math.Round(this.ClienteSeleccionado.KmsEnvio / 2 + costoEnvio + this.ProductoSeleccionado.Peso * this.Unidades / 10f, 2, MidpointRounding.AwayFromZero);
            costoTotal = Math.Round(totalUnidades + costoEnvioTotal, 2, MidpointRounding.AwayFromZero);
            this.lblTotalUnidades.Text = totalUnidades.ToString();
            this.lblCostoEnvio.Text = costoEnvioTotal.ToString();
            this.lblTotal.Text = costoTotal.ToString();
            Inicio.ResetTimeOutTime();
        }

        private void dgvClientes_MouseUp(object sender, MouseEventArgs e)
        {
            ClienteSeleccionado = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
            this.CargarCostos();
        }

        private void dgvProductos_MouseUp(object sender, MouseEventArgs e)
        {
            ProductoSeleccionado = (Producto)dgvProductos.CurrentRow.DataBoundItem;
            this.CargarCostos();
        }
    }
}
