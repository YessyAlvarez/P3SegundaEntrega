
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using AccesosDB;

namespace Dominio
{
    public class Tramite
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public int Tiempo { get; set; }  /*Tiempo previsto de ejecuciòn en días*/
        public List<GrupoTramite> Grupos { get; set; }
        public List<Etapa> Etapas { get; set; }

        #region VALIDACION
        bool Validar()
        {
            return this.Id > 0 && this.Titulo != null && this.Descripcion != null &&
                this.Costo >= 0 && this.Tiempo >= 0;
        }
        #endregion

/*
        public bool AgregarGrupoTramite(GrupoTramite gp)
        {
            if (this.Grupos == null)
                Grupos = new List<GrupoTramite>();
            if (!gp.Validar() || this.Grupos.Contains(gp)) return false;
            Grupos.Add(gp);
            return true;

        }*/

        #region CONSTRUCTOR

        public Tramite() {

        }

        public Tramite(string titulo, string descripcion, double costo, int tiempo)
        {
            this.Titulo = titulo;
            this.Descripcion = descripcion;
            this.Costo = costo;
            this.Tiempo = tiempo;
            List<GrupoTramite> Grupos = new List<GrupoTramite>();
            List<Etapa> etapas = new List<Etapa>();
        }

        #endregion



        #region ACTIVE RECORD 

        public bool AgregarTramite()
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
                cmd.CommandText = @"INSERT INTO Tramite VALUES (@titulo, @descripcion, @costo, @tiempo);";
                cmd.Parameters.Add(new SqlParameter("@titulo", Titulo));
                cmd.Parameters.Add(new SqlParameter("@descripcion", Descripcion));
                cmd.Parameters.Add(new SqlParameter("@costo", Costo));
                cmd.Parameters.Add(new SqlParameter("@tiempo", Tiempo));

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

        public static List<Tramite> ListarTodosLosTramites()
        {
            string consulta = @"SELECT * FROM Tramite";

            SqlConnection cn = Conexion.CrearConexion();
            List<Tramite> tramites = new List<Tramite>();

            SqlCommand cmd = new SqlCommand(consulta, cn);

            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Tramite tram = CargarDatosDesdeReader(dr);

                    if (tram.Id != 0)
                    {
                        tramites.Add(tram);
                    }
                }
                dr.Close();
                return tramites;
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


        public static Tramite ObtenerTramitePorId(int idTramite)
        {
            Tramite tramite = new Tramite();

            string consulta = @"SELECT * FROM Tramite WHERE idTramite=" + idTramite;

            SqlConnection cn = Conexion.CrearConexion();
            //List<Grupo> grupos = new List<Grupo>();

            SqlCommand cmd = new SqlCommand(consulta, cn);

            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tramite = CargarDatosDesdeReader(dr);
                }
                dr.Close();
                return tramite;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return tramite;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }


        public static int ObtenerTramitePorTituloUnico(string titulo)
        {
            int idTramite = -1;

            string consulta = @"SELECT * FROM Tramite WHERE tituloTramite=@ttramite;";

            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Parameters.Add(new SqlParameter("@ttramite", titulo));

            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    idTramite = dr.GetInt32(dr.GetOrdinal("idTramite"));
                }
                dr.Close();
                return idTramite;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return idTramite;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }



        public List<Tramite> ListarLosTramites()
        {
            string consulta = @"SELECT * FROM Tramite";

            SqlConnection cn = Conexion.CrearConexion();
            List<Tramite> tramites = new List<Tramite>();

            SqlCommand cmd = new SqlCommand(consulta, cn);

            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Tramite tra = CargarDatosDesdeReader(dr);

                    if (tra.Id != 0)
                    {
                        tramites.Add(tra);
                    }
                }
                dr.Close();
                return tramites;
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

        protected static Tramite CargarDatosDesdeReader(IDataRecord fila)
        {
            Tramite tramite = null;

            if (fila != null)
            {
                tramite = new Tramite
                {
                    Id = fila.GetInt32(fila.GetOrdinal("idTramite")),
                    Titulo = fila.IsDBNull(fila.GetOrdinal("tituloTramite")) ? "" : fila.GetString(fila.GetOrdinal("tituloTramite")),
                    Descripcion = fila.IsDBNull(fila.GetOrdinal("descTramite")) ? "" : fila.GetString(fila.GetOrdinal("descTramite")),
                    Tiempo = fila.GetInt32(fila.GetOrdinal("tiempoTramite"))
                };
            }

            return tramite;
        }



        public static bool ExisteNombreTramite(string nombreTramite)
        {
            bool existe = false;
            string consulta = @"SELECT tituloTramite FROM Tramite WHERE tituloTramite=@titulo";
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Parameters.Add(new SqlParameter("@titulo", nombreTramite));
            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Tramite tra = CargarDatosDesdeReader(dr);

                    if (tra.Id != 0)
                    {
                        existe = true;
                    }
                }
                dr.Close();
                return existe;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return existe;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }

        public bool ModificarTramite()
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
                cmd.CommandText = @"UPDATE Tramite SET descripcion = @descripcion, costo = @costo, tiempo = @tiempo WHERE id = @id;";

                cmd.Parameters.Add(new SqlParameter("@id", this.Id));
                cmd.Parameters.Add(new SqlParameter("@descripcion", this.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@costo", this.Costo));
                cmd.Parameters.Add(new SqlParameter("@tiempo", this.Tiempo));

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

        #region TO STRING
        public override string ToString()
        {
            return this.Id + "|" + this.Titulo + "|" + this.Descripcion + "|" + this.Costo + "|" + this.Tiempo + "|";
        }

        /**Preguntar**/
        public string ToString2()
        {
            return this.Id + "@" + this.Etapas.ToString();
        }

        #endregion

    }
}
