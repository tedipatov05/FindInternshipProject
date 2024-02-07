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

namespace FindInternship.Test.UnitTest
{
    [TestFixture]
    public class SchoolServiceTests
    {
        private DbContextOptions<FindInternshipDbContext> dbOptions;
        private FindInternshipDbContext dbContext;
        private IRepository repo;
        private ISchoolService schoolService;

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
            this.schoolService = new SchoolService(this.repo);

        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }


        [Test]
        public async Task CreateShouldCreateNewSchool()
        {
            string schoolName = "TestNewSchool";
            string city = "Kazanlak";

            var id = await schoolService.Create(schoolName, city);

            var isExists = await repo.All<School>()
                .AnyAsync(s => s.Id == id);

            Assert.True(isExists);
        }

        [Test]
        [TestCase("ППМГ Никола Обрешков")]
        [TestCase("ппмг никола Обрешков")]
        [TestCase("ппмгниколаОбрешков")]
        public async Task GetSchoolIdIfExistsAsyncShouldReturnCorrectResult(string schoolName)
        {
            var result = schoolService.GetSchoolIdIfExistsAsync(schoolName);

            var isExists = await repo.All<School>()
                .AnyAsync(s => s.Id == result);

            Assert.NotNull(result);
            Assert.True(isExists);

        }

        [Test]
        [TestCase("Ivan")]
        [TestCase("ОУ Георги Кирков")]
        [TestCase("Св. св. Кирил и Методий")]
        public void GetSchoolIdIfExistsAsyncShouldReturnNull(string schoolName)
        {
            var result = schoolService.GetSchoolIdIfExistsAsync(schoolName);

            Assert.Null(result);
        }
    }
}
