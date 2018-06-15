using InterfazWeb.ServiceReference;
using System;
using System.Collections.Generic;

namespace InterfazWeb.PerfilAdmin
{
    public partial class EditarGrupo : System.Web.UI.Page
    {
        Service1Client servicio = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Muestro los paneles
                Panel_Seleccion_Grupo.Visible = true;
                Panel_Edicion_Grupo.Visible = false;

                //Cargo el combo de grupos
                CargarGrupos();
            }
            
        }

        protected void CargarGrupos()
        {
            DropDownList_Grupos.Items.Clear();
            DropDownList_Grupos.DataSource = servicio.WCFListarGrupos();
            DropDownList_Grupos.DataBind();
        }



        protected void Combo_change(object sender, EventArgs e) {
            //Obtengo el seleccionado
            Label_CodigoGrupo.Text = DropDownList_Grupos.SelectedValue;
            TextBox_Nombre_Grupo.Text = DropDownList_Grupos.SelectedItem.Text;
        }

        protected void Button_Editar_Grupo_Click(object sender, EventArgs e)
        {
            //Obtengo el seleccionado
            Label_CodigoGrupo.Text = DropDownList_Grupos.SelectedValue;
            TextBox_Nombre_Grupo.Text = DropDownList_Grupos.SelectedItem.Text;

            Panel_Seleccion_Grupo.Visible = false;
            Panel_Edicion_Grupo.Visible = true;
        }

        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            Panel_Seleccion_Grupo.Visible = true;
            Panel_Edicion_Grupo.Visible = false;
        }

        protected void Button_Guardar_Click(object sender, EventArgs e)
        {
            //Obtengo los datos
            int id = Convert.ToInt32(Label_CodigoGrupo.Text);
            String nombreGrupo = TextBox_Nombre_Grupo.Text;

            //Le paso los datos al WCF para que guarde los cambios
            servicio.WCFEditGrupo(id, nombreGrupo);

            //Cargo nuevamente el combo
            CargarGrupos();

            //Muestro los paneles
            Panel_Seleccion_Grupo.Visible = true;
            Panel_Edicion_Grupo.Visible = false;
        }
    }
}