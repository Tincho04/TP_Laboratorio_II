using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidarPaquetesInstanciados()
        {
            ///Arrange: Genera el correo para verificar
            Correo c = new Correo();
            ///Act - Assert: se verifica que la lista de paquetes esté instanciada.
            Assert.IsNotNull(c.Paquetes);
        }
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void ValidarPaquetesRepetidos()
        {///Arrange: Se generan dos paquetes con el mismo TrackID para verificar si pueden agregarse pese a ser repetidos.
            Correo c = new Correo();
            c += new Paquete("Subject_Test1", "123456789");
            c += new Paquete("Subject_Test2", "123456789");

        }
    }
}
