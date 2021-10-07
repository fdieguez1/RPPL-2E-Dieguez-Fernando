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

namespace PetShopForms.Vistas.Productos
{
    public partial class ProductData : Form
    {
        ETipoProducto tipoProd;
        int cantidad;
        double precio;
        string descripcion;
        public ETipoProducto TipoProd
        {
            get
            {
                return this.tipoProd;
            }
            set
            {
                this.cmbTipo.SelectedIndex = (int)value;
                this.tipoProd = value;
            }
        }
        public int Cantidad
        {
            get
            {
                return this.cantidad;
            }
            set
            {
                this.txtCantidad.Text = value.ToString();
                this.cantidad = value;
            }
        }
        public double Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                this.txtPrecio.Text = value.ToString();
                this.precio = value;
            }
        }
        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.txtDescripcion.Text = value.ToString();
                this.descripcion = value;
            }
        }

        private void ProductData_Load(object sender, EventArgs e)
        {
            Array enums = Enum.GetValues(typeof(ETipoProducto));
            foreach (var item in enums)
            {
                this.cmbTipo.Items.Add(item);
            }
            this.cmbTipo.SelectedItem = this.cmbTipo.Items[0];
        }

        public ProductData()
        {
            InitializeComponent();
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            if (this.txtPrecio.Text.Length > 0)
            {
                if (Validaciones.ValidarDouble(this.txtPrecio.Text))
                    this.Precio = double.Parse(this.txtPrecio.Text);
                else
                {
                    this.txtPrecio.Text = string.Empty;
                    MessageBox.Show("Solo estan permitidos numeros",
                                         "Error",
                                         MessageBoxButtons.OK);
                }
            }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.Descripcion = this.txtDescripcion.Text;
        }
    }
}
