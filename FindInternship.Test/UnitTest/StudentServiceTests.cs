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
        [TestCase("7493d4c1-251f-4e9a-aaba-c11d5c4da798", "90bd5987-e991-4dfd-be1a-a57464b9d697")]
        public async Task GetStudentCompanyIdsAsyncShouldRetunrCorrectResult(string companyId, string classId)
        {
            var result = await studentService.GetStudentCompanyIdsAsync(companyId, classId);

            var expectedUser = await repo.All<Student>().FirstOrDefaultAsync();

            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0],Is.EqualTo( expectedUser!.UserId));
        }

        [Test]
        [TestCase("7493d4c1-251f-4e9a-aaba-c11d5c4da798", "28a172eb-6e0d-43ed-9a42-fb28025e1659")]
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

    }
}
