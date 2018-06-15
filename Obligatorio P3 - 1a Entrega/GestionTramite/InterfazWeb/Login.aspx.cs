using System;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using InterfazWeb.ServiceReference;

namespace InterfazWeb
{
    public partial class Login : System.Web.UI.Page
    {
        Service1Client servicio = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string usuario = LoginInicio.UserName;
            string password = LoginInicio.Password;
            int perfilUsuario = servicio.WCFValidarUsuario(usuario, password);
            if (perfilUsuario != 0) // != EnumPerfil.NoAutorizado
            {
                //Asigno a la sesion el tipo
                Session["perfilUsuario"] = perfilUsuario;
                //Asigno a la sesión el Nombre y Apellido
                Session["nombreUsuario"] = servicio.WCFGetNombreCompleto(usuario);
                //Asigno el usuario a la sesión
                Session["usuarioLogueado"] = usuario;
                //Autenticación exitosa
                e.Authenticated = true;
                //Re-dirijo a la home de cada perfil
                if (perfilUsuario == 1) //Es Admin (EnumPerfil.Admin)
                {
                    Response.Redirect("Bienvenidos/BienvenidoAdmin.aspx");
                }
                else if (perfilUsuario == 2) //EsFunc Mantenimiento (EnumPerfil.FuncionarioMantenimiento)
                {
                    Response.Redirect("Bienvenidos/BienvenidoFMantenimiento.aspx");
                }
                else
                {
                    //Response.Redirect("Bienvenidos/BienvenidoOrganizador.aspx");
                }
            }
            else
            {
                e.Authenticated = false;
            }
        }
    }
}