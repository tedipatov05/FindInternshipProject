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
using FindInternship.Core.Models.Class;

namespace FindInternship.Test.UnitTest
{
    [TestFixture]
    public class ClassServiceTests
    {
        private DbContextOptions<FindInternshipDbContext> dbOptions;
        private FindInternshipDbContext dbContext;
        private IRepository repo;
        private IClassService classService;

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
            this.classService = new ClassService(this.repo);

        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task AllClassesAsyncShouldReturnCorrectResult()
        {
            var result = await classService.AllClassesAsync();

            var expectedResult = new List<AllClassesViewModel>()
            {
                new AllClassesViewModel()
                {
                    Id = "90bd5987-e991-4dfd-be1a-a57464b9d697",
                    Name = "12 Б",
                    School = "ППМГ Никола Обрешков"
                }
            };

            Assert.That(expectedResult[0].Id, Is.EqualTo(result[0].Id));
            Assert.That(expectedResult[0].School, Is.EqualTo(result[0].School));
            Assert.That(expectedResult[0].Name, Is.EqualTo(result[0].Name));
        }

    }
}
