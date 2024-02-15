using FindInternship.Core.Contracts;
using FindInternship.Core.Hubs;
using FindInternship.Core.Services;
using FindInternship.Data.Repository;
using FindInternship.Data;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Moq;
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
    public class LectorServiceTest
    {
        private DbContextOptions<FindInternshipDbContext> dbOptions;
        private FindInternshipDbContext dbContext;
        private IRepository repo;
        private ILectorService lectorService;

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

            this.lectorService = new LectorService(this.repo);

        }
        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task DeleteAsyncShouldDeleteLectorCorrectly()
        {
            string lectorId = "724ebe11-96f9-4dfb-b255-da3041d887d5";

            await lectorService.DeleteAsync(lectorId);

            var result = await repo.All<Lector>()
                .FirstOrDefaultAsync(l => l.Id == lectorId);

            Assert.That(result!.IsActive, Is.False);
        }

        [Test]
        [TestCase("some id")]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2")]
        [TestCase("608924f2-e51d-4686-b1eb-1f33b5dd6aa7")]
        public async Task DeleteAsyncShouldDoNothingWithIncorrectLectorId(string lectorId)
        {
            await lectorService.DeleteAsync(lectorId);

            var result = await repo.All<Lector>()
                .FirstOrDefaultAsync(l => l.Id == lectorId);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task IsLectorExistsAsyncShouldReturnTrue()
        {
            string lectorId = "724ebe11-96f9-4dfb-b255-da3041d887d5";

            var result = await lectorService.IsLectorExistsAsync(lectorId);

            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase("some id")]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2")]
        [TestCase("608924f2-e51d-4686-b1eb-1f33b5dd6aa7")]
        public async Task IsLectorExistsAsyncShouldReturnFalse(string lectorId)
        {
            var result = await lectorService.IsLectorExistsAsync(lectorId);

            Assert.That(result, Is.False);
        }
    }
}
