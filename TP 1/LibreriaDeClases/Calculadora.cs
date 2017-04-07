using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibreriaDeClases
{
    public class Calculadora
    {
        #region Metodos

        /// <summary>
        /// Valida que el operador sea uno de los permitidos
        /// </summary>
        /// <param name="operador">Recibe el string a validar</param>
        /// <returns>Retorna el operador seleccionado, en caso de error, retorna "+"</returns>
        public static string validarOperador(string operador)
        {
            string retorno;
            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
                retorno = "+";
            else
                retorno = operador;

            return retorno;
        }

        /// <summary>
        /// Realiza operacion matematica entre dos objetos de clase Numero
        /// </summary>
        /// <param name="numeroUno">Recibe primer numero a operar</param>
        /// <param name="numeroDos">Recibe segundo numero a operar</param>
        /// <param name="operador">Recibe signo de la operacion</param>
        /// <returns>Retorna double con valor del resultado, en caso de error retorna 0</returns>
        public static double operar(Numero numeroUno, Numero numeroDos, string operador)
        {
            double resultado = 0;
            double num1 = numeroUno.getNumero();
            double num2 = numeroDos.getNumero();

            operador = validarOperador(operador);

            switch(operador)
            {
                case "+":

                    resultado = num1 + num2;
                    break;

                case "-":

                    resultado = num1 - num2;
                    break;

                case "*":

                    resultado = num1 * num2;
                    break;

                case "/":

                    if (num2 != 0)
                        resultado = num1 / num2;
                    break;

                default:

                    resultado = num1 + num2;
                    break;

            }
            return resultado;
        }

        #endregion
    }
}
