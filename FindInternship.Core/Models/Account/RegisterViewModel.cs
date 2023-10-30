
using FindInternship.Core.Models.Ability;
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
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength, ErrorMessage="Името трябва да бъде между {2} и {1} символа")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage="Имейла е задължителен")]
        [EmailAddress]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength, ErrorMessage = "Имейла трябва да бъде между {2} и {1} символа")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Паролата е задължителна")]
        [DataType(DataType.Password)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = "Паролата трябва да бъде между {2} и {1} символа")]

		public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Паролата е задължителна")]
        [Compare(nameof(Password), ErrorMessage = "Паролите не съвпадат")]
        [DataType(DataType.Password)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = "Паролата трябва да бъде между {2} и {1} символа")]
        public string PasswordRepeat { get; set; } = null!;

        [Required(ErrorMessage = "Телефона е задължителен")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "Държавата е задължителна")]
        [StringLength(CountryMaxLength, MinimumLength = CountryMinLength, ErrorMessage = "Държавата трябва да бъде между {2} и {1} символа")]
        public string Country { get; set; } = null!;

        [Required(ErrorMessage = "Градът е задължителен")]
        [StringLength(CityMaxLength, MinimumLength = CityMinLength, ErrorMessage = "Градът трябва да бъде между {2} и {1} символа")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "Адреса е задължителен")]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength, ErrorMessage = "Адреса трябва да бъде между {2} и {1} символа")]
        public string Address { get; set; } = null!;

        [Required]
        public string ClassId { get; set; } = null!;

        [Required]
        public DateTime BirthDate { get; set; }

        public string Gender { get; set; } = null!;

        public List<ClassViewModel> Classes { get; set; } = new List<ClassViewModel>();

        public List<AbilityViewModel> Abilities { get; set; } = new List<AbilityViewModel>();

        public List<string> AbilitiesIds { get; set; } = new List<string>();

        public IFormFile? ProfilePicture { get; set; }

    }
}
