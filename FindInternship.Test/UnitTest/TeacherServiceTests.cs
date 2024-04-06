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
using Moq;
using FindInternship.Core.Models.Student;
using FindInternship.Core.Models.Account;
using FindInternship.Data.Models;
using System.Diagnostics.Metrics;
using FindInternship.Data.Models.Enums;
using System.Globalization;

namespace FindInternship.Test.UnitTest
{
    [TestFixture]
    public class TeacherServiceTests
    {
        private DbContextOptions<FindInternshipDbContext> dbOptions;
        private FindInternshipDbContext dbContext;
        private IRepository repo;
        private Mock<IStudentService> studentServiceMock;
        private Mock<IClassService> classServiceMock;
        private Mock<ISchoolService> schoolServiceMock;
        private ITeacherService teacherService;

        [SetUp]
        public void SetUp()
        {

            this.dbOptions = new DbContextOptionsBuilder<FindInternshipDbContext>()
                    .UseInMemoryDatabase("FindInternshipInMemoryDb" + Guid.NewGuid().ToString())
                    .Options;

            this.dbContext = new FindInternshipDbContext(this.dbOptions, false);
            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);
            this.studentServiceMock = new Mock<IStudentService>();
            this.classServiceMock = new Mock<IClassService>();
            this.schoolServiceMock = new Mock<ISchoolService>();
          
            this.repo = new Repository(this.dbContext);

            this.teacherService = new TeacherService(this.repo, studentServiceMock.Object, classServiceMock.Object, schoolServiceMock.Object);

           
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        [TestCase("28a172eb-6e0d-43ed-9a42-fb28025e1659")]
        public async Task IsTeacherAsyncShuoldReturnTrue(string userId)
        {
            var result = await teacherService.IsTeacherAsync(userId);

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("null")]
        [TestCase("someId")]
        [TestCase("bae65efa-6885-4144-9786-0719b0e2ebc4")]
        public async Task IsTeacherAsyncShouldReturnFalse(string userId)
        {
            var result = await teacherService.IsTeacherAsync(userId);

            Assert.IsFalse(result);
        }

        [Test]
        [TestCase("28a172eb-6e0d-43ed-9a42-fb28025e1659")]
        public async Task GetTeacherIdAsyncShouldReturnCorrectResult(string userId)
        {
            var result = await teacherService.GetTeacherIdAsync(userId);

            string expected = "17cd4d78-a621-4bf3-a4a4-9d7d3af085d2";

            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(expected));
        }


        [Test]
        [TestCase("28a17b28025e1659")]
        [TestCase("eb8fc718-655e-4d32-9a0a-d905fa3956e7")]
        [TestCase("someId")]
        public async Task GetTeacherIdAsyncShouldReturnNull(string userId)
        {
            var result = await teacherService.GetTeacherIdAsync(userId);

            Assert.IsNull(result);
        }

