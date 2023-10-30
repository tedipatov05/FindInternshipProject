using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FindInternship.Common.ModelValidationConstants.UserConstants;

namespace FindInternship.Core.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Имейла е задължителен")]
        [EmailAddress]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength, ErrorMessage = "Имейла трабва да бъде между {2} и {1} символа")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Паролата е задължителна")]
        [DataType(DataType.Password)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = "Паролата трябва да бъде между {2} и {1} символа")]
        public string Password { get; set; } = null!;
    }
}
