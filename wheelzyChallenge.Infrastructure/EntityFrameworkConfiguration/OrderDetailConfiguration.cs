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
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrdersDetail");

            builder.HasKey(x => x.Id)
                   .HasName("PK_OrdersDetail");

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.Property(x => x.OrderId)
                   .HasColumnName("ID_ORDER");

            builder.Property(x => x.CarId)
                   .HasColumnName("ID_CAR");

            builder.Property(x => x.PickedUpDate)
                   .HasColumnName("PICKED_UP_DATE");

            builder.HasOne(x => x.Order)
                   .WithMany(o => o.OrderDetails)
                   .HasForeignKey(x => x.OrderId)
                   .HasConstraintName("FK_OrdersDetail_Orders");

            builder.HasOne(x => x.Car)
                   .WithMany(c => c.OrdersDetails)
                   .HasForeignKey(x => x.CarId)
                   .HasConstraintName("FK_OrdersDetail_Cars");
        }
    }
}
