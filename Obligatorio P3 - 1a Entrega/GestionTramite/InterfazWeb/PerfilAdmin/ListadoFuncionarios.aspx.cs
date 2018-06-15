using InterfazWeb.ServiceReference;
using System;


namespace InterfazWeb.Master
{
    public partial class ListadoFuncionarios : System.Web.UI.Page
    {
        Service1Client servicio = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListBox_listaFuncionarios.Items.Clear();
                ListBox_listaFuncionarios.DataSource = servicio.WCFListarFuncionarios();
                ListBox_listaFuncionarios.DataBind();
            }
        }
        
    }
}