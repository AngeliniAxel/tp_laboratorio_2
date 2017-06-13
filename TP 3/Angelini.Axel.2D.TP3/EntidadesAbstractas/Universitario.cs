using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesAbstractas
{
    public abstract class Universitario :Persona
    {
        #region Atributos

        private int legajo;

        #endregion

        #region Constructores

        public Universitario() :base()
        {
            this.legajo = 0;
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo abstracto
        /// </summary>
        /// <returns>Retorna string</returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Metodo virtual con los datos del objeto. Llama a base.Tostring()
        /// </summary>
        /// <returns>Retorna string con los datos del objeto</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine(base.ToString());
            retorno.AppendLine("LEGAJO NUMERO: " + this.legajo);

            return retorno.ToString();
        }

        /// <summary>
        /// Compara a dos Universitarios. Validando que sean distintos de null.
        /// Luego compara su tipo, legajo y Dni
        /// </summary>
        /// <param name="pg1">Universitario uno</param>
        /// <param name="pg2">Universitario dos</param>
        /// <returns>Retorna bool</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if (!(object.ReferenceEquals(pg1, null)) && !(object.ReferenceEquals(pg2, null)))
            {
                if (pg1.GetType() == pg2.GetType())
                {
                    if ((pg1.DNI == pg2.DNI) || (pg1.legajo == pg2.legajo))
                        retorno = true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Compara a dos Universitarios. Validando que sean distintos de null.
        /// Luego compara su tipo, legajo y Dni
        /// </summary>
        /// <param name="pg1">Universitario uno</param>
        /// <param name="pg2">Universitario dos</param>
        /// <returns>Retorna bool</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Compara cualquier tipo de objeto con el de referencia
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>Retorna bool</returns>
        public override bool Equals(object obj)
        {
            return this == ((Universitario)obj);
        }

        #endregion
    }
}
