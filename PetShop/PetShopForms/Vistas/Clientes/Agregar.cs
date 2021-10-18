using Entidades;
using PetShopForms.Vistas.Persona;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetShopForms.Vistas.Clientes
{
    public partial class Agregar : Form
    {
        public PersonaData PersonaDataForm;
        public Agregar()
        {
            InitializeComponent();
        }

        private void Agregar_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            PersonaDataForm = (PersonaData)Inicio.AddFormToControl(pFullContainer.Controls, new Persona.PersonaData());
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string usuario, contrasenia, nombre, apellido;
            double saldo, cuil;

            usuario = PersonaDataForm.Usuario;
            contrasenia = PersonaDataForm.Contrasenia;
            cuil = PersonaDataForm.Cuil;
            nombre = PersonaDataForm.Nombre;
            apellido = PersonaDataForm.Apellido;
            saldo = double.Parse(txtSaldo.Text);
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasenia) || cuil < 1
                || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || saldo < 1)
            {
                MessageBox.Show("Todos los campos son requeridos",
                                      "Error",
                                      MessageBoxButtons.OK);
            }
            else
            {
                Cliente auxCliente = new Cliente(nombre, apellido, usuario, contrasenia, saldo, cuil);
                bool altaOk = Core.ListaClientes + auxCliente;
                if (altaOk)
                {
                    MessageBox.Show("Alta de cliente exitosa",
                                              "Carga exitosa",
                                              MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Error en la carga del cliente",
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
            Inicio.ResetTimeOutTime();
        }

        private void Agregar_MouseClick(object sender, MouseEventArgs e)
        {
            Inicio.ResetTimeOutTime();
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            Inicio.ResetTimeOutTime();
        }
    }
}
