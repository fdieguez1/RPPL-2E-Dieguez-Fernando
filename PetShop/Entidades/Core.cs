using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Core
    {
        static Dictionary<string, float> tipoEnvio;
        /// <summary>
        /// Dictionary que guarda los tipos de envio con su costo
        /// </summary>
        public static Dictionary<string, float> CostoTipoEnvio
        {
            get
            {
                return tipoEnvio;
            }
            set
            {
                tipoEnvio = value;
            }
        }

        /// <summary>
        /// Usuario al cual pertenece la sesion iniciada
        /// </summary>
        public static Persona UsuarioLogueado;
        
        static List<Empleado> listaEmpleados;
        /// <summary>
        /// Listado de empleados cargados en el sistema
        /// </summary>
        public static List<Empleado> ListaEmpleados
        {
            get
            {
                return listaEmpleados;
            }
            set
            {
                listaEmpleados = value;
            }
        }

        static List<Cliente> listaClientes;
        /// <summary>
        /// Listado de clientes cargados en el sistema
        /// </summary>
        public static List<Cliente> ListaClientes
        {
            get
            {
                return listaClientes;
            }
            set
            {
                listaClientes = value;
            }
        }

        /// <summary>
        /// Construtor estatico de la clase core del sistema, inicializa las colecciones
        /// </summary>
        static Core()
        {
            ListaEmpleados = new List<Empleado>();
            ListaClientes = new List<Cliente>();
            CostoTipoEnvio = new Dictionary<string, float>
            {
                { "Moto", 250 },
                { "MiniFlete", 450 }
            };
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
