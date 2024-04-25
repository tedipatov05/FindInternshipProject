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
using FindInternship.Core.Models.CompanyInterns;

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

        [Test]
        public async Task GetTeacherUserIdByCompanyInternIdAsyncShouldReturnCorrectResult()
        {
            string companyInternId = "b2d1e4fd-5f48-4519-8c0d-4de8e8a408de";

            var result = await teacherService.GetTeacherUserIdByCompanyInternIdAsync(companyInternId);

            string expectedResult = "28a172eb-6e0d-43ed-9a42-fb28025e1659";

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("if")]
        [TestCase("28a172eb-6e0d-43ed-9a42-fb28025e1659")]
        [TestCase("wfnwiebuewrf")]
        public async Task GetTeacherUserIdByCompanyInternIdAsyncShouldReturnNull(string companyInternId)
        {
            var result = await teacherService.GetTeacherUserIdByCompanyInternIdAsync(companyInternId);

            Assert.That(result, Is.Null);

        }

        [Test]
        public async Task IsAllStudentsHaveGroupInCompanyAsyncShouldReturnTrue()
        {
            string teacherUserId = "28a172eb-6e0d-43ed-9a42-fb28025e1659";

            var result = await teacherService.IsAllStudentsHaveGroupInCompanyAsync(teacherUserId);

            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase("if")]
        [TestCase("28a172eb-6e0-43ed-9a42-fb289")]
        [TestCase("wfnwiebuewrf")]
        public async Task IsAllStudentsHaveGroupInCompanyAsyncShouldReturnFalse(string teacherUserId)
        {
            var result = await teacherService.IsAllStudentsHaveGroupInCompanyAsync(teacherUserId);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task IsAllStudentsHaveGroupInCompanyAsyncShouldReturnFalseWithNewStudent()
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

            string teacherUserId = "28a172eb-6e0d-43ed-9a42-fb28025e1659";

            var result = await teacherService.IsAllStudentsHaveGroupInCompanyAsync(teacherUserId);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task GetTeacherCompanyInternsAsyncShouldReturnCorrectResult()
        {
            string teacherUserId = "28a172eb-6e0d-43ed-9a42-fb28025e1659";

            var result = await teacherService.GetTeacherCompanyInternsAsync(teacherUserId);

            var expectedResult = new List<CompanyInternsViewModel>()
            {
                new CompanyInternsViewModel()
                {
                    Id = "b2d1e4fd-5f48-4519-8c0d-4de8e8a408de",
                    Name = "12 Б - Фирма",
                }

            };
        }

        [Test]
        [TestCase("if")]
        [TestCase("28a172eb-6e0-43ed-9a42-fb289")]
        [TestCase("wfnwiebuewrf")]
        public async Task GetTeacherCompanyInternsAsyncShouldReturnEmptyCollection(string teacherUserId)
        {
            var result = await teacherService.GetTeacherCompanyInternsAsync(teacherUserId);

            CollectionAssert.IsEmpty(result);
        }



    }
}
