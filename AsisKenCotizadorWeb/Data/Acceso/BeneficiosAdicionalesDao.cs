using Data.Conexion;
using Data.Entidades;
using System.Collections.Generic;
using System.Data;

namespace Data.Acceso
{
    public class BeneficiosAdicionalesDao
    {
        ConSql sql = new ConSql();
        
        public List<BeneficiosAdicionales> ListaBeneficiosAdicionales()
        {
            List<BeneficiosAdicionales> ListaBeneficios = new List<BeneficiosAdicionales>();
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_beneficios";

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        ListaBeneficios.Add(BeneficiosAdicionales.ConsultaBeneficiosAdicionalesDR(dataReader));
                    }
                }
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return ListaBeneficios;
        }
        public int IngresoBeneficioAdicional(BeneficiosAdicionales beneficio)
        {
            int idBeneficio = 0;
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_ing_beneficio";
                sql.Comando.Parameters.AddWithValue("p_idplan", beneficio.IdPlan);
                sql.Comando.Parameters.AddWithValue("p_beneficio", beneficio.DescBeneficio);
                sql.Comando.Parameters.AddWithValue("p_costo", beneficio.Costo);
                sql.Comando.Parameters.AddWithValue("p_observacion", beneficio.Observacion);
                sql.Comando.Parameters.AddWithValue("p_descripcion", beneficio.Descripcion);
                sql.Comando.Parameters.AddWithValue("p_idcatalogobeneficio", beneficio.IdCatalogoBeneficio);
                
                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        idBeneficio = int.Parse(dataReader[0].ToString());
                    }
                }
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return idBeneficio;
        }

        public int ActualizaBeneficioAdicional(BeneficiosAdicionales beneficio)
        {
            sql = new ConSql();
            int retorno = 0;
            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_mod_beneficio";
                sql.Comando.Parameters.AddWithValue("p_idbeneficio", beneficio.IdBeneficio);
                sql.Comando.Parameters.AddWithValue("p_beneficio", beneficio.DescBeneficio);
                sql.Comando.Parameters.AddWithValue("p_costo", beneficio.Costo);
                sql.Comando.Parameters.AddWithValue("p_observacion", beneficio.Observacion);
                sql.Comando.Parameters.AddWithValue("p_descripcion", beneficio.Descripcion);

                retorno = sql.EjecutaQuery();
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return retorno;
        }

        public List<BeneficioPlan> ListaBeneficiosAdicionalesByPlan(int idPlan)
        {
            List<BeneficioPlan> ListaBeneficios = new List<BeneficioPlan>();
            sql = new ConSql();
           
            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_beneficiobyplan";
                sql.Comando.Parameters.AddWithValue("p_idplan", idPlan);


                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        ListaBeneficios.Add(BeneficioPlan.ConBeneficiosAdicionalesByPlanDR(dataReader));
                    }
                }
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return ListaBeneficios;
        }

        public int IngresoCatalogoBeneficio(BeneficiosAdicionales beneficio)
        {
            int idBeneficio = 0;
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_ing_catalogobeneficio";
                sql.Comando.Parameters.AddWithValue("p_beneficio", beneficio.DescBeneficio);
                sql.Comando.Parameters.AddWithValue("p_costo", beneficio.Costo);

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        idBeneficio = int.Parse(dataReader[0].ToString());
                    }
                }
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return idBeneficio;
        }

        public int ActualizaCatalogoBeneficio(BeneficiosAdicionales beneficio)
        {
            sql = new ConSql();
            int retorno = 0;
            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_mod_catalogobeneficio";
                sql.Comando.Parameters.AddWithValue("p_idcatalogo", beneficio.IdCatalogoBeneficio);
                sql.Comando.Parameters.AddWithValue("p_beneficio", beneficio.DescBeneficio);
                sql.Comando.Parameters.AddWithValue("p_costo", beneficio.Costo);
                sql.Comando.Parameters.AddWithValue("p_estado", beneficio.Estado);

                retorno = sql.EjecutaQuery();
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return retorno;
        }

        public List<BeneficiosAdicionales> ListaCatalogosBeneficios()
        {
            List<BeneficiosAdicionales> ListaCatalogosBeneficios = new List<BeneficiosAdicionales>();
            sql = new ConSql();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "sp_con_catalogobeneficio";

                using (IDataReader dataReader = sql.EjecutaReader())
                {
                    while (dataReader.Read())
                    {
                        ListaCatalogosBeneficios.Add(BeneficiosAdicionales.ConCatalogosBeneficiosDR(dataReader));
                    }
                }
            }
            catch
            {
                sql.CerrarConexion();
                throw;
            }
            finally
            {
                sql.CerrarConexion();
            }
            return ListaCatalogosBeneficios;
        }
    }
}
