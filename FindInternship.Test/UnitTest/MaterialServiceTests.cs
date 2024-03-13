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
    public class MaterialServiceTests
    {
        private DbContextOptions<FindInternshipDbContext> dbOptions;
        private FindInternshipDbContext dbContext;
        private IRepository repo;
        private IMaterialService materialService;

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

            this.materialService = new MaterialService(this.repo);

        }
        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task CreateAsync()
        {
            string documentUrl = "document url";
            string name = "test name";
            string meetingId = "862db3a5-4126-41e7-9ea0-7bf052215571";

            string materialId = await materialService.CreateAsync(documentUrl, name, meetingId);

            var material = await repo.All<MeetingMaterial>()
                .FirstOrDefaultAsync(m => m.Id == materialId);

            Assert.Multiple(() =>
            {
                Assert.That(material!.Name, Is.EqualTo(name));
                Assert.That(material!.MeetingId, Is.EqualTo(meetingId));
                Assert.That(material!.DocumentUrl, Is.EqualTo(documentUrl));

            });

        }

        [Test]
        public async Task DeleteAllMeetingMaterials()
        {
            string documentUrl = "document url";
            string name = "test name";
            string meetingId = "862db3a5-4126-41e7-9ea0-7bf052215571";

            string materialId = await materialService.CreateAsync(documentUrl, name, meetingId);

            await materialService.DeleteAllMeetingMaterials(meetingId);

            var meeting = await repo.All<Meeting>()
                .Include(m => m.Materials)
                .FirstOrDefaultAsync(m => m.Id == meetingId);

            Assert.That(meeting!.Materials, Is.Empty);
        }

        [Test]
        public async Task GetAllMeetingMaterialsAsyncShouldReturnCorrectResult()
        {
            string documentUrl = "document url";
            string name = "test name";
            string meetingId = "862db3a5-4126-41e7-9ea0-7bf052215571";

            string materialId = await materialService.CreateAsync(documentUrl, name, meetingId);
            var result = await materialService.GetAllMeetingMatrialsAsync(meetingId);

            Assert.Multiple(() =>
            {
                Assert.That(result[0].Name,  Is.EqualTo(name));
                Assert.That(result[0].Url,  Is.EqualTo(documentUrl));
            });
        }


    }
}
