using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CotizadorWeb.Models
{
    public class ForAgeModel
    {

       public int edad { get; set; }
        public int femeninoSinMaternidad { get; set; }
        public int femeninoConMaternidad { get; set; }
        public int masculino { get; set; }
        public int id { get; set; }


        public static ForAgeModel ConForAgeModelDR(IDataRecord dataR)
        {
            ForAgeModel AgeModels = new ForAgeModel();
            AgeModels.edad = int.Parse(dataR["edad"].ToString());
            AgeModels.femeninoSinMaternidad = int.Parse(dataR["femeninoSinMaternidad"].ToString());
            AgeModels.femeninoConMaternidad = int.Parse(dataR["femeninoConMaternidad"].ToString());
            AgeModels.masculino = int.Parse(dataR["masculino"].ToString());

            return AgeModels;
        }
    }
}