using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CotizadorWeb.Models
{
    public class ForAgeConfigModel
    {
        public int IdRango { get; set; }
        public int RangoMinimo { get; set; }
        public int RangoMaximo { get; set; }
        public int Estado { get; set; }


        public static ForAgeConfigModel ConForAgeConfigModelDR(IDataRecord dataR)
        {
            ForAgeConfigModel AgeConfigModels = new ForAgeConfigModel();
            AgeConfigModels.IdRango = int.Parse(dataR["IdRango"].ToString());
            AgeConfigModels.RangoMaximo = int.Parse(dataR["RangoMaximo"].ToString());
            AgeConfigModels.RangoMinimo = int.Parse(dataR["RangoMinimo"].ToString());
            AgeConfigModels.Estado = int.Parse(dataR["Estado"].ToString());

            return AgeConfigModels;
        }
    }
}