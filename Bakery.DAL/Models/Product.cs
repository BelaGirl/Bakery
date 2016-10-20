using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.DAL.Models
{
    public class Product
    {       
            public int Id { get; set; }

            public string Name { get; set; }

            public decimal Price { get; set; }

            public string Url { get; set; }

            [ForeignKey("Category")]
            public int CatId { get; set; }

            public virtual Category Category { get; set; }


       
    }
}
