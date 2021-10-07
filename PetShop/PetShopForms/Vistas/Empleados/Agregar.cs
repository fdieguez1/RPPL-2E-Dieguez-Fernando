﻿using Entidades;
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

namespace PetShopForms.Vistas.Empleados
{
    public partial class Agregar : Form
    {
        public PersonaData PersonaDataForm;
        public EmpleadoData EmpleadoDataForm;
        public Agregar()
        {
            InitializeComponent();
        }

        private void Agregar_Load(object sender, EventArgs e)
        {
            EmpleadoDataForm = (EmpleadoData)Inicio.AddFormToControl(pFullContainer.Controls, new EmpleadoData());
            PersonaDataForm = (PersonaData)Inicio.AddFormToControl(pFullContainer.Controls, new Persona.PersonaData());
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string usuario, contrasenia, nombre, apellido;
            double sueldo, cuil, bono;
            bool isAdmin, isSuperAdmin;
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
                || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || sueldo < 1 || (isAdmin && bono < 1))
            {
                MessageBox.Show("Todos los campos son requeridos",
                                      "Error",
                                      MessageBoxButtons.OK);
            }
            else
            {
                bool altaOk = false;
                string userType = "";
                if (isAdmin) {
                    Administrador auxAdmin = new Administrador(nombre, apellido, usuario, contrasenia, cuil, sueldo, isSuperAdmin, bono);
                    altaOk = Administrador.ListaEmpleados + auxAdmin;
                    userType = auxAdmin.GetType().ToString();
                }
                else
                {
                    Empleado auxEmpleado = new Empleado(nombre, apellido, usuario, contrasenia, cuil, sueldo);
                    altaOk = Administrador.ListaEmpleados + auxEmpleado;
                    userType = auxEmpleado.GetType().ToString();
                }
                userType = userType.Split('.')[1];
                if (altaOk)
                {
                    MessageBox.Show($"Alta de {userType} exitosa",
                                              "Carga exitosa",
                                              MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Error en la carga del empleado",
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
    }
}
