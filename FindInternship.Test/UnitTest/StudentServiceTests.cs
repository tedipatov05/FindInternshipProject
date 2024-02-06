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

    }
}
