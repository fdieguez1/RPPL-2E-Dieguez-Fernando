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
        double cantidad;
        public double Cantidad
        {
            get { return this.cantidad; }
            set
            {
                this.txtCantidad.Text = value.ToString();
                this.cantidad = value;
            }
        }
        private void VentaDataForm_Load(object sender, EventArgs e)
        {
            dgvClientes.DataSource = Empleado.ListaClientes;
            dgvProductos.DataSource = Producto.ListaProductos;
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (this.txtCantidad.Text.Length > 0)
            {
                if (Validaciones.ValidarDouble(this.txtCantidad.Text))
                    this.Cantidad = int.Parse(this.txtCantidad.Text);
                else
                {
                    this.txtCantidad.Text = string.Empty;
                    MessageBox.Show("Solo estan permitidos numeros",
                                         "Error",
                                         MessageBoxButtons.OK);
                }
            }
        }
    }
}
