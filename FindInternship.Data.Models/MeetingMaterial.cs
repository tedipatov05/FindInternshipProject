using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FindInternship.Common.ModelValidationConstants.MeetingMaterialConstants;

namespace FindInternship.Data.Models
{
    public class MeetingMaterial
    {
        public MeetingMaterial()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; } = null!;

        [MaxLength(MaterialNameMaxLength)]
        public string Name { get; set; } = null!;

        public string DocumentUrl { get; set; } = null!;

        [ForeignKey(nameof(Meeting))]
        public string MeetingId { get; set; } = null!;

        public Meeting Meeting { get; set; } = null!;

        

        
    }
}
