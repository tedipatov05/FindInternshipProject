using FindInternship.Core.Models;
using FindInternship.Core.Models.Class;
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

        Task<string> GetClassIdAsync(string requestId);

        Task<List<ClassMeetingViewModel>> GetClassMeetingAsync(string companyId);

        Task<string> GetClassIdByClassNameAsync(string className, string schoolName);

        Task<List<ClassViewModel>> GetAllCompanyClassesAsync(string companyId);

		Task<string?> GetClassIdIfExistsAsync(string className);

        Task<string> CreateAsync(string className, string specialtiy, int schoolId);

        Task UpdateAsync(string classId, string teacherId);

    }
}
