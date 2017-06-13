using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesInstanciables
{
    public sealed class Alumno : EntidadesAbstractas.Universitario
    {
        #region Enumerados

        public enum EEstadoCuenta
        {
            Deudor,
            AlDia,
            Becado
        }

        #endregion

        #region Atributos

        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        #endregion

        #region Constructores

        public Alumno() : base()
        {
            this._claseQueToma = Universidad.EClases.Programacion;
            this._estadoCuenta = EEstadoCuenta.Deudor;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQuetoma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQuetoma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQuetoma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQuetoma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Compara Alumno con clase
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>True si cursa la clase y no tiene deuda, caso contrario, false</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;

            if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
                retorno = true;

            return retorno;
        }

        /// <summary>
        /// Compara Alumno con clase
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>devuelve exactamente lo contrario al ==</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a._claseQueToma == clase;
        }

        /// <summary>
        /// Metodo sobreescrito
        /// </summary>
        /// <returns>Retorna string con la clase que cursa</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this._claseQueToma;
        }

        /// <summary>
        /// Metodo sobreescrito con los datos del alumno
        /// </summary>
        /// <returns>Return string con los datos completos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine(base.MostrarDatos());
            retorno.AppendLine("ESTADO DE CUENTA: "+this._estadoCuenta.ToString());
            retorno.AppendLine(this.ParticiparEnClase());

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

        #endregion
    }
}
