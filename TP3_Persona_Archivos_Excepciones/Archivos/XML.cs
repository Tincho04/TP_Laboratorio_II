﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class XML<T> : IArchivo<T>
    {
        #region Metodos
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            try
            {
                XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8);
                serializer.Serialize(writer, datos);
                retorno = true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
            return retorno;
        }

        public bool Leer(string archivo, out T dato)
        {
            bool retorno = false;
            XmlSerializer serializer = new XmlSerializer(typeof(string));
            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    dato = (T)serializer.Deserialize(reader);
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
