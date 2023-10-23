using FindInternship.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Contracts
{
    public interface IClassService
    {
        Task<List<ClassViewModel>> AllClassesAsync();
    }
}
