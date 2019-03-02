using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [StringLength(11)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "CPF must be numeric")]
        public string CPF { get; set; }

        [Required]
        [StringLength(14)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone must be numeric")]
        public string Phone { get; set; }

    }
}