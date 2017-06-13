using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using Excepciones;


namespace Archivo
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Abre el archivo para escritura, de no encontrarlo, lo crea
        /// Guarda los datos en el archivo y lo cierra.
        /// En caso de haber error, lanza excepcion
        /// </summary>
        /// <param name="archivo">Nombre y direccion del archivo</param>
        /// <param name="datos">Datos a guardar de tipo Generico</param>
        /// <returns>Retorna true si no hubo errores</returns>
        public bool guardar(string archivo, T datos)
        {
            bool retorno = false;
            try
            {
                using (StreamWriter file = new StreamWriter(archivo, true))
                {
                    XmlSerializer sz = new XmlSerializer(typeof(T));
                    sz.Serialize(file, datos);
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
        /// <param name="datos">Aux de salida de tipo generico para guardar los datos leidos</param>
        /// <returns>Retorna true si no hubo errores</returns>
        public bool leer(string archivo, out T datos)
        {
            bool retorno = false;
            try
            {
                using (StreamReader file = new StreamReader(archivo))
                {
                    XmlSerializer sz = new XmlSerializer(typeof(T));
                    datos = (T)sz.Deserialize(file);
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
