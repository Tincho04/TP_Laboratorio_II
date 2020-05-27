using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        #region Metodo
        /// <summary>
        /// Excepción a raiz de un problema con el archivo, mediante innerException
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException) : base("Surgio un problema con el archivo", innerException)
        {
        }
        #endregion
    }
}
