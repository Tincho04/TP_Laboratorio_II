using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesAbstractas;
using Instancias;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniInvalido()
        {
            Alumno a = new Alumno(1, "SubjectTest", "1", "xxxxxx", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void NacionalidadInvalida()
        {
            Alumno a = new Alumno(2, "SubjectTest", "2", "1234", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);
        }

        [TestMethod]
        public void ValidaAtributoTipoColeccion()
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(3, "SubjectTest", "3", "987654", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            uni += a1;
            Assert.IsNotNull(uni.Alumnos);
        }
    }
}
