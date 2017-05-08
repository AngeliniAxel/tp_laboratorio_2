using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    public class Dulce : Producto
    {

        #region Constructores

        public Dulce(EMarca marca, string patente, ConsoleColor color) : base(marca, patente, color) { }

        #endregion

        #region Metodos

        /// <summary>
        /// ReadOnly: los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }


        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine((string) this);
            sb.AppendLine("");
            sb.AppendFormat("CALORIAS : {0}\n", this.CantidadCalorias);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
