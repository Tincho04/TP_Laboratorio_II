using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
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
                if (File.Exists(archivo))
                {
                    using (StreamWriter writer = File.AppendText(archivo))
                    writer.WriteLine(datos);
                }
                else
                {
                    StreamWriter writer = File.CreateText(archivo);
                    writer.WriteLine(datos);
                    writer.Close();
                }
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
                    reader.Close();
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
