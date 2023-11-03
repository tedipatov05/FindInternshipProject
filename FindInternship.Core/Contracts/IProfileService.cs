using FindInternship.Core.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Contracts
{
    public interface IProfileService
    {
        Task<StudentProfileViewModel> GetStudentProfileAsync(string studentId);

        Task<TeacherProfileViewModel> GetTeacherProfileAsync(string teacherId);

        Task<EditProfileModel> GetUserForEditAsync(string userId);

        Task EditProfileAsync(string userId, EditProfileModel model);
    }
}
