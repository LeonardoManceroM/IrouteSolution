using Data.Conexion;
using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace Data.Acceso
{
    public class MenuDao
    {
        public List<MenuPrincipal> ObtenerByRol(int idRol)
        {
            List<MenuPrincipal> menu = new List<MenuPrincipal>();
            try
            {
                using (var sql = new ConSql())
                {
                    sql.Comando.CommandType = CommandType.StoredProcedure;
                    sql.Comando.CommandText = "sp_con_menu";
                    sql.Comando.Parameters.Add(new Npgsql.NpgsqlParameter("var_idrol", idRol));
                    using (var reader = sql.EjecutaReader())
                    {
                        while (reader.Read())
                            menu.Add(MenuPrincipal.ConsultaUsuarioFromDataRecord(reader));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return menu;
        }
    }
}
