using FindInternship.Core.Models;
using FindInternship.Core.Models.Class;
using FindInternship.Core.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Contracts
{
    public interface IClassService
    {
        Task<List<AllClassesViewModel>> AllClassesAsync();

        Task<List<ClassViewModel>> GetAllClassesAsync();

        Task<List<StudentViewModel>> GetClassStudentsAsync(string classId);

        Task<string?> GetClassIdAsync(string requestId);

        Task<List<ClassMeetingViewModel>> GetClassMeetingAsync(string companyId);

        Task<string?> GetClassIdByClassNameAsync(string className, string schoolName);

        Task<string?> GetClassIdByStudentUserIdAsync(string userId);

        Task<string?> GetClassIdByTeacherUserIdAsync(string userId);

        Task<List<string>> GetClassIdsByCompanyUserIdAsync(string userId);

        Task<List<ClassViewModel>> GetAllCompanyClassesAsync(string companyId);

        string? GetClassIdIfExistsAsync(string className, string school);

        Task<string> CreateAsync(string className, string specialtiy, int schoolId);

        Task UpdateAsync(string classId, string teacherId);

        bool ExistsClassByNameAndSchoolAsync(string className, string schoolName);

        Task<bool> IsClassExistsByIdAsync(string classId);

        Task DeleteAsync(string classId);
    }
}
