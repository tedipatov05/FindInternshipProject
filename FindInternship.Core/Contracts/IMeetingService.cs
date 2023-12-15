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
        Task<List<MeetingViewModel>> GetAllCompanyMeetingsForDay(int days, string companyId);

        Task<List<MeetingViewModel>> GetClassMeetingsForDay(int days, string teacherId);
        
    }
}
