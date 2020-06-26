using System;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;
        static PaqueteDAO()
        {
            PaqueteDAO.conexion = new SqlConnection("Data Source = .\\SQLEXPRESS; Database = correo-sp-2017; Trusted_Connection = True;");
            PaqueteDAO.comando = new SqlCommand();
            PaqueteDAO.comando.CommandType = CommandType.Text;
            PaqueteDAO.comando.Connection = PaqueteDAO.conexion;
        }
        /// <summary>
        /// guarda los datos de los paquetes en la base de datos
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            try
            {
                PaqueteDAO.comando.CommandText = "insert into dbo.Paquetes values(@direccionEntrega, @trackingID, @alumno)";

                comando.Parameters.Add(new SqlParameter("direccionEntrega", p.DireccionEntrega));
                comando.Parameters.Add(new SqlParameter("trackingID", p.TrackingID.ToString()));
                comando.Parameters.Add(new SqlParameter("alumno", "Silva Martín"));

                conexion.Open();
                PaqueteDAO.comando.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Error en base de datos: " + e.Message);
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
