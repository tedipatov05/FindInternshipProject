using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Ability;
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
    public class AbilityService : IAbilityService
    {
        private IRepository repo;
        private IStudentService studentService;


        public AbilityService(IRepository repo, IStudentService studentService)
        {
            this.repo = repo;
            this.studentService = studentService;
        }

        public async Task AddAbilitiesToStudentAsync(List<string> abilities, string userId)
        {

            string studentId = await studentService.GetStudentId(userId);

            var abilityStudents = new List<StudentAbility>();
            foreach (var ability in abilities)
            {
                abilityStudents.Add(new StudentAbility()
                {
                    AbilityId = int.Parse(ability),
                    StudentId = studentId
                });

            }

            await repo.AddRangeAsync(abilityStudents);
            await repo.SaveChangesAsync();
        }

        public async Task<List<AbilityViewModel>> AllAbilitiesAsync()
        {
            var abilities = await repo.All<Ability>()
                .Select(a => new AbilityViewModel()
                {
                    Id = a.Id,
                    AbilityText = a.AbilityText
                })
                .ToListAsync();

            return abilities;
        }
    }
}
