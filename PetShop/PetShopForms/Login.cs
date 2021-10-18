using Entidades;
using Entidades.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetShopForms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            bool testAdminOk = Administrador.CrearAdminPrueba();
            if (!testAdminOk)
            {
                MessageBox.Show("Problema al cargar admin mock",
                                      "Error",
                                      MessageBoxButtons.OK);
            }
            bool testEmpleadoOk = Empleado.CrearEmpleadoPrueba();
            if (!testEmpleadoOk)
            {
                MessageBox.Show("Problema al cargar empleados",
                                      "Error",
                                      MessageBoxButtons.OK);
            }
            bool testClientesOk = Cliente.CrearClientesPrueba();
            if (!testClientesOk)
            {
                MessageBox.Show("Problema al cargar clientes",
                                      "Error",
                                      MessageBoxButtons.OK);
            }
            bool testProductoOk = Producto.CrearProductoPrueba();
            if (!testProductoOk)
            {
                MessageBox.Show("Problema al cargar los producto",
                                      "Error",
                                      MessageBoxButtons.OK);
            }
            bool testVentasOk = Venta.CrearVentaPrueba();
            if (!testVentasOk)
            {
                MessageBox.Show("Problema al cargar ventas",
                                      "Error",
                                      MessageBoxButtons.OK);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasenia = txtContrasenia.Text;

            if (!string.IsNullOrWhiteSpace(usuario) || !string.IsNullOrWhiteSpace(contrasenia))
            {
                try
                {
                    Persona auxUsuario = Persona.Login(usuario, contrasenia);
                    if (auxUsuario != null)
                    {
                        Core.UsuarioLogueado = auxUsuario;
                        Form inicio = new Inicio(this);
                        inicio.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña no encontrados",
                                          "Error",
                                          MessageBoxButtons.OK);
                    }
                }
                catch (UsuarioInvalidoException ex)
                {
                    MessageBox.Show(ex.Message, "Error",
                                     MessageBoxButtons.OK);
                }
                finally
                {
                    txtUsuario.Text = string.Empty;
                    txtContrasenia.Text = string.Empty;
                }
            }
            else
            {
                MessageBox.Show("Usuario y contraseña son requeridos",
                                     "Error",
                                     MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir?",
                                    "Confirmacion",
                                    MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnMockEmployee_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "ferdieguez";
            txtContrasenia.Text = "utnfra2021";
        }

        private void btnAdmin_Clicked(object sender, EventArgs e)
        {
            txtUsuario.Text = "Admin";
            txtContrasenia.Text = "utnfra2021";
        }
    }
}
