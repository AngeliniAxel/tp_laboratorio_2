using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excepciones
{
    public class SinProfesorException :Exception
    {
        public SinProfesorException() : base("Sin profesor")
        { }
    }
}
