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
    public class OrdersHistoryConfiguration : IEntityTypeConfiguration<OrderHistory>
    {
        public void Configure(EntityTypeBuilder<OrderHistory> builder)
        {
            builder.ToTable("OrdersHistory");

            // Clave primaria
            builder.HasKey(x => x.Id)
                   .HasName("PK_OrdersHistory");

            builder.Property(x => x.Id)
                   .HasColumnName("ID")
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.Property(x => x.OrderDetailId)
                   .HasColumnName("ID_ORDER_DETAIL")
                   .IsRequired();

            builder.Property(x => x.StatusId)
                   .HasColumnName("ID_STATUS");

            builder.Property(x => x.UpdateDate)
                   .HasColumnName("UPDATE_DATE");

            builder.HasOne(x => x.OrderDetail)
                   .WithMany(od => od.OrderHistories)
                   .HasForeignKey(x => x.OrderDetailId)
                   .HasConstraintName("FK_OrdersHistory_Orders");
        }
    }
}
