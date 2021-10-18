using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    public class ClienteSinDineroExcepcion : Exception
    {
        public string nombreCliente;
        public double saldoRestante;

        /// <summary>
        /// Constructor de la excepcion, se requiere el nombre de cliente y su saldo restante, el mensaje es opcional
        /// </summary>
        /// <param name="nombreCliente"></param>
        /// <param name="saldoRestante"></param>
        /// <param name="message"></param>
        public ClienteSinDineroExcepcion(string nombreCliente, double saldoRestante, string message = null) : base(message)
        {
            this.nombreCliente = nombreCliente;
            this.saldoRestante = saldoRestante;
        }
        /// <summary>
        /// Devuelve el mensaje de error con nombre y saldo del cliente.
        /// </summary>
        public string MensajeError
        {
            get
            {
                return $"{this.nombreCliente} no tiene suficiente saldo para esta venta, saldo: {saldoRestante}";
            }
        }
    }
}
