using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T3_N00024113.Models;

namespace T3_N00024113.PatronEstrategia
{
    public class EstrategiaContext
    {
        private IEstrategia estrategia;
        public EstrategiaContext()
        {

        }
        public EstrategiaContext(IEstrategia estrategia)
        {
            this.estrategia = estrategia;
        }
        public void SetEstrategia(IEstrategia estrategia)
        {
            this.estrategia = estrategia;
        }
        public List<Detalle> SeleccionarEjercicios(int rutinaId,List<Ejercicio> ejercicios)
        {
            return this.estrategia.SeleccionarEjercicios( rutinaId, ejercicios);
        }
    }
}
