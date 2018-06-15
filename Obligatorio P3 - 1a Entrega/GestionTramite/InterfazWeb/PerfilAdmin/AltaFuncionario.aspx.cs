using InterfazWeb.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCFService;

namespace InterfazWeb.PerfilAdmin
{
    public partial class AltaFuncionario : System.Web.UI.Page
    {
        Service1Client servicio = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //Muestro los paneles
                PanelStep_Grupos.Visible = true;
                PanelStep_Grupos.Visible = false;
                PanelStep_Mensaje.Visible = false;

                //Cargo los combos
                CargarPerfiles();
                CargarGrupos();
            }
        }


        protected void CargarPerfiles()
        {
            List<int> idPerfiles = servicio.WCFListarPerfiles();
            List<DTOEnumPerfil> DTOperfiles = new List<DTOEnumPerfil>();
            int i = 0;
            foreach (DTOEnumPerfil perfil in Enum.GetValues(typeof(DTOEnumPerfil)))
            {
                if (!(perfil == DTOEnumPerfil.Anonimo || perfil == DTOEnumPerfil.NoAutorizado))
                {
                    DTOEnumPerfil p = (DTOEnumPerfil)Enum.ToObject(typeof(DTOEnumPerfil), i);
                    DTOperfiles.Add(p);
                }
                i++;
            }
            
            DropDownList_Perfil.Items.Clear();
            DropDownList_Perfil.DataSource = DTOperfiles;
            DropDownList_Perfil.DataBind();

        }

        protected void CargarGrupos()
        {
            List<DTOGrupo> grupos = servicio.WCFListarGrupos();
            if (grupos != null)
            {
                DropDownList_Grupos.Items.Clear();
                DropDownList_Grupos.DataSource = grupos;
                DropDownList_Grupos.DataBind();

                //Despliego acciones para grupos
                Label_MsjSinGrupos.Text = "Sin grupos asignados";
                ListBox_GruposAsignados.Visible = false;
            }
            else
            {
                Label_MsjSinGrupos.Text = "No hay grupos disponibles por el momento.";
                ListBox_GruposAsignados.Visible = false;
                DropDownList_Grupos.Visible = false;
            }

            
        }
        /*
         * Para pasar a la siguiente pantalla primero debo corroborar que haya cargado todos los datos
         * y guardado el funcionario en la BD.
        */
        protected void ButtonSiguiente_Click(object sender, EventArgs e)
        {
            if (TextBox_Email.Enabled)
            {
                //Hago los controles necesarios
                if (this.Validaciones_Campos())
                {
                    //Si todo OK llamo al WCF
                    string email = TextBox_Email.Text;
                    string password = TextBox_Password.Text;
                    string perfil = DropDownList_Perfil.SelectedValue;
                    string nombreCompleto = TextBox_NombreCompleto.Text;
                    if (servicio.WCFAddFuncionario(email, password, perfil, nombreCompleto))
                    {
                        //Inhabilito los text
                        TextBox_Email.Enabled = false;
                        TextBox_Password.Enabled = false;
                        DropDownList_Perfil.Enabled = false;
                        TextBox_NombreCompleto.Enabled = false;

                        //Muestro los paneles
                        PanelStep_Datos.Visible = false;
                        PanelStep_Grupos.Visible = true;
                        PanelStep_Mensaje.Visible = false;
                    }

                }
            }
            else
            {
                //Muestro los paneles
                PanelStep_Datos.Visible = false;
                PanelStep_Grupos.Visible = true;
                PanelStep_Mensaje.Visible = false;
            }
            
        }

        protected void LinkButton_1_1_Datos_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            PanelStep_Datos.Visible = true;
            PanelStep_Grupos.Visible = false;
            PanelStep_Mensaje.Visible = false;
        }

        protected void LinkButton_1_2_Grupos_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            PanelStep_Datos.Visible = false;
            PanelStep_Grupos.Visible = true;
            PanelStep_Mensaje.Visible = false;
        }

        protected void LinkButton_2_1_Datos_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            PanelStep_Datos.Visible = true;
            PanelStep_Grupos.Visible = false;
            PanelStep_Mensaje.Visible = false;
        }

        protected void LinkButton_2_2_Datos_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            PanelStep_Datos.Visible = false;
            PanelStep_Grupos.Visible = true;
            PanelStep_Mensaje.Visible = false;
        }

        protected void Button_Anterior_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            PanelStep_Datos.Visible = true;
            PanelStep_Grupos.Visible = false;
            PanelStep_Mensaje.Visible = false;
        }

        protected void Button_AltaFuncionario_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            PanelStep_Grupos.Visible = false;
            PanelStep_Grupos.Visible = false;
            PanelStep_Mensaje.Visible = true;

            //Muestro el mensaje
            Label_MsjFinal.Text = "Funcionario creado con exito.";

            //Limpio los mensajes de validación
            Label_ErrorEmail.Text = "";
            Label_ErrorPassword.Text = "";
            Label_ErrorNombre.Text = "";
        }

        public bool Validaciones_Campos()
        {
            bool ok = false;
            //Limpio los mensajes de validación
            Label_ErrorEmail.Text = "";
            Label_ErrorPassword.Text = "";
            Label_ErrorNombre.Text = "";

            //Realizo las validaciones
            int cont = 0;
            string email = TextBox_Email.Text;
            string password = TextBox_Password.Text;
            string nombreCompleto = TextBox_NombreCompleto.Text;
            if (email.Length == 0)
            {
                Label_ErrorEmail.Text = "El email no puede ser vacio";
                cont++;
            }
            else if (!email.Contains("@") || !email.Contains("."))
            {
                Label_ErrorEmail.Text = "El email debe contener un @ y al menos un .";
                cont++;
            }
            if (password.Length == 0)
            {
                Label_ErrorPassword.Text = "La contraseña no puede ser vacía";
                cont++;
            }
            if (nombreCompleto.Length == 0)
            {
                Label_ErrorNombre.Text = "Debe ingresar el nombre completo";
                cont++;
            }
            if (cont == 0)
            {
                ok = true;
            }

            /*

            else if (a.WCFExisteNombreTramite(tituloTramite))
            {
                Label_Titulo_Error.Text = "El nombre del tramite ya existe. Ingrese uno nuevo.";
            }
            //Realizo las otras validaciones
            //
            //
            //
            //
            */
            return ok;
        }

        protected void Button_AddGrupoATramite_Click(object sender, EventArgs e)
        {
            //Obtengo el id del grupo Seleccionado y obtengo el grupo
            int idGrupo = Convert.ToInt32(DropDownList_Grupos.SelectedValue);
            //Grupo grupo = servicio.WCFObtenerGrupoPorId(idGrupo);
            /*int idUsuario = servicio.WCFObtenerIdUSuario(TextBox_Email.Text);
            bool resultado = servicio.WCFAddUsuarioGrupo(idGrupo, idUsuario);
            if (resultado)
            {
                //Si todo OK cargo los grupos
                ListBox_GruposAsignados.Visible = true;
                ListBox_GruposAsignados.Items.Clear();
                //ListBox_GruposAsignados.DataSource = servicio.WCFListarGrupoUsuario(idUsuario);
                ListBox_GruposAsignados.DataBind();
            }
            */


            //grupoAgregados.Add(grupo);

            //Agrego el grupo seleccionado a la lista
            Label_MsjSinGrupos.Visible = true;
            //Label_MsjSinGrupos.Text = grupo.Nombre;
            ListBox_GruposAsignados.Visible = true;
            //ListBox_GruposAsignados.Items.Clear();
            //ListBox_GruposAsignados.DataSource = grupoAgregados;
            ListBox_GruposAsignados.DataBind();



        }

        protected void Button_AsignarAGrupo_Click(object sender, EventArgs e)
        {
            //Obtengo el IdUsuario
            string email = TextBox_Email.Text;
            int idUsuario = servicio.WCFObtenerIdUSuario(email);
            if (idUsuario > 0)
            {
                //Inserto el funcionario al grupo seleccionado
                int idGrupo = Convert.ToInt32(DropDownList_Grupos.SelectedValue);
                bool resultado = servicio.WCFAddUsuarioGrupo(idUsuario, idGrupo);
                if (resultado)
                {
                    ListBox_GruposAsignados.Visible = true;
                    ListBox_GruposAsignados.Items.Clear();
                    ListBox_GruposAsignados.DataSource = servicio.WCFListarGrupoUsuario(idUsuario);
                    ListBox_GruposAsignados.DataBind();
                }
                else
                {
                    //Error!!!
                    Label_MsjSinGrupos.Visible = true;
                    Label_MsjSinGrupos.Text = "Imposible asociar al grupo. Intente mas tarde.";
                }

                    
            }
        }

        protected void Button_NewAddProveedor_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            PanelStep_Grupos.Visible = true;
            PanelStep_Grupos.Visible = false;
            PanelStep_Mensaje.Visible = false;
        }
    }
}
