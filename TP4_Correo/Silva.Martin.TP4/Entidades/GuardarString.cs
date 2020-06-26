using System;
using System.IO;

namespace Entidades
{
    public static class GuardarString
    {
        /// <summary>
        ///Crear un método de extensión para la clase String.
        /// Este guardará en un archivo de texto en el escritorio de la máquina.
        /// Recibirá como parámetro el nombre del archivo.
        /// Si el archivo existe, agregará información en él.
        /// </summary>
        /// <param name="texto">texto a agregar</param>
        /// <param name="archivo">nombre del archivo</param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo, File.Exists(archivo)))
                    writer.WriteLine(texto);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}