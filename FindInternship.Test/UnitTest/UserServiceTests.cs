using FindInternship.Core.Contracts;
using FindInternship.Core.Services;
using FindInternship.Data;
using FindInternship.Data.Repository;
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
    public class UserServiceTests
    {
        private DbContextOptions<FindInternshipDbContext> dbOptions;
        private FindInternshipDbContext dbContext;
        private IRepository repo;
        private IUserService userService;

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
            this.userService = new UserService(this.repo);
           
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        [TestCase("studentStudentov@abv.bg")]
        [TestCase("teacher@abv.bg")]
        [TestCase("company@abv.bg")]
        public async Task UserExistsByEmailShouldReturnTrue(string email)
        {
            var result = await userService.IsUserExistsByEmailAsync(email);

            Assert.That(result, Is.EqualTo(true));
        }
        [Test]
        [TestCase("test@abv.bg")]
        [TestCase(" ")]
        [TestCase("null")]
        public async Task UserExistsByEmailShouldReturnFalse(string email)
        {
            var result = await userService.IsUserExistsByEmailAsync(email);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        [TestCase("0887654563")]
        [TestCase("0887654560")]
        [TestCase("0887654561")]
        public async Task UserExistsByPhoneAsyncShouldReturnTrue(string phone)
        {
            var result = await userService.IsUserExistsByPhoneAsync(phone);

            Assert.That( result, Is.EqualTo(true));
        }

        [Test]
        [TestCase("null")]
        [TestCase("")]
        [TestCase("0887654569")]
        public async Task UserExistsByPhoneAsyncShouldReturnFalse(string phone)
        {
            var result = await userService.IsUserExistsByPhoneAsync(phone);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        [TestCase("28a172eb-6e0d-43ed-9a42-fb28025e1659")]
        [TestCase("eb8fc718-655e-4d32-9a0a-d905fa3956e7")]
        [TestCase("bae65efa-6885-4144-9786-0719b0e2ebc4")]
        public async Task UserExistsByIdAsyncShouldReturnTrue(string id)
        {
            var result = await userService.IsExistsByIdAsync(id);

            Assert.True(result);
        }
        [Test]
        [TestCase("025e1659")]
        [TestCase("e6e7")]
        [TestCase("b9b0e2ebc4")]
        public async Task UserExistsByIdAsyncShouldReturnFalse(string id)
        {
            var result = await userService.IsExistsByIdAsync(id);

            Assert.False(result);
        }

        [Test]
        [TestCase("studentTest")]
        [TestCase("teacherTest")]
        [TestCase("companyTest")]
        public async Task GetUserIdByUsernameAsyncShouldReturnCorrectResult(string username)
        {
            var result = await userService.GetUserIdByUsernameAsync(username);

            Assert.IsNotNull(result);
        }

        [Test]
        [TestCase("sTest")]
        [TestCase("tTest")]
        [TestCase("cTest")]
        public async Task GetUserIdByUsernameAsyncShouldReturnNull(string username)
        {

            var result = await userService.GetUserIdByUsernameAsync(username);

            Assert.IsNull(result);
          
        }
    }
}
