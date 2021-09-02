using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class Estado
    {
        public int IdEstado {get;set;}
        public string Descripcion { get; set; }
        public static Estado ConsultaEstadoFromDataRecord(IDataRecord dr)
        {
            Estado estadoReturn = new Estado();
            estadoReturn.IdEstado = int.Parse(dr["idestado"].ToString());
            estadoReturn.Descripcion = dr["estado"].ToString();
            return estadoReturn;
        }
    }
}
