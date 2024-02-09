using FindInternship.Core.Contracts;
using FindInternship.Core.Services;
using FindInternship.Data.Repository;
using FindInternship.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static FindInternship.Test.UnitTest.DatabaseSeeder;
using FindInternship.Data.Models;
using FindInternship.Core.Models.Ability;

namespace FindInternship.Test.UnitTest
{
    [TestFixture]
    public class AbilityServiceTests
    {
        private DbContextOptions<FindInternshipDbContext> dbOptions;
        private FindInternshipDbContext dbContext;
        private IRepository repo;
        private IAbilityService abilityService;
        private Mock<IStudentService> studentServiceMock;
        private Mock<ICompanyService> companyServiceMock;
       

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
            this.companyServiceMock = new Mock<ICompanyService>();


            this.repo = new Repository(this.dbContext);
            this.abilityService = new AbilityService(this.repo, studentServiceMock.Object, companyServiceMock.Object);

        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task AddAbilitiesToStudentAsyncShouldAddAbilitiesCorrectly()
        {
            string userId = "bae65efa-6885-4144-9786-0719b0e2ebc4";
            studentServiceMock.Setup(s => s.GetStudentId(userId)).ReturnsAsync("4d152c78-9dbb-470c-aaf0-65a62a1dd2a0");

            List<string> abilities = new List<string>() { "3", "5" };

            await abilityService.AddAbilitiesToStudentAsync(abilities, userId);

            var result = await repo.All<Student>()
                .Include(s => s.Abilities)
                .Include(s => s.User)
                .Where(s => s.UserId == userId && s.User.IsActive)
                .Select(s => s.Abilities.Select(a => a.Ability.Id))
                .FirstOrDefaultAsync();


            Assert.That(result!, Does.Contain(5));
            Assert.That(result!, Does.Contain(3));
           
        }

        [Test]
        public async Task AddAbilitiesToStudentAsyncShouldDoNothingIfAbilitiesDoesNotExists()
        {
            string userId = "bae65efa-6885-4144-9786-0719b0e2ebc4";
            studentServiceMock.Setup(s => s.GetStudentId(userId)).ReturnsAsync("4d152c78-9dbb-470c-aaf0-65a62a1dd2a0");

            List<string> abilities = new List<string>() { "12", "23" };

            await abilityService.AddAbilitiesToStudentAsync(abilities, userId);

            var result = await repo.All<Student>()
                .Include(s => s.Abilities)
                .Include(s => s.User)
                .Where(s => s.UserId == userId && s.User.IsActive)
                .Select(s => s.Abilities.Select(a => a.Ability.Id))
                .FirstOrDefaultAsync();


            Assert.That(result!, !Does.Contain(12));
            Assert.That(result!, !Does.Contain(23));

        }

        [Test]
        [TestCase("28a172eb-6e0d-43ed-9a42-fb28025e1659")]
        [TestCase("eb8fc718-655e-4d32-9a0a-d905fa3956e7")]
        public async Task AddAbilitiesToStudentAsyncShouldDoNothingWithWrongUserId(string userId)
        {

            List<string> abilities = new List<string>() { "12", "23" };

            await abilityService.AddAbilitiesToStudentAsync(abilities, userId);

            var result = await repo.All<Student>()
                .Include(s => s.Abilities)
                .Include(s => s.User)
                .Where(s => s.UserId == userId && s.User.IsActive)
                .Select(s => s.Abilities.Select(a => a.Ability.Id))
                .FirstOrDefaultAsync();


            Assert.That(result, Is.Null);
        }

