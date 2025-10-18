using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wheelzyChallenge.Domain.Entities;

namespace wheelzyChallenge.Infrastructure.EntityFrameworkConfiguration
{
    public class ZipCodeConfiguration : IEntityTypeConfiguration<ZipCode>
    {
        public void Configure(EntityTypeBuilder<ZipCode> builder)
        {
            builder.ToTable("ZipCodes");

            // Clave primaria
            builder.HasKey(x => x.Id)
                   .HasName("PK_ZipCodes");

            builder.Property(x => x.Id)
                   .HasColumnName("ID")
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.Property(x => x.zipCode)
                   .HasColumnName("ZIP_CODE");

            builder.HasIndex(x => x.zipCode)
                   .IsUnique();

            builder.Property(x => x.AreaName)
                   .HasColumnName("AREA_NAME")
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(x => x.IsActive)
                   .HasColumnName("IS_ACTIVE");

            builder.HasMany(x => x.Cars)
                   .WithOne(c => c.ZipCode)
                   .HasForeignKey(c => c.ZipCodeId)
                   .HasConstraintName("FK_Cars_ZipCodes");

            builder.HasMany(x => x.Quotes)
                   .WithOne(q => q.ZipCode)
                   .HasForeignKey(q => q.ZipCodeId)
                   .HasConstraintName("FK_Quotes_ZipCodes");
        }
    }
}
