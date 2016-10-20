using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Bakery.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Fill 'Name' field")]
        [StringLength(maximumLength:50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Fill 'Price' field")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Write the Url 'Image' field")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Fill 'CategoryId' field")]
        public int CatId { get; set; }

        public virtual CategoryViewModel Category { get; set; }


    }

   
}
