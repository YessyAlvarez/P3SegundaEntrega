using InterfazWeb.ServiceReference;
using System;
using WCFService;

namespace InterfazWeb.PerfilFMantenimiento
{
    public partial class AltaTramite : System.Web.UI.Page
    {

        Service1Client servicio = new Service1Client();


        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (!IsPostBack)
            {
                Inicializar();
                //Muestro los paneles y mensajes
                Panel_Paso1.Visible = true;
                Panel_Paso2.Visible = false;
                Panel_Msj.Visible = false;
                ListBox_GruposAgregados.Visible = false;
                Label_Msj_SinGrupos.Text = "No hay grupos agregados al trámite aún.";
            }
        }


        private void Inicializar() {
            //Cargo el combo de Grupos
            DropDownList_Grupos.Items.Clear();
            DropDownList_Grupos.DataSource = servicio.WCFGetGrupo();
            DropDownList_Grupos.DataBind();
        }


        public bool Validaciones_Campos()
        {
            bool ok = true;
            string tituloTramite = TextBox_Titulo.Text;
            if (tituloTramite.Length == 0)
            {
                Label_Titulo_Error.Text = "El nombre del tramite no puede ser vacio.";
                ok = false;
            }
            else if (servicio.WCFExisteNombreTramite(tituloTramite))
            {
                Label_Titulo_Error.Text = "Ya existe otro trámite con ese nombre. Modifíquelo.";
                ok = false;
            }
            if(TextBox_Descripcion.Text.Length == 0)
            {
                Label_Desc_Error.Text = "Ladescripcón no puede ser vacía.";
                ok = false;
            }
            if(TextBox_Costo.Text.Length == 0){
                Label_Costo_Error.Text = "El costo no puede ser vacio";
                ok = false;
            }
            else
            {
                double costo = Convert.ToDouble(TextBox_Costo.Text);
                if (costo < 0)
                {
                    Label_Costo_Error.Text = "El costo debe ser mayor a 0.";
                    ok = false;
                }
            }
            
            int dias = Convert.ToInt32(TextBox_Tiempo.Text);
            if (dias < 0)
            {
                Label_Tiempo_Error.Text = "La cantidad de dias debe ser mayor a 0.";
                ok = false;
            }
            return ok;
        }



        protected void Button_AgregarGrupo_Click(object sender, EventArgs e)
        {
            //Hago los controles necesarios
            if (this.Validaciones_Campos_Grupo())
            {
                string desc = TextBox_DescripcionGrupo.Text;
                int cantidad = Convert.ToInt32(TextBox_MaxFunc.Text);
                int idSeleccionado = Convert.ToInt32(DropDownList_Grupos.SelectedValue);
                DTOGrupoTramite dtogt = new DTOGrupoTramite
                {
                    Descripcion = desc,
                    CantidadMaxFuncionarios = cantidad,
                    IdGrupo = idSeleccionado
                };
                bool ok = servicio.WCFAddGrupoTramite(dtogt, TextBox_Titulo.Text);
                if (ok)
                {
                    //Muestro los elementos
                    Label_Msj_SinGrupos.Text = "";
                    Label_Msj_SinGrupos.Visible = false;

                    //Cargo los grupos
                    ListBox_GruposAgregados.Visible = true;
                    ListBox_GruposAgregados.Items.Clear();
                    ListBox_GruposAgregados.DataSource = servicio.WCFObtenerGrupoTramitePorIdTramite(TextBox_Titulo.Text);
                    ListBox_GruposAgregados.DataBind();
                }

            }
        }
        

        protected bool Validaciones_Campos_Grupo()
        {
            bool ok = true;
            if(TextBox_DescripcionGrupo.Text.Length == 0)
            {
                Label_DescGrupo_Error.Text = "La desripcion no pueste ser vacia.";
                ok = false;
            }
            int cantidad = Convert.ToInt32(TextBox_MaxFunc.Text);
            if(cantidad < 1)
            {
                Label_CantGrupo_Error.Text = "La cantidad debe ser al menos 1.";
                ok = false;
            }
            return ok;
        }

        protected void Button_NewTramite_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            Panel_Paso1.Visible = false;
            Panel_Paso2.Visible = false;
            Panel_Msj.Visible = true;
            //Muestro los mensajes
            Label_Msj.Text = "Tramite creado con exito.";
            
        }



        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            Panel_Paso1.Visible = true;
            Panel_Paso2.Visible = false;
            Panel_Msj.Visible = false;
            //Limpio los campos
            limpiar();
        }


        protected void limpiar()
        {
            TextBox_DescripcionGrupo.Text = "";
            TextBox_MaxFunc.Text = "";
            TextBox_Titulo.Text = "";
            TextBox_Descripcion.Text = "";
            TextBox_Costo.Text = "";
            TextBox_Tiempo.Text = "";
        }

        protected void LinkButton_1_datos_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            Panel_Paso1.Visible = true;
            Panel_Paso2.Visible = false;
            Panel_Msj.Visible = false;
        }

        protected void LinkButton_2_add_grupos_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            Panel_Paso1.Visible = false;
            Panel_Paso2.Visible = true;
            Panel_Msj.Visible = false;
        }

        protected void Button_Siguiente_Click(object sender, EventArgs e)
        {
            //Hago los controles necesarios
            if (this.Validaciones_Campos())
            {
                String titulo = TextBox_Titulo.Text;
                string desc = TextBox_Descripcion.Text;
                double costo = Convert.ToDouble(TextBox_Costo.Text);
                int tiempo = Convert.ToInt32(TextBox_Tiempo.Text);
                //Creo el trámite en la DB
                if (servicio.WCFAddTramite(titulo, desc, costo, tiempo))
                {
                    //Muestro los paneles y mensajes
                    Panel_Paso1.Visible = false;
                    Panel_Paso2.Visible = true;
                    Panel_Msj.Visible = false;
                }
                else
                {
                    //Muestro los paneles y mensajes
                    Panel_Paso1.Visible = false;
                    Panel_Paso2.Visible = false;
                    Panel_Msj.Visible = true;

                    Label_Msj.Text = "Problemas para cargar. Intente nuevamente.";
                }
            }
        }

        protected void LinkButton_2_add_gruposP2_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            Panel_Paso1.Visible = false;
            Panel_Paso2.Visible = true;
            Panel_Msj.Visible = false;
        }

        protected void LinkButton_1_datos_P2_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            Panel_Paso1.Visible = true;
            Panel_Paso2.Visible = false;
            Panel_Msj.Visible = false;
        }

        
        protected void Button_NuevoTramite_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            Panel_Paso1.Visible = true;
            Panel_Paso2.Visible = false;
            Panel_Msj.Visible = false;

            //Limpio los campos
            limpiar();
        }


    }
}