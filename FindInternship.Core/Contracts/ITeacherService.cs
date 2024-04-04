using FindInternship.Core.Models.Account;
using FindInternship.Core.Models.Teacher;
using FindInternship.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Contracts
{
    public interface ITeacherService
    {
        Task<bool> IsTeacherAsync(string userId);

        Task<string?> GetTeacherIdAsync(string userId);

        Task<string?> GetTeacherUserIdAsync(string teacherId);

        Task<string?> GetTeacherClassIdAsync(string userId);

        Task<string?> GetTeacherUserIdByMeetingIdAsync(string meetingId);

        Task<TeacherStudentsViewModel> GetTeacherStudentsAsync(string teacherId);

        Task Create(RegisterTeacherViewModel model, string userId);

        Task<string?> GetTeacherUserIdByClassAsync(string classId);

        Task<string?> GetTeacherUserIdByCompanyInternIdAsync(string companyInternId);

        Task<bool> IsAllStudentsHaveGroupInCompanyAsync(string teacherUserId);

        //Task<bool> IsTeacherClassHaveCompanyAsync(string userId);
    }
}
