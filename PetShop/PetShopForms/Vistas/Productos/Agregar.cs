﻿using Entidades;
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
    public partial class Agregar : Form
    {
        public ProductData ProductDataForm;
        public Agregar()
        {
            InitializeComponent();
        }

        private void Agregar_Load(object sender, EventArgs e)
        {
            ProductDataForm = (ProductData)Inicio.AddFormToControl(pFullContainer.Controls, new ProductData());
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            ETipoProducto tipoProd;
            double precio;
            int cantidad;
            string descripcion;
            cantidad = ProductDataForm.Cantidad;
            tipoProd = ProductDataForm.TipoProd;
            precio = ProductDataForm.Precio;
            descripcion = ProductDataForm.Descripcion;

            if (string.IsNullOrEmpty(descripcion) || precio < 1 || cantidad < 1)
            {
                MessageBox.Show("Todos los campos son requeridos",
                                      "Error",
                                      MessageBoxButtons.OK);
            }
            else
            {
                Producto auxProducto = new Producto(descripcion, tipoProd, precio, cantidad);
                bool altaOk = Producto.ListaProductos + auxProducto;
                if (altaOk)
                {
                    MessageBox.Show("Alta de producto exitosa",
                                              "Carga exitosa",
                                              MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Error en la carga del producto",
                                              "Error",
                                              MessageBoxButtons.OK);
                }
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pFullContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
