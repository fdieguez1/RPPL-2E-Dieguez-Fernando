using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
#pragma warning disable CS0661
    /// <summary>
    /// Clase empleado, hereda de persona, asignando un salario y es la contenedora de la lista de clientes
    /// </summary>
    public class Empleado : Persona
#pragma warning restore CS0661
    {
        double sueldo;
        public double Sueldo
        {
            get { return this.sueldo; }
            set
            {
                this.sueldo = value;
            }
        }

        /// <summary>
        /// Constructor de la clase empleado, utiliza el constructor de su clase padre Persona
        /// </summary>
        /// <param name="nombre">string nombre a asignar</param>
        /// <param name="apellido">string apellido a asignar</param>
        /// <param name="usuario">string usuario a asignar</param>
        /// <param name="contrasenia">string contraseña a asignar</param>
        /// <param name="cuil">double numero de cuil a asignar</param>
        /// <param name="sueldo">double sueldo sueldo a asignar</param>
        public Empleado(string nombre, string apellido, string usuario, string contrasenia, double cuil, double sueldo) : base(nombre, apellido, usuario, contrasenia, cuil)
        {
            this.sueldo = sueldo;
        }

        /// <summary>
        /// Dados un cliente y un producto, carga un registro en la lista de ventas
        /// </summary>
        /// <param name="cliente">cliente que realiza la compra</param>
        /// <param name="producto">producto vendido</param>
        /// <returns>devuelve true si logro la venta, false si fallo</returns>
        protected bool Vender(Producto producto, Cliente cliente, int unidades, ETipoEnvio tipoEnvio)
        {
            Venta auxVenta = new Venta(producto, cliente, unidades, tipoEnvio);
            bool altaOk = false;
            if (cliente.Saldo >= auxVenta.TotalAPagar && producto.Cantidad > 0 && producto.Cantidad >= unidades)
            {
                cliente.Saldo -= producto.Precio;
                if (producto.Cantidad > unidades)
                {
                    altaOk = Venta.ListaVentas + auxVenta;
                    producto.Cantidad -= unidades;
                }
            }
            return altaOk;
        }

        protected virtual void AumentarSueldo(float porcentaje)
        {
            this.Sueldo += this.Sueldo * porcentaje / 100;
        }


        /// <summary>
        /// Carga de prueba de empleados hardcodeados
        /// </summary>
        /// <returns>devuelve true si logro la carga, false si no la logro</returns>
        public static bool CrearEmpleadoPrueba()
        {
            Empleado auxEmpleado = new Empleado($"Fernando", "Dieguez", "ferdieguez", "utnfra2021", 20111111112, 50000);
            bool altaOk = Core.ListaEmpleados + auxEmpleado;
            int testCount = 0;
            for (int i = 0; i < 3; i++)
            {
                testCount++;
                int salary = new Random().Next(10000, 100000);
                Empleado newEmp = new Empleado($"NombreTest", $"ApellidoTest", $"User{testCount}", "utnfra2021", 20111111112, salary);
                altaOk = Core.ListaEmpleados + newEmp;
                if (!altaOk)
                {
                    break;
                }
            }
            return altaOk;
        }

        public override string Mostrar()
        {
            return this.ToString();
        }
        /// <summary>
        /// Sobrecarga del metodo + para cargar un empleado a la lista de empleados
        /// </summary>
        /// <param name="listaEmpleados">lista objetivo</param>
        /// <param name="empleado">empleado a cargar</param>
        /// <returns></returns>
        public static bool operator +(List<Empleado> listaEmpleados, Empleado empleado)
        {
            bool altaOk = false;
            foreach (Empleado empl in listaEmpleados)
            {
                if (empl == empleado)
                {
                    return false;
                }
            }
            listaEmpleados.Add(empleado);
            altaOk = true;
            return altaOk;
        }
        /// <summary>
        /// Sobrecarga del metodo - para eliminar un empleado de la lista de empleados
        /// </summary>
        /// <param name="listaEmpleados">lista objetivo</param>
        /// <param name="empleado">empleado a eliminar</param>
        /// <returns>devuelve true si logro eliminarlo, false si no lo logro</returns>
        public static bool operator -(List<Empleado> listaEmpleados, Empleado empleado)
        {
            bool removeOk = false;
            foreach (Empleado emp in listaEmpleados)
            {
                if (emp == empleado)
                {
                    listaEmpleados.Remove(emp);
                    return true;
                }
            }
            return removeOk;
        }
        /// <summary>
        /// Sobrecarga del metodo == para comparar si dos empleados son iguales en sus usuarios
        /// </summary>
        /// <param name="empleado1">primer empleado a evaluar</param>
        /// <param name="empleado2">segundo empleado a evaluar</param>
        /// <returns>devuelve true si son iguales sus usuarios, false si no lo son</returns>
        public static bool operator ==(Empleado empleado1, Empleado empleado2)
        {
            if (empleado1.Usuario == empleado2.Usuario)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Sobrecar del metodo != para evaluar si dos empleados son distintos en sus usuarios
        /// </summary>
        /// <param name="empleado1">primer empleado a evaluar</param>
        /// <param name="empleado2">segundo empleado a evaluar</param>
        /// <returns>devuelve true si son distintos sus usuarios, false si no lo son</returns>
        public static bool operator !=(Empleado empleado1, Empleado empleado2)
        {
            return !(empleado1 == empleado2);
        }
    }
}
