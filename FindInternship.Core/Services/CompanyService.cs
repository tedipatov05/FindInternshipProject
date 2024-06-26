﻿using FindInternship.Core.Contracts;
using FindInternship.Core.Models;
using FindInternship.Core.Models.Class;
using FindInternship.Core.Models.Company;
using FindInternship.Data.Models;
using FindInternship.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindInternship.Core.Hubs;
using Microsoft.AspNetCore.SignalR;
using FindInternship.Core.Models.Lector;
using FindInternship.Core.Models.Teacher;
using FindInternship.Core.Models.Student;

namespace FindInternship.Core.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository repo;

        public CompanyService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<List<CompanyViewModel>> GetAllCompaniesAsync(CompanyQueryModel model)
        {
            IQueryable<Company> companyQuery = repo.All<Company>()
                .Where(c => c.User.IsActive == true && c.User.IsApproved == true);

            if (!string.IsNullOrEmpty(model.SearchString))
            {

                string wildCard = $"%{model.SearchString.ToLower()}%";

                companyQuery = companyQuery
                    .Where(c => EF.Functions.Like(c.User.Name, wildCard) ||
                                EF.Functions.Like(c.Description, wildCard) ||
                                EF.Functions.Like(c.Services, wildCard));
            }

            if (!string.IsNullOrEmpty(model.Technology))
            {
                companyQuery = companyQuery
                    .Where(c => c.Technologies.Select(t => t.Ability.AbilityText).Contains(model.Technology));
            }

            var companies = await companyQuery
                .Select(c => new CompanyViewModel()
                {
                    Id = c.User.Id,
                    Name = c.User.Name,
                    ProfilePictureUrl = c.User.ProfilePictureUrl,
                    Address = c.User.Address,
                    Description = c.Description
                })
                .ToListAsync();

            return companies;

        }

        public async Task<string?> GetCompanyIdAsync(string userId)
        {
            var company = await repo.All<Company>()
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (company == null)
            {
                return null;
            }

            return company!.Id;
        }

        public async Task<string?> GetCompanyIdByNameAsync(string companyName)
        {
            var company = await repo.All<Company>()
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.User.Name == companyName && c.User.IsActive);

            if (company == null)
            {
                return null;
            }

            return company!.User.Id;
        }

        public async Task<bool> IsCompanyAsync(string userId)
        {
            return await repo.All<Company>().AnyAsync(c => c.UserId == userId);
        }

        public async Task<string?> GetCompanyNameByIdAsync(string companyId)
        {
            var company = await repo.All<Company>()
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.UserId == companyId && c.User.IsActive);

            if (company == null)
            {
                return null;
            }

            return company!.User.Name;
        }

        public async Task CreateAsync(string userId, string services, string description)
        {
            var company = new Company()
            {
                UserId = userId,
                Services = services,
                Description = description
            };

            await repo.AddAsync(company);
            await repo.SaveChangesAsync();
        }

        public async Task<bool> IsInCompanyScheduleAsync(string companyId, string meetingId)
        {
            var company = await repo.All<Company>()
                .Include(c => c.Meetings)
                .FirstOrDefaultAsync(c => c.Id == companyId && c.User.IsActive);

            if(company == null)
            {
                return false;
            }


            return company!.Meetings.Any(m => m.Id == meetingId);

        }


        //public async Task AddClassToCompany(string classId, string companyId)
        //{
        //    var classs = await repo.All<Class>()
        //        .FirstOrDefaultAsync(c => c.Id == classId);

        //    if(classs == null)
        //    {
        //        return;
        //    }

        //    classs!.CompanyId = companyId;

        //    await repo.SaveChangesAsync();
        //}

        public async Task AddLectorToCompany(string companyId, AddLectorViewModel model, string profilePicture)
        {
            var lector = new Lector()
            {
                Name = model.Name,
                Description = model.Description,
                CompanyId = companyId,
                ProfilePictureUrl = profilePicture
            };

            await repo.AddAsync(lector);
            await repo.SaveChangesAsync();
        }

        public async Task<bool> IsLectorInCompany(string companyId, string lectorId)
        {
            var company = await repo.All<Company>()
                .Include(c => c.Lectors)
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == companyId && c.User.IsActive);

            if(company == null)
            {
                return false;
            }


            return company!.Lectors.Any(l => l.IsActive && l.Id == lectorId);


        }

        public async Task<bool> IsCompanyInternExistsByIdAsync(string companyInternId)
        {
            return await repo.All<CompanyInterns>()
                .AnyAsync(c => c.Id == companyInternId);
        }

        public async Task<CompanyInternGroupViewModel> GetCompanyInternsAsync(string companyInternId)
        {
            var students = await repo.All<Student>()
                .Where(s => s.CompanyInternsId ==  companyInternId)
                .Include(s => s.Abilities)
                .Include(s => s.Class)
                .Include(s => s.Class!.School)
                .Select(s => new StudentInternViewModel()
                {
                    Id = s.User.Id,
                    Name = s.User.Name,
                    ProfilePictureUrl = s.User.ProfilePictureUrl,
                    School = s.Class!.School.Name,
                    Abilities = s.Abilities.Select(a => a.Ability.AbilityText).ToList()
                })
                .ToListAsync();


            var companyIntern = await repo.All<CompanyInterns>()
                .FirstOrDefaultAsync(c => c.Id == companyInternId);


            CompanyInternGroupViewModel model = new CompanyInternGroupViewModel()
            {
                Id = companyInternId,
                Name = companyIntern!.Name,
                Interns = students,
            };

            return model;





        }
    }
}
