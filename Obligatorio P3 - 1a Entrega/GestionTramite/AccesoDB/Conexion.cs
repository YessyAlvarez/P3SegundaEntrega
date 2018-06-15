using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace AccesosDB
{
    public class Conexion
    {
        #region Manejo de la conexión.
        private static string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionGestionTramites"].ConnectionString;
        public static SqlConnection CrearConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
        public static void AbrirConexion(SqlConnection cn)
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
            }
        }
        public static void CerrarConexion(SqlConnection cn)
        {
            try
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
            }
        }
        #endregion
    }
}
