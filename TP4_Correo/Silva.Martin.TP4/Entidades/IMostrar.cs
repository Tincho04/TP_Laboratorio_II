using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Interfaz que mostrará los datos.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMostrar<T>
    {
        string MostrarDatos(IMostrar<T> elemento);
    }
}
