using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesosDB;

namespace Dominio
{
    public class GestionTramites
    {

             

        

        #region GRUPOS

        public Boolean AddGrupo(string nombreGrupo) {
            //Verifico que no hay aotro repetido antes de mandarlo al Servicio web?
            Boolean retorno = true;
            //Llamo al ws
            //retorno = a.AddGrupo(nombreGrupo);
            return retorno;
        }


        public static List<Grupo> ListarTodosLosGrupos()
        {
            return Grupo.ListarTodosLosGrupos();
        }


        public static List<Grupo> ListarTodosLosGruposVacios()
        {
            return Grupo.ListarTodosLosGruposVacios();
        }


        public static void EliminarGrupo(string nombreGrupo)
        {
            Grupo.EliminarGrupo(nombreGrupo);
        }

        public static bool AgregarUsuarioGrupo(int idUsuario, int idGrupo)
        {
            return Usuario.InsertUsuarioGrupo(idUsuario, idGrupo);
        }


        public static List<Grupo> ListarTodosLosGruposDeUnUsuario(int idUsuario)
        {
            return Grupo.ListarTodosLosGruposDeUnUsuario(idUsuario);
        }


        public static Grupo ObtenerGrupoPorId(int idGrupo)
        {
            return Grupo.ObtenerGrupoPorId(idGrupo);
        }

        #endregion


        #region USUARIO


        public static List<Usuario> ListarTodosLosFuncionarios()
        {
            return Usuario.ListarTodosLosFuncionarios();
        }
        public static Usuario ObtenerUsuarioPorEmail(string email)
        {
            return Usuario.ObtenerUsuarioPorEmail(email);
        }
        

        public static List<int> RetornarPerfiles()
        {
            List<int> perfiles = new List<int>();
            int i = 0;
            foreach (EnumPerfil p in Enum.GetValues(typeof(EnumPerfil)))
            {
                if (!(p == EnumPerfil.Anonimo || p == EnumPerfil.NoAutorizado))
                {
                    perfiles.Add(i);
                }
                i++;
            }
            return perfiles;
        }


        #endregion


        #region GUARDAR EN .TXT

        public static bool GenerarTxt_Grupos()
        {
            bool ok = true;
            
            //Cargar la lista de Grupos
            List<Grupo> grupos = Grupo.ListarTodosLosGrupos();

            //Crear o reemplazar el archivo
            string path = @"C:\Users\Jessi\Desktop\Grupos.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            File.Create(path).Close();
            
            //Crear string para escribir en el txt
            TextWriter tw = new StreamWriter(path);
            foreach (Grupo g in grupos)
            {
                string textoArchivo = null;
                textoArchivo += g.ToString();
                    
                tw.WriteLine(textoArchivo);
            }
            tw.Close();

            return ok;
        }


        public static bool GenerarTxt_Funcionarios()
        {
            bool ok = true;

            //Cargar la lista de Grupos
            List<Usuario> usuarios = Usuario.ListarTodosLosFuncionarios();

            //Crear o reemplazar el archivo
            string path = @"C:\Users\Jessi\Desktop\Funcionarios.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            File.Create(path).Close();

            //Crear string para escribir en el txt
            TextWriter tw = new StreamWriter(path);
            foreach (Usuario user in usuarios)
            {
                string textoArchivo = null;
                textoArchivo += user.ToString();

                tw.WriteLine(textoArchivo);
            }
            tw.Close();

            return ok;
        }


        public static bool GenerarTxt_Tramites()
        {
            bool ok = true;
            //Cargar la lista de Grupos
            List<Tramite> allTramites = Tramite.ListarTodosLosTramites();

            //Crear o reemplazar el archivo
            string path = @"C:\Users\Jessi\Desktop\Tramites.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            File.Create(path).Close();

            string pathEtapa = @"C:\Users\Jessi\Desktop\TramitesEtapa.txt";
            if (File.Exists(pathEtapa))
            {
                File.Delete(pathEtapa);
            }
            File.Create(pathEtapa).Close();


            string pathGrupo = @"C:\Users\Jessi\Desktop\TramitesGrupo.txt";
            if (File.Exists(pathGrupo))
            {
                File.Delete(pathGrupo);
            }
            File.Create(pathGrupo).Close();

            //Crear string para escribir en el txt
            TextWriter tw = new StreamWriter(path);
            int idTramite = -1;
            foreach (Tramite tr in allTramites)
            {
                idTramite = tr.Id;
                string textoArchivo = null;
                textoArchivo += tr.ToString();

                tw.WriteLine(textoArchivo);
                GenerarTxt_Tramites_Etapas(idTramite, pathEtapa);
                GenerarTxt_Tramites_Grupos(idTramite, pathGrupo);
            }
            tw.Close();

            return ok;
        }

        public static void GenerarTxt_Tramites_Etapas(int idTramite, string pathEtapa)
        {
            Etapa miEtapa = Etapa.ObtenerEtapaPorIdTramite(idTramite);

            if (miEtapa != null)
            {
                //Crear string para escribir en el txt
                TextWriter tw = new StreamWriter(pathEtapa);

                string textoArchivo = null;
                textoArchivo += miEtapa.ToString();

                tw.WriteLine(textoArchivo);

                tw.Close();
            }
            
        }


        public static void GenerarTxt_Tramites_Grupos(int idTramite, string pathGrupo)
        {
            List<Grupo> misGrupos = GrupoTramite.ObtenerGrupoPorIdTramite(idTramite);

            if (misGrupos != null)
            {
                //Crear string para escribir en el txt
                TextWriter tw = new StreamWriter(pathGrupo);

                foreach (Grupo gr in misGrupos)
                {
                    string textoArchivo = null;
                    textoArchivo += idTramite + "$" + gr.ToString();

                    tw.WriteLine(textoArchivo);
                }
                tw.Close();
            }
        }


        #endregion


    }
}
