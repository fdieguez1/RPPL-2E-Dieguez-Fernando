using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    public class CuilException : Exception
    {
        /// <summary>
        /// Constructor de la excepcion utiliza el constructor de su clase padre, pasandole un mensaje requerido
        /// </summary>
        /// <param name="message">mensaje a mostrar, requerido</param>
        public CuilException(string message) : base (message)
        {

        }
    }
}
