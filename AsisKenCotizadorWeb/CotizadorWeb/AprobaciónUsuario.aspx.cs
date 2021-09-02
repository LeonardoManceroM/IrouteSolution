using Data.Acceso;
using Data.Entidades;
using System;
using System.Web.UI;

namespace CotizadorWeb
{
    public partial class AprobaciónUsuario : System.Web.UI.Page
    {
        private readonly UsuarioDao usuarioDao = new UsuarioDao();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            var param= Request.QueryString["ced"];
            try
            {
                if (!string.IsNullOrEmpty(param))
                {
                    Usuario usuario = usuarioDao.ObtenerTodos().Find(x => x.Identificacion.Equals(param));
                    if (usuario != null)
                    {
                        string nombres = usuario.Apellidos + " " + usuario.Nombres;
                        if (usuario.IdEstado.Equals(1))
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "alert('El Usuario " + nombres + " ya ha sido Activado, favor Revisar')", true);
                        else
                        {
                            usuario.IdEstado = 1;
                            int id = usuarioDao.ModificarEstado(usuario);
                            if (id > 0)
                            {
                                if (usuarioDao.EnvioMailUsuarioRemitente(usuario) == 1)
                                {
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "alert('El Usuario" + nombres + " fue ingresado con éxito')", true);
                                }

                            }
                        }
                    }
                    else
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "alert('Este Usuario no se ha encontrado favor revisar')", true);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}