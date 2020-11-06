using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T3_N00024113.Models.Map
{
    public class RutinaMap: IEntityTypeConfiguration<Rutina>
    {

        public void Configure(EntityTypeBuilder<Rutina> builder)
        {
            builder.ToTable("Rutina");
            builder.HasKey(o => o.IdRutina);

            builder.HasMany(o => o.Detalles).WithOne()
                .HasForeignKey(o=>o.IdRutina);

            //builder.HasMany(o => o.Detalles).WithOne(o=>o.Rutina)
            //   .HasForeignKey(o => o.IdRutina);

        }
    }
}
