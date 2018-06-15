using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterfazWeb.PerfilFMantenimiento
{
    public partial class ABMEtapa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_CrearEtapa_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilFMantenimiento/CrearEtapa.aspx");
        }

        protected void Button_EditarEtapa_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PerfilFMantenimiento/EditarEtapa.aspx");
        }
    }
}