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
        string usuario, contrasenia, nombre, apellido;
        double saldo, cuil;
        int kmsEnvio;

        public PersonaData PersonaDataForm;
        public Cliente selectedCliente;

        private void Editar_MouseClick(object sender, MouseEventArgs e)
        {
            Inicio.ResetTimeOutTime();
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            Inicio.ResetTimeOutTime();
        }

        public Editar(Cliente cliente)
        {
            InitializeComponent();
            selectedCliente = cliente;
        }

        private void Editar_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            PersonaDataForm = (PersonaData)Inicio.AddFormToControl(pFullContainer.Controls, new Persona.PersonaData());
            this.txtSaldo.Text = selectedCliente.Saldo.ToString();
            PersonaDataForm.Nombre = selectedCliente.Nombre;
            PersonaDataForm.Apellido = selectedCliente.Apellido;
            PersonaDataForm.Cuil = selectedCliente.Cuil;
            PersonaDataForm.Usuario = selectedCliente.Usuario;
            PersonaDataForm.Contrasenia = selectedCliente.Contrasenia;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            usuario = PersonaDataForm.Usuario;
            contrasenia = PersonaDataForm.Contrasenia;
            cuil = PersonaDataForm.Cuil;
            nombre = PersonaDataForm.Nombre;
            apellido = PersonaDataForm.Apellido;
            saldo = double.Parse(txtSaldo.Text);
            kmsEnvio = new Random().Next(100, 600);
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasenia) || cuil < 1
                || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || saldo < 1)
            {
                MessageBox.Show("Todos los campos son requeridos",
                                      "Error",
                                      MessageBoxButtons.OK);
            }
            else
            {
                Cliente auxCliente = new Cliente(nombre, apellido, usuario, contrasenia, saldo, cuil, kmsEnvio);
                auxCliente.Id = selectedCliente.Id;
                for (int i = 0; i < Core.ListaClientes.Count; i++)
                {
                    if (Core.ListaClientes[i] == selectedCliente)
                    {
                        Core.ListaClientes[i] = auxCliente;
                        Inicio.PlaySound(Inicio.SucessSoundPath);
                        MessageBox.Show("Cliente editado con exito",
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
