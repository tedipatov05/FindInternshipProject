using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Meeting;
using FindInternship.Data.Models;
using FindInternship.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly IRepository repo;

        public MeetingService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<List<MeetingViewModel>> GetAllCompanyMeetingsForDay(int days, string companyId)
        {
            var meetings = await repo.All<Meeting>()
                .Where(m => m.StartTime == DateTime.Today.AddDays(days) && m.CompanyId == companyId)
                .Select(m => new MeetingViewModel()
                {
                    Title = m.Title,
                    Address = m.Address,
                    Day = DateTime.Today.AddDays(days).ToString("dddd"),
                    Number = int.Parse(DateTime.Today.AddDays(days).ToString("dd")), 
                    StartHour = m.StartTime.ToString("HH"), 
                    EndHour = m.EndTime.ToString("HH")
                })
                .OrderBy(m => m.StartHour)
                .ToListAsync();

            return meetings;
                
        }

        public async Task<List<MeetingViewModel>> GetClassMeetingsForDay(int days, string teacherId)
        {
            var meeting = await repo.All<Meeting>()
                .Include(m => m.Class)
                .Where(m => m.StartTime == DateTime.Today.AddDays(days) && m.Class.TeacherId == teacherId)
                .Select(m => new MeetingViewModel()
                {
                    Title = m.Title,
                    Address = m.Address,
                    Day = DateTime.Today.AddDays(days).ToString("dddd"),
                    Number = int.Parse(DateTime.Today.AddDays(days).ToString("dd")),
                    StartHour = m.StartTime.ToString("HH"),
                    EndHour = m.EndTime.ToString("HH")
                })
                .OrderBy(m => m.StartHour)
                .ToListAsync();

            return meeting;
        }
    }
}
