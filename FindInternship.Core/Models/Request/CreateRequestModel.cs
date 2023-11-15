using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FindInternship.Common.ModelValidationConstants.RequestConstants;
using static FindInternship.Common.ErrorMessages;

namespace FindInternship.Core.Models.Request
{
    public class CreateRequestModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(RequestTopicMaxLength, MinimumLength = RequestTopicMinLength, ErrorMessage = InvalidLengthMessage)]
        public string Topic { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(RequestMessageMaxLength, MinimumLength = RequestMessageMinLength, ErrorMessage = InvalidLengthMessage)]
        public string Message { get; set; } = null!;

        public string? ClassId { get; set; }
        public string? CompanyId { get; set; }
    }
}
