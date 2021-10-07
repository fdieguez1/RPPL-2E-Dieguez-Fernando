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
    public partial class Editar : Form
    {
        public PersonaData PersonaDataForm;
        public Cliente selectedCliente;
        public Editar(int clienteId)
        {
            InitializeComponent();
            foreach (Cliente clt in Empleado.ListaClientes)
            {
                if (clt.Id == clienteId)
                {
                    selectedCliente = clt;
                }
            }
        }

        private void Editar_Load(object sender, EventArgs e)
        {
            PersonaDataForm = (PersonaData)Inicio.AddFormToControl(pFullContainer.Controls, new Persona.PersonaData());
            this.txtSaldo.Text = selectedCliente.Saldo.ToString();
            PersonaDataForm.Nombre = selectedCliente.Nombre;
            PersonaDataForm.Apellido = selectedCliente.Apellido;
            PersonaDataForm.Cuil = selectedCliente.Cuil;
            PersonaDataForm.Usuario= selectedCliente.Usuario;
            PersonaDataForm.Contrasenia= selectedCliente.Contrasenia;
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
                Cliente  auxCliente = new Cliente(nombre, apellido, usuario, contrasenia, saldo, cuil);
                auxCliente.Id = selectedCliente.Id;
                for (int i = 0; i < Empleado.ListaClientes.Count; i++)
                {
                    if (Empleado.ListaClientes[i] == selectedCliente)
                    {
                        Empleado.ListaClientes[i] = auxCliente;
                        MessageBox.Show("Empleado editado con exito",
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
    }
}
