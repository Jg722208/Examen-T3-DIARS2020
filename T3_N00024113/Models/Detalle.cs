using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T3_N00024113.Models
{
    public class Detalle
    {
        public int IdDetalle { get; set; }
        public int IdRutina { get; set; }

        public int IdEjercicio { get; set; }

        public int Tiempo { get; set; }

        public Ejercicio Ejercicio { get; set; }
        //public Rutina Rutina { get; set; }

    }
}
