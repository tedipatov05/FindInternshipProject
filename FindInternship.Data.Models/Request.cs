using FindInternship.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FindInternship.Common.ModelValidationConstants.RequestConstants;

namespace FindInternship.Data.Models
{
    public class Request
    {
        public Request()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [MaxLength(RequestTopicMaxLength)]
        public string Topic { get; set; }

        [ForeignKey(nameof(Class))]
        public string ClassId { get; set; }

        public Class Class { get; set; }

        [EnumDataType(typeof(RequestStatusEnum))]
        public string Status { get; set; }

        [MaxLength(RequestMessageMaxLength)]
        public string? Message { get; set; }

        [ForeignKey(nameof(Company))]
        public string CompanyId { get; set; }
        public Company Company { get; set; }
        public DateTime CreatedOn { get; set; }

        
    }
}
