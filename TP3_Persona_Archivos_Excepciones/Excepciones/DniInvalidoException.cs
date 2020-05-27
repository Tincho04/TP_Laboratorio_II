using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Aqui se listarán las excepcíones relevantes al DNI
        /// </summary>
        #region Metodos
        public DniInvalidoException() : this("El DNI no es válido.", null)
        {
        }

        public DniInvalidoException(Exception e) : this("El DNI no es valido",e)
        {
        }

        public DniInvalidoException(string message) : this(message, null)
        {
        }

        public DniInvalidoException(string message, Exception e) : base(message, e)
        {
        }
        #endregion
    }
}
