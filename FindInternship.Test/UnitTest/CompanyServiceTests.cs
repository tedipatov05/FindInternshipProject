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
using FindInternship.Core.Models.Company;
using FindInternship.Data.Models.Enums;
using FindInternship.Data.Models;
using System.Globalization;
using FindInternship.Core.Models.Lector;

namespace FindInternship.Test.UnitTest
{
    [TestFixture]
    public class CompanyServiceTests
    {
        private DbContextOptions<FindInternshipDbContext> dbOptions;
        private FindInternshipDbContext dbContext;
        private IRepository repo;
        private ICompanyService companyService;

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
            this.companyService = new CompanyService(this.repo);

        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        [TestCase("Фирма")]
        [TestCase("Company")]
        [TestCase("Software")]
        public async Task GetAllCompaniesAsyncShouldReturnCorrectResult(string searchString)
        {
            CompanyQueryModel model = new CompanyQueryModel()
            {
                SearchString = searchString,
                Technology = "C#"
            };

            var result = await companyService.GetAllCompaniesAsync(model);

            var expectedResult = new List<CompanyViewModel>()
            {
                new CompanyViewModel()
                {
                    Id = "eb8fc718-655e-4d32-9a0a-d905fa3956e7",
                    Name = "Фирма",
                    ProfilePictureUrl = null,
                    Address = "ул. Ал. Стамболийски 28 ет.2 ап.8",
                    Description = "At Company, we are at the forefront of driving innovation and digital transformation. As a leading IT solutions provider, we specialize in delivering cutting-edge technology services to empower businesses and organizations across various industries."
                }
            }.ToList();

            Assert.Multiple(() =>
            {
                Assert.That(result[0]!.Id, Is.EqualTo(expectedResult[0].Id));
            });

        }

        [Test]
        [TestCase("Тест")]
        [TestCase("Test")]
        [TestCase("nothing")]
        public async Task GetAllCompaniesAsyncShouldReturnEmptyCollection(string searchString)
        {
            var model = new CompanyQueryModel()
            {
                SearchString = searchString,
                Technology = "Docker"
            };

            var result = await companyService.GetAllCompaniesAsync(model);

            CollectionAssert.IsEmpty(result);

        }

