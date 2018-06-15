using InterfazWeb.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCFService;

namespace InterfazWeb.PerfilFMantenimiento
{
    public partial class EditarTramite : System.Web.UI.Page
    {
        Service1Client servicio = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Muestro los paneles
                Panel1.Visible = true;
                Panel2.Visible = false;
                Panel_Msj.Visible = false;

                //llamo a las Etapas
                InicializarEtapas();
            }
        }

        private void InicializarEtapas()
        {
            List<DTOEtapa> allEtapas = servicio.WCFListarEtapas();
            if(allEtapas != null)
            {
                //Cargo el combo de Grupos
                DropDownList_Etapas.Items.Clear();
                DropDownList_Etapas.DataSource = allEtapas;
                DropDownList_Etapas.DataBind();
            }
            else
            {
                //Muestro los paneles
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel_Msj.Visible = true;

                Label_Msj.Text = "No hay etapas creadas.";
                Button_EditNewEtapa.Visible = false;
            }
            
        }

        protected void Button_Modificar_Etapa_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel_Msj.Visible = false;

            //Obtengo la etapa seleccionada
            string idEtapa = DropDownList_Etapas.SelectedValue;
            DTOEtapa etapa = servicio.WCFObtenerEtapaPorIdEtapa(idEtapa);
            
            TextBox_Descripcion.Text = etapa.Descripcion;
            TextBox_Tiempo.Text = etapa.LapsoMax + "";
        }


        protected void Button_Guardar_Click(object sender, EventArgs e)
        {
            //Obtengo los datos
            string idEtapa = DropDownList_Etapas.SelectedValue;
            string Descripcion = TextBox_Descripcion.Text;
            int tiempo = Convert.ToInt32(TextBox_Tiempo.Text);

            bool ok = servicio.WCFEditarEtapa(idEtapa, Descripcion, tiempo);
            if (ok)
            {
                //Muestro los paneles
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel_Msj.Visible = true;

                //Muestro el mensaje
                Label_Msj.Text = "Etapa modificada con exito.";
            }
            else
            {
                //Muestro los paneles
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel_Msj.Visible = true;

                //Muestro el mensaje
                Label_Msj.Text = "Error al guardar la etapa. Intente nuevamente.";
            }
            
            
        }


        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            //Cargo de nuevo el combo
            InicializarEtapas();

            //Muestro los paneles
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel_Msj.Visible = false;
        }

        protected void Button_EditNewEtapa_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel_Msj.Visible = false;
        }
    }
}