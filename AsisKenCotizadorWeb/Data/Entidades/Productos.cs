using System.Data;

namespace Data.Entidades
{
    public class Productos
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }

        public static Productos ConsultaProductoDR(IDataRecord dataR)
        {
            Productos producto = new Productos();
            producto.IdProducto = int.Parse(dataR["idproducto"].ToString());
            producto.NombreProducto = dataR["producto"].ToString();

            return producto;
        }
    }
}