        [Test]
        public async Task GetCompanyIdAsyncShouldReturnCorrectResult()
        {
            string companyUserId = "eb8fc718-655e-4d32-9a0a-d905fa3956e7";

            var result = await companyService.GetCompanyIdAsync(companyUserId);

            string expectedResult = "7493d4c1-251f-4e9a-aaba-c11d5c4da798";

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("862db3a5-4126-41e7-9ea0-7bf052215571")]
        [TestCase("90bd5987-e991-4dfd-be1a-a57464b9d697")]
        [TestCase("bf13bfe6-b1be-4dc8-b8e8-2a0e3ff2af4a")]
        public async Task GetCompanyIdAsyncShouldReturnNull(string companyUserId)
        {
            var result = await companyService.GetCompanyIdAsync(companyUserId);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetCompanyIdByNameAsyncShouldReturnCorrectResult()
        {
            string companyName = "Фирма";
            var result = await companyService.GetCompanyIdByNameAsync(companyName);

            string expectedResult = "eb8fc718-655e-4d32-9a0a-d905fa3956e7";

            Assert.That(result, Is.EqualTo(expectedResult));

        }

        [Test]
        [TestCase("testName")]
        [TestCase("Firma")]
        [TestCase("Company")]
        public async Task GetCompanyIdByNameAsyncShouldReturnNull(string companyName)
        {
            var result = await companyService.GetCompanyIdByNameAsync(companyName);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task IsCompanyAsyncShouldReturnTrue()
        {
            string companyUserId = "eb8fc718-655e-4d32-9a0a-d905fa3956e7";
            var result = await companyService.IsCompanyAsync(companyUserId);

            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase("862db3a5-4126-41e7-9ea0-7bf052215571")]
        [TestCase("90bd5987-e991-4dfd-be1a-a57464b9d697")]
        [TestCase("bf13bfe6-b1be-4dc8-b8e8-2a0e3ff2af4a")]
        [TestCase(null)]
        public async Task IsCompanyAsyncShouldReturnFalse(string companyUserId)
        {
            var result = await companyService.IsCompanyAsync(companyUserId);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task GetCompanyNameByIdAsyncShouldReturnCorrectResult()
        {
            string companyId = "eb8fc718-655e-4d32-9a0a-d905fa3956e7";

            var result = await companyService.GetCompanyNameByIdAsync(companyId);

            string expectedResult = "Фирма";

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("862db3a5-4126-41e7-9ea0-7bf052215571")]
        [TestCase("90bd5987-e991-4dfd-be1a-a57464b9d697")]
        [TestCase("bf13bfe6-b1be-4dc8-b8e8-2a0e3ff2af4a")]
        [TestCase(null)]
        public async Task GetCompanyNameByIdAsyncShouldReturnNull(string companyId)
        {
            var result = await companyService.GetCompanyNameByIdAsync(companyId);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task CreateAsyncShouldCreateCompany()
        {
            var user = new User()
            {

                Id = "b976b65c-0d23-4ecb-b816-d3b53863eeb4",
                UserName = "newCompanyTest",
                NormalizedUserName = "NEWCOMPANYTEST",
                Email = "newCompany@abv.bg",
                NormalizedEmail = "NEWCOMPANY@ABV.BG",
                PhoneNumber = "0887651569",
                Name = "Нова Фирма",
                City = "Казанлък",
                Country = "България",
                Address = "ул. Ал. Стамболийски 32 ет.2 ап.8",
                Gender = Gender.Мъж.ToString(),
                RegisteredOn = DateTime.UtcNow,
                BirthDate = DateTime.ParseExact("2001-02-08 11:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                ProfilePictureUrl = null,
                IsApproved = true,
                IsActive = true

            };

            await repo.AddAsync(user);

            string services = "test services that company do";
            string description = "this is one of the best companies";

            await companyService.CreateAsync(user.Id, services, description);

            var result = await repo.All<Company>()
                .AnyAsync(c => c.UserId == user.Id);

            Assert.That(result, Is.True);

        }

        [Test]
        public async Task IsInCompanyScheduleAsyncShouldReturnTrue()
        {
            string companyId = "7493d4c1-251f-4e9a-aaba-c11d5c4da798";
            string meetingId = "862db3a5-4126-41e7-9ea0-7bf052215571";

            var result = await companyService.IsInCompanyScheduleAsync(companyId, meetingId);

            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase("7493d4c1-251f-4e9a-aaba-c11d5c4da798", "bf13bfe6-b1be-4dc8-b8e8-2a0e3ff2af4a")]
        [TestCase("90bd5987-e991-4dfd-be1a-a57464b9d697", "862db3a5-4126-41e7-9ea0-7bf052215571")]
        [TestCase(null, null)]
        public async Task IsInCompanyScheduleAsyncShouldReturnFalse(string companyId, string meetingId)
        {
            var result = await companyService.IsInCompanyScheduleAsync(companyId, meetingId);

            Assert.That(result, Is.False);
        }

        //[Test]
        //public async Task AddClassToCompanyShouldAddClassToCompany()
        //{
        //    var cl = new Class
        //    {
        //        Id = "18b764cd-e349-4ac1-9be8-1452d609e2ab",
        //        Speciality = "Приложен програмист",
        //        SchoolId = 1,
        //        Grade = "12 A",
        //        CompanyInterns = null,
        //        TeacherId = null
        //    };

        //    await repo.AddAsync(cl);

        //    await repo.SaveChangesAsync();

        //    string companyId = "7493d4c1-251f-4e9a-aaba-c11d5c4da798";

        //    await companyService.AddClassToCompany(cl.Id, companyId);

        //    var result = await repo.All<Company>()
        //        .Include(c => c.Classes)
        //        .AnyAsync(c => c.Classes.Any(c => c.Id == cl.Id));

        //    var classResult = await repo.All<Class>()
        //        .FirstOrDefaultAsync(c => c.Id == cl.Id);

        //    Assert.That(result, Is.True);
        //    Assert.That(classResult, Is.Not.Null);
        //    Assert.That(classResult.CompanyId, Is.EqualTo(companyId));

        //}

        //[Test]
        //[TestCase("7493d4c1-251f-4e9a-aaba-c11d5c4da798", "bf13bfe6-b1be-4dc8-b8e8-2a0e3ff2af4a")]
        //[TestCase("90bd5991-4dfd-be1a-a57464b9d697", "8626-41e7-9ea0-7bf052215571")]
        //public async Task AddClassToCompanyShouldDoNothing(string classId, string companyId)
        //{
        //    await companyService.AddClassToCompany(classId, companyId);

        //    var classResult = await repo.All<Class>()
        //       .FirstOrDefaultAsync(c => c.Id == classId);

        //    Assert.That(classResult, Is.Null);
        //}

        [Test]
        public async Task AddLectorToCompanyAsyncShouldAddLectorToCompany()
        {
            string companyId = "7493d4c1-251f-4e9a-aaba-c11d5c4da798";
            AddLectorViewModel model = new AddLectorViewModel()
            {
                Name = "New Lector",
                Description = "Some lector description",

            };

            await companyService.AddLectorToCompany(companyId, model, "some url");

            var result = await repo.All<Lector>()
                .AnyAsync(l => l.CompanyId == companyId && l.Name == model.Name);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task IsLectorInCompanyShouldReturnTrue()
        {
            string companyId = "7493d4c1-251f-4e9a-aaba-c11d5c4da798";
            Lector lector = new Lector()
            {
                Id = "fa87be82-7f70-4465-a528-094605d6075e",
                Name = "Test Lector",
                Description = "Some lector description",
                CompanyId = companyId,
                ProfilePictureUrl = "some url"
            };

            await repo.AddAsync(lector);
            await repo.SaveChangesAsync();

            var result = await companyService.IsLectorInCompany(companyId, lector.Id);

            Assert.That(result, Is.True);

        }

        [Test]
        [TestCase("862db3a5-4126-41e7-9ea0-7bf052215571")]
        [TestCase("90bd5987-e991-4dfd-be1a-a57464b9d697")]
        [TestCase("bf13bfe6-b1be-4dc8-b8e8-2a0e3ff2af4a")]
        public async Task IsLectorInCompanyShouldReturnFalse(string lectorId)
        {
            string companyId = "7493d4c1-251f-4e9a-aaba-c11d5c4da798";

            var result = await companyService.IsLectorInCompany(companyId, lectorId);

            Assert.That(result, Is.False);
        }

        [Test]
        [TestCase("862db3a5-4126-41e7-9ea0-7bf052215571")]
        [TestCase("90bd5987-e991-4dfd-be1a-a57464b9d697")]
        [TestCase("bf13bfe6-b1be-4dc8-b8e8-2a0e3ff2af4a")]
        public async Task IsLectorInCompanyShouldReturnFalseWithWrongCompanyId(string companyId)
        {
            string lectorId = "7493d4c1-251f-4e9a-aaba-c11d5c4da798";

            var result = await companyService.IsLectorInCompany(companyId, lectorId);

            Assert.That(result, Is.False);
        }



    }
}
