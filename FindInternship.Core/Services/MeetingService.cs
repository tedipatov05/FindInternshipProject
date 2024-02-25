using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Meeting;
using FindInternship.Data.Models;
using FindInternship.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
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

        public async Task<string> CreateAsync(FormMeetingViewModel model, string companyId, string classId)
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

            return meeting.Id;
        }
        public async Task DeleteMeetingAsync(string meetingId)
        {
            var meeting = await repo.All<Meeting>()
                .FirstOrDefaultAsync(m => m.Id == meetingId);

            if (meeting == null)
            {
                return;
            }

            meeting!.IsActive = false;

            await repo.SaveChangesAsync();

        }

        public async Task<PreDeleteMeetingViewModel?> GetMeetingForDeleteAsync(string meetingId)
        {
            var meeting = await repo.All<Meeting>()
                .Where(m => m.Id == meetingId && m.IsActive)
                .Select(m => new PreDeleteMeetingViewModel()
                {
                    Address = m.Address,
                    End = m.EndTime,
                    Start = m.StartTime,
                    Title = m.Title,
                })
                .FirstOrDefaultAsync();

            if (meeting == null)
            {
                return null;
            }

            return meeting;
        }

        public async Task<MeetingViewModel?> GetMeetingByIdAsync(string meetingId)
        {
            var meeting = await repo.All<Meeting>()
                .Include(m => m.Class)
                .Where(m => m.Id == meetingId && m.IsActive == true)
                .Select(m => new MeetingViewModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Address = m.Address,
                    Day = m.StartTime.DayOfWeek.ToString().Substring(0, 3),
                    Number = m.StartTime.Day,
                    StartHour = m.StartTime.ToString("HH"),
                    EndHour = m.EndTime.ToString("HH"), 
                    Class = m.Class.Grade
                })
                .FirstOrDefaultAsync();

            if (meeting == null)
            {
                return null;
            }

            return meeting!;


        }

        public async Task<FormMeetingViewModel?> GetMeetingForEditAsync(string meetingId)
        {
            var meeting = await repo.All<Meeting>()
                .Where(me => me.Id == meetingId && me.IsActive == true)
                .Select(m => new FormMeetingViewModel()
                {
                    Address = m.Address, 
                    End = m.EndTime,
                    Start = m.StartTime, 
                    Title = m.Title, 
                    ClassId = m.ClassId,
                })
                .FirstOrDefaultAsync();

            if(meeting == null) 
            {
                return null;
            }


            return meeting!;
        }

        public async Task EditMeetingAsync(string id, FormMeetingViewModel model)
        {
            var meeting = await repo.All<Meeting>()
                .FirstOrDefaultAsync(m => m.Id == id);

            if(meeting == null)
            {
                return;
            }

            meeting!.Address = model.Address;
            meeting.Title = model.Title;
            meeting.EndTime = model.End;
            meeting.StartTime = model.Start;


            await repo.SaveChangesAsync();
        }

        public async Task<List<MeetingViewModel>> GetAllCompanyMeetingsForDayAsync(int days, string companyId)
        {
            var meetings = await repo.All<Meeting>()
                .Include(m => m.Class)
                .OrderBy(m => m.StartTime)
                .Where(m => m.StartTime.DayOfYear == DateTime.Today.AddDays(days).DayOfYear &&
                m.StartTime.Year == DateTime.Today.AddDays(days).Year && m.CompanyId == companyId && m.IsActive)
                .Select(m => new MeetingViewModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Address = m.Address,
                    Day = m.StartTime.DayOfWeek.ToString().Substring(0, 3),
                    Number = m.StartTime.Day,
                    StartHour = m.StartTime.ToString("HH"),
                    EndHour = m.EndTime.ToString("HH"), 
                    Class = m.Class.Grade

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
                .Where(m => m.StartTime.DayOfYear == DateTime.Today.AddDays(days).DayOfYear && m.StartTime.Year == DateTime.Today.AddDays(days).Year && m.Class.TeacherId==teacherId && m.IsActive)
                .Select(m => new MeetingViewModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Address = m.Address,
                    Day = m.StartTime.DayOfWeek.ToString().Substring(0, 3),
                    Number = m.StartTime.Day,
                    StartHour = m.StartTime.ToString("HH"),
                    EndHour = m.EndTime.ToString("HH"), 
                    Class = m.Class.Grade
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

        public async Task<int> GetMeetingsCountAsync()
        {
            var meetingsCount = await repo.All<Meeting>().CountAsync();

            return meetingsCount;
                
        }

        public async Task<bool> IsMeetingExistsAsync(DateTime start, DateTime end, string classId)
        {
            var isExists = await repo.All<Meeting>()
                .AnyAsync(m => ((DateTime.Compare(m.StartTime, start) == 0 || DateTime.Compare(m.EndTime, end) == 0 || (DateTime.Compare(m.StartTime, start) > 0 && DateTime.Compare(m.StartTime, end) < 0) || (DateTime.Compare(m.EndTime, start) > 0 && DateTime.Compare(m.EndTime, end) < 0)) && m.IsActive && m.ClassId == classId));

            return isExists;
        }
    }
}
