using System.Data;

namespace Data.Entidades
{
    public class Agencia
    {
        public int IdBroker { get; set; }
        //public int IdTipo { get; set; }
        public string Broker { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }
        public string EstadoDescripcion { get; set; }
        public string Telefono { get; set; }
        public string Ruc { get; set; }
        public string Mail { get; set; }
        public string Descripcion { get; set; }
        public static Agencia ConsultaAgenciaFromDataRecord(IDataRecord dr)
        {
            Agencia agencia = new Agencia();
            agencia.IdBroker = int.Parse(dr["idbroker"].ToString());
            //agencia.IdTipo = int.Parse(dr["idtipousuario"].ToString());
            agencia.Broker = dr["broker"].ToString();
            agencia.Direccion = dr["direccion"].ToString();
            agencia.Estado = bool.Parse(dr["estado"].ToString());
            agencia.EstadoDescripcion = bool.Parse(dr["estado"].ToString()) ? "Activo" : "Inactivo";
            agencia.Telefono = dr["telefono"].ToString();
            agencia.Ruc = dr["ruc"].ToString();
            agencia.Mail = dr["mail"].ToString();
            agencia.Descripcion = dr["descripcion"].ToString();
            return agencia;
        }
    }
}
