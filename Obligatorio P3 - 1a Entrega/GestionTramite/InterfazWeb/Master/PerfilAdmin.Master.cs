using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterfazWeb.Master
{
    public partial class PerfilAdmin : System.Web.UI.MasterPage
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

        protected void LinkButtonABMGrupos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilAdmin/ABMGrupos.aspx");
        }

        protected void LinkButtonABMFuncionarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilAdmin/ABMFuncionarios.aspx");
        }

        protected void LinkButtonListadoFuncionarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilAdmin/ListadoFuncionarios.aspx");
        }
        

        protected void LinkButtonGrabarArchivo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilAdmin/GuardarEnTxt.aspx");
        }

        
        protected void LinkButton_ListarGrupos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilAdmin/ListarGrupos.aspx");
        }
    }
}