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
    public class StudentService : IStudentService
    {
        private IRepository repo;

        public StudentService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task Create(string userId, string classId)
        {
            var student = new Student()
            {
                UserId = userId,
                ClassId = classId
            };
            await repo.AddAsync(student);
            await repo.SaveChangesAsync();
        }

        public async Task<string> GetStudentId(string userId)
        {
            var student = await repo.All<Student>()
                .FirstOrDefaultAsync(student => student.UserId == userId);

            return student!.Id;
        }
    }
}
