using Bakery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace Bakery.DAL.EF
{
    class CategoryConfuguration: EntityTypeConfiguration<Category>
    {
        public CategoryConfuguration()
        {
            ToTable("Category");
            Property(p => p.Name).IsRequired().HasMaxLength(30);
        }
    }
}
