using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterfazWeb.Master
{
    public partial class PerfilFMantenimiento : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["perfilUsuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (Session["nombreUsuario"] != null)
            {
                PanelOnlyLoginTrue.Visible = true;
                lblNombreUsuario.Text = Session["nombreUsuario"].ToString();
            }
            else
            {
                PanelOnlyLoginTrue.Visible = false;
            }
        }

        protected void LinkButtonSalir_Click(object sender, EventArgs e)
        {
            //Dejo las variables de sesion en null 
            Session["perfilUsuario"] = null;
            Session["nombreUsuario"] = null;
            //Redirecciono al login
            Response.Redirect("~/Login.aspx");
        }

        protected void LinkButton_ABMTramite_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilFMantenimiento/ABMTramite.aspx");
        }

        protected void LinkButton_ABMEtapa_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilFMantenimiento/ABMEtapa.aspx");
        }

        protected void LinkButton_Etapa_Tramite_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilFMantenimiento/AsignarEtapaATramite.aspx");
        }
    }
}