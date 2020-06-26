using System;
using System.Text;
using System.Threading;

namespace Entidades
{
#pragma warning disable CS0660, CS0661
    public class Paquete : IMostrar<Paquete>
    {
        #region Delegado
        public delegate void DelegadoEstado(object sender, EventArgs e);
        #endregion

        #region Evento
        public event DelegadoEstado InformaEstado;
        #endregion

        #region Enumerado
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado,
        }
        #endregion

        #region Atributos
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #endregion

        #region Propiedades
        /// <summary>
        /// propiedades de las instancias de paquetes
        /// </summary>
        public string TrackingID
        {
            get { return trackingID; }
            set { trackingID = value; }
        }

        public EEstado Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string DireccionEntrega
        {
            get { return direccionEntrega; }
            set { direccionEntrega = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// constructor de instacia
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trinckingID"></param>
        public Paquete(string direccionEntrega, string trinckingID)
        {
            DireccionEntrega = direccionEntrega;
            TrackingID = trinckingID;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// muestra los datos de una instacia paquete
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} para {1}\n", TrackingID, DireccionEntrega);
            return sb.ToString();
        }
        /// <summary>
        /// Cada cuatro segundos modificará el estado de los paquetes hasta entregarlos y posteriormente los registrará en la Base de Datos.
        /// </summary>
        public void MockCicloDeVida()
        {
            for (int i = 0; i < 3; i++)
            {
                Estado = (EEstado)i;
                InformaEstado(this, new EventArgs());
                Thread.Sleep(4000);
            }
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception e)
            {
                throw new Exception("Error en base de datos: " + e.Message);
            }
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Dos paquetes serán iguales siempre y cuando su Tracking ID sea el mismo
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingID == p2.TrackingID;
        }
        /// <summary>
        /// Dos paquetes serán distintos siempre y cuando su Tracking ID sea distinto
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion

        #region Sobrecarga
        /// <summary>
        /// override de ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion
    }
}
