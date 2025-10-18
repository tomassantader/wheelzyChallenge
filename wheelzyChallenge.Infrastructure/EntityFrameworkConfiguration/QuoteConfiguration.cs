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
    public class QuoteConfiguration : IEntityTypeConfiguration<Quote>
    {
        public void Configure(EntityTypeBuilder<Quote> builder)
        {
            builder.ToTable("Quotes");

            builder.HasKey(x => x.Id)
                   .HasName("PK_Quotes");

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.Property(x => x.BuyerId)
                   .HasColumnName("ID_BUYER");

            builder.Property(x => x.ZipCodeId)
                   .HasColumnName("ID_ZIP_CODE");

            builder.Property(x => x.Amount)
                   .HasColumnName("AMOUNT")
                   .IsRequired();

            builder.Property(x => x.IsCurrent)
                   .HasColumnName("IS_CURRENT");

            builder.Property(x => x.IsActive)
                   .HasColumnName("IS_ACTIVE");

            builder.HasOne(x => x.Buyer)
                   .WithMany(b => b.Quotes)
                   .HasForeignKey(x => x.BuyerId)
                   .HasConstraintName("FK_Quotes_Buyers");

            builder.HasOne(q => q.ZipCode)
                   .WithMany(z => z.Quotes)
                   .HasForeignKey(q => q.ZipCodeId)    
                   .HasPrincipalKey(z => z.zipCode)  
                   .HasConstraintName("FK_Quotes_ZipCodes");
        }
    }
}
