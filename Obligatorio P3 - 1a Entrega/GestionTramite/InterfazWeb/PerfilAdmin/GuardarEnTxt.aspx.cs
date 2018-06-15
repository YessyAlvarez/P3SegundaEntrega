using InterfazWeb.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InterfazWeb.PerfilAdmin
{
    public partial class GuardarEnTxt : System.Web.UI.Page
    {
        Service1Client servicio = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Label_Msj.Text = "";
            }
        }

        protected void Button_Grupos_Click(object sender, EventArgs e)
        {
            bool ok = servicio.WCFGuardarTxt_Grupos();
            if (ok)
            {
                Label_Msj.Text = "Grupos guardados con exitos en Grupos.txt";
            }
        }

        protected void Button_Funcionarios_Click(object sender, EventArgs e)
        {
            bool ok = servicio.WCFGuardarTxt_Funcionarios();
            if (ok)
            {
                Label_Msj.Text = "Funcionarios guardados con exitos en Funcionarios.txt";
            }
        }

        protected void Button_Tramites_Click(object sender, EventArgs e)
        {
            bool ok = servicio.WCFGuardarTxt_Tramites();
            if (ok)
            {
                Label_Msj.Text = "Tramites guardados con exitos en Tramites.txt";
            }
        }

        



    }
}