using FindInternship.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Data.Models
{
    public class Document
    {
        public Document()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [EnumDataType(typeof(DocumentTypeEnum))]
        public string Type { get; set; } = null!;

        public string? DocumentUrl { get; set; } 

        [ForeignKey(nameof(Request))]
        public string RequestId { get; set; } = null!;

        public Request Request { get; set; } = null!;


    }
}
