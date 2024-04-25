using FindInternship.Core.Contracts;
using FindInternship.Core.Services;
using FindInternship.Data.Repository;
using FindInternship.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static FindInternship.Test.UnitTest.DatabaseSeeder;
using FindInternship.Data.Models;
using FindInternship.Core.Models.Student;
using FindInternship.Data.Models.Enums;
using System.Globalization;
using FindInternship.Core.Models.Users;

namespace FindInternship.Test.UnitTest
{
    [TestFixture]
    public class StudentServiceTests
    {
        private DbContextOptions<FindInternshipDbContext> dbOptions;
        private FindInternshipDbContext dbContext;
        private IRepository repo;
        private IStudentService studentService;

        [SetUp]
        public void SetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<FindInternshipDbContext>()
                    .UseInMemoryDatabase("FindInternshipInMemoryDb" + Guid.NewGuid().ToString())
                    .Options;

            this.dbContext = new FindInternshipDbContext(this.dbOptions, false);
            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);


            this.repo = new Repository(this.dbContext);
            this.studentService = new StudentService(this.repo);

        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        [TestCase("4d152c78-9dbb-470c-aaf0-65a62a1dd2a0")]
        public async Task GetStudentAbilitiesAsyncShouldReturnCorrectResult(string studentId)
        {
            var result = await studentService.GetStudentAbilitiesAsync(studentId);

            var expectedResult = new List<string>() { "C#", "JS", "ASP.NET" };

            CollectionAssert.AreEqual(expectedResult, result);
            Assert.That(result.Count, Is.EqualTo(expectedResult.Count));
        }

        [Test]
        [TestCase("7493d4c1-251f-4e9a-aaba-c11d5c4da798")]
        [TestCase("28a172eb-6e0d-43ed-9a42-fb28025e1659")]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2")]
        public async Task GetStudentAbilitiesAsyncShouldReturnEmptyCollection(string studentId)
        {
            var result = await studentService.GetStudentAbilitiesAsync(studentId);

            CollectionAssert.IsEmpty(result);

        }

        [Test]
        [TestCase("bae65efa-6885-4144-9786-0719b0e2ebc4")]
        public async Task GetStudentIdShouldReturnCorrectResult(string userId)
        {
            var result = await studentService.GetStudentId(userId);

            string expected = "4d152c78-9dbb-470c-aaf0-65a62a1dd2a0";

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("7493d4c1-251f-4e9a-aaba-c11d5c4da798")]
        [TestCase("28a172eb-6e0d-43ed-9a42-fb28025e1659")]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2")]
        public async Task GetStudentUIdShouldReturnNull(string userId)
        {
            var result = await studentService.GetStudentId(userId);

            Assert.Null(result);
        }

        [Test]
        [TestCase("4d152c78-9dbb-470c-aaf0-65a62a1dd2a0")]
        public async Task GetStudentTeacherIdAsyncShouldReturnCorrectResult(string studentId)
        {
            var result = await studentService.GetStudentTeacherIdAsync(studentId);

            string expected = "17cd4d78-a621-4bf3-a4a4-9d7d3af085d2";

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("7493d4c1-251f-4e9a-aaba-c11d5c4da798")]
        [TestCase("28a172eb-6e0d-43ed-9a42-fb28025e1659")]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2")]
        public async Task GetStudentTeacherIdAsyncShouldReturnNull(string studentId)
        {
            var result = await studentService.GetStudentTeacherIdAsync(studentId);

            Assert.Null(result);
        }

