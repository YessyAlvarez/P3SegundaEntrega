
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data;
using AccesosDB;

namespace Dominio
{
    public class Grupo
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        
        #region CONTRUCTOR

        public Grupo()
        {
            this.Nombre = "";
        }

        #endregion


        #region VALIDACION
        bool Validar()
        {
            return this.Nombre != null;
        }
        #endregion

        #region ACTIVE RECORD
        public bool AgregarGrupo()
        {
            SqlConnection cn = Conexion.CrearConexion();

            SqlCommand cmd = new SqlCommand();
            SqlTransaction trn = null;
            cmd.Connection = cn;
            try
            {
                if (!this.Validar()) return false;
                Conexion.AbrirConexion(cn);
                trn = cn.BeginTransaction();
                cmd.Transaction = trn;
                
                cmd.Parameters.Clear();
                cmd.CommandText = @"INSERT INTO Grupo VALUES (@nombre);";

                cmd.Parameters.Add(new SqlParameter("@nombre", Nombre));

                cmd.ExecuteNonQuery();

                trn.Commit();
                trn.Dispose();
                return true;
            }
            catch (SqlException ex)
            {
                Debug.Assert(false, ex.Message);
                trn.Rollback();
                return false;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }
        


        public bool ModificarGrupo()
        {
            SqlConnection cn = Conexion.CrearConexion();

            SqlCommand cmd = new SqlCommand();
            SqlTransaction trn = null;
            cmd.Connection = cn;
            try
            {
                if (!this.Validar()) return false;
                Conexion.AbrirConexion(cn);
                trn = cn.BeginTransaction();
                cmd.Transaction = trn;

                cmd.Parameters.Clear();
                cmd.CommandText = @"UPDATE Grupo SET nombreGrupo = @nombre WHERE idGrupo = @idgrupo;";

                cmd.Parameters.Add(new SqlParameter("@idgrupo", this.Codigo));
                cmd.Parameters.Add(new SqlParameter("@nombre", this.Nombre));

                cmd.ExecuteNonQuery();

                trn.Commit();
                trn.Dispose();
                return true;
            }
            catch (SqlException ex)
            {
                Debug.Assert(false, ex.Message);
                trn.Rollback();
                return false;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }

        }



        public static bool EliminarGrupo(string nombreGrupo)
        {
            SqlConnection cn = Conexion.CrearConexion();

            SqlCommand cmd = new SqlCommand();
            SqlTransaction trn = null;
            cmd.Connection = cn;
            try
            {
                Conexion.AbrirConexion(cn);
                trn = cn.BeginTransaction();
                cmd.Transaction = trn;

                cmd.Parameters.Clear();
                cmd.CommandText = @"DELETE Grupo WHERE nombreGrupo = @nombre;";

                cmd.Parameters.Add(new SqlParameter("@nombre", nombreGrupo));

                cmd.ExecuteNonQuery();

                trn.Commit();
                trn.Dispose();
                return true;
            }
            catch (SqlException ex)
            {
                Debug.Assert(false, ex.Message);
                trn.Rollback();
                return false;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }

        }



        #endregion

        #region METODO

        public static List<Grupo> ListarTodosLosGruposDeUnUsuario(int idUsuario)
        {
            string consulta = @"SELECT idGrupo FROM UsuarioGrupo WHERE idUsuario=" + idUsuario + ";";

            SqlConnection cn = Conexion.CrearConexion();
            List<Grupo> grupos = new List<Grupo>();

            SqlCommand cmd = new SqlCommand(consulta, cn);
            

            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Grupo grup = CargarDatosDesdeReader(dr);

                    if (grup.Codigo != 0)
                    {
                        grupos.Add(grup);
                    }
                }
                dr.Close();
                return grupos;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return null;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }

        public static List<Grupo>LlistarTodosLosGruposDeUnUsuario(int idUsuario)
        {
            string consulta = @"SELECT idGrupo FROM UsuarioGrupo WHERE idUsuario=" + idUsuario + ";";

            SqlConnection cn = Conexion.CrearConexion();
            List<Grupo> grupos = new List<Grupo>();

            SqlCommand cmd = new SqlCommand(consulta, cn);


            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Grupo grup = CargarDatosDesdeReader(dr);

                    if (grup.Codigo != 0)
                    {
                        grupos.Add(grup);
                    }
                }
                dr.Close();
                return grupos;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return null;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }


        public static List<Grupo> ListarTodosLosGruposVacios() {
            string consulta = @"SELECT * FROM Grupo WHERE idGrupo NOT IN (SELECT idGrupo FROM GrupoTramite GROUP BY idGrupo);";

            SqlConnection cn = Conexion.CrearConexion();
            List<Grupo> grupos = new List<Grupo>();

            SqlCommand cmd = new SqlCommand(consulta, cn);

            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Grupo grup = CargarDatosDesdeReader(dr);

                    if (grup.Codigo != 0)
                    {
                        grupos.Add(grup);
                    }
                }
                dr.Close();
                return grupos;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return null;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }


        public static List<Grupo> ListarTodosLosGrupos()
        {
            string consulta = @"SELECT * FROM Grupo";

            SqlConnection cn = Conexion.CrearConexion();
            List<Grupo> grupos = new List<Grupo>();

            SqlCommand cmd = new SqlCommand(consulta, cn);

            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Grupo grup = CargarDatosDesdeReader(dr);

                    if (grup.Codigo != 0)
                    {
                        grupos.Add(grup);
                    }
                }
                dr.Close();
                return grupos;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return null;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }

        public static List<Grupo> MiListarTodosLosGrupos()
        {
            List<Grupo> grupos = new List<Grupo>();


            string consulta = @"SELECT nombreGrupo FROM Grupo";
            SqlConnection cn = Conexion.CrearConexion();

            SqlCommand cmd = new SqlCommand(consulta, cn);

            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Grupo grup = CargarDatosDesdeReader(dr);
                    grupos.Add(grup);
                }
                dr.Close();
                return grupos;
            }
            catch ( Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return null;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }
            
 
        public static Grupo ObtenerGrupoPorId(int idGrupo) {
            Grupo grupo = new Grupo();
            
            string consulta = @"SELECT * FROM Grupo WHERE idGrupo=" + idGrupo;

            SqlConnection cn = Conexion.CrearConexion();
            //List<Grupo> grupos = new List<Grupo>();

            SqlCommand cmd = new SqlCommand(consulta, cn);

            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Grupo grup = CargarDatosDesdeReader(dr);
                }
                dr.Close();
                return grupo;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return null;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }

        protected static Grupo CargarDatosDesdeReader(IDataRecord fila)
        {
            Grupo grupo = null;

            if (fila != null)
            {
                grupo = new Grupo
                {
                    Codigo = fila.GetInt32(fila.GetOrdinal("idGrupo")),
                    Nombre = fila.IsDBNull(fila.GetOrdinal("nombreGrupo")) ? "" : fila.GetString(fila.GetOrdinal("nombreGrupo"))
                };
            }
            return grupo;
        }

        


        #endregion

        #region TOSTRING
        public override string ToString()
        {
            return this.Nombre + "$" + this.Codigo;
        }
        #endregion

    }
}
