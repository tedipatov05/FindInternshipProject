using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Contracts
{
    public interface ISchoolService
    {
        int? GetSchoolIdIfExistsAsync(string schoolName);

        Task<int> Create(string schooName, string city);
    }
}
