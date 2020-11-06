using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T3_N00024113.Models
{
    public class Ejercicio
    {
        public int IdEjercicio{ get; set; }
        public string NombreEjercicio { get; set;}
        public string LinkYoutube { get; set; }
        public Detalle Detalle { get; set; }
    }
}
