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
using FindInternship.Core.Models.Meeting;
using FindInternship.Data.Models;

namespace FindInternship.Test.UnitTest
{
    [TestFixture]
    public class MeetingServiceTests
    {
        
        private DbContextOptions<FindInternshipDbContext> dbOptions;
        private FindInternshipDbContext dbContext;
        private IRepository repo;
        private IMeetingService meetingService;

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
            this.meetingService = new MeetingService(this.repo);

        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task CreateAsyncShouldCreateNewMeeting()
        {
            string companyId = "7493d4c1-251f-4e9a-aaba-c11d5c4da798";
            string classId = "90bd5987-e991-4dfd-be1a-a57464b9d697";
            FormMeetingViewModel model = new FormMeetingViewModel()
            {
                Title = "test title",
                Address = "test address",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(3),
                Description = "test add new meeting description", 
                LectorId = "724ebe11-96f9-4dfb-b255-da3041d887d5"

            };

            string result = await meetingService.CreateAsync(model, companyId, classId);

            var expected = await repo.All<Meeting>()
                .AnyAsync(m => m.Id == result);

            Assert.That(expected, Is.True);
        }

        [Test]
        public async Task DeleteMeetingAsyncShouldDeleteMeetingCorrectly()
        {
            string meetingId = "862db3a5-4126-41e7-9ea0-7bf052215571";

            await meetingService.DeleteMeetingAsync(meetingId);

            var result = await repo.All<Meeting>()
                .FirstOrDefaultAsync(m => m.Id == meetingId);

            Assert.That(result!.IsActive, Is.False);
        }

