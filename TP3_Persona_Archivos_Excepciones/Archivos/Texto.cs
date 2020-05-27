using Excepciones;
using System;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region Metodos
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo, File.Exists(archivo)))
                    writer.WriteLine(datos);
                retorno = true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }

            return retorno;
        }

        public bool Leer(string archivo, out string dato)
        {
            bool retorno = false;
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    dato = reader.ReadToEnd();
                    retorno = true;
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }

            return retorno;
        }
        #endregion
    }
}
