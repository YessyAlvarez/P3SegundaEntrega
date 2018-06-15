using InterfazWeb.ServiceReference;
using System;
using WCFService;

namespace InterfazWeb.PerfilAdmin
{
    public partial class EditarFuncionario : System.Web.UI.Page
    {

        Service1Client servicio = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Muestro los paneles
                Panel_BuscadorPorID.Visible = true;
                Panel_ResultadoFuncionario.Visible = false;
                Panel_Mensaje.Visible = false;
            }
        }


        protected void ButtonBuscarFuncionario_Click(object sender, EventArgs e)
        {
            String email = Text_EmailBuscar.Text;
            if (email.Length == 0)
            {
                Label_ErrorEmail.Text = "El email no puede ser vacio";
            }
            else
            {
                DTOUsuario usuario = servicio.WCFObtenerUsuario(email);
                if (usuario != null)
                {
                    //Vacio los campos
                    Label_ErrorEmail.Text = "";
                    Text_EmailBuscar.Text = "";

                    //Muestro los paneles
                    Panel_BuscadorPorID.Visible = false;
                    Panel_ResultadoFuncionario.Visible = true;
                    Panel_Mensaje.Visible = false;

                    //Cargo los datos en la pantalla
                    Label_Email.Text = usuario.Email;
                    TextBoxNombreCompleto.Text = usuario.NombreCompleto;
                }
                else
                {
                    //Muestro los paneles
                    Panel_BuscadorPorID.Visible = true;
                    Panel_ResultadoFuncionario.Visible = false;
                    Panel_Mensaje.Visible = false;

                    //Muestro el mensaje
                    Label_ErrorEmail.Text = "Correo invalido. Intente nuevamente";
                }
                
            }
        }


        protected void Button_GuardarCambios_Click1(object sender, EventArgs e)
        {
            //Obtengo los datos
            string email = Label_Email.Text;
            string nombreCompleto = TextBoxNombreCompleto.Text;
            string contrasenia = TextBoxContrasenia.Text;

            //Valido los campos
            if(Validar(email, nombreCompleto, contrasenia))
            {
                //Muestro los paneles
                Panel_BuscadorPorID.Visible = false;
                Panel_ResultadoFuncionario.Visible = false;
                Panel_Mensaje.Visible = true;

                //Muestro el mensaje
                Label_Msj.Text = "Cambios guardados con exito.";
            }
            else
            {
                //Muestro los paneles
                Panel_BuscadorPorID.Visible = false;
                Panel_ResultadoFuncionario.Visible = false;
                Panel_Mensaje.Visible = true;

                //Muestro el mensaje
                Label_Msj.Text = "Error al guardar. Intente nuevamente.";
            }

        }


        protected bool Validar(string email, string nombreCompleto, string contrasenia)
        {
            bool ok = true;
            if (nombreCompleto.Length == 0 || nombreCompleto == null)
            {
                Label_ErrorNombre.Text = "El nombre no puede ser null";
                ok = false;
            }
            if (contrasenia.Length == 0 || contrasenia == null)
            {
                Label_ErrorPass.Text = "El nombre no puede ser null";
                ok = false;
            }
            return ok;
        }

        protected void Button_NewEdit_Click(object sender, EventArgs e)
        {
            //Muestro los paneles
            Panel_BuscadorPorID.Visible = true;
            Panel_ResultadoFuncionario.Visible = false;
            Panel_Mensaje.Visible = false;

            //Vacio los campos
            Label_ErrorEmail.Text = "";
            Text_EmailBuscar.Text = "";
        }
    }
}