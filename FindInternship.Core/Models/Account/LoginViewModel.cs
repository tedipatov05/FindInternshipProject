using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FindInternship.Common.ModelValidationConstants.UserConstants;
using static FindInternship.Common.ErrorMessages;

namespace FindInternship.Core.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        [EmailAddress]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength, ErrorMessage = InvalidLengthMessage)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [DataType(DataType.Password)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = InvalidLengthMessage)]
        public string Password { get; set; } = null!;
    }
}
