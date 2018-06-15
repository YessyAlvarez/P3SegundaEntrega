using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfazWeb.ServiceReference;
using WCFService;

namespace InterfazWeb.PerfilFMantenimiento
{
    public partial class CrearEtapa : System.Web.UI.Page
    {

        Service1Client servicio = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Muestro los paneles
                Panel_CrearEtapa.Visible = true;
                Panel_Msj.Visible = false;

                //Inicializo los combos
                Inicializar();
            }
        }


        private void Inicializar()
        {
            //Cargo el combo de Grupos
            List<DTOTramite> allTramites = servicio.WCFGetTramite();
            if (allTramites != null)
            {
                DropDownList_Tramites.Items.Clear();
                DropDownList_Tramites.DataSource = allTramites;
                DropDownList_Tramites.DataBind();
            }
            else
            {
                Panel_Msj.Visible = true;
                Panel_CrearEtapa.Visible = false;

                Label_Msj.Text = "Debe existir al menos un tramite para poder crear una Etapa";
                Button_NewEtapa.Visible = false;
            }
            
        }


        public bool Validaciones_Campos()
        {
            bool ok = true;
            string Codigo = TextBox_Codigo.Text;
            string Descripcion = TextBox_Descripcion.Text;
            int LapsoMax = Convert.ToInt32(TextBox_Tiempo.Text);

            if (Codigo.Length == 0)
            {
                Label_CodigoError.Text = "El codigo no puede ser vacio.";
                ok = false;
            }
            if (Descripcion.Length == 0)
            {
                TextBox_Descripcion.Text = "La descripcion no puede ser vacia.";
                ok = false;
            }
            if (LapsoMax < 1)
            {
                Label_LapsoError.Text = "El tiempo minimo tiene que superar un dia.";
                ok = false;
            }

            return ok;
        }

        protected void Button_NewEtapa_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            Panel_CrearEtapa.Visible = true;
            Panel_Msj.Visible = false;

            //Limpiar los campos
            TextBox_Codigo.Text = "";
            TextBox_Descripcion.Text = "";
            TextBox_Tiempo.Text = "";
        }

        protected void Button_CrearEtapa_Click(object sender, EventArgs e)
        {
            

            if (Validaciones_Campos())
            {
                //Obtengo los datos
                string Codigo = TextBox_Codigo.Text;
                string Descripcion = TextBox_Descripcion.Text;
                int LapsoMax = Convert.ToInt32(TextBox_Tiempo.Text);
                int IdTramite = Convert.ToInt32(DropDownList_Tramites.SelectedValue);

                bool ok = servicio.WCFAddEtapa(Codigo, Descripcion, LapsoMax, IdTramite);
                if (ok)
                {
                    //Muestro los paneles
                    Panel_CrearEtapa.Visible = false;
                    Panel_Msj.Visible = true;

                    //Mensajes
                    Label_Msj.Text = "Etapa creada con exito";
                }
                else
                {
                    //Muestro los paneles
                    Panel_CrearEtapa.Visible = false;
                    Panel_Msj.Visible = true;

                    //Mensajes
                    Label_Msj.Text = "Error al crear esta etapa. Intente nuevamente. ";
                }
            }
        }
    }
}