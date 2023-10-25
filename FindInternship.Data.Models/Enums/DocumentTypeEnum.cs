using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Data.Models.Enums
{
    public enum DocumentTypeEnum
    {
        [Display(Name = "Медицинско")]
        MedicalDoc,
        [Display(Name = "Диплома за средно образование първа степен")]
        Diploma,
        [Display(Name = "Документ за самоличност")]
        Identification,
        [Display(Name = "Акт за раждане")]
        BirthDocument

    }
}
