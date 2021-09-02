using Data.Acceso;
using Data.Entidades;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace CotizadorWeb.Models
{
    public class BrokerAgenciaDto
    {
        private readonly bool _onLine = bool.Parse(ConfigurationManager.AppSettings["OnLine"]);
        private readonly AgenciaDao agenciaDao = new AgenciaDao();
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public int IdBroker { get; set; }
        //public int IdTipo { get; set; }
        public string Broker { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }
        public string EstadoDescripcion { get; set; }
        public string Telefono { get; set; }
        public string Ruc { get; set; }
        public string Mail { get; set; }
        public string  Descripcion{ get; set; }

        public List<BrokerAgenciaDto> ObtenerTodos()
        {
            List<BrokerAgenciaDto> brokersTep = new List<BrokerAgenciaDto>();
            List<BrokerAgenciaDto> brokers = new List<BrokerAgenciaDto>();
            try
            {
                if (!_onLine)
                {
                    brokersTep.Add(new BrokerAgenciaDto
                    {
                        Broker = "Asisken",
                        IdBroker = 1,
                        //IdTipo = 1
                    });
                    brokersTep.Add(new BrokerAgenciaDto
                    {
                        Broker = "Brokers",
                        IdBroker = 2,
                        //IdTipo = 2
                    });
                }
                else
                {
                    agenciaDao.ObtenerTodos().ForEach(x =>
                    {
                        brokers.Add(new BrokerAgenciaDto
                        {
                            Broker = x.Broker,
                            IdBroker = x.IdBroker,
                            //IdTipo = x.IdTipo,
                            Direccion=x.Direccion,
                            Estado=x.Estado,
                            EstadoDescripcion=x.EstadoDescripcion,
                            Descripcion=x.Descripcion,
                            Mail=x.Mail,
                            Ruc=x.Ruc,
                            Telefono=x.Telefono
                        });
                    });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return brokers;
        }
        public BrokerAgenciaDto ObtenerAgencia(int broker)
        {
            BrokerAgenciaDto brokerAgencia = new BrokerAgenciaDto();
            try
            {
                if (!_onLine)
                {
                    List<BrokerAgenciaDto> brokers = new List<BrokerAgenciaDto>();
                    brokers.Add(new BrokerAgenciaDto
                    {
                        Broker = "Asisken",
                        IdBroker = 1,
                        //IdTipo = 1
                    });
                    brokers.Add(new BrokerAgenciaDto
                    {
                        Broker = "Brokers",
                        IdBroker = 2,
                        //IdTipo = 2
                    });
                    brokerAgencia = brokers.FirstOrDefault(x => x.IdBroker == broker);
                }
                else
                {
                    var agenciaBd = agenciaDao.ObtenerById(broker);
                    brokerAgencia.Broker = agenciaBd.Broker;
                    brokerAgencia.IdBroker = agenciaBd.IdBroker;
                    //brokerAgencia.IdTipo = agenciaBd.IdTipo;
                    brokerAgencia.Direccion = agenciaBd.Direccion;
                    brokerAgencia.Estado = agenciaBd.Estado;
                    brokerAgencia.EstadoDescripcion = agenciaBd.EstadoDescripcion;
                    brokerAgencia.Descripcion = agenciaBd.Descripcion;
                    brokerAgencia.Mail = agenciaBd.Mail;
                    brokerAgencia.Ruc = agenciaBd.Ruc;
                    brokerAgencia.Telefono = agenciaBd.Telefono;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return brokerAgencia;
        }
        public List<BrokerAgenciaDto> ObtenerByEstado(bool idEstado)
        {
            List<BrokerAgenciaDto> brokers = new List<BrokerAgenciaDto>();
            try
            {
                var agenciasBd = agenciaDao.ObtenerTodos().FindAll(x => x.Estado.Equals(idEstado));
                agenciasBd.ForEach(x =>
                {
                    brokers.Add(new BrokerAgenciaDto
                    {
                        Broker = x.Broker,
                        Descripcion = x.Descripcion,
                        Direccion = x.Direccion,
                        Estado = x.Estado,
                        EstadoDescripcion = x.EstadoDescripcion,
                        IdBroker = x.IdBroker,
                        //IdTipo = x.IdTipo,
                        Mail = x.Mail,
                        Ruc = x.Ruc,
                        Telefono = x.Telefono
                    });
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return brokers;
        }
        public int Insertar(BrokerAgenciaDto agencia)
        {
            int insertado;
            try
            {
                if (!_onLine)
                {
                    List<BrokerAgenciaDto> agencias = new List<BrokerAgenciaDto>();
                    agencias.Add(agencia);
                    insertado = 1;
                }
                else
                {
                    var agencias = agenciaDao.ObtenerTodos();
                    //if (agencias.Exists(x => x.Mail == agencia.Mail && x.IdBroker != agencia.IdBroker))
                    if (agencias.Exists(x => x.Mail == agencia.Mail))
                            insertado = -1;
                    else if (agencias.Exists(x => x.Ruc == agencia.Ruc))
                        insertado = -2;
                    else
                        insertado = agenciaDao.Insertar(new Agencia
                        {
                            Broker = agencia.Broker,
                            IdBroker = agencia.IdBroker,
                            //IdTipo = agencia.IdTipo,
                            Direccion = agencia.Direccion,
                            Estado = agencia.Estado,
                            EstadoDescripcion = agencia.EstadoDescripcion,
                            Descripcion = agencia.Descripcion,
                            Mail = agencia.Mail,
                            Ruc = agencia.Ruc,
                            Telefono = agencia.Telefono
                        });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return insertado;
        }
        public int Modificar(BrokerAgenciaDto agencia)
        {
            int modificado;
            try
            {
                if (!_onLine)
                {
                    List<BrokerAgenciaDto> agencias = new List<BrokerAgenciaDto>();
                    agencias.Add(agencia);
                    modificado = 1;
                }
                else
                {
                    var agencias = agenciaDao.ObtenerTodos();
                    if (agencias.Exists(x => x.Mail == agencia.Mail && x.IdBroker != agencia.IdBroker))
                        modificado = -1;
                    //else if (agencias.Exists(x => x.Ruc == agencia.Ruc))
                    //    modificado = -2;
                    else
                        modificado = agenciaDao.Modificar(new Agencia
                    {
                        Broker = agencia.Broker,
                        IdBroker = agencia.IdBroker,
                        //IdTipo = agencia.IdTipo,
                        Direccion = agencia.Direccion,
                        Estado = agencia.Estado,
                        EstadoDescripcion = agencia.EstadoDescripcion,
                        Descripcion = agencia.Descripcion,
                        Mail = agencia.Mail,
                        Ruc = agencia.Ruc,
                        Telefono = agencia.Telefono
                    });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
            return modificado;
        }
    }


}