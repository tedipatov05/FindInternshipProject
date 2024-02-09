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
using FindInternship.Core.Models.Profile;
using System.Diagnostics.Metrics;
using FindInternship.Data.Models;
using System.ComponentModel.Design;

namespace FindInternship.Test.UnitTest
{
    [TestFixture]
    public class ProfileServiceTests
    {
        private DbContextOptions<FindInternshipDbContext> dbOptions;
        private FindInternshipDbContext dbContext;
        private IRepository repo;
        private IProfileService profileService;
        private Mock<IStudentService> studentServiceMock;
        private Mock<IImageService> imageServiceMock;
        private Mock<IAbilityService> abilityServiceMock;

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
            this.imageServiceMock = new Mock<IImageService>();
            this.abilityServiceMock = new Mock<IAbilityService>();

            this.repo = new Repository(this.dbContext);
            this.profileService = new ProfileService(this.repo, studentServiceMock.Object, imageServiceMock.Object, abilityServiceMock.Object);

        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task EditProfileAsyncShouldEditProfileCorrectly()
        {
            string userId = "bae65efa-6885-4144-9786-0719b0e2ebc4";
            EditProfileModel model = new EditProfileModel()
            {
                Name = "Name edited", 
                Email = "Email edited",
                PhoneNumber = "0887896754",
                Country = "Bulgaria edited", 
                City = "Kazanlak edited",
                Address = "edited", 
                ProfilePicture = null
            };

            await profileService.EditProfileAsync(userId, model);

            var resultUser = await repo.GetByIdAsync<User>(userId);

            Assert.IsNotNull(resultUser);
            Assert.Multiple(() =>
            {
                Assert.That(resultUser.Name, Is.EqualTo(model.Name));
                Assert.That(resultUser.Email, Is.EqualTo(model.Email));
                Assert.That(resultUser.PhoneNumber, Is.EqualTo(model.PhoneNumber));
                Assert.That(resultUser.Address, Is.EqualTo(model.Address));
                Assert.That(resultUser.Country, Is.EqualTo(model.Country));
                Assert.That(resultUser.City, Is.EqualTo(model.City));
            });
        }
        [Test]
        [TestCase("some id")]
        [TestCase("251f-4e9a-aaba-c11d5c4da798")]
        [TestCase("6e0d-43ed-9a42-fb28025e1659")]
        public async Task EditProfileAsyncShouldDoNothingWhenUserDoesNotExists(string userId)
        {
            EditProfileModel model = new EditProfileModel()
            {
                Name = "Name edited",
                Email = "Email edited",
                PhoneNumber = "0887896754",
                Country = "Bulgaria edited",
                City = "Kazanlak edited",
                Address = "edited",
                ProfilePicture = null
            };

            await profileService.EditProfileAsync(userId, model);

            var resultUser = await repo.GetByIdAsync<User>(userId);

            Assert.IsNull(resultUser);
        }

        [Test]
        public async Task GetCompanyProfileAsyncShouldReturnCorrectResult()
        {
            string companyId = "7493d4c1-251f-4e9a-aaba-c11d5c4da798";

            abilityServiceMock.Setup(a => a.GetCompanyAbilityNamesAsync(companyId))
                .ReturnsAsync(new List<string>() { "JS", "C#", "ASP.NET", "HTML" });

            var result = await profileService.GetCompanyProfileAsync(companyId);

            var expected = new CompanyProfileViewModel()
            {
                Id = "eb8fc718-655e-4d32-9a0a-d905fa3956e7",
                Name = "Фирма",
                Address = "ул. Ал. Стамболийски 28 ет.2 ап.8",
                City = "Казанлък",
                Country = "България",
                Description = "At Company, we are at the forefront of driving innovation and digital transformation. As a leading IT solutions provider, we specialize in delivering cutting-edge technology services to empower businesses and organizations across various industries.",
                Email = "company@abv.bg",
                PhoneNumber = "0887654561",
                ProfilePictureUrl = null,
                Services = "Custom Software Development, Web and Mobile App Development, Cloud Solutions"
            };

            Assert.Multiple(() =>
            {
                Assert.That(result!.Id, Is.EqualTo(expected.Id));
                Assert.That(result.Name, Is.EqualTo(expected.Name));
                Assert.That(result.Address, Is.EqualTo(expected.Address));
                Assert.That(result.City, Is.EqualTo(expected.City));
                Assert.That(result.Country, Is.EqualTo(expected.Country));
                Assert.That(result.Description, Is.EqualTo(expected.Description));
                Assert.That(result.Email, Is.EqualTo(expected.Email));
                Assert.That(result.Services,  Is.EqualTo(expected.Services));
            });

            CollectionAssert.AreEqual(result!.Technologies, new List<string>() { "JS", "C#", "ASP.NET", "HTML" });



        }

