using System.Collections.Generic;

namespace Data.Entidades
{
    public class SeccionCaracteristicas
    {
        public int IdSeccion { get; set; }
        public string Seccion { get; set; }
        public int Posicion { get; set; }
        public List<CaracteristicasSeccion> Charecteristics { get; set; }
    }
}
