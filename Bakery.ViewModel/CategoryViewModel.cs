using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.ViewModel
{
   public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fill 'Name' field")]
        [StringLength(maximumLength: 15)]
        public string Name { get; set; }

    }
}
