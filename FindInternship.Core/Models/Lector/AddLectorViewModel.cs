using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using static FindInternship.Common.ModelValidationConstants.LectorConstants;
using static FindInternship.Common.ErrorMessages;

namespace FindInternship.Core.Models.Lector
{
    public class AddLectorViewModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = InvalidLengthMessage)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = InvalidLengthMessage)]
        public string Description { get; set; } = null!;

        public IFormFile? ProfilePicture { get; set; } 

    }
}
