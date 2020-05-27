using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Excepciones con respecto a la nacionalidad.
        /// </summary>
        #region Metodos
        public NacionalidadInvalidaException()
        {
        }

        public NacionalidadInvalidaException(string message) : base(message)
        {
        }
        #endregion
    }
}
