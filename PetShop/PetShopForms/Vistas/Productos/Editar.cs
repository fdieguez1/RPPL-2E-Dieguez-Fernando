using Entidades;
using Entidades.Enums;
using PetShopForms.Vistas.Productos;
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
    public partial class Editar : Form
    {
        public ProductData ProductDataForm;
        public Producto SelectedProduct;
        ETipoProducto tipoProd;
        double precio;
        int cantidad;
        string descripcion;
        float peso;

        public Editar(Producto producto)
        {
            InitializeComponent();
            SelectedProduct = producto;
        }

        private void Editar_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            ProductDataForm = (ProductData)Inicio.AddFormToControl(pFullContainer.Controls, new ProductData());
            ProductDataForm.Precio = SelectedProduct.Precio;
            ProductDataForm.Cantidad = SelectedProduct.Cantidad;
            ProductDataForm.TipoProd = SelectedProduct.TipoProducto;
            ProductDataForm.Descripcion = SelectedProduct.Descripcion;
            ProductDataForm.Peso = SelectedProduct.Peso;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            cantidad = ProductDataForm.Cantidad;
            tipoProd = ProductDataForm.TipoProd;
            precio = ProductDataForm.Precio;
            descripcion = ProductDataForm.Descripcion;
            peso = ProductDataForm.Peso;

            if (precio < 1 || cantidad < 1)
            {
                MessageBox.Show("Todos los campos son requeridos",
                                      "Error",
                                      MessageBoxButtons.OK);
            }
            else
            {
                Producto auxProducto = new Producto(descripcion, tipoProd, precio, cantidad, peso);
                auxProducto.Id = SelectedProduct.Id;
                for (int i = 0; i < Producto.ListaProductos.Count; i++)
                {
                    if (Producto.ListaProductos[i] == SelectedProduct)
                    {
                        Producto.ListaProductos[i] = auxProducto;
                        MessageBox.Show("Producto editado con exito",
                                    "Operacion exitosa",
                                    MessageBoxButtons.OK);
                        break;
                    }
                }
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            Inicio.ResetTimeOutTime();
        }

        private void Editar_MouseClick(object sender, MouseEventArgs e)
        {
            Inicio.ResetTimeOutTime();
        }
    }
}
