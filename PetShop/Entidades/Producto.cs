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
    /// Clase producto que representa los objetos a vender el en petshop
    /// </summary>
    public class Producto
#pragma warning restore CS0661 
    {
        public static int PrevId;
        string descripcion;
        int id;
        double precio;
        int cantidad;

        static List<Producto> listaProductos;
        public static List<Producto> ListaProductos
        {
            get { return listaProductos; }
            set { listaProductos = value; }
        }

        ETipoProducto tipoProducto;
        public ETipoProducto TipoProducto
        {
            get { return this.tipoProducto; }
            set { this.tipoProducto = value; }
        }

        public Producto this[int id]
        {
            get
            {
                foreach (Producto prod in ListaProductos)
                {
                    if (prod.id == id)
                    {
                        return prod;
                    }
                }
                return null;
            }
        }

        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }
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
        public double Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }
        public int Cantidad
        {
            get { return this.cantidad; }
            set { this.cantidad = value; }
        }

        static Producto()
        {
            PrevId = 0;
            ListaProductos = new List<Producto>();
        }


        /// <summary>
        /// Carga de prueba de productos hardcodeados
        /// </summary>
        /// <returns>devuelve true si logro la carga, false si no la logro</returns>
        public static bool CrearProductoPrueba()
        {
            bool altaOk = false;
            Random rnd = new Random();
            int testCount = 0;
            for (int i = 0; i < 10; i++)
            {
                testCount++;
                int salary = rnd.Next(10000, 100000);
                Producto newProducto = new Producto($"producto{testCount}", (ETipoProducto)rnd.Next(0, 3), rnd.Next(100, 500), rnd.Next(5, 20));
                altaOk = ListaProductos + newProducto;
                if (!altaOk)
                {
                    break;
                }
            }
            return altaOk;
        }

        /// <summary>
        /// Constructor de la clase producto, asigna sus valores de tipo, precio y cantidad, no se puede inicializar un producto sin estos datos
        /// </summary>
        /// <param name="tipo">ETipoProducto Enumerado, de valores predefinidos, con el valor a ser asignado</param>
        /// <param name="precio">Precio del producto por unidad</param>
        /// <param name="cantidad">Cantidad de productos en existencia</param>
        public Producto(string descripcion, ETipoProducto tipo, double precio, int cantidad)
        {
            this.Id = ++PrevId;
            PrevId = this.Id;
            this.TipoProducto = tipo;
            this.Precio = precio;
            this.Cantidad = cantidad;
            this.descripcion = descripcion;
        }
        #region sobrecargas operadores

        /// <summary>
        /// Sobrecarga del metodo + para agregar una carga de producto al listado de productos
        /// </summary>
        /// <param name="listaProductos">listado de productos</param>
        /// <param name="Producto">producto a ser cargado</param>
        /// <returns>devuelve true si fue exitoso, false si no lo fue</returns>
        public static bool operator +(List<Producto> listaProductos, Producto Producto)
        {
            bool altaOk = false;
            foreach (Producto clt in listaProductos)
            {
                if (clt == Producto)
                {
                    return false;
                }
            }
            listaProductos.Add(Producto);
            altaOk = true;
            return altaOk;
        }
        /// <summary>
        /// Sobrecarga del metodo - para eliminar una carga de producto del listado de productos
        /// </summary>
        /// <param name="listaProductos">listado de productos</param>
        /// <param name="Producto">producto a ser eliminado</param>
        /// <returns>devuelve true si fue exitoso, false si no lo fue</returns>
        public static bool operator -(List<Producto> listaProductos, Producto Producto)
        {
            bool removeOk = false;
            foreach (Producto clt in listaProductos)
            {
                if (clt == Producto)
                {
                    listaProductos.Remove(clt);
                    return true;
                }
            }
            return removeOk;
        }

        /// <summary>
        /// Compara dos productos por sus ids
        /// </summary>
        /// <param name="Producto1">primer producto a ser evaluado</param>
        /// <param name="Producto2">segundo producto a ser evaluado</param>
        /// <returns>devuelve true si son iguales, false si no lo son</returns>
        public static bool operator ==(Producto Producto1, Producto Producto2)
        {
            if (Producto1.Id == Producto2.Id)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Diferencia dos productos por sus ids
        /// </summary>
        /// <param name="Producto1">primer producto a ser evaluado</param>
        /// <param name="Producto2">segundo producto a ser evaluado</param>
        /// <returns>devuelve true si son diferentes, false si no lo son</returns>
        public static bool operator !=(Producto Producto1, Producto Producto2)
        {
            return !(Producto1 == Producto2);
        }
        #endregion
    }
}
