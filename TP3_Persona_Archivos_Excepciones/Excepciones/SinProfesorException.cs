using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        #region Metodo
        /// <summary>
        /// Excepción que se disparará en cuanto una clase no posea profesor.
        /// </summary>
        public SinProfesorException() : base("No hay Profesor para la clase.")
        {
        }
        #endregion
    }
}
