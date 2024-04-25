using FindInternship.Core.Contracts;
using FindInternship.Core.Models.Users;
using FindInternship.Core.Services;
using FindInternship.Data;
using FindInternship.Data.Models;
using FindInternship.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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

        [Test]
        [TestCase("studentTest")]
        [TestCase("teacherTest")]
        [TestCase("companyTest")]
        public async Task IsExistsByUsernameAsyncShoudReturnTrue(string username)
        {
            var result = await userService.IsExistsByUsernameAsync(username);

            Assert.True(result);
        }

        [Test]
        [TestCase("sTest")]
        [TestCase("tTest")]
        [TestCase("cTest")]
        public async Task IsExistsByUsernameAsyncShoudReturnFalse(string username)
        {
            var result = await userService.IsExistsByUsernameAsync(username);

            Assert.False(result);
        }
        [Test]
        public async Task GetUsersCountAsyncShouldReturnCorrectResult()
        {
            var resultExpected = await userService.GetUsersCountAsync();

            var actual = await repo.All<User>().ToListAsync();

            Assert.That(actual.Count, Is.EqualTo(resultExpected));
        }

        [Test]
        [TestCase("28a172eb-6e0d-43ed-9a42-fb28025e1659")]
        [TestCase("eb8fc718-655e-4d32-9a0a-d905fa3956e7")]
        public async Task ChangeUserIsApprovedAsyncShouldChangedIsApproved(string userId)
        {
            await userService.ChangeUserIsApprovedAsync(userId);

            var user = await repo.All<User>().FirstOrDefaultAsync(u => u.Id == userId);

            Assert.True(user!.IsApproved);
            
        }

        [Test]
        [TestCase("e1659")]
        [TestCase("e956e7")]
        [TestCase("bae2ebc4")]
        public async Task ChangeUserIsApprovedAsyncShouldDoNothingWhenUserIsNotFound(string userId)
        {
            await userService.ChangeUserIsApprovedAsync(userId);

            var user = await repo.All<User>().FirstOrDefaultAsync(u => u.Id == userId);

            Assert.That(user, Is.Null);

        }

        [Test]
        [TestCase("28a172eb-6e0d-43ed-9a42-fb28025e1659")]
        [TestCase("eb8fc718-655e-4d32-9a0a-d905fa3956e7")]
        [TestCase("bae65efa-6885-4144-9786-0719b0e2ebc4")]
        public async Task DeleteUserAsyncShouldChangeIsActiveToFalse(string userId)
        {
            await userService.DeleteUserAsync(userId);

            var user = await repo.All<User>().FirstOrDefaultAsync(u => u.Id == userId);

            Assert.That(user!.IsActive, Is.False);
        }

        [Test]
        [TestCase("28a2-fb28025e1659")]
        [TestCase("eb8fc718-655d905fa3956e7")]
        [TestCase("bae65ef-0719b0e2ebc4")]
        public async Task DeleteUserAsyncShouldDoNothingWhenUserDoesNotExists(string userId)
        {
            await userService.DeleteUserAsync(userId);

            var user = await repo.All<User>().FirstOrDefaultAsync(u => u.Id == userId);

            Assert.That(user, Is.Null);
        }

        [Test]
        public async Task GetFilteredUsersAsyncShouldReturnZeroUsers()
        {
            UsersQueryModel model = new UsersQueryModel()
            {
                SearchString = "None"
            };

            var users = await userService.GetFilteredUsersAsync(model, "501889c2-7883-473b-9333-c55267249071");

            Assert.That(users, Is.Empty);
            Assert.That(users.Count, Is.EqualTo(0));
            CollectionAssert.IsEmpty(users);
        }

        [Test]
        public async Task GetFilteredUsersAsyncShouldReturnCorrectResult()
        {
            var user1 = new User() { Name = "John Doe", Email = "john@example.com", PhoneNumber = "123456789", Address="Test", Country="Bulgaria", City="Kazanlak" };
            var user2 = new User() { Name = "Jane Doe", Email = "jane@example.com", PhoneNumber = "987654321", Address = "Test", Country = "Bulgaria", City = "Kazanlak" };
            var user3 = new User() { Name = "Alice Smith", Email = "alice@example.com", PhoneNumber = "555555555", Address = "Test", Country = "Bulgaria", City = "Kazanlak" };

            dbContext.Users.AddRange(user1, user2, user3);
            dbContext.SaveChanges();

            UsersQueryModel model = new UsersQueryModel()
            {
                SearchString = "a"
            };

            var users = await userService.GetFilteredUsersAsync(model, "501889c2-7883-473b-9333-c55267249071");

            CollectionAssert.IsNotEmpty(users);
            Assert.That(users, Has.Count.EqualTo(6));

            var userViewModel1 = users.FirstOrDefault(u => u.Name == "John Doe");
            Assert.Multiple(() =>
            {
                Assert.That(user1.Email, Is.EqualTo(userViewModel1!.Email));
                Assert.That(user1.Id, Is.EqualTo(userViewModel1!.Id));
            });
        }

        [Test]
        [TestCase("companyTest")]
        [TestCase("teacherTest")]
        [TestCase("studentTest")]
        public async Task GetUserProfilePictureByUsernameAsyncShouldReturnCorrectResult(string userName)
        {
            var result = await userService.GetUserProfilePictureByUsernameAsync(userName);

            string expectedResult = "../img/blank-profile-picture.png";

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task GetParticipantsProfilePictureAsyncShouldReturnCorrectResult()
        {
            var list = new List<string>() { "companyTest", "teacherTest", "studentTest" };

            var result = await userService.GetParticipantsProfilePictureAsync(list);

            CollectionAssert.AreEqual(result, new List<string>() { null, null, null});

        }


    }
}
