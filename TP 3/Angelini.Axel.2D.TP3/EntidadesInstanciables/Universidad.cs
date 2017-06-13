using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excepciones;
using Archivo;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        #region Enumerados

        public enum EClases
        {
            Programacion,
            Legislacion,
            Laboratorio,
            SPD
        }

        #endregion

        #region Atributos

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto. Inicializa las listas
        /// </summary>
        public Universidad()
        {
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
            this.alumnos = new List<Alumno>();
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// propiedad de lectura y escritura para atributo alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// propiedad de lectura y escritura para atributo alumnos
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// propiedad de lectura y escritura para atributo alumnos
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para la jornada en el indice deseado
        /// </summary>
        /// <param name="i">Recibe el indice de la jornada a utilizar</param>
        /// <returns>Retorna la jornada del indice pedido</returns>
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Crea un string con los datos de todas las jornadas de la universidad
        /// </summary>
        /// <param name="u">Universidad a utilizar</param>
        /// <returns>Retorna string con los datos</returns>
        private static string MostrarDatos(Universidad u)
        {
            StringBuilder retorno = new StringBuilder();

            foreach (Jornada item in u.jornada)
            {
                retorno.Append(item.ToString());
                retorno.AppendLine("<----------------------------------------------->");
            }

            return retorno.ToString();
        }

        /// <summary>
        /// Hace publico el metodo MostrarDatos
        /// </summary>
        /// <returns>Retorna string con los datos de la universidad</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// recorre la lista de alumnos en la Universidad y los compara con el que es pasado por parametro
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>Devuelve true si dicho alumno esta en la lista</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno item in g.alumnos)
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
        /// recorre la lista de alumnos en la Universidad y los compara con el que es pasado por parametro
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>Devuelve exactamente lo contrario al ==</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// recorre la lista de Profesores en la Universidad y los compara con el que es pasado por parametro
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="i">Profesor a comparar</param>
        /// <returns>Devuelve true si dicho Profesor esta en la lista</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            foreach (Profesor item in g.profesores)
            {
                if (item == i)
                {
                    retorno = true;
                    break;
                }

            }

            return retorno;
        }

        /// <summary>
        /// recorre la lista de Profesores en la Universidad y los compara con el que es pasado por parametro
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="i">Profesor a comparar</param>
        /// <returns>Devuelve exactamente lo contrario al ==</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Compara universidad con clase y busca al profesor que pueda darla
        /// En caso de no encontrarlo arroja excepcion
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>Retorna al primer profesor que pueda dar la clase</returns>
        public static Profesor operator ==(Universidad g,EClases clase)
        {
            Profesor retorno = null;
            byte flag = 0;
            foreach (Profesor item in g.profesores)
            {
                if (item == clase)
                {
                    retorno = new Profesor();
                    retorno = item;
                    flag = 1;
                    break;
                }
            }

            if (flag == 0)
                throw new SinProfesorException();

            return retorno;
        }

        /// <summary>
        /// Compara universidad con clase y busca al profesor que no de dicha case
        /// En caso de no encontrar profesor que no de dicha clase arroja excepcion
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>Retorna al primer profesor que no pueda dar la clase</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            Profesor retorno = null;

            foreach (Profesor item in g.profesores)
            {
                if (item != clase)
                {
                    retorno = new Profesor();
                    retorno = item;
                    break;
                }
            }

            if (retorno == null)
                throw new SinProfesorException();

            return retorno;
        }

        /// <summary>
        /// Si el alumno no esta en la Universidad, lo agrega.
        /// Si ya se encuentra en la Universidad, arroja excepcion
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>Retorna la universidad con o sin alumno</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
                g.alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();

            return g;
        }

        /// <summary>
        /// Si el profesor no esta en la Universidad, lo agrega.
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="i">Profesor a comparar</param>
        /// <returns>Retorna la Universidad, con o sin el nuevo profesor</returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
                g.profesores.Add(i);

            return g;
        }

        /// <summary>
        /// Busca un profesor de la Universidad que pueda dar la clase.
        /// Si lo encuentra crea la jornada, 
        /// y agrega a los alumnos que la puedan cursar
        /// </summary>
        /// <param name="g">Universiadad a utilizar</param>
        /// <param name="clase">Clase a agregar</param>
        /// <returns>Retorna la universidad, con o sin la nueva jornada</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada retorno = null;

            Profesor profe = null;
            profe = g == clase; 

            if (profe != null)
            {
                retorno = new Jornada(clase, profe);

                foreach (Alumno item in g.alumnos)
                {
                    retorno += item;
                }

                if (retorno != null)
                    g.jornada.Add(retorno);
            }
            return g;
        }

        /// <summary>
        /// Guarda los datos de toda la Universidad en archivo Xml
        /// </summary>
        /// <param name="u">Universidad a guardar</param>
        /// <returns>Retorna true si no hubo problemas guardando el archivo</returns>
        public static bool Guardar(Universidad u)
        {
            Xml<Universidad> xml = new Xml<Universidad>();

            return xml.guardar(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", u);
        }

        #endregion
    }
}
