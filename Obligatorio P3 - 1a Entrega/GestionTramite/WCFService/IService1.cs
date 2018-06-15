using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        /***    NEWS WCF    ***/
        [OperationContract]
        bool WCFAddGrupo(string nombreGrupo);

        [OperationContract]
        bool WCFAddTramite(string titulo, string desc, double costo, int tiempo);

        [OperationContract]
        List<DTOTramite> WCFGetTramite();

        [OperationContract]
        List<DTOTramite> WCFListarTramites();

        [OperationContract]
        DTOTramite WCFObtenerTramitePorId(int idTramite);

        [OperationContract]
        void WCFEditarTramite(int Id, string Descripcion, double Costo, int Tiempo);

        [OperationContract]
        bool WCFAddEtapa(string Codigo, string Descripcion, int LapsoMax, int IdTramite);

        [OperationContract]
        List<DTOEtapa> WCFListarEtapas();

        [OperationContract]
        bool WCFEditarEtapaCodDes(string codigo, string descripcion);

        [OperationContract]
        bool WCFGuardarTxt();


        [OperationContract]
        bool WCFExisteNombreTramite(string nombreTramite);

        [OperationContract]
        List<DTOGrupo> WCFListarGrupos();

        [OperationContract]
        List<DTOGrupo> WCFGetGrupo();

        [OperationContract]
        DTOGrupo WCFObtenerGrupoPorId(int idGrupo);

        [OperationContract]
        void WCFEditGrupo(int idGrupo, string nombreGrupo);


        [OperationContract]
        int WCFValidarUsuario(string usuario, string password);

        [OperationContract]
        string WCFGetNombreCompleto(string nombreUsuario);


        [OperationContract]
        List<DTOGrupo> WCFListarGruposVacios();

        [OperationContract]
        void WCFEliminarGrupo(string nombreGrupo);

        [OperationContract]
        List<int> WCFListarPerfiles();

        [OperationContract]
        bool WCFAddFuncionario(string email, string password, string perfil, string nombreCompleto);

        [OperationContract]
        int WCFObtenerIdUSuario(string email);

        [OperationContract]
        bool WCFAddUsuarioGrupo(int idUsuario, int idGrupo);

        [OperationContract]
        List<DTOGrupo> WCFListarGrupoUsuario(int idUsuario);

        [OperationContract]
        DTOUsuario WCFObtenerUsuario(string email);

        [OperationContract]
        List<DTOUsuario> WCFListarFuncionarios();

        [OperationContract]
        bool WCFGuardarTxt_Grupos();

        [OperationContract]
        bool WCFGuardarTxt_Funcionarios();

        [OperationContract]
        bool WCFGuardarTxt_Tramites();

        [OperationContract]
        bool WCFAddGrupoTramite(DTOGrupoTramite gt, string tituloTramiteUnico);
        
        [OperationContract]
        int WCFAddGrupoDeGRupoTramitePorIdGT(int idGrupoTramite);

        [OperationContract]
        bool WCFEditarEtapa(string idEtapa, string Descripcion, int tiempo);

        [OperationContract]
        DTOEtapa WCFObtenerEtapaPorIdEtapa(string idEtapa);
        
        [OperationContract]
        int WCFObtenerIdGrupoTramitePorIdTramite(String tituloTramite);

        [OperationContract]
        List<DTOGrupoTramite> WCFObtenerGrupoTramitePorIdTramite(String tituloTramite);
        
    }



    [DataContract]
    public class DTOTramite
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public string Titulo { get; set; }
        [DataMember] public string Descripcion { get; set; }
        [DataMember] public double Costo { get; set; }
        [DataMember] public int Tiempo { get; set; }  /*Tiempo previsto de ejecuciòn en días*/
        [DataMember] public List<DTOGrupoTramite> Grupos { get; set; }
        [DataMember] public List<DTOEtapa> Etapas { get; set; }
        
    }


    [DataContract]
    public class DTOEtapa
    {
        [DataMember] public string IdEtapa { get; set; }
        [DataMember] public string Descripcion { get; set; }
        [DataMember] public int LapsoMax { get; set; }
        [DataMember] public bool Activa { get; set; }
        [DataMember] public int IdTramite { get; set; }

    }


    [DataContract]
    public class DTOGrupo
    {
        [DataMember] public int Codigo { get; set; }
        [DataMember] public string Nombre { get; set; }
        
    }

    [DataContract]
    public class DTOGrupoTramite
    {
        [DataMember] public int IdGrupoTramite { get; set; }
        [DataMember] public string Descripcion { get; set; }
        [DataMember] public int CantidadMaxFuncionarios { get; set; }
        [DataMember] public int IdGrupo { get; set; }
        [DataMember] public List<DTOUsuario> GrupoFuncionarios { get; set; }

    }


    [DataContract]
    public enum DTOEnumPerfil
    {
        [DataMember] NoAutorizado = 0,
        [DataMember] Admin = 1,
        [DataMember] FuncionarioMantenimiento = 2,
        [DataMember] Anonimo = 3
    }


    [DataContract]
    public class DTOUsuario
    {
        [DataMember] public int IdUsuario { set; get; }
        [DataMember] public string Email { set; get; }
        [DataMember] public string Password { set; get; }
        [DataMember] public string NombreCompleto { set; get; }
        [DataMember] public EnumPerfil TipoPerfil { set; get; }
        [DataMember] public Grupo Rol { set; get; }
    }



}
