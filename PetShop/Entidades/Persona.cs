using System;
using System.Text;

namespace Entidades
{
    /// <summary>
    /// Clase base desde la que se generaran los usuarios de esta aplicacion. No puede instanciarse
    /// </summary>
    public abstract class Persona
    {
        /// <summary>
        /// Usuario al cual pertenece la sesion iniciada
        /// </summary>
        public static Persona UsuarioLogueado;
        /// <summary>
        /// Id autoincremental
        /// </summary>
        public static int PrevId;

        int id;
        string nombre;
        string apellido;
        double cuil;
        string usuario;
        string contrasenia;

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if (Validaciones.ValidarNombreApellido(value))
                {
                    this.nombre = value;
                }
            }
        }
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                if (Validaciones.ValidarNombreApellido(value))
                {
                    this.apellido = value;
                }
            }
        }
        public double Cuil
        {
            get
            {
                return this.cuil;
            }
            set
            {
                if (Validaciones.ValidarCuil(value))
                {
                    this.cuil = value;
                }
            }
        }
        public string Usuario
        {
            get { return this.usuario; }
            set
            {
                this.usuario = value;
            }
        }

        public string Contrasenia
        {
            get { return this.contrasenia; }
            set
            {
                this.contrasenia = value;
            }
        }

        public virtual string NombreCompleto
        {
            get
            {
                return $"{this.Nombre} {this.Apellido}";
            }
        }
        /// <summary>
        /// Constructor estatico inicializa el conteo de ids autoincrementales la primera vez que se utiliza esta clase
        /// </summary>
        static Persona()
        {
            PrevId = 0;
        }

        /// <summary>
        /// Constructor base para cargar los datos basicos de una persona
        /// </summary>
        /// <param name="nombre">nombre a asignar</param>
        /// <param name="apellido">apellido a asignar</param>
        /// <param name="usuario">usuario a asignar</param>
        /// <param name="contrasenia">contraseña a asignar</param>
        /// <param name="cuil">cuil a asignar</param>
        public Persona(string nombre, string apellido, string usuario, string contrasenia, double cuil)
        {
            this.Id = ++PrevId;
            PrevId = this.Id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Usuario = usuario;
            this.Contrasenia = contrasenia;
            this.Cuil = cuil;
        }

        /// <summary>
        /// Metodo virtual para poder ser sobreescrito, utiliza el stringbuilder para mostrar en dos lineas el contenido de la clase Persona
        /// </summary>
        /// <returns>Devuelve la cadena de string con formato</returns>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Id: {this.Id} Usuario: {this.Usuario}");
            sb.AppendLine($"Nombre completo: { this.NombreCompleto} Cuil: { this.Cuil.ToString()}");
            return sb.ToString();
        }

        /// <summary>
        /// Dados un usuario y contraseña se busca en la lista de empleados por una coincidencia
        /// </summary>
        /// <param name="usuario">string usuario a buscar</param>
        /// <param name="contrasenia">string contraseña a buscar</param>
        /// <returns>Devuelve el usuario encontrado si es exitoso, null si no hubo coincidencias</returns>
        public static Persona Login(string usuario, string contrasenia)
        {
            foreach (Persona item in Core.ListaEmpleados)
            {
                if (item.usuario == usuario && item.contrasenia == contrasenia)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
