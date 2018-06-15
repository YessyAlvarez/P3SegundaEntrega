using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterfazWeb.PerfilAdmin
{
    public partial class ABMFuncionarios : System.Web.UI.Page
    {

        protected void ButtonAltaFuncionario_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilAdmin/AltaFuncionario.aspx");
        }

        protected void ButtonEditarFuncionario_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilAdmin/EditarFuncionario.aspx");
        }
    }

}