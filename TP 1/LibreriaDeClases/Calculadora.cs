using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibreriaDeClases
{
    public class Calculadora
    {
        #region Metodos

        public static string validarOperador(string operador)
        {
            string retorno;
            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
                retorno = "+";
            else
                retorno = operador;

            return retorno;
        }

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

            //if (operador == "+")
            //    resultado = num1 + num2;

            //else if (operador == "-")
            //    resultado = num1 - num2;

            //else if (operador == "*")
            //    resultado = num1 * num2;

            //else if (operador == "/")
            //{ }

            return resultado;
        }

        #endregion
    }
}
