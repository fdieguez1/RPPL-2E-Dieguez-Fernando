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
            char[] ponderador = { '5', '4', '3', '2', '7', '6', '5', '4', '3', '2' };
            int i;
            double suma = 0;
            char[] numero = cuil.ToString("00000000000").ToCharArray();
            for (i = 0; i < 10; i++)
            {
                suma += (int.Parse(ponderador[i].ToString()) * int.Parse(numero[i].ToString()));
            }

            suma = suma % 11;
            suma = 11 - suma;

            suma = suma == 10 ? 0 : suma == 11 ? 1 : suma;


            return suma == int.Parse(numero[10].ToString());
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
