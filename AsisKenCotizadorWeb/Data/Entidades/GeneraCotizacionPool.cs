using System.Collections.Generic;

namespace Data.Entidades
{
    public class GeneraCotizacionPool
    {
        public int IdCotizacion { get; set; }
        public int IdUsuario { get; set; }
        public string Cliente { get; set; }
        public string Actividad { get; set; }
        public int IdPlan { get; set; }
        public bool Estado { get; set; }
        public bool GuardarCotizacion { get; set; }
        public List<CotizacionCategoriaPool> CategoriaPools { get; set; }

    }
}
