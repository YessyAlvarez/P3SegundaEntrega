using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterfazWeb.PerfilFMantenimiento
{
    public partial class ABMTramite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButtonAltaTramite_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilFMantenimiento/AltaTramite.aspx");
        }

        protected void ButtonEditarTramite_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilFMantenimiento/EditarTramite.aspx");
        }
    }
}