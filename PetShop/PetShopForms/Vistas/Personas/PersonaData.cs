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

namespace PetShopForms.Vistas.Persona
{
    public partial class PersonaData : Form
    {
        string usuario, contrasenia, nombre, apellido;
        double cuil;
        public string Usuario
        {
            get { return this.usuario; }
            set
            {
                this.txtUsuario.Text = value;
                this.usuario = value;
            }
        }
        public string Contrasenia
        {
            get { return this.contrasenia; }
            set
            {
                this.txtContrasenia.Text = value;
                this.contrasenia = value;
            }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set
            {
                this.txtNombre.Text = value;
                this.nombre = value;
            }
        }
        public string Apellido
        {
            get { return this.apellido; }
            set
            {
                this.txtApellido.Text = value;
                this.apellido = value;
            }
        }
        public double Cuil
        {
            get { return this.cuil; }
            set
            {
                this.txtCuil.Text = value.ToString();
                this.cuil = value;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            Inicio.ResetTimeOutTime();
            if (this.txtNombre.Text.Length > 0)
            {
                if (Validaciones.ValidarNombreApellido(this.txtNombre.Text))
                    this.Nombre = this.txtNombre.Text;
                else
                {
                    this.txtNombre.Text = string.Empty;
                    MessageBox.Show("Solo estan permitidas letras",
                                         "Error",
                                         MessageBoxButtons.OK);
                }
            }
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            if (this.txtApellido.Text.Length > 0)
            {
                if (Validaciones.ValidarNombreApellido(this.txtApellido.Text))
                    this.Apellido = this.txtApellido.Text;
                else
                {
                    this.txtApellido.Text = string.Empty;
                    MessageBox.Show("Solo estan permitidas letras",
                                         "Error",
                                         MessageBoxButtons.OK);
                }
            }
            Inicio.ResetTimeOutTime();
        }

        private void txtCuil_TextChanged(object sender, EventArgs e)
        {
            Inicio.ResetTimeOutTime();
            if (this.txtCuil.Text.Length > 0)
            {
                if (Validaciones.ValidarDouble(this.txtCuil.Text))
                    this.Cuil = double.Parse(this.txtCuil.Text);
                else
                {
                    this.txtCuil.Text = string.Empty;
                    MessageBox.Show("Solo estan permitidos numeros",
                                         "Error",
                                         MessageBoxButtons.OK);
                }
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            Inicio.ResetTimeOutTime();
            this.Usuario = txtUsuario.Text;
        }

        private void txtContrasenia_TextChanged(object sender, EventArgs e)
        {
            Inicio.ResetTimeOutTime();
            this.Contrasenia = txtContrasenia.Text;
        }

        public PersonaData()
        {
            InitializeComponent();
        }
    }
}
