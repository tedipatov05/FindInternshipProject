
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static FindInternship.Common.ModelValidationConstants.UserConstants;

namespace FindInternship.Core.Models.Account
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage="Името е задължително")]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength, ErrorMessage="Името трябва да бъде между {2} и {1}")]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        public string Password { get; set; } = null!;

        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        public string PasswordRepeat { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(CountryMaxLength, MinimumLength = CountryMinLength)]
        public string Country { get; set; } = null!;

        [Required]
        [StringLength(CityMaxLength, MinimumLength = CityMinLength)]
        public string City { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string Address { get; set; } = null!;

        [Required]
        public string ClassId { get; set; } = null!;

        [Required]
        public DateTime BirthDate { get; set; }

        public string Gender { get; set; } = null!;

        public List<ClassViewModel> Classes { get; set; } = new List<ClassViewModel>();

        public IFormFile? ProfilePicture { get; set; }

    }
}
