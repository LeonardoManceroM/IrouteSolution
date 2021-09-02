using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class CorreoRequest
    {
        public string Cliente { get; set; }
        public string Destinatario { get; set; }
        public string Asunto { get; set; }
        public string Contenido { get; set; }
        public string ArchivoBase64 { get; set; }
        public string ExtensionArchivo { get; set; }
        public string NombreArchivo { get; set; }
    }
}
