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

        public async Task GetTeacherStudentsAsyncShouldThrowsException(string teacherId)
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
    }
}
