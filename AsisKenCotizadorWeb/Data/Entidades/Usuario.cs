using System;
using System.Data;

namespace Data.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        //public int IdTipo { get; set; }//ojo
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Direccion { get; set; }
        public int IdBroker { get; set; }
        public string Telefono { get; set; }
        public char Genero { get; set; }//M Hombre F mujer
        public DateTime FechaNacimineto { get; set; }
        public int IdEstado { get; set; }
        public int IdRol { get; set; }
        public string ObservacionEstado { get; set; }
        public string DescripcionEstado { get; set; }
        public string NombreAgencia { get; set; }
        public bool EstadoAgencia { get; set; }
        public int IdProvincia { get; set; }
        public string Provincia { get; set; }
        public string DireccionAgencia { get; set; }

        public static Usuario ConsultaUsuarioFromDataRecord(IDataRecord dr)
        {
            Usuario usuario = new Usuario();
            try
            {
                usuario.Apellidos = dr["apellidos"].ToString();
                usuario.Clave = dr["clave"].ToString();
                usuario.Correo = dr["correo"].ToString();
                usuario.Direccion = dr["direccion"].ToString();
                usuario.FechaNacimineto = DateTime.Parse(dr["fechanacimiento"].ToString());
                usuario.Genero = char.Parse(dr["genero"].ToString());
                usuario.IdBroker = int.Parse(dr["idbroker"].ToString());
                usuario.Identificacion = dr["identificacion"].ToString();
                usuario.IdEstado = int.Parse(dr["idestado"].ToString());
                usuario.IdRol = int.Parse(dr["idrol"].ToString());
                //usuario.IdTipo = int.Parse(dr["idTipoUsuario"].ToString());
                usuario.IdUsuario = int.Parse(dr["idusuario"].ToString());
                usuario.Nombres = dr["nombres"].ToString();
                usuario.ObservacionEstado = dr["observacionestado"].ToString();
                usuario.Telefono = dr["telefono"].ToString();
                usuario.TipoIdentificacion = dr["tipoidentificacion"].ToString();
                usuario.DescripcionEstado = dr["estado"].ToString();
                usuario.NombreAgencia = dr["agencia"].ToString();
                usuario.IdProvincia = int.Parse(dr["idprovincia"].ToString());
                usuario.Provincia = dr["provincia"].ToString();
                usuario.DireccionAgencia = dr["direccionagencia"].ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return usuario;
            
        }

        public static Usuario ValidaUsuarioDR(IDataRecord dr)
        {
            Usuario usuario = new Usuario();
            try
            {
                usuario.Apellidos = dr["apellidos"].ToString();
                usuario.Clave = dr["clave"].ToString();
                usuario.Correo = dr["correo"].ToString();
                usuario.Direccion = dr["direccion"].ToString();
                usuario.FechaNacimineto = DateTime.Parse(dr["fechanacimiento"].ToString());
                usuario.Genero = char.Parse(dr["genero"].ToString());
                usuario.IdBroker = int.Parse(dr["idbroker"].ToString());
                usuario.Identificacion = dr["identificacion"].ToString();
                usuario.IdEstado = int.Parse(dr["idestado"].ToString());
                usuario.IdRol = int.Parse(dr["idrol"].ToString());
                usuario.IdUsuario = int.Parse(dr["idusuario"].ToString());
                usuario.Nombres = dr["nombres"].ToString();
                usuario.ObservacionEstado = dr["observacionestado"].ToString();
                usuario.Telefono = dr["telefono"].ToString();
                usuario.TipoIdentificacion = dr["tipoidentificacion"].ToString();
                usuario.DescripcionEstado = dr["estado"].ToString();
                usuario.NombreAgencia = dr["agencia"].ToString();
                usuario.EstadoAgencia = bool.Parse(dr["estadoagencia"].ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return usuario;

        }
    }
}
