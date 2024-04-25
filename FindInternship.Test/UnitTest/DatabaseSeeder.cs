using FindInternship.Data;
using FindInternship.Data.Models;
using FindInternship.Data.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Test.UnitTest
{
    public static class DatabaseSeeder
    {

        public static void SeedDatabase(FindInternshipDbContext context)
        {
            SeedUsers(context);
            SeedCompanies(context);
            SeedSchool(context);
            SeedTeacher(context);
            SeedClasses(context);
            SeedAbilities(context);
            SeedStudentAbilities(context);
            SeedCompanyAbilities(context);
            SeedStudent(context);
            SeedMeeting(context);
            SeedRequest(context);
            SeedGroup(context);
            SeedUserGroups(context);
            SeedLectors(context);
            SeedCompanyInterns(context);

            context.SaveChanges();
        }

        public static void SeedUsers(FindInternshipDbContext context) 
        {
            var admin = new User()
            {
                Id = "501889c2-7883-473b-9333-c55267249071",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@abv.bg",
                NormalizedEmail = "ADMIN@ABV.BG",
                PhoneNumber = "0887654263",
                Name = "Админ",
                City = "Казанлък",
                Country = "България",
                Address = "ул.Възраждане 6 ет.2 ап.8",
                Gender = Gender.Мъж.ToString(),
                RegisteredOn = DateTime.UtcNow,
                BirthDate = DateTime.ParseExact("2005-05-20 11:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                ProfilePictureUrl = null, 
                IsActive = true
            };

            var student = new User()
            {
                Id = "bae65efa-6885-4144-9786-0719b0e2ebc4",
                UserName = "studentTest",
                NormalizedUserName = "STUDENTTEST",
                Email = "studentStudentov@abv.bg",
                NormalizedEmail = "STUDENTSTUDENTOV@ABV.BG",
                PhoneNumber = "0887654563",
                Name = "Студент Студентов",
                City = "Казанлък",
                Country = "България",
                Address = "ул.Възраждане 6 ет.2 ап.8",
                Gender = Gender.Мъж.ToString(),
                RegisteredOn = DateTime.UtcNow,
                BirthDate = DateTime.ParseExact("2007-06-10 11:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                ProfilePictureUrl = null,
                IsActive = true
            };

            var teacher = new User()
            {
                Id = "28a172eb-6e0d-43ed-9a42-fb28025e1659",
                UserName = "teacherTest",
                NormalizedUserName = "TEACHERTEST",
                Email = "teacher@abv.bg",
                NormalizedEmail = "TEACHER@ABV.BG",
                PhoneNumber = "0887654560",
                Name = "Учител Учителов",
                City = "Казанлък",
                Country = "България",
                Address = "ул.Кокиче 14 ет.2 ап.8",
                Gender = Gender.Мъж.ToString(),
                RegisteredOn = DateTime.UtcNow,
                BirthDate = DateTime.ParseExact("1988-02-08 11:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                ProfilePictureUrl = null,
                IsApproved = false,
                IsActive = true
            };

            var company = new User()
            {

                Id = "eb8fc718-655e-4d32-9a0a-d905fa3956e7",
                UserName = "companyTest",
                NormalizedUserName = "COMPANYTEST",
                Email = "company@abv.bg",
                NormalizedEmail = "COMPANY@ABV.BG",
                PhoneNumber = "0887654561",
                Name = "Фирма",
                City = "Казанлък",
                Country = "България",
                Address = "ул. Ал. Стамболийски 28 ет.2 ап.8",
                Gender = Gender.Мъж.ToString(),
                RegisteredOn = DateTime.UtcNow,
                BirthDate = DateTime.ParseExact("2001-02-08 11:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                ProfilePictureUrl = null,
                IsApproved = true,
                IsActive = true

            };

            context.Users.Add(admin);
            context.Users.Add(student);
            context.Users.Add(teacher);
            context.Users.Add(company);

        }
        public static void SeedGroup(FindInternshipDbContext context)
        {
            var group = new Group()
            {
                Id = "bd0fd8e0-70ca-4475-9bef-d6ca66daefa1",
                Name = "testGroup"
            };

            context.Groups.Add(group);
        }

        public static void SeedLectors(FindInternshipDbContext context)
        {
            var lector = new Lector()
            {
                Id = "724ebe11-96f9-4dfb-b255-da3041d887d5",
                Name = "Test Lector",
                Description = "Test lector description",
                ProfilePictureUrl = "some url",
                CompanyId = "7493d4c1-251f-4e9a-aaba-c11d5c4da798",
                IsActive = true
            };

            context.Lectors.Add(lector);
        }

        public static void SeedUserGroups(FindInternshipDbContext context)
        {
            var userGroups = new List<UserGroup>()
            {
                new UserGroup()
                {
                    UserId = "28a172eb-6e0d-43ed-9a42-fb28025e1659",
                    GroupId = "bd0fd8e0-70ca-4475-9bef-d6ca66daefa1"
                }, 
                new UserGroup()
                {
                    UserId = "eb8fc718-655e-4d32-9a0a-d905fa3956e7", 
                    GroupId = "bd0fd8e0-70ca-4475-9bef-d6ca66daefa1"
                }
            };

            context.UserGroups.AddRange(userGroups);
        }

        public static void SeedCompanies(FindInternshipDbContext context)
        {
            var company = new Company()
            {
                Id = "7493d4c1-251f-4e9a-aaba-c11d5c4da798", 
                UserId = "eb8fc718-655e-4d32-9a0a-d905fa3956e7",
                Description = "At Company, we are at the forefront of driving innovation and digital transformation. As a leading IT solutions provider, we specialize in delivering cutting-edge technology services to empower businesses and organizations across various industries.",
                Services = "Custom Software Development, Web and Mobile App Development, Cloud Solutions", 

            };

            context.Companies.Add(company);
        }
        public static void SeedMeeting(FindInternshipDbContext context)
        {
            var meeting = new Meeting()
            {
                Id = "862db3a5-4126-41e7-9ea0-7bf052215571",
                Title = "test meeting",
                Address = "Bulgaria, Kazanlak",
                StartTime = DateTime.UtcNow,
                EndTime = DateTime.UtcNow.AddHours(3),
                CompanyId = "7493d4c1-251f-4e9a-aaba-c11d5c4da798",
                CompanyInternsId = "b2d1e4fd-5f48-4519-8c0d-4de8e8a408de",
                Description = "Test Description", 
                LectorId = "724ebe11-96f9-4dfb-b255-da3041d887d5",
                IsActive = true

            };

            context.Meetings.Add(meeting);
        }

        public static void SeedCompanyInterns(FindInternshipDbContext context)
        {
            var companyIntern = new CompanyInterns()
            {
                Id = "b2d1e4fd-5f48-4519-8c0d-4de8e8a408de",
                Name = "12 Б - Фирма",
                CompanyId = "7493d4c1-251f-4e9a-aaba-c11d5c4da798",
                TeacherId = "17cd4d78-a621-4bf3-a4a4-9d7d3af085d2",
                IsActive = true
            };

            context.CompanyInterns.Add(companyIntern);
        }

        public static void SeedRequest(FindInternshipDbContext context)
        {
            var request = new Request()
            {
                Id = "bf13bfe6-b1be-4dc8-b8e8-2a0e3ff2af4a",
                Topic = "Test request",
                ClassId = "90bd5987-e991-4dfd-be1a-a57464b9d697",
                Status = RequestStatusEnum.Waiting.ToString(),
                Message = "test message",
                CompanyId = "7493d4c1-251f-4e9a-aaba-c11d5c4da798",
                CreatedOn = DateTime.UtcNow,
            };

            context.Requests.Add(request);
        }

        public static void SeedSchool(FindInternshipDbContext context)
        {
            var school = new School()
            {
                Id = 1,
                Name = "ППМГ Никола Обрешков",
                City = "Казанлък"


            };
            context.Schools.Add(school);
        }

        public static void SeedTeacher(FindInternshipDbContext context)
        {
            var teacher = new Teacher()
            {
                Id = "17cd4d78-a621-4bf3-a4a4-9d7d3af085d2",
                UserId = "28a172eb-6e0d-43ed-9a42-fb28025e1659",
                ClassId = "90bd5987-e991-4dfd-be1a-a57464b9d697"

            };

            context.Teachers.Add(teacher);
        }

        public static void SeedClasses(FindInternshipDbContext context)
        {
            var classSeed = new Class()
            {
                Id = "90bd5987-e991-4dfd-be1a-a57464b9d697",
                Speciality = "Приложен програмист",
                SchoolId = 1,
                Grade = "12 Б",
                TeacherId = "17cd4d78-a621-4bf3-a4a4-9d7d3af085d2"
            };

            context.Classes.Add(classSeed);
        }

        public static void SeedStudent(FindInternshipDbContext context)
        {
            var student = new Student()
            {
                Id = "4d152c78-9dbb-470c-aaf0-65a62a1dd2a0",
                UserId = "bae65efa-6885-4144-9786-0719b0e2ebc4",
                ClassId = "90bd5987-e991-4dfd-be1a-a57464b9d697",
                CompanyInternsId = "b2d1e4fd-5f48-4519-8c0d-4de8e8a408de"
            };

            context.Students.Add(student);
        }

        public static void SeedAbilities(FindInternshipDbContext context)
        {
            var ab1 = new Ability()
            {
                Id = 1,
                AbilityText = "C#",
            };
            var ab2 = new Ability()
            {
                Id = 2,
                AbilityText = "JS",
            };
            var ab3 = new Ability()
            {
                Id = 3,
                AbilityText = "SQL",
            };
            var ab4 = new Ability()
            {
                Id = 4,
                AbilityText = "ASP.NET",
            };
            var ab5 = new Ability()
            {
                Id = 5,
                AbilityText = "HTML",
            };
            var ab6 = new Ability()
            {
                Id = 6,
                AbilityText = "CSS",
            };

            context.Abilities.Add(ab1);
            context.Abilities.Add(ab2);
            context.Abilities.Add(ab3);
            context.Abilities.Add(ab4);
            context.Abilities.Add(ab5);
            context.Abilities.Add(ab6);
        }

        public static void SeedStudentAbilities(FindInternshipDbContext context)
        {
            var studentAbilities = new List<StudentAbility>()
            {
                new StudentAbility()
                {
                    StudentId = "4d152c78-9dbb-470c-aaf0-65a62a1dd2a0",
                    AbilityId = 1,
                },
                new StudentAbility()
                {
                    StudentId = "4d152c78-9dbb-470c-aaf0-65a62a1dd2a0",
                    AbilityId = 2,
                },
                new StudentAbility()
                {
                    StudentId = "4d152c78-9dbb-470c-aaf0-65a62a1dd2a0",
                    AbilityId = 4,
                }
            };

            context.StudentAbilities.AddRange(studentAbilities);
        }

        public static void SeedCompanyAbilities(FindInternshipDbContext context)
        {
            var technologies = new List<CompanyAbility>()
            {
                new CompanyAbility()
                {
                    CompanyId = "7493d4c1-251f-4e9a-aaba-c11d5c4da798",
                    AbilityId = 2
                },
                new CompanyAbility()
                {
                    CompanyId = "7493d4c1-251f-4e9a-aaba-c11d5c4da798",
                    AbilityId = 4
                },
                new CompanyAbility()
                {
                    CompanyId = "7493d4c1-251f-4e9a-aaba-c11d5c4da798",
                    AbilityId = 5
                },
                new CompanyAbility()
                {
                    CompanyId = "7493d4c1-251f-4e9a-aaba-c11d5c4da798",
                    AbilityId = 1
                }
            };

            context.Technologies.AddRange(technologies);
        }
        
    }
}
