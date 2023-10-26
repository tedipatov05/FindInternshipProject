using FindInternship.Core.Contracts;
using FindInternship.Data.Models;
using FindInternship.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Services
{
    public class TeacherService : ITeacherService
    {
        private IRepository repo;

        public TeacherService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<string> GetTeacherIdAsync(string userId)
        {
            var teacher= await repo.All<Teacher>().FirstOrDefaultAsync(t => t.UserId == userId);

            return teacher!.Id;
        }

        public async Task<bool> IsTeacherAsync(string userId)
        {
            var isTeacher = await repo.All<Teacher>()
                .AnyAsync(t => t.UserId == userId);

            return isTeacher;
        }
    }
}
