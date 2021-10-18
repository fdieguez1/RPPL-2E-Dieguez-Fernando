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

namespace PetShopForms.Vistas.Empleados
{
    public partial class EmpleadoData : Form
    {
        double sueldo;
        bool isSuperAdmin;
        bool isAdmin;
        double bono;

        public double Sueldo
        {
            get
            {
                return this.sueldo;
            }
            set
            {
                this.txtSueldo.Text = value.ToString();
                this.sueldo = value;
            }
        }

        public double Bono
        {
            get
            {
                return this.bono;
            }
            set
            {
                this.txtBono.Text = value.ToString();
                this.bono = value;
            }
        }
        public bool IsSuperAdmin
        {
            get
            {
                return this.isSuperAdmin && this.IsAdmin;
            }
            set
            {
                this.chkIsSuperAdmin.Checked = value;
                this.isSuperAdmin = value;
            }
        }
        public bool IsAdmin
        {
            get
            {
                return this.isAdmin;
            }
            set
            {
                this.chkIsAdmin.Checked = value;
                this.isAdmin = value;
            }
        }

        public EmpleadoData()
        {
            InitializeComponent();
        }

        private void txtSueldo_TextChanged(object sender, EventArgs e)
        {
            Inicio.ResetTimeOutTime();
            if (this.txtSueldo.Text.Length > 0)
            {
                if (Validaciones.ValidarDouble(this.txtSueldo.Text))
                    this.Sueldo = double.Parse(this.txtSueldo.Text);
                else
                {
                    this.txtSueldo.Text = string.Empty;
                    MessageBox.Show("Solo estan permitidos numeros",
                                         "Error",
                                         MessageBoxButtons.OK);
                }
            }
        }

        private void chkIsAdmin_CheckedChanged(object sender, EventArgs e)
        {
            Inicio.ResetTimeOutTime();
            IsAdmin = chkIsAdmin.Checked;
            if (chkIsAdmin.Checked)
            {
                pIsAdmin.Enabled = true;
                pIsAdmin.Visible = true;
            }
            else
            {
                pIsAdmin.Enabled = false;
                pIsAdmin.Visible = false;
            }
        }

        private void EmpleadoData_Load(object sender, EventArgs e)
        {
            pIsAdmin.Enabled = false;
            pIsAdmin.Visible = false;
        }

        private void txtBono_TextChanged(object sender, EventArgs e)
        {
            Inicio.ResetTimeOutTime();
            if (this.txtBono.Text.Length > 0)
            {
                if (Validaciones.ValidarDouble(this.txtBono.Text))
                    this.Bono = double.Parse(this.txtBono.Text);
                else
                {
                    this.txtBono.Text = string.Empty;
                    MessageBox.Show("Solo estan permitidos numeros",
                                         "Error",
                                         MessageBoxButtons.OK);
                }
            }
        }
    }
}
