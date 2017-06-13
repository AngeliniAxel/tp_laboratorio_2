using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesAbstractas;
using EntidadesInstanciables;

namespace UniversidadUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Crea un profesor con un Dni invalido y verifica que tire la excepcion correcta
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void ComprobarExcepcionDniInvalido()
        {
            Profesor uno = new Profesor(2, "Axel", "Angelini", "-5", Persona.ENacionalidad.Argentino);
        }

        /// <summary>
        /// Crea un alumno con un Dni que no corresponde con su nacionalidad
        /// Y verifica que tire excepcion correcta
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void ComprobarExcepcionNacionalidadInvalida()
        {
            Alumno uno = new Alumno(2, "Nazareno", "Loria", "12234458", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);
        }

        /// <summary>
        /// Intenta crear una clase sin profesor que pueda darla
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void ComprobarExcepcionSinProfesor()
        {
            Universidad uni = new Universidad();
            uni += Universidad.EClases.Programacion;
        }

        /// <summary>
        /// Carga datos invalidos en Dni y verifica que no se carguen
        /// </summary>
        [TestMethod]
        public void ComprobarLetrasEnDni()
        {
            Alumno aux = new Alumno(56, "Javier", "Romero", "36dfg890", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);
            Assert.AreEqual(aux.DNI, 0);
        }

        /// <summary>
        /// Carga null en apellido y constata que se cargue un string vacio
        /// </summary>
        [TestMethod]
        public void ComprobarValorNuloEnApellido()
        {
            Profesor aux = new Profesor(5, "Facundo", null, "35876345", Persona.ENacionalidad.Argentino);
            Assert.AreEqual(aux.Apellido, "");
        }

        /// <summary>
        /// Intenta cargar un null en Dni y verifica que se haya cargado el valor correcto para salvar el error
        /// </summary>
        [TestMethod]
        public void ComprobarValorNuloEnDni()
        {
            Profesor aux = new Profesor(5, "Facundo", "Abieri", null, Persona.ENacionalidad.Argentino);
            Assert.AreEqual(aux.DNI, 0);
        }
    }
}
