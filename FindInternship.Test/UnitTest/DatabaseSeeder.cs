using FindInternship.Data;
using FindInternship.Data.Models;
using FindInternship.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Test.UnitTest
{
    public class DatabaseSeeder
    {
        public static void SeedDatabase(FindInternshipDbContext context)
        {

        }

        public static void SeedUsers(FindInternshipDbContext context) 
        {
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
                ProfilePictureUrl = null
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
                ProfilePictureUrl = null
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
                ProfilePictureUrl = null
            };

            context.Users.Add(student);
            context.Users.Add(teacher);
            context.Users.Add(company);

        }
        
    }
}