        [Test]
        [TestCase("Docker")]
        [TestCase("Terraform")]
        [TestCase("React")]
        public async Task AddNewAbilityAsyncShouldAddNewAbilityCorrectly(string ability)
        {
            await abilityService.AddNewAbilityAsync(ability);

            var result = await repo.All<Ability>()
                .Where(a => a.AbilityText == ability)
                .FirstOrDefaultAsync();

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task AddTechnologiesToCompanyAsyncShouldAddTechnologiesCorrectly()
        {
            string userId = "eb8fc718-655e-4d32-9a0a-d905fa3956e7";
            companyServiceMock.Setup(s => s.GetCompanyIdAsync(userId)).ReturnsAsync("7493d4c1-251f-4e9a-aaba-c11d5c4da798");

            List<string> abilities = new List<string>() { "3", "6" };

            await abilityService.AddTechnologiesToCompanyAsync(abilities, userId);

            var result = await repo.All<Company>()
                .Include(s => s.Technologies)
                .Include(s => s.User)
                .Where(s => s.UserId == userId && s.User.IsActive)
                .Select(s => s.Technologies.Select(a => a.Ability.Id))
                .FirstOrDefaultAsync();


            Assert.That(result!, Does.Contain(3));
            Assert.That(result!, Does.Contain(6));
        }
        [Test]
        public async Task AddTechnologiesToCompanyAsyncShouldDoNothingWhenAbilitiesDoesNotExists()
        {
            string userId = "eb8fc718-655e-4d32-9a0a-d905fa3956e7";
            companyServiceMock.Setup(s => s.GetCompanyIdAsync(userId)).ReturnsAsync("7493d4c1-251f-4e9a-aaba-c11d5c4da798");

            List<string> abilities = new List<string>() { "31", "63" };

            await abilityService.AddTechnologiesToCompanyAsync(abilities, userId);

            var result = await repo.All<Company>()
                .Include(s => s.Technologies)
                .Include(s => s.User)
                .Where(s => s.UserId == userId && s.User.IsActive)
                .Select(s => s.Technologies.Select(a => a.Ability.Id))
                .FirstOrDefaultAsync();


            Assert.That(result!, !Does.Contain(31));
            Assert.That(result!, !Does.Contain(63));
            Assert.That(result!.Count(), Is.EqualTo(4));
        }

        [Test]
        [TestCase("28a172eb-6e0d-43ed-9a42-fb28025e1659")]
        [TestCase("bae65efa-6885-4144-9786-0719b0e2ebc4")]
        public async Task AddTechnologiesToCompanyAsyncShouldDoNothingWithWrongUserId(string userId)
        {

            List<string> abilities = new List<string>() { "3", "6" };

            await abilityService.AddTechnologiesToCompanyAsync(abilities, userId);

            var result = await repo.All<Company>()
                .Include(s => s.Technologies)
                .Include(s => s.User)
                .Where(s => s.UserId == userId && s.User.IsActive)
                .Select(s => s.Technologies.Select(a => a.Ability.Id))
                .FirstOrDefaultAsync();


            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task AllAbilitiesAsyncShouldReturnCorrectResult()
        {
            var result = await abilityService.AllAbilitiesAsync();

            var expectedResult = await repo.All<Ability>()
                .Select(a => new AbilityViewModel()
                {
                    Id = a.Id,
                    AbilityText = a.AbilityText
                })
                .ToListAsync();

            Assert.NotNull(result);
            Assert.That(expectedResult, Is.Not.Null);
            Assert.That(result.First().Id,  Is.EqualTo(expectedResult.First().Id));
        }

        [Test]
        public async Task AllAbilityNamesAsyncShouldReturnCorrectResult()
        {
            var result = await abilityService.AllAbilityNamesAsync();

            var expectedResult = new List<string>() { "C#", "JS", "SQL", "ASP.NET", "HTML", "CSS" };

            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        [Test]
        public async Task GetCompanyAbilityNamesAsyncShouldReturnCorrectResult()
        {
            string companyId = "7493d4c1-251f-4e9a-aaba-c11d5c4da798";

            var result = await abilityService.GetCompanyAbilityNamesAsync(companyId);

            var expectedResult = new List<string>() { "C#", "JS", "ASP.NET", "HTML" };

            CollectionAssert.AreEquivalent(expectedResult, result);

        }

        [Test]
        [TestCase("28a172eb-6e0d-43ed-9a42-fb28025e1659")]
        [TestCase("bae65efa-6885-4144-9786-0719b0e2ebc4")]
        public async Task GetCompanyAbilityNamesAsyncShouldReturnEmptyCollection(string companyId)
        {
            var result = await abilityService.GetCompanyAbilityNamesAsync(companyId);

            CollectionAssert.IsEmpty(result);
        }

        



    }
}