        [Test]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2")]
        public async Task GetTeacherUserIdAsyncShouldReturnCorrectResult(string teacherId)
        {
            var result = await teacherService.GetTeacherUserIdAsync(teacherId);

            var expected = "28a172eb-6e0d-43ed-9a42-fb28025e1659";
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(result);

                Assert.That(expected, Is.EqualTo(result));
            });
        }

        [Test]
        [TestCase("17caf085d2")]
        [TestCase("7493d4c1-251f-4e9a-aaba-c11d5c4da798")]
        [TestCase("bae65efa-6885-4144-9786-0719b0e2ebc4")]
        public async Task GetTeacherUserIdAsyncShouldReturnNull(string teacherId)
        {
            var result = await teacherService.GetTeacherUserIdAsync(teacherId);

            Assert.IsNull(result);
        }

        [Test]
        [TestCase("28a172eb-6e0d-43ed-9a42-fb28025e1659")]
        public async Task GetTeacherClassIdAsyncShouldReturnCorrectResult(string userId)
        {
            var result = await teacherService.GetTeacherClassIdAsync(userId);

            string expected = "90bd5987-e991-4dfd-be1a-a57464b9d697";

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("bae65efa-6885-4144-9786-0719b0e2ebc4")]
        [TestCase("eb8fc718-655e-4d32-9a0a-d905fa3956e7")]
        public async Task GetTeacherClassIdAsyncShouldReturnNull(string userId)
        {
            var result = await teacherService.GetTeacherClassIdAsync(userId);

            Assert.IsNull(result);
        }

        [Test]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2")]
        public async Task GetTeacherStudentsAsyncShouldReturnCorrectResult(string teacherId)
        {
            studentServiceMock.Setup(st => st.GetTeacherStudentsAsync("90bd5987-e991-4dfd-be1a-a57464b9d697"))
                .ReturnsAsync(new List<StudentViewModel>() {new StudentViewModel()
                {
                    Id = "bae65efa-6885-4144-9786-0719b0e2ebc4", 
                    ProfilePictureUrl = null, 
                    Name = "Студент Студентов", 
                    Abilities = new List<string>() {"C#", "JS", "ASP.NET"}
                } 
                });


            string expectedClass = "12 Б";
            string expectedSpeciality = "Приложен програмист";
            string expectedSchool = "ППМГ Никола Обрешков";

            var result = await teacherService.GetTeacherStudentsAsync(teacherId);

            Assert.That(result.Class, Is.EqualTo(expectedClass));
            Assert.That(result.ClassSpeciality, Is.EqualTo(expectedSpeciality));
            Assert.That(result.School, Is.EqualTo(expectedSchool));
            CollectionAssert.IsNotEmpty(result.Students);
            Assert.That(result.Students.Count, Is.EqualTo(1));

        }

        [Test]
        [TestCase("someId")]
        [TestCase("bae65efa-6885-4144-9786-0719b0e2ebc4")]
        [TestCase("eb8fc718-655e-4d32-9a0a-d905fa3956e7")]

        public void GetTeacherStudentsAsyncShouldThrowsException(string teacherId)
        {
            Assert.ThrowsAsync<NullReferenceException>(async () =>
            {
                var result = await teacherService.GetTeacherStudentsAsync(teacherId);
            });

        }

        [Test]
        [TestCase("90bd5987-e991-4dfd-be1a-a57464b9d697")]
        public async Task GetTeacherUserIdByClassAsyncShouldReturnCorrectResult(string classId)
        {
            var result = await teacherService.GetTeacherUserIdByClassAsync(classId);

            string expected = "28a172eb-6e0d-43ed-9a42-fb28025e1659";

            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(expected));

        }

        [Test]
        [TestCase("someId")]
        [TestCase("bae65efa-6885-4144-9786-0719b0e2ebc4")]
        [TestCase("eb8fc718-655e-4d32-9a0a-d905fa3956e7")]
        public async Task GetTeacherUserIdByClassAsyncShouldReturnNull(string classId)
        {
            var result = await teacherService.GetTeacherUserIdByClassAsync(classId);

            Assert.IsNull(result);

        }
        [Test]
        public async Task GetTeacherUserIdByMeetingIdAsyncShouldReturnCorrectResult()
        {
            string meetingId = "862db3a5-4126-41e7-9ea0-7bf052215571";

            var result = await teacherService.GetTeacherUserIdByMeetingIdAsync(meetingId);

            string expectedResult = "28a172eb-6e0d-43ed-9a42-fb28025e1659";

            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(expectedResult));

        }

        [Test]
        [TestCase("bae65efa-6885-4144-9786-0719b0e2ebc4")]
        [TestCase("eb8fc718-655e-4d32-9a0a-d905fa3956e7")]
        public async Task GetTeacherUserIdByMeetingIdAsyncShouldReturnNull(string meetingId)
        {
            var result = await teacherService.GetTeacherUserIdByMeetingIdAsync(meetingId);

            Assert.IsNull(result);
        }

        [Test]
        public async Task CreateShouldCreateTeacherCorrectly()
        {
            var user = new User()
            {
                Id = "f34361d0-3db5-4807-bfc7-8248bd7e972c",
                Name = "Test Create Teacher",
                UserName = "newTeacher",
                NormalizedUserName = "NEWTEACHER",
                Email = "newTeacher@abv.bg",
                NormalizedEmail = "NEWTEACHER@ABV.BG",
                PhoneNumber = "0889876483",
                Country = "Bulgaria",
                City = "Казанлък",
                Address = "Test Address",
                BirthDate = DateTime.ParseExact("1993-02-08 11:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                RegisteredOn = DateTime.Now, 
                Gender = "Мъж",
                ProfilePictureUrl = null
            };

            await repo.AddAsync(user);
            await repo.SaveChangesAsync();

            RegisterTeacherViewModel model = new RegisterTeacherViewModel()
            {
                Name = "Test Create Teacher",
                Email = "newTeacher@abv.bg",
                Password = "123456",
                PasswordRepeat = "123456",
                School = "ППМГ Никола Обрешков",
                PhoneNumber = "0889876483",
                Country = "Bulgaria",
                City = "Казанлък",
                Address = "Test Address",
                Class = "12 Б",
                Speciality = "Приложен програмист",
                BirthDate = DateTime.Now,
                Gender = "Мъж",
                ProfilePicture = null
            };

            //string classId = "90bd5987-e991-4dfd-be1a-a57464b9d697";

            await teacherService.Create(model, user.Id);

            var result = await repo.All<User>()
                .AnyAsync(u => u.Id == user.Id);

             var resultTeacher = await repo.All<Teacher>()
                .AnyAsync(t => t.UserId == user.Id);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(result, Is.True);
            });
        }

        //[Test]
        //public async Task IsTeacherClassHaveCompanyAsyncShouldReturnTrue()
        //{
        //    string teacherUserId = "28a172eb-6e0d-43ed-9a42-fb28025e1659";

        //    var result = await teacherService.IsTeacherClassHaveCompanyAsync(teacherUserId);

        //    Assert.That(result, Is.True);
        //}

        //[Test]
        //[TestCase("someId")]
        //[TestCase("bae65efa-6885-4144-9786-0719b0e2ebc4")]
        //[TestCase("eb8fc718-655e-4d32-9a0a-d905fa3956e7")]
        //[TestCase(null)]
        //public async Task IsTeacherClassHaveCompanyAsyncShouldReturnFalse(string teacherUserId)
        //{
        //    var result = await teacherService.IsTeacherClassHaveCompanyAsync(teacherUserId);

        //    Assert.That(result, Is.False);
        //}
    }
}
