
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
    public class GrupoTramite
    {
        public int IdGrupoTramite { get; set; }
        public string Descripcion { get; set; }
        public int CantidadMaxFuncionarios { get; set; }
        public int IdGrupo { get; set; }
        public int IdTramite { get; set; }
        public List<Usuario> GrupoFuncionarios { get; set; }



        #region VALIDACION
        public bool Validar()
        {
            return this.Descripcion != null && CantidadMaxFuncionarios >= 0;
        }
        #endregion


        #region ACTIVE RECORD
        public bool AgregarGrupoTramite(string titulo)
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
                int idTramitePorTitulo = Tramite.ObtenerTramitePorTituloUnico(titulo);

                cmd.Parameters.Clear();
                cmd.CommandText = @"INSERT INTO GrupoTramite VALUES (@descripcion, @cantMax, @idGrupo, @idTramite);";

                cmd.Parameters.Add(new SqlParameter("@descripcion", this.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@cantMax", this.CantidadMaxFuncionarios));
                cmd.Parameters.Add(new SqlParameter("@idGrupo", this.IdGrupo));
                cmd.Parameters.Add(new SqlParameter("@idTramite", idTramitePorTitulo));

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


        public static List<Grupo> ObtenerGrupoPorIdTramite(int idTramite)
        {
            string consulta = @"SELECT GrupoTramite.idGrupo, Grupo.nombreGrupo FROM GrupoTramite, Grupo WHERE idTramite=@idTramite AND Grupo.idGrupo=GrupoTramite.idGrupo;";

            SqlConnection cn = Conexion.CrearConexion();
            List<Grupo> grupos = new List<Grupo>();

            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Parameters.Add(new SqlParameter("@idTramite", idTramite));

            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Grupo gr = CargarDatosDesdeReader(dr);
                    grupos.Add(gr);
                }
                dr.Close();
                return grupos;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return grupos;
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


        protected static GrupoTramite CargarDatosDesdeReaderGrupoTramite(IDataRecord fila)
        {
            GrupoTramite grupo = null;

            if (fila != null)
            {
                grupo = new GrupoTramite
                {
                    IdGrupoTramite = fila.GetInt32(fila.GetOrdinal("idGrupoTramite")),
                    Descripcion = fila.IsDBNull(fila.GetOrdinal("descripcion")) ? "" : fila.GetString(fila.GetOrdinal("descripcion")),
                    CantidadMaxFuncionarios = fila.GetInt32(fila.GetOrdinal("cantMaxFuncionarios")),
                    IdGrupo = fila.GetInt32(fila.GetOrdinal("idGrupo")),
                    IdTramite = fila.GetInt32(fila.GetOrdinal("idTramite"))
                };
            }
            return grupo;
        }


        public static List<GrupoTramite> ObtenerListadoDeGrupoTramitePorIdTramite(int idTramite)
        {
            List<GrupoTramite> retorno = new List<GrupoTramite>();
            string consulta = @"SELECT * FROM GrupoTramite WHERE idTramite=@idTramite;";

            SqlConnection cn = Conexion.CrearConexion();
            
            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Parameters.Add(new SqlParameter("@idTramite", idTramite));

            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    GrupoTramite gr = CargarDatosDesdeReaderGrupoTramite(dr);
                    retorno.Add(gr);
                }
                dr.Close();
                return retorno;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return retorno;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }

        #endregion
    }

}

