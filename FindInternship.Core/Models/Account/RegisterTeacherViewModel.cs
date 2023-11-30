using FindInternship.Common;
using FindInternship.Core.Models.Ability;
using Microsoft.AspNetCore.Http;
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
    public class RegisterTeacherViewModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength, ErrorMessage = InvalidLengthMessage)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [EmailAddress]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength, ErrorMessage = InvalidLengthMessage)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [DataType(DataType.Password)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = InvalidLengthMessage)]

        public string Password { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Compare(nameof(Password), ErrorMessage = DifferentPasswordMessage)]
        [DataType(DataType.Password)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = InvalidLengthMessage)]
        public string PasswordRepeat { get; set; } = null!;


        //TODO: MAKE VALIDATION BECAUSE I DONT KNOW HOW <3
        // I love you
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(SchoolNameMaxLength, MinimumLength = SchoolNameMinLength, ErrorMessage = InvalidLengthMessage)]
        public string School { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(CountryMaxLength, MinimumLength = CountryMinLength, ErrorMessage = InvalidLengthMessage)]
        public string Country { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(CityMaxLength, MinimumLength = CityMinLength, ErrorMessage = InvalidLengthMessage)]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength, ErrorMessage = InvalidLengthMessage)]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string Class { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(SpecialityMaxLength, MinimumLength = SpecialityMinLength, ErrorMessage = InvalidLengthMessage)]
        public string Speciality { get; set; } = null!;

        [Required]
        public DateTime BirthDate { get; set; }

        public string Gender { get; set; } = null!;

        public IFormFile? ProfilePicture { get; set; }

        
    }
}
