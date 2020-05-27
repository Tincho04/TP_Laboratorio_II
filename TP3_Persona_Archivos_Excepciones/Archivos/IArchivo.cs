using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;

namespace Archivos
{
    public interface IArchivo<T>
    {
        #region Metodos
        bool Guardar(string archivo, T datos);

        bool Leer(string archivo, out T dato);
        #endregion
    }
}
