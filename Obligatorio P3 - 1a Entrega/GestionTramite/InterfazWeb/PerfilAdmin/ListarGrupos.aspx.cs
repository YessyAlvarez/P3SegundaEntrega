using InterfazWeb.ServiceReference;
using System;


namespace InterfazWeb.Master
{
    public partial class ListarGrupos : System.Web.UI.Page
    {
        Service1Client servicio = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListBox_listaGrupos.Items.Clear();
                ListBox_listaGrupos.DataSource = servicio.WCFListarGrupos();
                ListBox_listaGrupos.DataBind();
            }
        }
        
    }
}