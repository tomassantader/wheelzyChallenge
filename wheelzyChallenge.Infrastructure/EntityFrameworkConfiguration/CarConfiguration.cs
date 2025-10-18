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
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");

            builder.HasKey(x => x.Id)
                   .HasName("PK_Cars");

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.Property(x => x.Make)
                   .HasColumnName("MAKE")
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(x => x.Model)
                   .HasColumnName("MODEL")
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(x => x.Submodel)
                   .HasColumnName("SUBMODEL")
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(x => x.Year)
                   .HasColumnName("YEAR")
                   .IsRequired();

            builder.Property(x => x.ZipCodeId)
                   .HasColumnName("ID_ZIP_CODE");

            builder.Property(x => x.IsActive)
                   .HasColumnName("IS_ACTIVE");

            builder.HasOne(x => x.ZipCode)
                   .WithMany(z => z.Cars)
                   .HasForeignKey(x => x.ZipCodeId)
                   .HasConstraintName("FK_Cars_ZipCodes");
        }
    }
}
