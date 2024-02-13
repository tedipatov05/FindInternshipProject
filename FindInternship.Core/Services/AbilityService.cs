using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Ability;
using FindInternship.Data.Models;
using FindInternship.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Core.Services
{
    public class AbilityService : IAbilityService
    {
        private readonly IRepository repo;
        private readonly IStudentService studentService;
        private readonly ICompanyService companyService;


        public AbilityService(IRepository repo, IStudentService studentService, ICompanyService companyService)
        {
            this.repo = repo;
            this.studentService = studentService;
            this.companyService = companyService;
        }

        public async Task AddAbilitiesToStudentAsync(List<string> abilities, string userId)
        {

            string? studentId = await studentService.GetStudentId(userId);

            if (studentId == null)
            {
                return;
            }

            var abilityStudents = new List<StudentAbility>();
            foreach (var ability in abilities)
            {
                bool isExists = await repo.All<Ability>().AnyAsync(a => a.Id == int.Parse(ability));
                
                if(isExists)
                {
                    abilityStudents.Add(new StudentAbility()
                    {
                        AbilityId = int.Parse(ability),
                        StudentId = studentId!
                    });
                }
                

            }

            await repo.AddRangeAsync(abilityStudents);
            await repo.SaveChangesAsync();
        }

        public async Task AddNewAbilityAsync(string ability)
        {
            Ability abilityModel = new Ability()
            {
                AbilityText = ability
            };

            await repo.AddAsync(abilityModel);
            await repo.SaveChangesAsync();
        }

        public async Task AddTechnologiesToCompanyAsync(List<string> technologies, string userId)
		{
            string companyId = await companyService.GetCompanyIdAsync(userId);

            if(companyId == null) { return; }

            var companyTechnologies = new List<CompanyAbility>();
            foreach(var tech in technologies)
            {
                bool isExists = await repo.All<Ability>().AnyAsync(a => a.Id == int.Parse(tech));

                if(isExists)
                {
                    companyTechnologies.Add(new CompanyAbility()
                    {
                        AbilityId = int.Parse(tech),
                        CompanyId = companyId
                    });
                }
                
            }

            await repo.AddRangeAsync(companyTechnologies);
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

        public async Task<List<string>> AllAbilityNamesAsync()
        {
            var abilitites = await repo.All<Ability>()
                .Select(a => a.AbilityText)
                .ToListAsync();

            return abilitites;
        }

        public async Task<List<string>> GetCompanyAbilityNamesAsync(string companyId)
        {
            var abilities = await repo.All<CompanyAbility>()
                .Where(c => c.CompanyId == companyId)
                .Select(c => c.Ability.AbilityText)
                .ToListAsync();

            return abilities;

        }

        public async Task<bool> IsAbilityExistsAsync(string ability)
        {
            var isExists = await repo.All<Ability>()
                .AnyAsync(a => a.AbilityText == ability);

            return isExists;
        }
    }
}
