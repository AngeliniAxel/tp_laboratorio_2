using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibreriaDeClases
{
    public class Numero
    {
        #region Atributos

        private double _numero;

        #endregion

        #region Constructores

        /// <summary>
        /// Crea una variable de tipo numero y carga su valor en 0;
        /// </summary>
        public Numero()
        {
            _numero = 0;
        }

        /// <summary>
        /// Crea una variable de tipo numero
        /// </summary>
        /// <param name="numero">Recibe un string y lo carga mediante setNumero()</param>
        public Numero(string numero) : this()
        {
            this.setNumero(numero);
        }

        /// <summary>
        /// Crea una variable de tipo numero
        /// </summary>
        /// <param name="numero">Recibe un double y lo carga en Numero</param>
        public Numero(double numero)
        {
            this._numero = numero;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Retorna valor de atributo _numero
        /// </summary>
        /// <returns>Valor del atribuno _numero en double</returns>
        public double getNumero()
        {
            return this._numero;
        }

        /// <summary>
        /// Verifica que sea posible convertir string a double
        /// </summary>
        /// <param name="numeroString">Recibe string y verifica posibilidad de parse</param>
        /// <returns>Retorna double con el valor requerido, en caso de error retorna 0</returns>
        private static double validarNumero(string numeroString)
        {
            double retorno = 0;
            double.TryParse(numeroString, out retorno);
            return retorno;
        }

        /// <summary>
        /// Carga un string en Numero
        /// </summary>
        /// <param name="numero">Recibe string y lo carga en _numero mediante validarNumero</param>
        private void setNumero(string numero)
        {
            this._numero = validarNumero(numero);
        }

        #endregion

        #region Operador

        /// <summary>
        /// Compara igualdad de atributo _numero con un valor double
        /// </summary>
        /// <param name="a">Recibe el double a comparar</param>
        /// <returns>Retorna true si hay igualdad, caso contrario retorna false</returns>
        public bool equalsNumeric(double a)
        {
            return (this._numero == a);
        }

        #endregion
    }
}
