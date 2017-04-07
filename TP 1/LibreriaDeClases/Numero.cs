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

        public Numero()
        {
            _numero = 0;
        }

        public Numero(string numero) : this()
        {
            this.setNumero(numero);
        }

        public Numero(double numero)
        {
            this._numero = numero;
        }

        #endregion

        #region Metodos

        public double getNumero()
        {
            return this._numero;
        }

        private static double validarNumero(string numeroString)
        {
            double retorno = 0;
            double.TryParse(numeroString, out retorno);
            return retorno;
        }

        private void setNumero(string numero)
        {
            this._numero = validarNumero(numero);
        }

        #endregion

        #region Operador

        public bool equalsNumeric(double a)
        {
            return (this._numero == a);
        }

        #endregion
    }
}
