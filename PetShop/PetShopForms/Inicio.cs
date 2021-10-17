using Entidades;
using PetShopForms.Vistas.Menu;
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
    public partial class Inicio : Form
    {
        Form login;

        Form menu;

        public Form Login
        {
            get { return this.login; }
            set { this.login = value; }
        }
        public Form Menu
        {
            get { return this.menu; }
            set { this.menu = value; }
        }


        public Inicio(Form loginForm)
        {
            InitializeComponent();
            Login = loginForm;
        }

        /// <summary>
        /// Metodo estatico que pasandole un controlcollection y un form, le da formato para mostrarse dentro del control sin barra superior y ocupando todo el espacio disponible
        /// </summary>
        /// <param name="controlCollection">Control al que se le va a realizar el Add() del formulario</param>
        /// <param name="sourceForm">instancia del formulario a agregar</param>
        /// <returns>devuelve la instancia del formulario con los formatos aplicados</returns>
        public static Form AddFormToControl(Control.ControlCollection controlCollection, Form sourceForm)
        {
            controlCollection.Remove(sourceForm);
            sourceForm.Dock = DockStyle.Top;
            sourceForm.TopLevel = false;
            sourceForm.TopMost = true;
            sourceForm.FormBorderStyle = FormBorderStyle.None;
            controlCollection.Add(sourceForm);
            sourceForm.Show();
            return sourceForm;
        }
        /// <summary>
        /// Evento de carga del formulario de inicio, se verifica el rol del usuario logueado y se muestra el menu correspondiente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Inicio_Load(object sender, EventArgs e)
        {
            if (Persona.UsuarioLogueado is Administrador)
            {
                Menu = new MenuAdministrador(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            }
            else
            {
                Menu = new MenuEmpleado(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            }
            this.pMenu.Controls.Add(Menu);
            menu.Show();
            lblWelcome.Text = $"Bienvenido, {Persona.UsuarioLogueado.NombreCompleto}";
            lblUserType.Text = Persona.UsuarioLogueado is Administrador ? "Administrador" : "Empleado";
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }
        /// <summary>
        /// Metodo que se ocupa de cambiar contenido del paner principal del form Inicio con una instancia de un form dada, limpia el control y luego agrega la nueva vista
        /// </summary>
        /// <param name="formToUse">Instancia del form a mostrar</param>
        public void ChangeBody(Form formToUse)
        {
            pRenderBody.Controls.Clear();
            AddFormToControl(pRenderBody.Controls, formToUse);
        }

        /// <summary>
        /// Metodo que cierra la sesion del usuario y vuelve a la pantalla de ingreso/login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea cerrar su sesion?",
                                    "Confirmacion",
                                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Persona.UsuarioLogueado = null;
                this.Login.Show();
                this.Close();
            }
        }
       
    }
}
