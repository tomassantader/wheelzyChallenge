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
    public class BuyerConfiguration : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> builder)
        {
            builder.ToTable("Buyers");

            builder.HasKey(x => x.Id)
                   .HasName("PK_Buyers");

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.Property(x => x.FullName)
                   .HasColumnName("FULLNAME")
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(x => x.IsActive)
                   .HasColumnName("IS_ACTIVE");

            builder.HasMany(x => x.Quotes)
                   .WithOne(q => q.Buyer)
                   .HasForeignKey(q => q.BuyerId)
                   .HasConstraintName("FK_Quotes_Buyers");
        }
    }
}
