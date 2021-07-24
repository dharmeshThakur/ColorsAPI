using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colors.Data
{
    public class ColorsMap
    {
        public ColorsMap(EntityTypeBuilder<Colors> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.Property(t => t.Type).IsRequired();
            entityBuilder.Property(t => t.Category).IsRequired();
            entityBuilder.Property(t => t.RGBA).IsRequired();
            entityBuilder.Property(t => t.Hex).IsRequired();
        }
    }
}
