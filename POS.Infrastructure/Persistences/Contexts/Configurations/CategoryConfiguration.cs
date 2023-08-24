using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infrastructure.Persistences.Contexts.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.Id); //COMO HEMOS HECHO EL CAMNIO CON EL METODO ABSTRACTO BASENETITY LE DIREMOS QUE EL IDENTIFICAXDOR SERA EL CAMPO LLAMADO ID

            builder.Property(e => e.Id)
                .HasColumnName("CategoryId");

            builder.Property(e => e.Name).HasMaxLength(100);
        }
    }
}
