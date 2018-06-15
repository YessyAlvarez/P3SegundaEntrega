
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
    public class Solicitante
    {
        public string Ci { get; set; }
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        #region VALIDACION
        bool Validar()
        {
            return this.Ci != null && this.NombreCompleto != null && this.Telefono != null && this.Email != null;
        }
        #endregion

        #region ACTIVE RECORD
        public bool AgregarSolicitante()
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
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                //procedimiento para verificar si ya existe el ci
                cmd.CommandText = @"CREATE PROCEDURE verificarCedula (@ci) AS IF EXIST (SELECT ci FROM Solicitante WHERE ci = @ci) BEGIN PRINT 'Ya existe esta Cédula de Identidad' END ELSE INSERT INTO Solicitante VALUES (@ci, @nombreCompleto, @telefono, @email);";
                cmd.Parameters.AddWithValue("@ci", Ci);
                cmd.Parameters.Add(new SqlParameter("@ci", Ci));
                cmd.Parameters.Add(new SqlParameter("@nombreCompleto", NombreCompleto));
                cmd.Parameters.Add(new SqlParameter("@telefono", Telefono));
                cmd.Parameters.Add(new SqlParameter("@email", Email));
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

        #endregion

        #region TOSTRING
        public override string ToString()
        {
            return "Cédula: " + this.Ci + " Nombre Completo: " + this.NombreCompleto + " Teléfono: " + this.Telefono + " Email: " + this.Email;
        }
        #endregion


    }
}
