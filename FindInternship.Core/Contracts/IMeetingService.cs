using FindInternship.Core.Models.Meeting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Contracts
{
    public interface IMeetingService
    {
        Task<List<MeetingViewModel>> GetAllCompanyMeetingsForDayAsync(int days, string companyId);

        Task<List<MeetingViewModel>> GetClassMeetingsForDayAsync(int days, string teacherId);

        Task<string> CreateAsync(FormMeetingViewModel model, string companyId, string classId);

        Task<MeetingViewModel?> GetMeetingByIdAsync(string meetingId);

        Task<FormMeetingViewModel?> GetMeetingForEditAsync(string meetingId);

        Task EditMeetingAsync(string id, FormMeetingViewModel model);
        Task DeleteMeetingAsync(string meetingId);

        Task<PreDeleteMeetingViewModel?> GetMeetingForDeleteAsync(string meetingId);

        Task<int> GetMeetingsCountAsync();

    }
}
