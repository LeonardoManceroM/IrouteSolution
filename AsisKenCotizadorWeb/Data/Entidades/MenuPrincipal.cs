using System.Data;

namespace Data.Entidades
{
    public class MenuPrincipal
    {
        public int IdMenu { get; set; }
        public int IdRol { get; set; }
        public string Titulo { get; set; }
        public int Padre { get; set; }
        public string Icon { get; set; }
        public string Page { get; set; }//url de la pagina
        public string Bullet { get; set; }// para subitems
        public bool Root { get; set; }//true si es padre 2 si es hijo
        public string Persmission { get; set; }
        public static MenuPrincipal ConsultaUsuarioFromDataRecord(IDataRecord dr)
        {
            MenuPrincipal menu = new MenuPrincipal
            {
                Bullet = dr["bullet"].ToString(),
                Icon = dr["imagen"].ToString(),
                IdMenu = int.Parse(dr["idmenu"].ToString()),
                Padre=int.Parse(dr["padre"].ToString()),
                Page=dr["page"].ToString(),
                Persmission=dr["permission"].ToString(),
                Root=bool.Parse(dr["root"].ToString()),
                Titulo=dr["menu"].ToString()
            };
            return menu;
        }
    }
}
