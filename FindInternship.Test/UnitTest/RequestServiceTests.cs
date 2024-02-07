﻿using FindInternship.Core.Contracts;
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
using FindInternship.Core.Models.Request;
using FindInternship.Data.Models;
using FindInternship.Data.Models.Enums;

namespace FindInternship.Test.UnitTest
{
    [TestFixture]
    public class RequestServiceTests
    {
        private DbContextOptions<FindInternshipDbContext> dbOptions;
        private FindInternshipDbContext dbContext;
        private IRepository repo;
        private IRequestService requestService;

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

            this.requestService = new RequestService(this.repo);

        }
        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task CreateShouldCreateNewRequest()
        {
            CreateRequestModel model = new CreateRequestModel()
            {
                Topic = "Test sednig request",
                Message = "Test message to company",
                CompanyId = "7493d4c1-251f-4e9a-aaba-c11d5c4da798",
                ClassId = "90bd5987-e991-4dfd-be1a-a57464b9d697",

            };

            string requestId = await requestService.Create(model);

            var isExists = await repo.All<Request>()
                .AnyAsync(r => r.Id == requestId);

            Assert.True(isExists);
        }

        [Test]
        public async Task EditRequestStatusShouldEditStatusCorrectly()
        {
            string requestId = "bf13bfe6-b1be-4dc8-b8e8-2a0e3ff2af4a";
            string newStatus = RequestStatusEnum.Rejected.ToString();

            bool isEdited = await requestService.EditRequestStatus(newStatus, requestId);

            var request = await repo.All<Request>()
                .FirstOrDefaultAsync(r => r.Id == requestId);

            Assert.True(isEdited);

            Assert.That(request!.Status, Is.EqualTo(newStatus));

        }

        [Test]
        [TestCase("28a17b28025e1659")]
        [TestCase("eb8fc718-655e-4d32-9a0a-d905fa3956e7")]
        [TestCase("someId")]
        public async Task EditRequestStatusShouldReturnFalseWhenRequestDoesNotExists(string requestId)
        {
            
            string newStatus = RequestStatusEnum.Rejected.ToString();

            bool isEdited = await requestService.EditRequestStatus(newStatus, requestId);

            Assert.False(isEdited);

        }
        [Test]
        public async Task GetAcceptedRequestCountAsyncShouldReturnCorrectResult()
        {
            var request = new Request()
            {
                Id = Guid.NewGuid().ToString(),
                Topic = "Test request Accepted",
                ClassId = "90bd5987-e991-4dfd-be1a-a57464b9d697",
                Status = RequestStatusEnum.Accepted.ToString(),
                Message = "test message Accepted",
                CompanyId = "7493d4c1-251f-4e9a-aaba-c11d5c4da798",
                CreatedOn = DateTime.UtcNow,
            };

            await repo.AddAsync(request);
            await repo.SaveChangesAsync();

            var result = await requestService.GetAcceptedRequestCountAsync();

            int expectedCount = await repo.All<Request>()
                .Where(r => r.Status == RequestStatusEnum.Accepted.ToString())
                .CountAsync();

            Assert.That(result, Is.EqualTo(expectedCount));
        }

    }
}
