using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase sellada Administrador, que no permite herencia, hereda los atributos de empleado y posee permisos especiales.
    /// </summary>
#pragma warning disable CS0661
    public sealed class Administrador : Empleado
#pragma warning restore CS0661 
    {
        bool isAdmin;
        public bool IsAdmin
        {
            get
            {
                return this.isAdmin;
            }
            set
            {
                this.isAdmin = value;
            }
        }

        bool superAdminPower;
        public bool SuperAdminPower
        {
            get
            {
                return this.superAdminPower;
            }
            set
            {
                this.superAdminPower = value;
            }
        }
        double bono;
        public double Bono
        {
            get
            {
                return this.bono;
            }
            set
            {
                this.bono = value;
            }
        }
        public override string NombreCompleto
        {
            get
            {
                return $"{base.NombreCompleto} | Admin";
            }
        }

        /// <summary>
        /// Constructor de la clase administrador
        /// </summary>
        /// <param name="nombre">string nombre a asignar</param>
        /// <param name="apellido">string gapellido a asignar</param>
        /// <param name="usuario">string usuario a asignar</param>
        /// <param name="contrasenia">string contraseña a asignar</param>
        /// <param name="cuil">double cuil a asignar</param>
        /// <param name="sueldo">double sueldo a asignar</param>
        /// <param name="superAdminPower">bool permiso a asignar</param>
        /// <param name="bono">double bono a asignar</param>
        public Administrador(string nombre, string apellido, string usuario, string contrasenia, double cuil,
            double sueldo, bool isAdmin, bool superAdminPower, double bono) : base(nombre, apellido, usuario, contrasenia, cuil, sueldo)
        {
            this.isAdmin = isAdmin;
            this.SuperAdminPower = superAdminPower;
            this.Bono = bono;
        }

        /// <summary>
        /// Metodo utilizado para aumentar el sueldo de un administrador, reutiliza el codigo de su clase padre y asigna un nuevo valor al bono
        /// </summary>
        /// <param name="porcentaje">porcentaje a aumentar</param>
        protected override void AumentarSueldo(float porcentaje)
        {
            base.AumentarSueldo(porcentaje);
            this.Bono += this.Bono * porcentaje / 100;
        }

        /// <summary>
        /// Metodo de prueba que carga un admin se llama desde el form de login
        /// </summary>
        /// <returns>bool true si logro realizar la carga, false si no lo logro</returns>
        public static bool CrearAdminPrueba()
        {
            Empleado auxAdmin = new Administrador("Elpe", "Rrito", "Admin", "utnfra2021", 20222222223, 1000000, true, true, 100000);
            bool altaOk = Core.ListaEmpleados + auxAdmin;
            return altaOk;
        }

        /// <summary>
        /// Sobrecarga del metodo + para cargar un administrador a la lista de administradors
        /// </summary>
        /// <param name="listaEmpleados">lista objetivo</param>
        /// <param name="administrador">administrador a cargar</param>
        /// <returns></returns>
        public static bool operator +(List<Administrador> listaEmpleados, Administrador administrador)
        {
            foreach (Administrador admin in listaEmpleados)
            {
                if (admin == administrador)
                {
                    return false;
                }
            }
            listaEmpleados.Add(administrador);
            return true;
        }
        /// <summary>
        /// Sobrecarga del metodo - para eliminar un administrador de la lista de administradors
        /// </summary>
        /// <param name="listaEmpleados">lista objetivo</param>
        /// <param name="administrador">administrador a eliminar</param>
        /// <returns>devuelve true si logro eliminarlo, false si no lo logro</returns>
        public static bool operator -(List<Administrador> listaEmpleados, Administrador administrador)
        {
            bool removeOk = false;
            foreach (Administrador emp in listaEmpleados)
            {
                if (emp == administrador)
                {
                    listaEmpleados.Remove(emp);
                    return true;
                }
            }
            return removeOk;
        }
        /// <summary>
        /// Sobrecarga del metodo == para comparar si dos administradors son iguales en sus usuarios
        /// </summary>
        /// <param name="administrador1">primer administrador a evaluar</param>
        /// <param name="administrador2">segundo administrador a evaluar</param>
        /// <returns>devuelve true si son iguales sus usuarios, false si no lo son</returns>
        public static bool operator ==(Administrador administrador1, Administrador administrador2)
        {
            if (administrador1.Usuario == administrador2.Usuario)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Sobrecar del metodo != para evaluar si dos administradors son distintos en sus usuarios
        /// </summary>
        /// <param name="administrador1">primer administrador a evaluar</param>
        /// <param name="administrador2">segundo administrador a evaluar</param>
        /// <returns>devuelve true si son distintos sus usuarios, false si no lo son</returns>
        public static bool operator !=(Administrador administrador1, Administrador administrador2)
        {
            return !(administrador1 == administrador2);
        }

    }
}