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
        [Required]
        [EmailAddress]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        public string Password { get; set; } = null!;
    }
}
