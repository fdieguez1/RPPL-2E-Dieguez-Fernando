using Entidades.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Validaciones
    {
        /// <summary>
        /// Valida que un Cuil sea valido
        /// </summary>
        /// <param name="cuil">double cuil a evaluar</param>
        /// <returns>true si es correcto, false si es incorrecto</returns>
        public static bool ValidarCuil(double cuil)
        {
            if (cuil <= 0)
            {
                throw new CuilException("cuil erroneo");
            }
            if (cuil.ToString().Length != 11)
            {
                throw new CuilException("longitud de cuil incorrecta");
            }
            bool rv = false;
            int verificador;
            int resultado = 0;
            string codes = "6789456789";
            string cuilString = cuil.ToString();
            verificador = int.Parse(cuilString[cuilString.Length - 1].ToString());
            int x = 0;
            while (x < 10)
            {
                int digitoValidador = int.Parse(codes.Substring((x), 1));
                int digito = int.Parse(cuilString.Substring((x), 1));
                int digitoValidacion = digitoValidador * digito;
                resultado += digitoValidacion;
                x++;
            }
            resultado %= 11;
            rv = (resultado == verificador);
            return rv;
        }

        /// <summary>
        /// Valida que solo se ingresen caracteres para los nombres y apellidos
        /// </summary>
        /// <param name="cadena">cadena a evaluar</param>
        /// <returns>true si es correcta, false si es incorrecta</returns>
        public static bool ValidarNombreApellido(string cadena)
        {
            bool esValida = true;
            foreach (Char caracter in cadena.ToCharArray())
            {
                if (Char.IsDigit(caracter))
                {
                    esValida = false;
                }
            }
            return esValida;
        }
        /// <summary>
        /// Valida que solo se ingresen numeros enteros dada una cadena
        /// </summary>
        /// <param name="cadena">cadena a evaluar</param>
        /// <returns>true si es correcta, false si es incorrecta</returns>
        public static bool ValidarSoloEnteros(string cadena)
        {
            bool esValida = true;
            foreach (Char caracter in cadena.ToCharArray())
            {
                if (!Char.IsDigit(caracter))
                {
                    esValida = false;
                }
            }
            return esValida;
        }

        /// <summary>
        /// Valida que una cadena pueda ser convertida a double
        /// </summary>
        /// <param name="cadena">cadena a evaluar</param>
        /// <returns>true si es correcta, false si es incorrecta</returns>
        public static bool ValidarDouble(string cadena)
        {
            bool esValida = true;
            esValida = double.TryParse(cadena, out double convertida);
            return esValida;
        }
    }
}
