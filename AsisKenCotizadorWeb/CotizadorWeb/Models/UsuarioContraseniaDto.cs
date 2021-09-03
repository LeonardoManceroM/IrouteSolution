namespace CotizadorWeb.Models
{
    public class UsuarioContraseniaDto
    {
        public int IdUsuario { get; set; }
        public string ClaveActual { get; set; }
        public string ClaveNueva { get; set; }
    }
}