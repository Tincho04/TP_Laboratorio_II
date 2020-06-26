using System.Collections.Generic;
using System.Text;
using System.Threading;
using System;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region Propiedades
        public List<Paquete> Paquetes
        {
            get { return paquetes; }
            set { paquetes = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// constructor de la instancia correo
        /// </summary>
        public Correo()
        {
            paquetes = new List<Paquete>();
            mockPaquetes = new List<Thread>();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// verificará la existencia de cada hilo y los finalizará
        /// </summary>
        public void finEntregas()
        {
            foreach (Thread hilo in this.mockPaquetes)
            {
                hilo.Abort();
            }
        }
        /// <summary>
        /// Muestra los datos de cada paquete en el correo
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Paquete p in Paquetes)
            {
                sb.AppendFormat("{0} para {1} ({2})\n", p.TrackingID,
                    p.DireccionEntrega, p.Estado.ToString());
            }
            return sb.ToString();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Agrega un nuevo paquete anexándole la vida de un nuevo hilo
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete paquete in c.Paquetes)
            {
                if (paquete == p)
                {
                    throw new TrackingIdRepetidoException("Tracking ID repetido");
                }
            }
            try
            {
                c.Paquetes.Add(p);
                Thread hilo = new Thread(p.MockCicloDeVida);
                c.mockPaquetes.Add(hilo);
                hilo.Start();
                return c;
            }
            catch (Exception e)
            {
                throw new Exception("Error en base de datos: " + e.Message);
            }
        }
        #endregion
    }
}
