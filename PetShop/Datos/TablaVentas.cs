using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public static class TablaVentas
    {
        static List<Venta> listaVentas;
        public static List<Venta> ListaVentas
        {
            get { return listaVentas; }
            set { listaVentas = value; }
        }
        static TablaVentas()
        {
            ListaVentas = new List<Venta>();
        }
    }
}
