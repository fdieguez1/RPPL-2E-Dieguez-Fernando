using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
#pragma warning disable CS0661 
    /// <summary>
    /// Clase cliente, hereda de persona sus caracteristicas basicas, asignando un saldo a cada cliente
    /// </summary>
    public class Cliente : Persona
#pragma warning restore CS0661 
    {
        double saldo;
        public double Saldo
        {
            get
            {
                return saldo;
            }
            set
            {
                this.saldo = value;
            }
        }
        /// <summary>
        /// Carga de test de clientes
        /// </summary>
        /// <returns></returns>
        public static bool CrearClientesPrueba()
        {
            bool altaOk = false;
            int testCount = 20;
            for (int i = 0; i < 10; i++)
            {
                testCount++;
                int salary = new Random().Next(10000, 100000);
                Cliente newEmp = new Cliente($"ClienteTst", $"ApellidoTest", $"User{testCount}", "utnfra2021", 500, 20222222223);
                altaOk = Core.ListaClientes + newEmp;
                if (!altaOk)
                {
                    break;
                }
            }
            return altaOk;
        }

        /// <summary>
        /// Constructor de cliente, utiliza el constructor de la clase persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="usuario"></param>
        /// <param name="contrasenia"></param>
        /// <param name="saldo"></param>
        /// <param name="cuil"></param>
        public Cliente(string nombre, string apellido, string usuario, string contrasenia, double saldo, double cuil) : base(nombre, apellido, usuario, contrasenia, cuil)
        {
            this.Saldo = saldo;
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Saldo: {this.Saldo.ToString()}");
            return sb.ToString();
        }

        #region sobrecargas

        /// <summary>
        /// Sobrecarga del operador + para agregar clientes a la lista de clientes
        /// </summary>
        /// <param name="listaClientes">lista objetivo</param>
        /// <param name="cliente">cliente a agregar</param>
        /// <returns>true si logro agregarlo, false si no lo logro</returns>
        public static bool operator +(List<Cliente> listaClientes, Cliente cliente)
        {
            bool altaOk = false;
            if (Core.CantidadMaximaClientes > listaClientes.Count)
            {
                foreach (Cliente clt in listaClientes)
                {
                    if (clt == cliente)
                    {
                        return false;
                    }
                }
                listaClientes.Add(cliente);
                altaOk = true;
            }
            return altaOk;
        }
        /// <summary>
        /// Sobrecarga del operador - para eliminar clientes a la lista de clientes
        /// </summary>
        /// <param name="listaClientes">lista objetivo</param>
        /// <param name="cliente">cliente a agregar</param>
        /// <returns>true si logro agregarlo, false si no lo logro</returns>
        public static bool operator -(List<Cliente> listaClientes, Cliente Cliente)
        {
            bool removeOk = false;
            foreach (Cliente clt in listaClientes)
            {
                if (clt == Cliente)
                {
                    listaClientes.Remove(clt);
                    return true;
                }
            }
            removeOk = false;
            return removeOk;
        }
        /// <summary>
        /// Sobrecarga del operador == para comparar dos clientes por su nombre de usuario
        /// </summary>
        /// <param name="cliente1">primer cliente a evaluar</param>
        /// <param name="cliente2">segundo cliente a evaluar</param>
        /// <returns>true si son usuarios iguales, false si son usuarios diferentes</returns>
        public static bool operator ==(Cliente cliente1, Cliente cliente2)
        {
            if (cliente1.Usuario == cliente2.Usuario)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// sobrecarga del operador != para evaluar si dos clientes dados son diferentes en su usuario
        /// </summary>
        /// <param name="cliente1">primer cliente a evaluar</param>
        /// <param name="cliente2">segundo cliente a evaluar</param>
        /// <returns>true si son usuarios diferentes, false si son usuarios iguales</returns>
        public static bool operator !=(Cliente cliente1, Cliente cliente2)
        {
            return !(cliente1 == cliente2);
        }
        #endregion
    }
}
