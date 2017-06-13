using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesInstanciables
{
    public sealed class Profesor : EntidadesAbstractas.Universitario
    {

        #region Atributos

        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

        #endregion

        #region Constructores

        static Profesor()
        {
            _random = new Random();
        }

        public Profesor() : base()
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClase();
            this._randomClase();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClase();
            this._randomClase();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Genera una clase random utilizando cualquiera de las iteraciones posibles
        /// </summary>
        private void _randomClase()
        {
            this._clasesDelDia.Enqueue((Universidad.EClases)_random.Next(0, 3));
        }

        /// <summary>
        /// Metodo sobreescrito
        /// </summary>
        /// <returns>Retorna string con las clases en las que es instructor</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine("CLASES DEL DIA: ");
            foreach (Universidad.EClases item in this._clasesDelDia)
            {
                retorno.AppendLine(item.ToString());
            }

            return retorno.ToString();
        }

        /// <summary>
        /// Metodo sobreescrito con los datos del Profesor
        /// </summary>
        /// <returns>Return string con los datos completos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append(base.MostrarDatos());
            retorno.Append(this.ParticiparEnClase());

            return retorno.ToString();
        }

        /// <summary>
        /// Hace publico l metodo MostrarDatos
        /// </summary>
        /// <returns>return string</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Compara un profesor con una clase
        /// </summary>
        /// <param name="a">Profesor a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>Retorna true si el profesor da esa clase</returns>
        public static bool operator ==(Profesor a, Universidad.EClases clase)
        {
            bool retorno = false;

            foreach (Universidad.EClases item in a._clasesDelDia)
            {
                if (item == clase)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Compara un profesor con una clase
        /// </summary>
        /// <param name="a">Profesor a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>devuelve exactamente lo contrario al ==</returns>
        public static bool operator !=(Profesor a, Universidad.EClases clase)
        {
            return !(a == clase);
        }

        #endregion
    }
}
