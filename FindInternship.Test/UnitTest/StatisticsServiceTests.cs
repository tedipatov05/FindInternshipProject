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
using FindInternship.Data.Models.Enums;

namespace FindInternship.Test.UnitTest
{
    [TestFixture]
    public class StatisticsServiceTests
    {
        private DbContextOptions<FindInternshipDbContext> dbOptions;
        private FindInternshipDbContext dbContext;
        private IRepository repo;
        private IStatisticService statisticService;

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
            this.statisticService = new StatisticService(this.repo);

        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }


        [Test]
        public async Task GetHappyUsersCountAsyncShouldReturnCorrectResult()
        {
            var result = await statisticService.GetHappyUsersCountAsync();

            var expectedResult = await repo.All<User>().CountAsync();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task GetInternshipsCountAsyncShouldReturnCorrectResult()
        {
            var result = await statisticService.GetInternshipsCountAsync();

            var expectedCount = await repo.All<Request>()
                .Where(r => r.Status == RequestStatusEnum.Accepted.ToString())
                .CountAsync();

            Assert.That(result, Is.EqualTo(expectedCount));
        }

        [Test]
        public async Task GetMeetingsArrangedCountAsyncShouldReturnCorrectResult()
        {
            var result = await statisticService.GetMeetingsArrangedCountAsync();

            var expectedCount = await repo.All<Meeting>()
                .CountAsync();

            Assert.That( result, Is.EqualTo(expectedCount));
        }
    }
}
