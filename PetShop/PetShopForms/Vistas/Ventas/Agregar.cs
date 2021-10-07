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

namespace PetShopForms.Vistas.Ventas
{
    public partial class Agregar : Form
    {
        public VentaDataForm ventaDataForm;
        public Agregar()
        {
            InitializeComponent();
        }

        private void Agregar_Load(object sender, EventArgs e)
        {
            //VentaDataForm newMDIChild = new VentaDataForm();
            //this.IsMdiContainer = true;
            //newMDIChild.Dock = DockStyle.Fill;
            //newMDIChild.MdiParent = this;
            //newMDIChild.Show();
            ventaDataForm = (VentaDataForm)Inicio.AddFormToControl(pFullContainer.Controls, new VentaDataForm());
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No implementado, gritele al dev",
                                      "No llegue",
                                      MessageBoxButtons.OK);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
