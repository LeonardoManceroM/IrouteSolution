using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CotizadorWeb.Models
{
    public class AnotherRateModel
    {
        public int id { get; set; }
        public int edad { get; set; }
        public int dependientes { get; set; }
        public int ninosSolos { get; set; }


        public static AnotherRateModel ConAnotherRateModelDR(IDataRecord dataR)
        {
            AnotherRateModel AnotherRateModels = new AnotherRateModel();
            AnotherRateModels.id = int.Parse(dataR["id"].ToString());
            AnotherRateModels.edad = int.Parse(dataR["edad"].ToString());
            AnotherRateModels.dependientes = int.Parse(dataR["dependientes"].ToString());
            AnotherRateModels.ninosSolos = int.Parse(dataR["ninosSolos"].ToString());
            
            return AnotherRateModels;
        }
    }
}