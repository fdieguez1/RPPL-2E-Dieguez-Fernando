using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Core
    {
        public static List<Empleado> ListaEmpleados { get; set; }
        public static int CantidadMaximaEmpleados { get; set; }
        static List<Cliente> listaClientes;
        public static List<Cliente> ListaClientes
        {
            get { return listaClientes; }
            set { listaClientes = value; }
        }
        public static int CantidadMaximaClientes { get; set; }


        static Core()
        {
            ListaEmpleados = new List<Empleado>();
            CantidadMaximaEmpleados = 20;
            ListaClientes = new List<Cliente>();
            CantidadMaximaClientes = 20;
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
                if (emp is Administrador)
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
                if (emp is Empleado && !(emp is Administrador))
                {
                    empleados.Add((Empleado)emp);
                }
            }
            return empleados;
        }

    }
}
