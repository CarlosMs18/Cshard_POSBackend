﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infrastructure.Persistences.Contexts.Configurations
{
    public class PurcharseDetailConfiguration : IEntityTypeConfiguration<PurcharseDetail>
    {
        public void Configure(EntityTypeBuilder<PurcharseDetail> builder)
        {
            builder.HasKey(e => e.PurcharseDetailId).HasName("PK__Purchars__7353248B569AD8D3");

            builder.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            builder.HasOne(d => d.Product).WithMany(p => p.PurcharseDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Purcharse__Produ__534D60F1");

            builder.HasOne(d => d.Purcharse).WithMany(p => p.PurcharseDetails)
                .HasForeignKey(d => d.PurcharseId)
                .HasConstraintName("FK__Purcharse__Purch__5441852A");
        }
    }
}
