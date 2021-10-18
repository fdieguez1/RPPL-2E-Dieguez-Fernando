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
        public VentaData ventaDataForm;
        public Agregar()
        {
            InitializeComponent();
        }

        private void Agregar_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            //VentaData newMDIChild = new VentaData();
            //this.IsMdiContainer = true;
            //newMDIChild.Dock = DockStyle.Fill;
            //newMDIChild.FormBorderStyle = FormBorderStyle.None;
            //newMDIChild.MdiParent = this;
            //newMDIChild.Show();
            ventaDataForm = (VentaData)Inicio.AddFormToControl(pFullContainer.Controls, new VentaData());
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (ventaDataForm.Unidades > 0)
            {
                //Todo completo
            }
            else
            {
                //Incompleto
                MessageBox.Show("Seleccione un producto, un cliente e ingrese una cantidad",
                                      "Error",
                                      MessageBoxButtons.OK);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Agregar_Paint(object sender, PaintEventArgs e)
        {
            Inicio.ResetTimeOutTime();
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            Inicio.ResetTimeOutTime();
        }

        private void Agregar_MouseClick(object sender, MouseEventArgs e)
        {
            Inicio.ResetTimeOutTime();
        }
    }
}
