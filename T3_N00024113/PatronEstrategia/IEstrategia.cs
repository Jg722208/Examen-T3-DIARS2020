using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T3_N00024113.Models;

namespace T3_N00024113.PatronEstrategia
{
    public interface IEstrategia
    {
        public List<Detalle> SeleccionarEjercicios(int rutinaId, List<Ejercicio> ejercicios);

    }
    public class Principiante : IEstrategia
    {
        public List<Detalle> SeleccionarEjercicios(int rutinaId, List<Ejercicio> ejercicios)
        {
            var random = new Random();
            List<Detalle> ejerciciosRutina = new List<Detalle>();
            for (int i = 0;i<5;i++)
            {
                var detalle = new Detalle();
                detalle.IdRutina = rutinaId;
                int index = random.Next(ejercicios.Count);
                var ejercicio = ejercicios.ElementAt<Ejercicio>(index);
                detalle.IdEjercicio = ejercicio.IdEjercicio;
                detalle.Tiempo = random.Next(60, 120);
                ejerciciosRutina.Add(detalle);
            }
            return ejerciciosRutina;
        }
    }
    public class Intermedio : IEstrategia
    {
        public List<Detalle> SeleccionarEjercicios(int rutinaId, List<Ejercicio> ejercicios)
        {
            var random = new Random();
            List<Detalle> ejerciciosRutina = new List<Detalle>();
            for (int i = 0; i <10; i++)
            {
                var detalle = new Detalle();
                detalle.IdRutina = rutinaId;
                int index = random.Next(ejercicios.Count);
                var ejercicio = ejercicios.ElementAt<Ejercicio>(index);
                detalle.IdEjercicio = ejercicio.IdEjercicio;
                detalle.Tiempo = random.Next(60, 120);
                ejerciciosRutina.Add(detalle);
            }
            return ejerciciosRutina;
        }
    }
    public class Avanzado : IEstrategia
    {
        public List<Detalle> SeleccionarEjercicios(int rutinaId, List<Ejercicio> ejercicios)
        {
            var random = new Random();
            List<Detalle> ejerciciosRutina = new List<Detalle>();
            for (int i = 0; i < 15; i++)
            {
                var detalle = new Detalle();
                detalle.IdRutina = rutinaId;
                int index = random.Next(ejercicios.Count);
                var ejercicio = ejercicios.ElementAt<Ejercicio>(index);
                detalle.IdEjercicio = ejercicio.IdEjercicio;
                detalle.Tiempo = 120;
                ejerciciosRutina.Add(detalle);
            }
            return ejerciciosRutina;
        }
    }
}
