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

        Task<string> GetTeacherIdAsync(string userId);

        Task<TeacherStudentsViewModel> GetTeacherStudentsAsync(string teacherId);
    }
}
