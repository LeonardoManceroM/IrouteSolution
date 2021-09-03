namespace Data.Entidades
{
    public class CalculaTarifas
    {
        public int IdPlan { get; set; }
        public bool TitularBeneficio { get; set; }
        public int TitularEdad { get; set; }
        public string TitularGenero { get; set; }
        public bool TitularMaternidad { get; set; }
        public string ConyugueGenero { get; set; }
        public int ConyugueEdad { get; set; }
        public int[] Dependientes { get; set; }
        public int[] CoberturasAdicionales { get; set; }
        public int ContadorPersonas { get; set; }

    }
}
