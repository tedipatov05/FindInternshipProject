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

namespace FindInternship.Core.Models.Profile
{
    public class EditProfileModel
    {


        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength, ErrorMessage = InvalidLengthMessage)]

        public string Name { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [EmailAddress]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength, ErrorMessage = InvalidLengthMessage)]
        public string Email { get; set; } = null!;

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


        public IFormFile? ProfilePicture { get; set; }


       
    }
}
