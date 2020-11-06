using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T3_N00024113.Extenciones;
using T3_N00024113.Models;
using T3_N00024113.PatronEstrategia;

namespace T3_N00024113.Controllers
{
    public class RutinaController : Controller
    {
        private readonly T3Context context;
        public RutinaController(T3Context context)
        {
            this.context = context;
        }
        public IActionResult Index( int rutinaId)
        {
            var rutina = context.Rutinas.FirstOrDefault(o => o.IdRutina == rutinaId);
            var detalles = context.Detalles.Where(o => o.IdRutina == rutinaId);
            List<Ejercicio> ejercicios = new List<Ejercicio>();
            foreach (var item in detalles)
            {
                var ejercicio = context.Ejercicios.FirstOrDefault(o=>o.IdEjercicio==item.IdEjercicio);
                ejercicios.Add(ejercicio);
            }
            ViewBag.Detalles = detalles;
            ViewBag.Ejercicios = ejercicios;
            return View(rutina);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Rutina());
        }
        [HttpPost]
        public IActionResult Create(Rutina rutina)
        {
            if(!ModelState.IsValid)
            {
                return View(rutina);
            }
            var usuario = HttpContext.Session.Get<Usuario>("Logueado");
            rutina.IdUsuario = usuario.IdUsuario;
            context.Rutinas.Add(rutina);
            context.SaveChanges();
            var strategyContext = new EstrategiaContext();
            var ejercicios = context.Ejercicios.ToList();
            switch (rutina.Tipo)
            {
                case "Principiante":
                    strategyContext.SetEstrategia(new Principiante());
                    break;
                case "Intermedio":
                    strategyContext.SetEstrategia(new Intermedio());
                    break;
                case "Avanzado":
                    strategyContext.SetEstrategia(new Avanzado());
                    break;
            }
            var ejerciciosRutina = strategyContext.SeleccionarEjercicios(rutina.IdRutina,ejercicios);
            context.Detalles.AddRange(ejerciciosRutina);
            context.SaveChanges();
            return RedirectToAction("Index", "Usuario");
        }

    }
}