        [Test]
        [TestCase("some id")]
        [TestCase("251f-4e9a-aaba-c11d5c4da798")]
        [TestCase("6e0d-43ed-9a42-fb28025e1659")]
        public async Task GetCompanyProfileAsyncShouldReturnNull(string companyId)
        {
            var result = await profileService.GetCompanyProfileAsync(companyId);

            Assert.Null(result);
        }
        [Test]
        public async Task GetStudentProfileAsyncShouldReturnCorrectResult()
        {
           
            string studentId = "4d152c78-9dbb-470c-aaf0-65a62a1dd2a0";

            studentServiceMock.Setup(a => a.GetStudentAbilitiesAsync(studentId))
               .ReturnsAsync(new List<string>() { "JS", "C#", "ASP.NET" });

            var result = await profileService.GetStudentProfileAsync(studentId);

            var expected = new StudentProfileViewModel()
            {

                Id = "bae65efa-6885-4144-9786-0719b0e2ebc4",
                Name = "Студент Студентов",
                Address = "ул.Възраждане 6 ет.2 ап.8",
                City = "Казанлък",
                Country = "България",
                Email = "studentStudentov@abv.bg",
                PhoneNumber = "0887654563",
                ProfilePictureUrl = null,
                Class = "12 Б",
                School = "ППМГ Никола Обрешков",
            };

            Assert.Multiple(() =>
            {
                Assert.That(result!.Id, Is.EqualTo(expected.Id));
                Assert.That(result.Name, Is.EqualTo(expected.Name));
                Assert.That(result.Address, Is.EqualTo(expected.Address));
                Assert.That(result.City, Is.EqualTo(expected.City));
                Assert.That(result.Country, Is.EqualTo(expected.Country));
                Assert.That(result.Class, Is.EqualTo(expected.Class));
                Assert.That(result.Email, Is.EqualTo(expected.Email));
                Assert.That(result.School, Is.EqualTo(expected.School));
            });

        }

        [Test]
        [TestCase("some id")]
        [TestCase("251f-4e9a-aaba-c11d5c4da798")]
        [TestCase("6e0d-43ed-9a42-fb28025e1659")]
        public async Task GetStudentProfileAsyncShouldReturnNull(string studentId)
        {
            var result = await profileService.GetStudentProfileAsync(studentId);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetTeacherProfileAsyncShouldReturnCorrectResult()
        {
            string teacherId = "17cd4d78-a621-4bf3-a4a4-9d7d3af085d2";

            var result = await profileService.GetTeacherProfileAsync(teacherId);



            var expectedResult = new TeacherProfileViewModel()
            {
                Id = "28a172eb-6e0d-43ed-9a42-fb28025e1659",
                Name = "Учител Учителов",
                Address = "ул.Кокиче 14 ет.2 ап.8",
                City = "Казанлък",
                Country = "България",
                Email = "teacher@abv.bg",
                PhoneNumber = "0887654560",
                ProfilePictureUrl = null,
                Class = "12 Б", 
                StudentsNames = new List<string>() { "Студент Студентов" }

            };

            
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(result);
                Assert.That(result!.Id, Is.EqualTo(expectedResult.Id));
                Assert.That(result.Name, Is.EqualTo(expectedResult.Name));
                Assert.That(result.Address, Is.EqualTo(expectedResult.Address));
                Assert.That(result.Email, Is.EqualTo(expectedResult.Email));
                Assert.That(result.Class, Is.EqualTo(expectedResult.Class));
                CollectionAssert.AreEqual(result.StudentsNames, expectedResult.StudentsNames);
            });
        }
        [Test]
        [TestCase("some id")]
        [TestCase("251f-4e9a-aaba-c11d5c4da798")]
        [TestCase("6e0d-43ed-9a42-fb28025e1659")]
        public async Task GetTeacherProfileAsyncShouldReturnNull(string teacherId)
        {
            var result = await profileService.GetTeacherProfileAsync(teacherId);

            Assert.That(result, Is.Null);
        }

        [Test]
        [TestCase("bae65efa-6885-4144-9786-0719b0e2ebc4")]
        [TestCase("28a172eb-6e0d-43ed-9a42-fb28025e1659")]
        [TestCase("eb8fc718-655e-4d32-9a0a-d905fa3956e7")]
        public async Task GetUserForEditShouldReturnCorrectResult(string userId)
        {
            var result = await profileService.GetUserForEditAsync(userId);

            var expectedResult = await repo.All<User>()
                .Where(u => u.Id == userId && u.IsActive)
                .Select(u => new EditProfileModel()
                {
                    Name = u.Name,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    City = u.City,
                    Country = u.Country,
                    Address = u.Address,
                })
                .FirstOrDefaultAsync();

            Assert.Multiple(() =>
            {
                Assert.NotNull(result);
                Assert.That(result!.Name, Is.EqualTo(expectedResult!.Name));
                Assert.That(result.Email, Is.EqualTo(expectedResult.Email));
                Assert.That(result.PhoneNumber, Is.EqualTo(expectedResult.PhoneNumber));
                Assert.That(result.City, Is.EqualTo(expectedResult.City));

            });
               
        }

        [Test]
        [TestCase("some id")]
        [TestCase("251f-4e9a-aaba-c11d5c4da798")]
        [TestCase("6e0d-43ed-9a42-fb28025e1659")]
        public async Task GetUserForEditAsyncShouldReturnNull(string userId)
        {
            var result = await profileService.GetUserForEditAsync(userId);

            Assert.Null(result);
        }

    }
}
