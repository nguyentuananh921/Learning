using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products","Mukesh");
            builder.Property(e => e.Id).ValueGeneratedNever().HasColumnName("Id");
            builder.Property(p => p.Rate).HasColumnType("decimal(10, 2)");
        }
    }
}
