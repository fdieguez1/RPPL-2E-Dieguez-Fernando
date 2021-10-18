using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase venta, que establece la relacion entre un cliente y un producto cada vez que el primero realiza una compra del segundo
    /// Su carga esta a cargo del empleado o administrador
    /// </summary>
#pragma warning disable CS0661
    public class Venta
#pragma warning restore CS0661 
    {
        public static int PrevId;
        int id;
        Producto producto;
        Cliente cliente;
        int unidades;
        ETipoEnvio tipoEnvio;


        static List<Venta> listaVentas;
        public static List<Venta> ListaVentas
        {
            get
            {
                return listaVentas;
            }
            set
            {
                listaVentas = value;
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
        public Producto Producto
        {
            get
            {
                return this.producto;
            }
            set
            {
                this.producto = value;
            }
        }
        public Cliente Cliente
        {
            get
            {
                return this.cliente;
            }
            set
            {
                this.cliente = value;
            }
        }
        public int Unidades
        {
            get
            {
                return this.unidades;
            }
            set
            {
                this.unidades = value;
            }
        }
        public double TotalAPagar
        {
            get
            {
                return Math.Round(this.Producto.Precio * this.Unidades + this.TotalEnvio, 2, MidpointRounding.AwayFromZero);
            }
        }
        public ETipoEnvio TipoEnvio
        {
            get
            {
                return this.tipoEnvio;
            }
            set
            {
                this.tipoEnvio = value;
            }
        }

        /// <summary>
        /// Solo lectura, devuelve el calculo total del envio 
        /// ( Total kms + precio tipo envio + peso )
        /// Valores: 2kms = $1 | 10gr = $1
        /// </summary>
        public double TotalEnvio
        {
            get
            {
                float costoEnvio = Core.CostoTipoEnvio[TipoEnvio.ToString()];
                return Math.Round(this.Cliente.KmsEnvio / 2 + costoEnvio + this.Producto.Peso * this.Unidades / 10f, 2, MidpointRounding.AwayFromZero);
            }
        }


        static Venta()
        {
            PrevId = 0;
            ListaVentas = new List<Venta>();
        }

        /// <summary>
        /// Constructor parametrizado de venta
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="cliente"></param>
        /// <param name="unidades"></param>
        public Venta(Producto producto, Cliente cliente, int unidades, ETipoEnvio tipoEnvio)
        {
            this.Id = ++PrevId;
            PrevId = this.Id;
            this.Producto = producto;
            this.Cliente = cliente;
            this.Unidades = unidades;
            this.TipoEnvio = tipoEnvio;
        }
        /// <summary>
        /// Devuelve una lista de ventas, filtrando solo del tipo Venta
        /// </summary>
        /// <returns></returns>
        public static List<object> ListarVentas()
        {
            List<object> ventasDisplay = new List<object>();
            foreach (object emp in ListaVentas)
            {
                Venta venta = (Venta)emp;
                ventasDisplay.Add(new
                {
                    Id = venta.id,
                    Cliente = venta.Cliente.Usuario,
                    Producto = venta.Producto.Descripcion,
                    venta.Unidades,
                    venta.TotalAPagar,
                    venta.TipoEnvio,
                    venta.TotalEnvio
                });
            }
            return ventasDisplay;
        }

        /// <summary>
        /// Carga de prueba de ventas hardcodeados
        /// </summary>
        /// <returns>devuelve true si logro la carga, false si no la logro</returns>
        public static bool CrearVentaPrueba()
        {
            bool altaOk = false;
            Random rnd = new Random();
            int testCount = 0;
            for (int i = 0; i < 5; i++)
            {
                testCount++;
                Venta newVenta = new Venta(Producto.ListaProductos[rnd.Next(0, Producto.ListaProductos.Count)], Core.ListaClientes[rnd.Next(0, Core.ListaClientes.Count)], rnd.Next(1, 2),
                     rnd.Next(10) > 5 ? ETipoEnvio.Moto : ETipoEnvio.MiniFlete);
                altaOk = ListaVentas + newVenta;
                if (!altaOk)
                {
                    break;
                }
            }
            return altaOk;
        }
        #region sobrecargas

        public string Mostrar()
        {
            return (string)this;
        }

        public static explicit operator string(Venta vnt)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{vnt.Cliente}\r");
            sb.AppendLine($"{vnt.Producto}\r");
            sb.AppendLine($"Total a pagar: {vnt.Producto.Cantidad * vnt.Producto.Precio}\r");

            return sb.ToString();
        }




        /// <summary>
        /// Sobrecarga del metodo + para cargar un venta a la lista de ventas
        /// </summary>
        /// <param name="listaVentas">lista objetivo</param>
        /// <param name="venta">venta a cargar</param>
        /// <returns>Devuelve true si logro cargar la venta, false si no lo logro</returns>
        public static bool operator +(List<Venta> listaVentas, Venta venta)
        {
            foreach (Venta vnt in listaVentas)
            {
                if (vnt == venta)
                {
                    return false;
                }
            }
            listaVentas.Add(venta);
            return true;
        }
        /// <summary>
        /// Sobrecarga del metodo - para eliminar un venta de la lista de ventas
        /// </summary>
        /// <param name="listaVentas">lista objetivo</param>
        /// <param name="venta">venta a eliminar</param>
        /// <returns>devuelve true si logro eliminarlo, false si no lo logro</returns>
        public static bool operator -(List<Venta> listaVentas, Venta venta)
        {
            foreach (Venta emp in listaVentas)
            {
                if (emp == venta)
                {
                    listaVentas.Remove(emp);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Sobrecarga del metodo == para comparar si dos ventas son iguales en sus usuarios
        /// </summary>
        /// <param name="venta1">primer venta a evaluar</param>
        /// <param name="venta2">segundo venta a evaluar</param>
        /// <returns>devuelve true si son iguales sus usuarios, false si no lo son</returns>
        public static bool operator ==(Venta venta1, Venta venta2)
        {
            if (venta1.Id == venta2.Id)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Sobrecar del metodo != para evaluar si dos ventas son distintos en sus usuarios
        /// </summary>
        /// <param name="venta1">primer venta a evaluar</param>
        /// <param name="venta2">segundo venta a evaluar</param>
        /// <returns>devuelve true si son distintos sus usuarios, false si no lo son</returns>
        public static bool operator !=(Venta venta1, Venta venta2)
        {
            return !(venta1 == venta2);
        }
        #endregion
    }
}