        [Test]
        [TestCase("7493d4c1-251f-4e9a-aaba-c11d5c4da798", "b2d1e4fd-5f48-4519-8c0d-4de8e8a408de")]
        public async Task GetStudentCompanyIdsAsyncShouldRetunrCorrectResult(string companyId, string classId)
        {
            var result = await studentService.GetStudentCompanyIdsAsync(companyId, classId);

            var expectedUser = await repo.All<Student>().FirstOrDefaultAsync();

            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0],Is.EqualTo( expectedUser!.UserId));
        }

        [Test]
        [TestCase("7493d4c1-251f-4e9a-aaba-c11d5c4da798", "724ebe11-96f9-4dfb-b255-da3041d887d5")]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2", "some if")]
        [TestCase("7cd4d78-a621-4bf3-a4a4-9d7d3af085d2", "f4jvberuuv")]
        public async Task GetStudentCompanyIdsShouldReturnEmptyCollection(string companyId, string classId)
        {
            var result = await studentService.GetStudentCompanyIdsAsync(companyId, classId);

            CollectionAssert.IsEmpty(result);
        }

        [Test]
        [TestCase("7493d4c1-251f-4e9a-aaba-c11d5c4da798", "862db3a5-4126-41e7-9ea0-7bf052215571")]
        public async Task GetCompanyStudentIdsAsyncShouldReturnCorrectResult(string companyId, string meetingId)
        {
            var result = await studentService.GetCompanyStudentIdsAsync(companyId, meetingId);

            var expectedUser = await repo.All<Student>().FirstOrDefaultAsync();

            CollectionAssert.IsNotEmpty(result);
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0], Is.EqualTo(expectedUser!.UserId));
        }

        [Test]
        [TestCase("7493d4c1-251f-4e9a-aaba-c11d5c4da798", "28a172eb-6e0d-43ed-9a42-fb28025e1659")]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2", "some if")]
        [TestCase("7cd4d78-a621-4bf3-a4a4-9d7d3af085d2", "f4jvberuuv")]
        public async Task GetCompanyStudentIdsAsyncShouldReturnEmptyCollection(string companyId, string meetingId)
        {
            var result = await studentService.GetCompanyStudentIdsAsync(companyId, meetingId);

            CollectionAssert.IsEmpty(result);
        }

        [Test]
        [TestCase("4d152c78-9dbb-470c-aaf0-65a62a1dd2a0")]
        public async Task GetStudentClassIdAsyncShouldReturnCorrectResult(string studentId)
        {
            var result = await studentService.GetStudentClassIdAsync(studentId);

            string expected = "90bd5987-e991-4dfd-be1a-a57464b9d697";

            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(expected));

        }


        [Test]
        [TestCase("7493d4c1-251f-4e9a-aaba-c11d5c4da798")]
        [TestCase("28a172eb-6e0d-43ed-9a42-fb28025e1659")]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2")]

        public async Task GetStudentClassIdAsyncShouldReturnNull(string studentId)
        {
            var result = await studentService.GetStudentClassIdAsync(studentId);

            Assert.IsNull(result);
        }

        [Test]
        [TestCase("90bd5987-e991-4dfd-be1a-a57464b9d697")]
        public async Task GetTeacherStudentsAsyncShouldReturnCorrectResult(string classId)
        {
            var result = await studentService.GetTeacherStudentsAsync(classId);

            var expectedViewModel = new StudentViewModel()
            {
                Id = "bae65efa-6885-4144-9786-0719b0e2ebc4",
                ProfilePictureUrl = null,
                Name = "Студент Студентов",
                Abilities = new List<string>() { "C#", "JS", "ASP.NET" }
            };

            Assert.IsNotNull(result);
            Assert.That(expectedViewModel.Id, Is.EqualTo(result[0].Id));
            Assert.That(expectedViewModel.Name, Is.EqualTo(result[0].Name));
            CollectionAssert.AreEqual(expectedViewModel.Abilities, result[0].Abilities);

        }

        [Test]
        [TestCase("7493d4c1-251f-4e9a-aaba-c11d5c4da798")]
        [TestCase("28a172eb-6e0d-43ed-9a42-fb28025e1659")]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2")]
        public async Task GetTeacherStudentsAsyncShouldReturnEmptyCollection(string classId)
        {
            var result = await studentService.GetTeacherStudentsAsync(classId);

            CollectionAssert.IsEmpty(result);
        }

        [Test]
        [TestCase("bae65efa-6885-4144-9786-0719b0e2ebc4")]
        public async Task IsStudentAsyncShouldReturnTrue(string userId)
        {
            var result = await studentService.IsStudent(userId);

            Assert.True(result);
        }

        [Test]
        [TestCase("7493d4c1-251f-4e9a-aaba-c11d5c4da798")]
        [TestCase("28a172eb-6e0d-43ed-9a42-fb28025e1659")]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2")]
        public async Task IsStudentAsyncShouldReturnFalse(string userId)
        {

            var result = await studentService.IsStudent(userId);

            Assert.False(result);
        }

        [Test]
        public async Task CreateShouldCreateNewStudent()
        {
            var user = new User()
            {

                Id = "9741281f-f3f7-480b-a066-85770a3bce6e",
                UserName = "newStudentTest",
                NormalizedUserName = "NEWSTUDENTTEST",
                Email = "newStudent@abv.bg",
                NormalizedEmail = "NEWSTUDENT@ABV.BG",
                PhoneNumber = "0887654569",
                Name = "Нов Ученик",
                City = "Казанлък",
                Country = "България",
                Address = "ул. Ал. Стамболийски 28 ет.2 ап.8",
                Gender = Gender.Мъж.ToString(),
                RegisteredOn = DateTime.UtcNow,
                BirthDate = DateTime.ParseExact("2006-02-08 11:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                ProfilePictureUrl = null,
                IsApproved = true,
                IsActive = true

            };

            await repo.AddAsync(user);

            await studentService.Create(user.Id, "90bd5987-e991-4dfd-be1a-a57464b9d697");
            var expectedResult = await repo.All<Student>().AnyAsync(u => u.UserId == user.Id);

            Assert.True(expectedResult);

        }

        [Test]
        public async Task GetFilteredStudentsAsyncShouldReturnCorrectResult()
        {
            string classId = "90bd5987-e991-4dfd-be1a-a57464b9d697";

            var result = await studentService.GetFilteredStudentsAsync(classId);

            var expectedResult = new List<UserViewModel>()
            {
                new UserViewModel
                {
                    Id = "4d152c78-9dbb-470c-aaf0-65a62a1dd2a0",
                    Name = "Студент Студентов",
                    Email = "studentStudentov@abv.bg",
                    ProfilePictureUrl = null,
                    IsApproved = true

                }
            };

            Assert.Multiple(() =>
            {
                Assert.That(result[0].Id, Is.EqualTo(expectedResult[0].Id));
                Assert.That(result[0].Name, Is.EqualTo(expectedResult[0].Name));
                Assert.That(result[0].Email, Is.EqualTo(expectedResult[0].Email));
                Assert.That(result[0].ProfilePictureUrl, Is.EqualTo(null));


            }); 
        }

        [Test]
        [TestCase("7493d4c1-251f-4e9a-aaba-c11d5c4da798")]
        [TestCase("28a172eb-6e0d-43ed-9a42-fb28025e1659")]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2")]

        public async Task GetFilteredStudentsAsyncShouldReturnEmptyCollection(string classId)
        {
            var result = await studentService.GetFilteredStudentsAsync(classId);

            CollectionAssert.IsEmpty(result);

        }

        [Test]
        public async Task GetStudentsForChooseAsyncShouldReturnEmptyCollection()
        {
            string requestId = "bf13bfe6-b1be-4dc8-b8e8-2a0e3ff2af4a";

            var result = await studentService.GetStudentsForChooseAsync(requestId);

            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public async Task GetStudentsForChooseAsyncShouldReturnCorrectResult()
        {
            var user = new User()
            {

                Id = "9741281f-f3f7-480b-a066-85770a3bce6e",
                UserName = "newStudentTest",
                NormalizedUserName = "NEWSTUDENTTEST",
                Email = "newStudent@abv.bg",
                NormalizedEmail = "NEWSTUDENT@ABV.BG",
                PhoneNumber = "0887654569",
                Name = "Нов Ученик",
                City = "Казанлък",
                Country = "България",
                Address = "ул. Ал. Стамболийски 28 ет.2 ап.8",
                Gender = Gender.Мъж.ToString(),
                RegisteredOn = DateTime.UtcNow,
                BirthDate = DateTime.ParseExact("2006-02-08 11:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                ProfilePictureUrl = null,
                IsApproved = true,
                IsActive = true

            };

            await repo.AddAsync(user);

            var student = new Student()
            {
                Id = "4e352493-cdaa-4633-b84a-84bab2f2acf0",
                UserId = user.Id,
                ClassId = "90bd5987-e991-4dfd-be1a-a57464b9d697",
                CompanyInternsId = null
            };
            await repo.AddAsync(student);
            await repo.SaveChangesAsync();

            string requestId = "bf13bfe6-b1be-4dc8-b8e8-2a0e3ff2af4a";

            var result = await studentService.GetStudentsForChooseAsync(requestId);

            var expectedResult = new List<UserViewModel>()
            {
                new UserViewModel()
                {
                    Id = "4e352493-cdaa-4633-b84a-84bab2f2acf0",
                    Name = "Нов Ученик",
                    Email = "newStudent@abv.bg",
                    ProfilePictureUrl = null,
                    IsApproved = true,

                }
            };

            Assert.Multiple(() =>
            {
                Assert.That(result[0].Id, Is.EqualTo(expectedResult[0].Id));
                Assert.That(result[0].Name, Is.EqualTo(expectedResult[0].Name));
                Assert.That(result[0].Email, Is.EqualTo(expectedResult[0].Email));
            });

        }

        [Test]
        public async Task AddStudentToCompanyIternsAsync()
        {
            var user = new User()
            {

                Id = "9741281f-f3f7-480b-a066-85770a3bce6e",
                UserName = "newStudentTest",
                NormalizedUserName = "NEWSTUDENTTEST",
                Email = "newStudent@abv.bg",
                NormalizedEmail = "NEWSTUDENT@ABV.BG",
                PhoneNumber = "0887654569",
                Name = "Нов Ученик",
                City = "Казанлък",
                Country = "България",
                Address = "ул. Ал. Стамболийски 28 ет.2 ап.8",
                Gender = Gender.Мъж.ToString(),
                RegisteredOn = DateTime.UtcNow,
                BirthDate = DateTime.ParseExact("2006-02-08 11:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                ProfilePictureUrl = null,
                IsApproved = true,
                IsActive = true

            };

            await repo.AddAsync(user);

            var student = new Student()
            {
                Id = "4e352493-cdaa-4633-b84a-84bab2f2acf0",
                UserId = user.Id,
                ClassId = "90bd5987-e991-4dfd-be1a-a57464b9d697",
                CompanyInternsId = null
            };
            await repo.AddAsync(student);
            await repo.SaveChangesAsync();


            List<string> studentIds = new List<string>() { student.Id };
            string companyUserId = "eb8fc718-655e-4d32-9a0a-d905fa3956e7";

            await studentService.AddStudentToCompanyIternsAsync(studentIds, companyUserId);

            var expectedResult = await repo.All<CompanyInterns>()
                .Include(c => c.Company)
                .Where(c => c.Company.UserId == companyUserId)
                .Include(c => c.Students)
                .FirstOrDefaultAsync();

            Assert.That(expectedResult.Students.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task IsAllStudentsExistsAsyncShouldReturnTrue()
        {
            var students = new List<string>() { "4d152c78-9dbb-470c-aaf0-65a62a1dd2a0" };
            var result = await studentService.IsAllStudentsExistsAsync(students);


            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase("ajax", "arssad" )]
        [TestCase("ajax", "4d152c78-9dbb-470c-aaf0-65a62a1dd2a0")]
        public async Task IsAllStudentsExistsAsyncShouldReturnFalse(params string[] students)
        {
            var result = await studentService.IsAllStudentsExistsAsync(students.ToList());


            Assert.That(result, Is.False);
        }

        [Test]
        public async Task GetStudentGroupIdAsyncShouldReturnCorrectResult()
        {
            string studentId = "4d152c78-9dbb-470c-aaf0-65a62a1dd2a0";

            var result = await studentService.GetStudentGroupIdAsync(studentId);

            var expectedResult = "b2d1e4fd-5f48-4519-8c0d-4de8e8a408de";

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("id")]
        [TestCase("b2d1e4fd-5f48-4519-8c0d-4de8e8a408de")]
        [TestCase("qreofvnjibqwjbvf")]
        public async Task GetStudentGroupIdAsyncShouldReturnNull(string studentId)
        {
            var result = await studentService.GetStudentGroupIdAsync(studentId);

            Assert.That(result, Is.Null);
        }



    }
}