        [Test]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2")]
        [TestCase("90bd5987-e991-4dfd-be1a-a57464b9d697")]
        public async Task DeleteMeetingAsyncShouldDoNothingWithIncorrectMeetingId(string meetingId)
        {
            await meetingService.DeleteMeetingAsync(meetingId);

            var result = await repo.All<Meeting>()
                .FirstOrDefaultAsync(m => m.Id == meetingId);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetMeetingForDeleteAsyncShouldReturnCorrectResult()
        {
            string meetingId = "862db3a5-4126-41e7-9ea0-7bf052215571";

            var result = await meetingService.GetMeetingForDeleteAsync(meetingId);

            var expectedResult = new PreDeleteMeetingViewModel()
            {
                Title = "test meeting",
                Address = "Bulgaria, Kazanlak",
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow.AddHours(3),
            };

            Assert.Multiple(() =>
            {
                Assert.That(result!.Title, Is.EqualTo(expectedResult.Title));
                Assert.That(result.Address, Is.EqualTo(expectedResult.Address));

            });
        }
        [Test]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2")]
        [TestCase("90bd5987-e991-4dfd-be1a-a57464b9d697")]
        public async Task GetMeetingForDeleteAsyncShouldReturnNull(string meetingId)
        {
            var result = await meetingService.GetMeetingForDeleteAsync(meetingId);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetMeetingByIdAsyncShouldReturnCorrectResult()
        {
            string meetingId = "862db3a5-4126-41e7-9ea0-7bf052215571";

            var result = await meetingService.GetMeetingByIdAsync(meetingId);

            var expectedResult = new MeetingViewModel()
            {
                Id = "862db3a5-4126-41e7-9ea0-7bf052215571",
                Title = "test meeting",
                Address = "Bulgaria, Kazanlak",
                Day = DateTime.Now.DayOfWeek.ToString().Substring(0, 3),
                Number = DateTime.Now.Day,
                StartHour = "10",
                EndHour = "13"

            };

            Assert.Multiple(() =>
            {
                Assert.That(result!.Id, Is.EqualTo(expectedResult.Id));
                Assert.That(result.Title, Is.EqualTo(expectedResult.Title));
                Assert.That(result.Address, Is.EqualTo(expectedResult.Address));
                Assert.That(result.Day, Is.EqualTo(expectedResult.Day));

            });
        }

        [Test]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2")]
        [TestCase("90bd5987-e991-4dfd-be1a-a57464b9d697")]
        public async Task GetMeetingByIdAsyncShouldReturnNull(string meetingId)
        {
            var result = await meetingService.GetMeetingByIdAsync(meetingId);
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetMeetingForEditAsyncShouldReturnCorrectResult()
        {
            string meetingId = "862db3a5-4126-41e7-9ea0-7bf052215571";

            var result = await meetingService.GetMeetingForEditAsync(meetingId);

            var expectedResult = new FormMeetingViewModel()
            {
                Title = "test meeting",
                Address = "Bulgaria, Kazanlak",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(3),
            };

            Assert.Multiple(() =>
            {
                Assert.That(result!.Title, Is.EqualTo(expectedResult.Title));
                Assert.That(result.Address, Is.EqualTo(expectedResult.Address));
            });
        }

        [Test]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2")]
        [TestCase("90bd5987-e991-4dfd-be1a-a57464b9d697")]
        public async Task GetMeetingForEditAsyncShouldReturnNull(string meetingId)
        {

            var result = await meetingService.GetMeetingForEditAsync(meetingId);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task EditMeetinAsyncShouldEditMeeting()
        {
            string meetingId = "862db3a5-4126-41e7-9ea0-7bf052215571";
            var model = new FormMeetingViewModel()
            {
                Title = "test meeting [edited]",
                Address = "Bulgaria, Kazanlak [edited]",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(3),
            };

            await meetingService.EditMeetingAsync(meetingId, model);

            var expectedResult = await repo.All<Meeting>()
                .FirstOrDefaultAsync(m => m.Id == meetingId);

            Assert.Multiple(() =>
            {
                Assert.That(model.Title, Is.EqualTo(expectedResult!.Title));
                Assert.That(model.Address, Is.EqualTo(expectedResult!.Address));
                Assert.That(model.Start, Is.EqualTo(expectedResult!.StartTime));
                Assert.That(model.End, Is.EqualTo(expectedResult!.EndTime));

            });

        }

        [Test]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2")]
        [TestCase("90bd5987-e991-4dfd-be1a-a57464b9d697")]
        public async Task EditMeetingAsyncShouldDoNothingWithWrongMeetingId(string meetingId)
        {
            var model = new FormMeetingViewModel()
            {
                Title = "test meeting [edited]",
                Address = "Bulgaria, Kazanlak [edited]",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(3),
            };

            await meetingService.EditMeetingAsync(meetingId, model);

            var expectedResult = await repo.All<Meeting>()
                .FirstOrDefaultAsync(m => m.Id == meetingId);

            Assert.That(expectedResult, Is.Null);
        }

        [Test]
        public async Task GetMeetingsCountAsyncShouldReturnCorrectResult()
        {
            var result = await meetingService.GetMeetingsCountAsync();

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public async Task GetAllCompanyMeetingsForDayAsyncShouldReturnCorrectResult()
        {
            string companyId = "7493d4c1-251f-4e9a-aaba-c11d5c4da798";

            var result = await meetingService.GetAllCompanyMeetingsForDayAsync(0, companyId);

            var expectedResult = new List<MeetingViewModel>()
            {
                new MeetingViewModel
                {
                    Id = "862db3a5-4126-41e7-9ea0-7bf052215571",
                    Title = "test meeting",
                    Address = "Bulgaria, Kazanlak",
                    Day = DateTime.Now.DayOfWeek.ToString().Substring(0, 3),
                    Number = DateTime.Now.Day,
                    StartHour = "10",
                    EndHour = "13"
                }
            };

            Assert.Multiple(() =>
            {
                Assert.That(result[0].Id, Is.EqualTo(expectedResult[0].Id));
                Assert.That(result[0].Title, Is.EqualTo(expectedResult[0].Title));
                Assert.That(result[0].Address, Is.EqualTo(expectedResult[0].Address));
                Assert.That(result[0].Day, Is.EqualTo(expectedResult[0].Day));
                Assert.That(result[0].Number, Is.EqualTo(expectedResult[0].Number));

            });
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]

        public async Task GetAllCompanyMeetingsForDayAsyncShouldReturnEmptyViewModel(int days)
        {
            string companyId = "7493d4c1-251f-4e9a-aaba-c11d5c4da798";


            var result = await meetingService.GetAllCompanyMeetingsForDayAsync(days, companyId);

            var expectedResult = new List<MeetingViewModel>()
            {
                new MeetingViewModel
                {
                    Day = DateTime.Now.AddDays(days).DayOfWeek.ToString().Substring(0, 3),
                    Number = DateTime.Now.AddDays(days).Day,
                }
            };

            Assert.Multiple(() =>
            {
                Assert.That(result[0].Day, Is.EqualTo(expectedResult[0].Day));
                Assert.That(result[0].Number, Is.EqualTo(expectedResult[0].Number));

            });
        }



        [Test]
        public async Task GetAllClassMeetingsForDayAsyncShouldReturnCorrectResult()
        {
            string classId = "17cd4d78-a621-4bf3-a4a4-9d7d3af085d2";

            var result = await meetingService.GetClassMeetingsForDayAsync(0, classId);

            var expectedResult = new List<MeetingViewModel>()
            {
                new MeetingViewModel
                {
                    Id = "862db3a5-4126-41e7-9ea0-7bf052215571",
                    Title = "test meeting",
                    Address = "Bulgaria, Kazanlak",
                    Day = DateTime.Now.DayOfWeek.ToString().Substring(0, 3),
                    Number = DateTime.Now.Day,
                    StartHour = "10",
                    EndHour = "13"
                }
            };

            Assert.Multiple(() =>
            {
                Assert.That(result[0].Id, Is.EqualTo(expectedResult[0].Id));
                Assert.That(result[0].Title, Is.EqualTo(expectedResult[0].Title));
                Assert.That(result[0].Address, Is.EqualTo(expectedResult[0].Address));
                Assert.That(result[0].Day, Is.EqualTo(expectedResult[0].Day));
                Assert.That(result[0].Number, Is.EqualTo(expectedResult[0].Number));

            });
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public async Task GetAllClassMeetingsForDayAsyncShouldReturnEmptyViewModel(int days)
        {
            string classId = "17cd4d78-a621-4bf3-a4a4-9d7d3af085d2";

            var result = await meetingService.GetClassMeetingsForDayAsync(days, classId);

            var expectedResult = new List<MeetingViewModel>()
            {
                new MeetingViewModel
                {
                    
                    Day = DateTime.Now.AddDays(days).DayOfWeek.ToString().Substring(0, 3),
                    Number = DateTime.Now.AddDays(days).Day,
                    
                }
            };

            Assert.Multiple(() =>
            {
                
                Assert.That(result[0].Day, Is.EqualTo(expectedResult[0].Day));
                Assert.That(result[0].Number, Is.EqualTo(expectedResult[0].Number));

            });
        }

        [Test]
        public async Task IsMeetingExistsAsyncShouldReturnTrue()
        {
            string classId = "90bd5987-e991-4dfd-be1a-a57464b9d697";

            var meeting = new Meeting()
            {
                Id = "747ad88f-6c9e-402a-97dc-b9a9360adc71",
                Title = "test meeting2",
                Address = "Bulgaria, Kazanlak",
                StartTime = DateTime.UtcNow,
                EndTime = DateTime.UtcNow.AddHours(3),
                CompanyId = "7493d4c1-251f-4e9a-aaba-c11d5c4da798",
                ClassId = "90bd5987-e991-4dfd-be1a-a57464b9d697",
                Description = "test add new meeting description",
                LectorId = "724ebe11-96f9-4dfb-b255-da3041d887d5",
                IsActive = true
            };

            await repo.AddAsync(meeting);
            await repo.SaveChangesAsync();

            var result = await meetingService.IsMeetingExistsAsync(meeting.StartTime, meeting.EndTime, classId);

            Assert.That(result, Is.True);
        }


        [Test]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2")]
        [TestCase("90ba5987-e991-4dfd-be1a-a57464b9d697")]
        public async Task IsMeetingExistsAsyncShouldReturnFalse(string classId)
        {
            var result = await meetingService.IsMeetingExistsAsync(DateTime.Now, DateTime.Now, classId);

            Assert.That(result, Is.False);
        }




    }
}
