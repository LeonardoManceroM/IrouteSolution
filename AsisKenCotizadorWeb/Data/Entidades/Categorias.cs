using System;
using System.Data;

namespace Data.Entidades
{
    public class Categorias
    {
        public int IdCategoria { get; set; }
        public string DescCategoria { get; set; }
        public string Descripcion { get; set; }
        public bool AplicaBeneficio { get; set; }
        public bool Hombre { get; set; }
        public bool Mujer { get; set; }
        public int TitularDesde { get; set; }
        public int TitularHasta { get; set; }
        public bool Conyugue { get; set; }
        public bool Maternidad { get; set; }
        public bool Dependientes { get; set; }
        public int DependienteDesde { get; set; }
        public int DependientesHasta { get; set; }
        public int PersonasDesde { get; set; }
        public int PersonasHasta { get; set; }

        public static Categorias ConsultaCategoriasDR(IDataRecord dataR)
        {
            Categorias categorias = new Categorias();
            categorias.IdCategoria = int.Parse(dataR["idcategoria"].ToString());
            categorias.DescCategoria = dataR["categoria"].ToString();
            categorias.Descripcion = dataR["descripcion"].ToString();
            categorias.AplicaBeneficio = bool.Parse(dataR["aplicabeneficio"].ToString());
            categorias.Hombre = bool.Parse(dataR["hombre"].ToString());
            categorias.Mujer = bool.Parse(dataR["mujer"].ToString());
            categorias.TitularDesde = (int)(dataR["titulardesde"]  == DBNull.Value ? 0 : int.Parse(dataR["titulardesde"].ToString()));
            categorias.TitularHasta = (int)(dataR["titularhasta"] == DBNull.Value ? 0 : int.Parse(dataR["titularhasta"].ToString()));
            categorias.Conyugue = bool.Parse(dataR["conyugue"].ToString());
            categorias.Maternidad = bool.Parse(dataR["maternidad"].ToString());
            categorias.Dependientes = bool.Parse(dataR["dependientes"].ToString());
            categorias.DependienteDesde = int.Parse(dataR["dependientesdesde"].ToString());
            categorias.DependientesHasta = int.Parse(dataR["dependienteshasta"].ToString());
            categorias.PersonasDesde = (int)(dataR["personasdesde"] == DBNull.Value ? 0 : int.Parse(dataR["personasdesde"].ToString()));
            categorias.PersonasHasta = (int)(dataR["personashasta"] == DBNull.Value ? 0 : int.Parse(dataR["personashasta"].ToString()));
            //categorias.TipoCategoria = int.Parse(dataR["tipocategoria"].ToString());
            //categorias.AplicaPool = bool.Parse(dataR["aplicapool"].ToString());
            return categorias;
        }
    }


}
