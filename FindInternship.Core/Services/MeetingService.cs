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

        public async Task CreateAsync(AddMeetingViewModel model, string companyId, string classId)
        {
            var meeting = new Meeting()
            {
                Title = model.Title,
                Address = model.Address,
                ClassId = classId,
                CompanyId = companyId,
                EndTime = model.End,
                StartTime = model.Start

            };

            await repo.AddAsync(meeting);
            await repo.SaveChangesAsync();
        }

        public async Task<List<MeetingViewModel>> GetAllCompanyMeetingsForDayAsync(int days, string companyId)
        {
            var meetings = await repo.All<Meeting>()
                .OrderBy(m => m.StartTime)
                .Where(m => m.StartTime.DayOfYear == DateTime.Today.AddDays(days).DayOfYear &&
                m.StartTime.Year == DateTime.Today.AddDays(days).Year && m.CompanyId == companyId)
                .Select(m => new MeetingViewModel()
                {
                    Title = m.Title,
                    Address = m.Address,
                    Day = m.StartTime.DayOfWeek.ToString().Substring(0, 3),
                    Number = m.StartTime.Day,
                    StartHour = m.StartTime.ToString("HH"),
                    EndHour = m.EndTime.ToString("HH")
                })

                .ToListAsync();

            if (meetings.Count == 0)
            {
                meetings.Add(new MeetingViewModel()
                {
                    Day = DateTime.Today.AddDays(days).DayOfWeek.ToString().Substring(0, 3),
                    Number = DateTime.Today.AddDays(days).Day
                });
            }

            return meetings;

        }

        public async Task<List<MeetingViewModel>> GetClassMeetingsForDayAsync(int days, string teacherId)
        {
            var meetings = await repo.All<Meeting>()
                .Include(m => m.Class)
                .OrderBy(m => m.StartTime)
                .Where(m => m.StartTime.DayOfYear == DateTime.Today.AddDays(days).DayOfYear && m.StartTime.Year == DateTime.Today.AddDays(days).Year && m.Class.TeacherId==teacherId)
                .Select(m => new MeetingViewModel()
                {
                    Title = m.Title,
                    Address = m.Address,
                    Day = m.StartTime.DayOfWeek.ToString().Substring(0, 3),
                    Number = m.StartTime.Day,
                    StartHour = m.StartTime.ToString("HH"),
                    EndHour = m.EndTime.ToString("HH")
                })
                .ToListAsync();

            if (meetings.Count == 0)
            {
                meetings.Add(new MeetingViewModel()
                {
                    Day = DateTime.Today.AddDays(days).DayOfWeek.ToString().Substring(0, 3),
                    Number = DateTime.Today.AddDays(days).Day
                });
            }

            return meetings;
        }
    }
}
