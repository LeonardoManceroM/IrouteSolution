//using System.Data.SqlClient;
using log4net;
using Npgsql;
using System;
using System.Data;
using System.Reflection;

namespace Data.Conexion
{
    public class ConSql : IDisposable
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private NpgsqlConnection laConexion;
        public NpgsqlCommand Comando { get; set; }

        private Base conexion = new Base();

        public ConSql()
        {
            laConexion = conexion.GetConexion();
            Comando = new NpgsqlCommand();
        }

        public void AbrirConexion()
        {
            if (laConexion.State != ConnectionState.Open)
                laConexion.Open();
        }

        public void CerrarConexion()
        {
            if (laConexion.State != ConnectionState.Closed)
                laConexion.Close();
        }

        public IDataReader EjecutaReader()
        {
            IDataReader retValue;
            AbrirConexion();
            Comando.Connection = laConexion;
            retValue = Comando.ExecuteReader(CommandBehavior.CloseConnection);

            return retValue;
        }

        public int EjecutaQuery()
        {
            int retValue;

            try
            {
                AbrirConexion();
                Comando.Connection = laConexion;
                retValue = Comando.ExecuteNonQuery();
                CerrarConexion();
            }
            catch (Exception ex)
            {

                Log.Error(ex.Message, ex);
                throw;
            }


            return retValue;
        }

        public void Dispose()
        {
            CerrarConexion();
            laConexion = null;
        }

    }
}
