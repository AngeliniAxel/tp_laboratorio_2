using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Archivo;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        #region Atributos

        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        #endregion

        #region Constructores

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// propiedad de lectura y escritura para atributo _alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this._alumnos;
            }
            set
            {
                this._alumnos = value;
            }
        }

        /// <summary>
        /// propiedad de lectura y escritura para atributo _clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this._clase;
            }
            set
            {
                this._clase = value;
            }
        }

        /// <summary>
        /// propiedad de lectura y escritura para atributo _instructor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this._instructor;
            }
            set
            {
                this._instructor = value;
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// recorre la lista de alumnos en la jornada y los compara con el que es pasado por parametro
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>Devuelve true si dicho alumno esta en la lista</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno item in j._alumnos)
            {
                if (item == a)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// recorre la lista de alumnos en la jornada y los compara con el que es pasado por parametro
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>Devuelve exactamente lo contrario al ==</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// verifica que el alumno no este en la clase, y que pueda cursarla.
        /// De ser asi, lo agrega a la lista
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>Devuelve jornada con el nuevo alumno, caso contrario retorna la lista sin modificaciones</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a && a == j._clase)
                j._alumnos.Add(a);

            return j;
        }

        /// <summary>
        /// Hace publicos los datos de la jornada
        /// </summary>
        /// <returns>Retorna string con los datos de todos los alumnos y profesores de la jornada</returns>
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine("CLASE DE " + this._clase.ToString() + " POR " + this._instructor.ToString());
            retorno.AppendLine("ALUMNOS:");

            foreach (Alumno item in this._alumnos)
            {
                retorno.Append(item.ToString());
            }

            return retorno.ToString();
        }

        /// <summary>
        /// Crea un archivo de tecto y guarda la jornada en el
        /// </summary>
        /// <param name="j">Jornada a guardar</param>
        /// <returns>Retorna true si no hubo errores al guardar el archivo</returns>
        public static bool Guardar(Jornada j)
        {
            Texto text = new Texto();

            return text.guardar(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", j.ToString());
        }

        /// <summary>
        /// Lee un archvo de jornada y toma sus datos
        /// </summary>
        /// <returns>Retorna string con los datos del archivo de jornada leido</returns>
        public static string Leer()
        {
            string retorno;
            Texto text = new Texto();

            text.leer(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", out retorno);

            return retorno;
        }


        #endregion
    }
}
