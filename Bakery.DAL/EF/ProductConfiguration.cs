using Bakery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.DAL.EF
{
    public class ProductConfiguration:EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(30);
            Property(p => p.Price).IsRequired();
            Property(p => p.Url).IsRequired().IsMaxLength();
            Property(p => p.CatId).IsRequired();
        }

    }
}
