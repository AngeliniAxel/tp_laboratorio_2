using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Excepciones;

namespace Archivo
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Abre el archivo para escritura, de no encontrarlo, lo crea
        /// Guarda los datos en el archivo y lo cierra.
        /// En caso de haber error, lanza excepcion
        /// </summary>
        /// <param name="archivo">Nombre y direccion del archivo</param>
        /// <param name="datos">Datos a guardar</param>
        /// <returns>Retorna true si no hubo errores</returns>
        public bool guardar(string archivo, string datos)
        {
            bool retorno = false;
            try
            {
                using (StreamWriter file = new StreamWriter(archivo, true))
                {
                    file.WriteLine(datos);
                    file.Close();
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
            
        }

        /// <summary>
        /// Abre el archivo en modo lectura.
        /// En caso de error lanza excepcion
        /// </summary>
        /// <param name="archivo">Nombre y direccion del archivo</param>
        /// <param name="datos">Aux de salida para guardar los datos que se leyeron</param>
        /// <returns>Retorna true si no hubo errores</returns>
        public bool leer(string archivo, out string datos)
        {
            bool retorno = false;
            try
            {
                using (StreamReader file = new StreamReader(archivo))
                {
                    datos = file.ReadToEnd();
                    file.Close();
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }
    }
}
