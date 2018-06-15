using InterfazWeb.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCFService;

namespace InterfazWeb.Master
{
    public partial class EditarTramite : System.Web.UI.Page
    {
        Service1Client servicio = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTramites();

                Panel1.Visible = true;
                Panel2.Visible = false;
                
            }
        }


        private void CargarTramites()
        {
            DropDownList_Tramite.Items.Clear();
            DropDownList_Tramite.DataSource = servicio.WCFListarTramites();
            DropDownList_Tramite.DataBind();
        }

        protected void Button_Guardar_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(DropDownList_Tramite.SelectedValue);
            string Descripcion = TextBox_Descripcion.Text;
            double Costo = Convert.ToDouble(TextBox_Costo.Text);
            int Tiempo = Convert.ToInt32(TextBox_Tiempo.Text);

            servicio.WCFEditarTramite(Id, Descripcion, Costo, Tiempo);

            Panel1.Visible = true;
            Panel2.Visible = false;
        }

        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;

            //Limpio los campos
            TextBox_Descripcion.Text = "";
            TextBox_Costo.Text = "";
            TextBox_Tiempo.Text = "";
        }

        protected void Button_Modificar_Etapa_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(DropDownList_Tramite.SelectedValue);
            DTOTramite tramite = servicio.WCFObtenerTramitePorId(Id);

            TextBox_Descripcion.Text = tramite.Descripcion + "";
            TextBox_Costo.Text = tramite.Costo + "";
            TextBox_Tiempo.Text = tramite.Tiempo + "";

            Panel1.Visible = false;
            Panel2.Visible = true;
        }

    }
}