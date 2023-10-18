using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Data.Models.Enums
{
    public enum AbilityEnum
    {
        [Display(Name = "C")]
        C,
        [Display(Name = "C#")]
        CScharp,
        [Display(Name = "ASP.NET")] 
        ASPNET,
        [Display(Name = "JS")] 
        JS,
        [Display(Name = "Node.js")]
        NodeJs,
        [Display(Name = "PHP")]
        PHP, 
        [Display(Name = "Python")]
        Python,
        [Display(Name = "Entity Framework")]
        EntityFramework

    }
}
