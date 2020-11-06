using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T3_N00024113.Models
{
    public class Rutina
    {
        public int IdRutina {get; set;}
        public string NombreRutina { get; set; }
        public string Tipo { get; set; }
        public int IdUsuario { get; set; }
        public List<Detalle> Detalles { get; set; }
    }
}
