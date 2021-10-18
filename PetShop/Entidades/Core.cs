﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Core
    {
        /// <summary>
        /// Usuario al cual pertenece la sesion iniciada
        /// </summary>
        public static Persona UsuarioLogueado;
        public static List<Empleado> ListaEmpleados { get; set; }
        static List<Cliente> listaClientes;
        public static List<Cliente> ListaClientes
        {
            get { return listaClientes; }
            set { listaClientes = value; }
        }

        static Core()
        {
            ListaEmpleados = new List<Empleado>();
            ListaClientes = new List<Cliente>();
        }
        /// <summary>
        /// Devuelve una lista de administradores, filtrando solo del tipo Administrador
        /// </summary>
        /// <returns></returns>
        public static List<Administrador> ListarAdministradores()
        {
            List<Administrador> admins = new List<Administrador>();
            foreach (Persona emp in Core.ListaEmpleados)
            {
                if (emp.EsAdmin())
                {
                    admins.Add((Administrador)emp);
                }
            }
            return admins;
        }

        /// <summary>
        /// Devuelve una lista de empleados, filtrando solo del tipo Empleado
        /// </summary>
        /// <returns></returns>
        public static List<Empleado> ListarEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>();
            foreach (Persona emp in Core.ListaEmpleados)
            {
                if (emp.EsEmpleado())
                {
                    empleados.Add((Empleado)emp);
                }
            }
            return empleados;
        }

        /// <summary>
        /// Metodo de extension, recibe una persona y devuelve si es administrador
        /// </summary>
        /// <param name="persona">persona a evaluar</param>
        /// <returns>true si es admin, false si no lo es</returns>
        public static bool EsAdmin(this Persona persona)
        {
            if (persona is Administrador)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Metodo de extension, recibe una persona y devuelve si solo es empleado
        /// </summary>
        /// <param name="persona">persona a evaluar</param>
        /// <returns>true si es empleado, false si no lo es</returns>
        public static bool EsEmpleado(this Persona persona)
        {
            if (persona is Empleado && !(persona is Administrador))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}