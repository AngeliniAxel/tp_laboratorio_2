using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excepciones
{
    public class NacionalidadInvalidaException :Exception
    {
        public NacionalidadInvalidaException() : base("La nacionalidad no se condide con el numero de DNI")
        { }

        public NacionalidadInvalidaException(string message) : base(message)
        { }
    }
}
