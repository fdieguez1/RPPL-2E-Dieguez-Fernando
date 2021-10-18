using Entidades;
using Entidades.Exceptions;
using PetShopForms.Vistas.Empleados;
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

namespace PetShopForms.Vistas.Administradores
{
    public partial class Editar : Form
    {
        public PersonaData PersonaDataForm;
        public EmpleadoData EmpleadoDataForm;
        public Administrador selectedAdmin;
        string usuario, contrasenia, nombre, apellido;
        double sueldo, cuil, bono;
        bool isAdmin, isSuperAdmin;

        private void Editar_MouseClick(object sender, MouseEventArgs e)
        {
            Inicio.ResetTimeOutTime();
        }

        private void Editar_Paint(object sender, PaintEventArgs e)
        {
            Inicio.ResetTimeOutTime();
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            Inicio.ResetTimeOutTime();
        }

        string userType = "";

        public Editar(Administrador admin)
        {
            InitializeComponent();
            selectedAdmin = admin;

        }

        private void Editar_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            EmpleadoDataForm = (EmpleadoData)Inicio.AddFormToControl(pFullContainer.Controls, new EmpleadoData());
            PersonaDataForm = (PersonaData)Inicio.AddFormToControl(pFullContainer.Controls, new Persona.PersonaData());
            EmpleadoDataForm.Sueldo = selectedAdmin.Sueldo;
            PersonaDataForm.Nombre = selectedAdmin.Nombre;
            PersonaDataForm.Apellido = selectedAdmin.Apellido;
            PersonaDataForm.Cuil = selectedAdmin.Cuil;
            PersonaDataForm.Usuario = selectedAdmin.Usuario;
            PersonaDataForm.Contrasenia = selectedAdmin.Contrasenia;
            EmpleadoDataForm.Bono = selectedAdmin.Bono;
            EmpleadoDataForm.IsSuperAdmin = selectedAdmin.SuperAdminPower;
            EmpleadoDataForm.IsAdmin = selectedAdmin.EsAdmin();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            usuario = PersonaDataForm.Usuario;
            contrasenia = PersonaDataForm.Contrasenia;
            cuil = PersonaDataForm.Cuil;
            nombre = PersonaDataForm.Nombre;
            apellido = PersonaDataForm.Apellido;
            sueldo = EmpleadoDataForm.Sueldo;
            isAdmin = EmpleadoDataForm.IsAdmin;
            isSuperAdmin = EmpleadoDataForm.IsSuperAdmin;
            bono = EmpleadoDataForm.Bono;
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasenia) || cuil < 1
                || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || sueldo < 1)
            {
                MessageBox.Show("Todos los campos son requeridos", "Error", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    if (isAdmin)
                    {
                        Administrador auxAdmin = new Administrador(nombre, apellido, usuario, contrasenia, cuil, sueldo, isAdmin, isSuperAdmin, bono);
                        auxAdmin.Id = selectedAdmin.Id;
                        for (int i = 0; i < Core.ListaEmpleados.Count; i++)
                        {
                            if (Core.ListaEmpleados[i] == selectedAdmin)
                            {
                                Core.ListaEmpleados[i] = auxAdmin;
                                MessageBox.Show("Administrador editado con exito", "Operacion exitosa", MessageBoxButtons.OK);
                                break;
                            }
                        }
                        userType = auxAdmin.GetType().ToString();
                    }
                    else
                    {
                        Empleado auxEmpleado = new Empleado(nombre, apellido, usuario, contrasenia, cuil, sueldo);
                        auxEmpleado.Id = selectedAdmin.Id;
                        for (int i = 0; i < Core.ListaEmpleados.Count; i++)
                        {
                            if (Core.ListaEmpleados[i] == selectedAdmin)
                            {
                                Core.ListaEmpleados[i] = auxEmpleado;
                                MessageBox.Show("Empleado editado con exito", "Operacion exitosa", MessageBoxButtons.OK);
                                break;
                            }
                        }
                        userType = auxEmpleado.GetType().ToString();
                    }
                    this.Close();
                }
                catch (CuilException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
