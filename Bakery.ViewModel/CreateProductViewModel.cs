using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Bakery.ViewModel
{
    public class CreateProductViewModel
    {     

        [Required(ErrorMessage ="Fill 'Name' field")]
        [StringLength(maximumLength:50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Fill 'Price' field")]
        public decimal Price { get; set; }        


    }

   
}
