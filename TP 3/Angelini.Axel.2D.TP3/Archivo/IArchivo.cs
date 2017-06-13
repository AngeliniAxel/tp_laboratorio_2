using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Archivo
{
    interface IArchivo <T>
    {
        #region Metodos

        bool guardar(string archivo, T datos);

        bool leer(string archivo, out T datos);

        #endregion
    }
}
