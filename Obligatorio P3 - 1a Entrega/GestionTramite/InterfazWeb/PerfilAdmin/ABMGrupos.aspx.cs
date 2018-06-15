using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterfazWeb.PerfilAdmin
{
    public partial class ABMGrupos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAltaGrupo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilAdmin/AltaGrupo.aspx");
        }

        protected void ButtonEditarGrupo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilAdmin/EditarGrupo.aspx");
        }

        protected void ButtonEliminarGrupo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilAdmin/EliminarGrupo.aspx");
        }

    }
}