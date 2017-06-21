using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    /// <summary>
    /// La clase Producto será abstracta, evitando que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        #region Enumerador

        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }

        #endregion

        #region Atributos

        protected EMarca _marca;
        protected string _codigoDeBarras;
        protected ConsoleColor _colorPrimarioEmpaque;

        #endregion

        #region Constructores

        /// <summary>
        /// Inicializa el producto con los parametros que recibe
        /// </summary>
        public Producto(EMarca marca, string patente, ConsoleColor color)
        {
            this._marca = marca;
            this._codigoDeBarras = patente;
            this._colorPrimarioEmpaque = color;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// ReadOnly: Retornará la cantidad de calorias del producto
        /// </summary>
        protected abstract short CantidadCalorias { get; }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns> return string </returns>
        public abstract string Mostrar();

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Metodo explicito que retorna string con los atributos por defecto de un producto
        /// </summary>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p._codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p._marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p._colorPrimarioEmpaque.ToString());
            sb.AppendFormat("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"> Producto a comparar </param>
        /// <param name="v2"> Producto a comparar </param>
        /// <returns> Bool </returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            bool retorno = false;
            if (v1._codigoDeBarras == v2._codigoDeBarras)
                retorno = true;
            return retorno;
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"> Producto a comparar </param>
        /// <param name="v2"> Producto a comparar </param>
        /// <returns> Bool </returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            bool retorno = false;
            if (v1._codigoDeBarras != v2._codigoDeBarras)
                retorno = true;
            return retorno;
        }

        #endregion
    }
}
