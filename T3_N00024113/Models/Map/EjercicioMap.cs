using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T3_N00024113.Models.Map
{
    public class EjercicioMap : IEntityTypeConfiguration<Ejercicio>
    {

        public void Configure(EntityTypeBuilder<Ejercicio> builder)
        {
            builder.ToTable("Ejercicio");
            builder.HasKey(o => o.IdEjercicio);
            builder.HasOne(o => o.Detalle).WithOne(o => o.Ejercicio)
                .HasForeignKey<Ejercicio>(o=>o.IdEjercicio);
        }
    }
}
