using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Enumerados

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #endregion

        #region Atributos

        private string _nombre;
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;

        #endregion

        #region Propiedades

        /// <summary>
        /// De lectura y escritura. Devuelve y/o valida y carga el atributo _nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// De lectura y escritura. Devuelve y/o valida y carga el atributo _apellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// De lectura y escritura. Devuelve y/o valida y carga el atributo _dni 
        /// atrapando las excepciontes que pueda generar la validacion
        /// </summary>
        public int DNI
        {
            get
            {
                return this._dni;
            }
            set
            {
                try
                {
                    this._dni = ValidarDni(this.Nacionalidad, value);
                }
                catch (DniInvalidoException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (NacionalidadInvalidaException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Solo escritura. Recibe string, lo valida y lo carga en atributo _dni 
        /// atrapando las excepciontes que pueda generar la validacion
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.DNI = ValidarDni(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// De lectura y escritura. Devuelve y/o valida y carga el atributo _nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }

        #endregion

        #region Constructores

        public Persona()
        {
            this._apellido = "";
            this._nombre = "";
            this._dni = 0;
            this._nacionalidad = ENacionalidad.Extranjero;
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Recibe un dato y, de no ser valido para dni, tira la excepcion correspondiente a cada caso
        /// </summary>
        /// <param name="nacionalidad">recibe la nacionalidad deseada para comparar</param>
        /// <param name="dato">recibe el dato a utilizar como dni</param>
        /// <returns>retorna el mismo dato, de no haber excepciones</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato < 1)
                throw new DniInvalidoException("Dni invalido");

            else if ((dato > 89999999 && nacionalidad == ENacionalidad.Argentino) || (dato <= 89999999 && nacionalidad != ENacionalidad.Argentino))
                throw new NacionalidadInvalidaException();
            return dato;
        }

        /// <summary>
        /// Convierte un string a int, de ser posible, llama a su sobrecarga
        /// </summary>
        /// <param name="nacionalidad">recibe la nacionalidad deseada para comparar</param>
        /// <param name="dato">recibe el dato a utilizar como dni</param>
        /// <returns>Retorna el dato, en caso de error, retorna 0</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dni)
        {
            int retorno = 0;

            if (int.TryParse(dni, out retorno))
                retorno = ValidarDni(nacionalidad, retorno);
            return retorno;
        }

        /// <summary>
        /// Valida que el dato sea solo letras
        /// </summary>
        /// <param name="dato">Recibe el dato a comparar</param>
        /// <returns>Retorna el mismo dato, en caso de error, retorna string vacio ("")</returns>
        private static string ValidarNombreApellido(string dato)
        {
            string retorno = null;
            if (dato != null)
            {
                foreach (char letra in dato)
                {
                    if (!char.IsLetter(letra))
                    {
                        retorno = "";
                        break;
                    }
                    else
                        retorno = dato;
                }
            }
            else
                retorno = "";

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del metodo ToString
        /// </summary>
        /// <returns>Retorna los datos del Objeto en un string</returns>
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            retorno.AppendLine("NACIONALIDAD: " + this.Nacionalidad);

            return retorno.ToString();
        }

        #endregion
    }
}
