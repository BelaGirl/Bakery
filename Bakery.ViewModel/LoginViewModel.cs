using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter your 'Email'")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your 'Password'")]
        [DataType(DataType.Password)]
        public string Password { get; set; }       

    }
}
