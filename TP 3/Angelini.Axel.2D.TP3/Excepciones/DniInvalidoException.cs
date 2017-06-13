using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excepciones
{
    public class DniInvalidoException :Exception
    {
        private string mensajeBase;

        public DniInvalidoException() : base()
        {
            this.mensajeBase = "Dni invalido";
        }

        public DniInvalidoException(Exception e) : base("Dni invalido", e)
        {

        }

        public DniInvalidoException(string message) : base(message)
        {
            this.mensajeBase = "Dni invalido";
        }

        public DniInvalidoException(string message, Exception e) : base(message, e)
        { this.mensajeBase = "Dni invalido"; }
    }
}
