
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using AccesosDB;

namespace Dominio
{
    public class Usuario
    {
        public int IdUsuario { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string NombreCompleto { set; get; }
        public EnumPerfil TipoPerfil { set; get; }
        public Grupo Rol { set; get; }

        #region CREAR USUARIO

        public bool AddFuncionario()
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
                cmd.CommandText = @"INSERT INTO Usuario VALUES (@email, @password, @nombreCompleto, @idRol);";

                cmd.Parameters.Add(new SqlParameter("@email", this.Email));
                cmd.Parameters.Add(new SqlParameter("@password", Usuario.MD5Hash(this.Password)));
                cmd.Parameters.Add(new SqlParameter("@nombreCompleto", this.NombreCompleto));
                cmd.Parameters.Add(new SqlParameter("@idRol", this.TipoPerfil));

                //int ultimoId = (int)cmd.ExecuteScalar();
                //if(ultimoId>0)
                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas == 1)
                {
                    trn.Commit();
                    return true;
                }
                else
                {
                    trn.Rollback();
                    return false;
                }
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


        #region ACTUALIZAR USUARIO

        public bool EditFuncionario()
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
                cmd.CommandText = @"UPDATE Usuario SET password=@password, nombreCompleto=@nombreCompleto WHERE email=@email;";

                cmd.Parameters.Add(new SqlParameter("@email", this.Email));
                cmd.Parameters.Add(new SqlParameter("@password", Usuario.MD5Hash(this.Password)));
                cmd.Parameters.Add(new SqlParameter("@nombreCompleto", this.NombreCompleto));
                
                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas == 1)
                {
                    trn.Commit();
                    return true;
                }
                else
                {
                    trn.Rollback();
                    return false;
                }
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


        #region BUSCAR USUARIO

        public static List<Usuario> ListarTodosLosFuncionarios()
        {
            List<Usuario> allUsuarios = new List<Usuario>();
            string consulta = @"SELECT * FROM Usuario;";
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand(consulta, cn);
            Usuario user = null;
            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    user = new Usuario
                    {
                        IdUsuario = Convert.ToInt32(dr["idUsuario"].ToString()),
                        Email = dr["email"].ToString(),
                        Password = "",
                        NombreCompleto = dr["nombreCompleto"].ToString(),
                        TipoPerfil = (EnumPerfil)Enum.ToObject(typeof(EnumPerfil), Convert.ToInt32(dr["idRol"].ToString())),
                        Rol = null
                    };
                    allUsuarios.Add(user);
                }
                dr.Close();
                return allUsuarios;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return allUsuarios;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }

        public static Usuario ObtenerUsuarioPorEmail(string email)
        {
            string consulta = @"SELECT * FROM Usuario WHERE email='" + email + "';";
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand(consulta, cn);
            Usuario user = null;
            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    user = new Usuario
                    {
                        IdUsuario = Convert.ToInt32(dr["idUsuario"].ToString()),
                        Email = email,
                        Password = "",
                        NombreCompleto = dr["nombreCompleto"].ToString(),
                        TipoPerfil = (EnumPerfil)Enum.ToObject(typeof(EnumPerfil), Convert.ToInt32(dr["idRol"].ToString())),
                        Rol = null
                    };
                    
                }
                dr.Close();
                return user;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return user;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }
        


        public static int ObtenerIdUsuarioPorEmail(string email)
        {
            int idUsuario = -1;
            string consulta = @"SELECT idUsuario FROM Usuario WHERE email='" + email + "';";
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand(consulta, cn);
            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    idUsuario = Convert.ToInt32(dr["idUsuario"].ToString());
                }
                dr.Close();
                return idUsuario;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return idUsuario;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }




        public int ObtenerRol()
        {
            int perfilUsuario = 0; //Por defecto no Autorizado

            string consulta = @"SELECT idRol FROM Usuario WHERE email='" + Email + "' AND password='" + Usuario.MD5Hash(Password) + "';";
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand(consulta, cn);
            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string perfil = dr["idRol"].ToString();
                    if (perfil.Equals("1"))
                    {
                        perfilUsuario = 1; //EnumPerfil.Admin
                    }
                    else if (perfil.Equals("2"))
                    {
                        perfilUsuario = 2; //EnumPerfil.FuncionarioMantenimiento
                    }
                    else
                    {
                        perfilUsuario = 3; //EnumPerfil.Anonimo
                    }
                }
                dr.Close();
                return perfilUsuario;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return perfilUsuario;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }

        
        public static string ObtenerNombreCompleto(string emailUsuario)
        {
            string nombreCompleto = "Sin nombre";

            string consulta = @"SELECT nombreCompleto FROM Usuario WHERE email='" + emailUsuario + "';";
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand(consulta, cn);
            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    nombreCompleto = dr["nombreCompleto"].ToString();
                }
                dr.Close();
                return nombreCompleto;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return nombreCompleto;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }

        #endregion


        #region INSERTAR tabla USUARIO-GRUPO

        public static bool InsertUsuarioGrupo(int idUsuario, int idGrupo)
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
                cmd.CommandText = @"INSERT INTO UsuarioGrupo VALUES (@idUsuario, @idGrupo);";

                cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
                cmd.Parameters.Add(new SqlParameter("@idGrupo", idGrupo)); ;

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


        #region BUSCAR tabla USUARIO-GRUPO

        public static List<Grupo> ListarTodosLosGruposPorUsuario(int idUsuario)
        {
            List<Grupo> allGrupos = new List<Grupo>();
            string consulta = @"SELECT idGrupo FROM UsuarioGrupo WHERE idUsuario=@idUsuario;";
            SqlConnection cn = Conexion.CrearConexion();
            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
            try
            {
                Conexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Grupo grupo = new Grupo
                    {
                        Codigo = Convert.ToInt32(dr["idGrupo"].ToString())
                    };
                    allGrupos.Add(grupo);
                }
                dr.Close();
                return allGrupos;
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.Message);
                return allGrupos;
            }
            finally
            {
                Conexion.CerrarConexion(cn);
            }
        }


        #endregion


        #region MASCARA PARA PASSWORD

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        #endregion


        #region TOSTRING

        public string gruposPertenece(int idUsuario)
        {
            string retorno = "";
            List<Grupo> misGrupos = ListarTodosLosGruposPorUsuario(idUsuario);
            if (misGrupos != null && misGrupos.Count>0)
            {
                foreach(Grupo grup in misGrupos)
                {
                    retorno += grup.Codigo + "#";
                }
            }
            return retorno;
        }

        public override string ToString()
        {
            return this.IdUsuario + "#" + this.Email + "#" + this.NombreCompleto + "#"
                 + this.TipoPerfil + "#" + gruposPertenece(this.IdUsuario);
        }

        #endregion


    }
}
