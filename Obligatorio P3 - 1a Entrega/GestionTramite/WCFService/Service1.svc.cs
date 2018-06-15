using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Dominio;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public bool WCFAddGrupo(string nombreGrupo)
        {
            Grupo grupo = new Grupo
            {
                Nombre = nombreGrupo
            };
            return grupo.AgregarGrupo();
        }

        public bool WCFAddTramite(string titulo, string desc, double costo, int tiempo)
        {
            Tramite tramite = new Tramite
            {
                Titulo = titulo,
                Descripcion = desc,
                Costo = costo,
                Tiempo = tiempo
            };

            return tramite.AgregarTramite();
        }

        public bool WCFGuardarTxt()
        {
            throw new NotImplementedException();
        }

        
        public bool WCFEditarEtapaCodDes(string codigo, string descripcion)
        {
            Etapa eta = new Etapa
            {
                IdEtapa = codigo,
                Descripcion = descripcion
            };
            return eta.ModificarEtapa();
        }

        public bool WCFExisteNombreTramite(string nombreTramite)
        {
            return Tramite.ExisteNombreTramite(nombreTramite);
        }


        public List<DTOTramite> WCFListarTramites()
        {
            List<DTOTramite> dtoTramites = new List<DTOTramite>();
            List<Tramite> tramites = Tramite.ListarTodosLosTramites();
            foreach (Tramite tt in tramites)
            {
                DTOTramite dto = new DTOTramite
                {
                    Id = tt.Id,
                    Titulo = tt.Titulo,
                    Descripcion = tt.Descripcion
                };
                dtoTramites.Add(dto);
            }
            return dtoTramites;
        }

        public List<DTOTramite> WCFGetTramite()
        {
            List<DTOTramite> dtoTramites = new List<DTOTramite>();
            List<Tramite> tramites = Tramite.ListarTodosLosTramites();
            foreach (Tramite tt in tramites)
            {
                DTOTramite dto = new DTOTramite
                {
                    Id = tt.Id,
                    Titulo = tt.Titulo,
                    Descripcion = tt.Descripcion
                };
                dtoTramites.Add(dto);
            }
            return dtoTramites;
        }

        public DTOTramite WCFObtenerTramitePorId(int idTramite)
        {
            Tramite tr = Tramite.ObtenerTramitePorId(idTramite);
            DTOTramite tramite = new DTOTramite
            {
                Id = tr.Id,
                Costo = tr.Costo,
                Descripcion = tr.Descripcion,
                Tiempo = tr.Tiempo,
                Titulo = tr.Titulo
            };

            return tramite;
        }

        public void WCFEditarTramite(int Id, string Descripcion, double Costo, int Tiempo)
        {
            Tramite tra = new Tramite
            {
                Id = Id,
                Descripcion = Descripcion,
                Costo = Costo,
                Tiempo = Tiempo
            };
            tra.ModificarTramite();

        }

        public bool WCFAddEtapa(string Codigo, string Descripcion, int LapsoMax, int IdTramite)
        {
            Etapa et = new Etapa(Codigo, Descripcion, LapsoMax, IdTramite);
            return et.InsertarEtapa(IdTramite);
        }

        public List<DTOEtapa> WCFListarEtapas()
        {
            List<DTOEtapa> grupos = new List<DTOEtapa>();
            List<Etapa> upEtapas = Etapa.ListarTodasEtapas();
            foreach (Etapa e in upEtapas)
            {
                DTOEtapa gpo = new DTOEtapa
                {
                    IdEtapa = e.IdEtapa,
                    Descripcion = e.Descripcion,
                    LapsoMax = e.LapsoMax,
                    IdTramite = e.IdTramite
                };
                grupos.Add(gpo);
            }
            return grupos;
        }

        public List<DTOGrupo> WCFGetGrupo()
        {
            List<DTOGrupo> grupos = new List<DTOGrupo>();
            List<Grupo> upGrupos = GestionTramites.ListarTodosLosGrupos();
            foreach (Grupo grupo in upGrupos)
            {
                DTOGrupo gpo = new DTOGrupo
                {
                    Codigo = grupo.Codigo,
                    Nombre = grupo.Nombre
                };
                grupos.Add(gpo);
            }
            return grupos;
        }

        public DTOGrupo WCFObtenerGrupoPorId(int idGrupo)
        {
            Grupo upGrupo = GestionTramites.ObtenerGrupoPorId(idGrupo);
            DTOGrupo gpo = new DTOGrupo
            {
                Codigo = upGrupo.Codigo,
                Nombre = upGrupo.Nombre
            };
            return gpo;
        }

        public List<DTOGrupo> WCFListarGrupos()
        {
            List<DTOGrupo> grupos = new List<DTOGrupo>();
            List<Grupo> upGrupos = GestionTramites.ListarTodosLosGrupos();
            foreach(Grupo grupo in upGrupos)
            {
                DTOGrupo gpo = new DTOGrupo
                {
                    Codigo = grupo.Codigo,
                    Nombre = grupo.Nombre
                };
                grupos.Add(gpo);
            }
            return grupos;
        }

        public void WCFEditGrupo(int idGrupo, string nombreGrupo)
        {
            Grupo grupo = new Grupo
            {
                Codigo = idGrupo,
                Nombre = nombreGrupo
            };
            grupo.ModificarGrupo();
        }


        public int WCFValidarUsuario(string usuario, string password)
        {
            Usuario user = new Usuario
            {
                Email = usuario,
                Password = password
            };
            return user.ObtenerRol();
        }


        public string WCFGetNombreCompleto(string emailUsuario)
        {
            return Usuario.ObtenerNombreCompleto(emailUsuario);
        }


        public List<DTOGrupo> WCFListarGruposVacios()
        {
            List<DTOGrupo> grupos = new List<DTOGrupo>();
            List<Grupo> upGrupos = GestionTramites.ListarTodosLosGruposVacios();
            foreach (Grupo grupo in upGrupos)
            {
                DTOGrupo gpo = new DTOGrupo
                {
                    Codigo = grupo.Codigo,
                    Nombre = grupo.Nombre
                };
                grupos.Add(gpo);
            }
            return grupos;
        }



        public void WCFEliminarGrupo(string nombreGrupo)
        {
            GestionTramites.EliminarGrupo(nombreGrupo);
        }

        

        public bool WCFAddFuncionario(string email, string password, string perfil, string nombreCompleto)
        {
            EnumPerfil enumP = new EnumPerfil();
            int i = 0;
            foreach (EnumPerfil pp in Enum.GetValues(typeof(EnumPerfil)))
            {
                if (!(pp.ToString().Equals(perfil)))
                {
                    enumP = pp;
                    continue;
                }
                i++;
            }
            Usuario usuario = new Usuario
            {
                Email = email,
                NombreCompleto = nombreCompleto,
                Password = password,
                TipoPerfil = enumP
            };
            return usuario.AddFuncionario();
        }

        public int WCFObtenerIdUSuario(string email)
        {
            return Usuario.ObtenerIdUsuarioPorEmail(email);
        }

        public bool WCFAddUsuarioGrupo(int idUsuario, int idGrupo)
        {
            return GestionTramites.AgregarUsuarioGrupo(idUsuario, idGrupo);
        }

        public List<DTOGrupo> WCFListarGrupoUsuario(int idUsuario)
        {
            List<DTOGrupo> grupos = new List<DTOGrupo>();
            List<Grupo> upGrupos = GestionTramites.ListarTodosLosGruposDeUnUsuario(idUsuario);
            foreach (Grupo grupo in upGrupos)
            {
                DTOGrupo gpo = new DTOGrupo
                {
                    Codigo = grupo.Codigo,
                    Nombre = grupo.Nombre
                };
                grupos.Add(gpo);
            }
            return grupos;
        }

        public List<int> WCFListarPerfiles()
        {
            return GestionTramites.RetornarPerfiles();
        }

        /*
        public List<EnumPerfil> WCFListarPerfiles => GestionTramites.RetornarPerfiles();
        
            */
        /*    public List<DTOEnumPerfil> WCFListarPerfiles()
            {
                List<DTOEnumPerfil> perfilesDTO = new List<DTOEnumPerfil>();
                int i = 0;
                foreach (EnumPerfil p in Enum.GetValues(typeof(EnumPerfil)))
                {
                    if (!(p == EnumPerfil.Anonimo || p == EnumPerfil.NoAutorizado))
                    {
                        DTOEnumPerfil DTOp = (DTOEnumPerfil)Enum.ToObject(typeof(DTOEnumPerfil), i);
                        string uno = DTOp.ToString();
                        string dos = p.ToString();
                        if (uno.Equals(dos))
                        {
                            perfilesDTO.Add(DTOp);
                        }
                    }
                    i++;
                }
                return perfilesDTO;
            }
            */

        /*public List<DTOGrupo> WCFListarGrupoUsuario(int idUsuario)
        {
            List<DTOGrupo> grupos = new List<DTOGrupo>();
            List<Grupo> listGrupos = Grupo.ListarTodosLosGruposDeUnUsuario(idUsuario);
            foreach (Grupo grupo in listGrupos)
            {
                DTOGrupo gpo = new DTOGrupo
                {
                    Codigo = grupo.Codigo,
                    Nombre = grupo.Nombre
                };
                grupos.Add(gpo);
            }
            return grupos;
        }*/

        public DTOUsuario WCFObtenerUsuario(string email)
        {
            Usuario obtenido = GestionTramites.ObtenerUsuarioPorEmail(email);
            DTOUsuario user = new DTOUsuario
            {
                IdUsuario = obtenido.IdUsuario,
                Email = email,
                Password = obtenido.Password,
                NombreCompleto = obtenido.NombreCompleto,
                TipoPerfil = obtenido.TipoPerfil,
                Rol = obtenido.Rol

            };
            return user;
        }

        public List<DTOUsuario> WCFListarFuncionarios()
        {
            List<DTOUsuario> usuarios = new List<DTOUsuario>();
            List<Usuario> allUsuarios = GestionTramites.ListarTodosLosFuncionarios();
            foreach (Usuario all in allUsuarios)
            {
                DTOUsuario user = new DTOUsuario
                {
                    IdUsuario = all.IdUsuario,
                    Email = all.Email,
                    NombreCompleto = all.NombreCompleto,
                    Password = "",
                    Rol = all.Rol,
                    TipoPerfil = all.TipoPerfil
                };
                usuarios.Add(user);
            }
            return usuarios;
        }

        public bool WCFGuardarTxt_Grupos()
        {
            bool ret = false;
            GestionTramites.GenerarTxt_Grupos();
            if (File.Exists(@"C:\Users\Jessi\Desktop\Grupos.txt"))
            {
                ret = true;
            }
            return ret;
        }

        public bool WCFGuardarTxt_Funcionarios()
        {
            bool ret = false;
            GestionTramites.GenerarTxt_Funcionarios();
            if (File.Exists(@"C:\Users\Jessi\Desktop\Funcionarios.txt"))
            {
                ret = true;
            }
            return ret;
        }

        public bool WCFGuardarTxt_Tramites()
        {
            bool ret = false;
            GestionTramites.GenerarTxt_Tramites();
            if (File.Exists(@"C:\Users\Jessi\Desktop\Tramites.txt"))
            {
                ret = true;
            }
            return ret;
        }


        public bool WCFAddGrupoTramite(DTOGrupoTramite gt, string tituloTramiteUnico)
        {
            bool ok = true;
            GrupoTramite grupoT = new GrupoTramite
            {
                Descripcion = gt.Descripcion,
                CantidadMaxFuncionarios = gt.CantidadMaxFuncionarios,
                IdGrupo = gt.IdGrupo,
                GrupoFuncionarios = new List<Usuario>()
            };
            ok = grupoT.AgregarGrupoTramite(tituloTramiteUnico);
            
            return ok;
        }


        public int WCFAddGrupoDeGRupoTramitePorIdGT(int idGrupoTramite)
        {
            int id = 0;


            return id;
        }

        public bool WCFEditarEtapa(string idEtapa, string Descripcion, int tiempo)
        {
            return Etapa.EditarEtapa(idEtapa, Descripcion, tiempo);
        }

        public DTOEtapa WCFObtenerEtapaPorIdEtapa(string idEtapaCodigo)
        {
            Etapa et = Etapa.ObtenerEtapaPorIdEtapa(idEtapaCodigo);
            DTOEtapa etapa = new DTOEtapa
            {
                IdEtapa = et.IdEtapa,
                Descripcion = et.Descripcion,
                LapsoMax = et.LapsoMax,
                IdTramite = et.IdTramite
            };
            return etapa;
        }



        public int WCFObtenerIdGrupoTramitePorIdTramite(string tituloTramite)
        {
            return Tramite.ObtenerTramitePorTituloUnico(tituloTramite);
        }

        public List<DTOGrupoTramite> WCFObtenerGrupoTramitePorIdTramite(string tituloTramite)
        {
            List<GrupoTramite> aux = new List<GrupoTramite>();
            List<DTOGrupoTramite> retorno = new List<DTOGrupoTramite>();
            int idTramite = Tramite.ObtenerTramitePorTituloUnico(tituloTramite);
            aux = GrupoTramite.ObtenerListadoDeGrupoTramitePorIdTramite(idTramite);
            foreach(GrupoTramite gt in aux)
            {
                DTOGrupoTramite dtogt = new DTOGrupoTramite
                {
                    IdGrupoTramite = gt.IdGrupoTramite,
                    Descripcion = gt.Descripcion,
                    CantidadMaxFuncionarios = gt.CantidadMaxFuncionarios,
                    IdGrupo = gt.IdGrupo
                };
                retorno.Add(dtogt);
            }
            return retorno;
        }
    }
}
