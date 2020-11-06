using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T3_N00024113.Models.Map;

namespace T3_N00024113.Models
{
    public class T3Context: DbContext
    {
        public T3Context(DbContextOptions<T3Context>options) 
            : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ejercicio> Ejercicios { get; set; }
        public DbSet<Rutina> Rutinas { get; set; }
        public DbSet<Detalle> Detalles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new EjercicioMap());
            modelBuilder.ApplyConfiguration(new RutinaMap());
            modelBuilder.ApplyConfiguration(new DetalleMap());
        }

    }
}
