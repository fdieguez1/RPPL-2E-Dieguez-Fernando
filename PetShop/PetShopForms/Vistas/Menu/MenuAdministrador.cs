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
    public partial class MenuAdministrador : Form
    {
        Inicio inicioForm;
        Inicio InicioForm
        {
            get
            {
                return this.inicioForm;
            }
            set
            {
                this.inicioForm = value;
            }
        }
        public MenuAdministrador(Inicio inicioForm)
        {
            InitializeComponent();
            this.InicioForm = inicioForm;
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            InicioForm.ChangeBody(new Empleados.Listado());
            Inicio.PlaySound(Inicio.SwitchSoundPath);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            InicioForm.ChangeBody(new Clientes.Listado());
            Inicio.PlaySound(Inicio.SwitchSoundPath);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            InicioForm.ChangeBody(new Productos.Listado());
            Inicio.PlaySound(Inicio.SwitchSoundPath);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            InicioForm.ChangeBody(new Ventas.Listado());
            Inicio.PlaySound(Inicio.SwitchSoundPath);
        }

        private void btnAdministradores_Click(object sender, EventArgs e)
        {
            InicioForm.ChangeBody(new Administradores.Listado());
            Inicio.PlaySound(Inicio.SwitchSoundPath);
        }
    }
}
