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
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("States");

            builder.HasKey(x => x.Id)
                   .HasName("PK_States");

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.Property(x => x.Description)
                   .HasColumnName("DESCRIPTION")
                   .IsRequired()
                   .HasMaxLength(255);

        }
    }
}
