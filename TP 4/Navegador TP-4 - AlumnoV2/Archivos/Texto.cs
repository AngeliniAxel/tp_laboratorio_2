using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _archivo;

        /// <summary>
        /// Establece la ruta del archivo pasada por parametro
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        public Texto(string archivo)
        {
            this._archivo = archivo;
        }

        /// <summary>
        /// Abre el archivo para escritura, de no encontrarlo, lo crea
        /// Guarda los datos en el archivo y lo cierra.
        /// En caso de haber error, retorna false
        /// </summary>
        /// <param name="datos">Datos a guardar</param>
        /// <returns>Retorna true si no hubo errores</returns>
        public bool guardar(string datos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(this._archivo,true))
                {
                    sw.WriteLine(datos);
                    sw.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Abre el archivo en modo lectura
        /// lee linea por linea y la guarda en un list de string
        /// </summary>
        /// <param name="datos">Lista de string con todos los datos leidos</param>
        /// <returns>Retorna tru si no hubo errores</returns>
        public bool leer(out List<string> datos)
        {
            datos = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(this._archivo))
                {
                    while (!sr.EndOfStream)
                    {
                        datos.Add(sr.ReadLine());
                    }
                    sr.Close();
                }
                return true;
            }
            catch (Exception)
            {
                datos = default(List<string>);
                return false;
            }
        }
    }
}
