using FindInternship.Core.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Contracts
{
    public interface IStudentService
    {
        Task Create(string userId, string classId);
        Task<string?> GetStudentId(string userId);

        Task<bool> IsStudent(string userId);

        Task<List<string>> GetStudentAbilitiesAsync(string studentId);

        Task<List<StudentViewModel>> GetTeacherStudentsAsync(string classId);

        Task<string?> GetStudentTeacherIdAsync(string studentId);

        Task<List<string>> GetStudentCompanyIdsAsync(string companyId, string classId);

        Task<List<string>> GetCompanyStudentIdsAsync(string companyId, string meetingId);

        Task<string?> GetStudentClassIdAsync(string studentId);
    }
}
