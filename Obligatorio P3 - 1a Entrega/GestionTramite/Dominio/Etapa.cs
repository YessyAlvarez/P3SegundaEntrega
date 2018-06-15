
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Configuration;
using AccesosDB;

namespace Dominio
{
    public class Etapa
    {
        public string IdEtapa { get; set; }
        public string Descripcion { get; set; }
        public int LapsoMax { get; set; }
        public bool Activa { get; set; }
        public int IdTramite { get; set; }


        #region VALIDAR
        public bool Validar()
        {
            return this.IdEtapa != null && this.Descripcion != null && this.LapsoMax >= 0;
        }

        #endregion

        #region CONSTRUCTOR
        public Etapa()
        {

        }

        public Etapa(string codigo, string descrpcion, int lapdoMax, int idTramite)
        {
            this.IdEtapa = codigo;
            this.Descripcion = descrpcion;
            this.LapsoMax = lapdoMax;
            this.IdTramite = idTramite;
            this.Activa = true;
        }
        #endregion

        #region METODOS
        public bool InsertarEtapa(int IdTramite)
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
                cmd.CommandText = @"INSERT INTO Etapa VALUES (@codigo, @descripcion, @lapsoMax, @activa, @idTramite);";
                cmd.Parameters.Add(new SqlParameter("@codigo", this.IdEtapa));
                cmd.Parameters.Add(new SqlParameter("@descripcion", this.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@lapsoMax", this.LapsoMax));
                cmd.Parameters.Add(new SqlParameter("@activa", 1));
                cmd.Parameters.Add(new SqlParameter("@idTramite", this.IdTramite == IdTramite));
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



        public static bool EditarEtapa(string idEtapa, string Descripcion, int tiempo)
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
                cmd.CommandText = @"UPDATE Etapa SET descripcion=@descr, lapsoMaxEtapas=@tiempo WHERE codigo=@idEtapa;";
                cmd.Parameters.Add(new SqlParameter("@idEtapa", idEtapa));
                cmd.Parameters.Add(new SqlParameter("@descr", Descripcion));
                cmd.Parameters.Add(new SqlParameter("@tiempo", tiempo));
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



        public static Etapa ObtenerEtapaPorIdEtapa(string idEtapa)
        {
            string consulta = @"SELECT * FROM Etapa WHERE codigo=@idEtapa";

            SqlConnection cn = Conexion.CrearConexion();
            Etapa eta = null;

            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Parameters.Add(new SqlParameter("@idEtapa", idEtapa));

            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    eta = CargarDatosDesdeReader(dr);
                }
                dr.Close();
                return eta;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return eta;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }


        }


        public static Etapa ObtenerEtapaPorIdTramite(int idTramite)
        {
            string consulta = @"SELECT * FROM Etapa WHERE idTramite=@idTramite";

            SqlConnection cn = Conexion.CrearConexion();
            Etapa eta = null;

            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Parameters.Add(new SqlParameter("@idTramite", idTramite));

            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    eta = CargarDatosDesdeReader(dr);
                }
                dr.Close();
                return eta;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return eta;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }




        public static List<Etapa> ListarTodasEtapas()
        {
            string consulta = @"SELECT * FROM Etapa";

            SqlConnection cn = Conexion.CrearConexion();
            List<Etapa> etapas = new List<Etapa>();

            SqlCommand cmd = new SqlCommand(consulta, cn);

            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Etapa eta = CargarDatosDesdeReader(dr);

                    if (eta.IdEtapa != "")
                    {
                        etapas.Add(eta);
                    }
                }
                dr.Close();
                return etapas;
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

        protected static Etapa CargarDatosDesdeReader(IDataRecord fila)
        {
            Etapa etapa = null;

            if (fila != null)
            {
                etapa = new Etapa
                {
                IdEtapa = fila.IsDBNull(fila.GetOrdinal("codigo")) ? "" : fila.GetString(fila.GetOrdinal("codigo")),
                Descripcion = fila.IsDBNull(fila.GetOrdinal("descripcion")) ? "" : fila.GetString(fila.GetOrdinal("descripcion")),
                LapsoMax = fila.GetInt32(fila.GetOrdinal("lapsoMaxEtapas")),
                IdTramite = fila.GetInt32(fila.GetOrdinal("idTramite"))
             };
            }
            return etapa;
        }




        public bool ModificarEtapa()
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
                cmd.CommandText = @"UPDATE Etapa SET descripcion = @descripcion WHERE codigo = @codigo;";

                cmd.Parameters.Add(new SqlParameter("@codigo", this.IdEtapa));
                cmd.Parameters.Add(new SqlParameter("@descripcion", this.Descripcion));

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




        #region TOSTRING
        public override string ToString()
        {
            return this.IdEtapa + "@" + this.Descripcion + "@" + this.LapsoMax + "@";
        }
        #endregion


    }


}


