using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T3_N00024113.Models.Map
{
    public class DetalleMap : IEntityTypeConfiguration<Detalle>
    {

        public void Configure(EntityTypeBuilder<Detalle> builder)
        {
            builder.ToTable("Detalle");
            builder.HasKey(o => o.IdDetalle);
        }
    }
}
