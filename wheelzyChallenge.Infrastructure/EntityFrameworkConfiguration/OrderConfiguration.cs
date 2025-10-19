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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.Id)
                   .HasName("PK_Orders");

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.Property(x => x.QuoteId)
                   .HasColumnName("ID_QUOTE");

            builder.Property(x => x.StatusId)
                   .HasColumnName("ID_STATUS");

            builder.Property(x => x.CreatedDate)
                   .HasColumnName("CREATED_DATE");

            builder.Property(x => x.IsActive)
                   .HasColumnName("IS_ACTIVE");

            builder.HasOne(x => x.Quote)
                   .WithMany(q => q.Orders)
                   .HasForeignKey(x => x.QuoteId)
                   .HasConstraintName("FK_Orders_Quotes");

            //builder.HasOne(x => x.Status)
            //        .WithMany(x => x.Orders)
            //        .HasForeignKey(x => x.StatusId)
            //        .HasConstraintName("FK_Orders_States");

            builder.HasMany(x => x.OrderDetails)
                    .WithOne(od => od.Order)
                    .HasForeignKey(od => od.OrderId)
                    .HasConstraintName("FK_OrdersDetail_Orders");
        }
    }
}
