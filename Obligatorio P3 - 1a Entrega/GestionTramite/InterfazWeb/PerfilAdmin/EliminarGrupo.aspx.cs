using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using InterfazWeb.ServiceReference;
using WCFService;

namespace InterfazWeb.PerfilAdmin
{
    public partial class EliminarGrupo : System.Web.UI.Page
    {
        Service1Client servicio = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                PanelBuscarGrupo.Visible = true;
                PanelDatosGrupo.Visible = false;
                PanelMensaje.Visible = false;

                //Cargo el combo de grupos
                CargarGrupos();
            }
        }

        protected void CargarGrupos()
        {
            //Verifico que la lista no vuelva vacía
            List<DTOGrupo> grupos = servicio.WCFListarGruposVacios();
            if (grupos != null)
            {
                DropDownListGruposAEliminar.Items.Clear();
                DropDownListGruposAEliminar.DataSource = grupos;
                DropDownListGruposAEliminar.DataBind();
            }
            else
            {
                //Muestro los paneles
                PanelMensaje.Visible = true;
                PanelDatosGrupo.Visible = false;
                PanelBuscarGrupo.Visible = false;

                //Muestro el mensaje
                LabelMensaje.Text = "No hay grupos disponibles para su eliminación";
                Button_Eliminar_Otro.Visible = false;
            }
        }


        protected void Button_Eliminar_Grupo_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            PanelBuscarGrupo.Visible = false;
            PanelDatosGrupo.Visible = true;
            PanelMensaje.Visible = false;

            //Acciones
            Label_Id.Text = DropDownListGruposAEliminar.SelectedValue;
            LabelNombre.Text = DropDownListGruposAEliminar.SelectedItem.Text;
            
        }

        protected void ButtonEliminarProveedor_Click(object sender, EventArgs e)
        {
            //Acciones
            int id = Convert.ToInt32(DropDownListGruposAEliminar.SelectedValue);
            string nombreGrupo = DropDownListGruposAEliminar.SelectedItem.Text;
            servicio.WCFEliminarGrupo(nombreGrupo);

            //Muestro los paneles
            PanelBuscarGrupo.Visible = false;
            PanelDatosGrupo.Visible = false;
            PanelMensaje.Visible = true;

            //Muestro el mensaje
            LabelMensaje.Text = "Grupos eliminado con éxito";

            //Cargo el combo de grupos
            CargarGrupos();
        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            PanelBuscarGrupo.Visible = true;
            PanelDatosGrupo.Visible = false;
            PanelMensaje.Visible = false;
        }

        protected void Button_Eliminar_Otro_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            PanelBuscarGrupo.Visible = true;
            PanelDatosGrupo.Visible = false;
            PanelMensaje.Visible = false;
        }
    }
}