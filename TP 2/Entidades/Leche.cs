using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2017
{
    public class Leche : Producto
    {
        #region Enumerador

        public enum ETipo { Entera, Descremada }

        #endregion

        #region Atributos

        ETipo _tipo;

        #endregion

        #region Constructores

        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        public Leche(EMarca marca, string patente, ConsoleColor color) : base(marca, patente, color)
        {
            _tipo = ETipo.Entera;
        }

        /// <summary>
        /// Se asigna el TIPO recibido
        /// </summary>
        public Leche(EMarca marca, string patente, ConsoleColor color, ETipo tipo) : this(marca,patente,color)
        {
            this._tipo = tipo;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// ReadOnly: las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }

        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine((string)this);
            sb.AppendLine("");
            sb.AppendFormat("CALORIAS : {0}\n", this.CantidadCalorias);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
