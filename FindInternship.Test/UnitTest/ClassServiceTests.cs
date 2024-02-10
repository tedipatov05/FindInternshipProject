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
using FindInternship.Core.Models.Class;
using FindInternship.Core.Models;
using FindInternship.Data.Models;
using FindInternship.Data.Models.Enums;
using System.Globalization;
using FindInternship.Core.Models.Student;

namespace FindInternship.Test.UnitTest
{
    [TestFixture]
    public class ClassServiceTests
    {
        private DbContextOptions<FindInternshipDbContext> dbOptions;
        private FindInternshipDbContext dbContext;
        private IRepository repo;
        private IClassService classService;

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
            this.classService = new ClassService(this.repo);

        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task AllClassesAsyncShouldReturnCorrectResult()
        {
            var result = await classService.AllClassesAsync();

            var expectedResult = new List<AllClassesViewModel>()
            {
                new AllClassesViewModel()
                {
                    Id = "90bd5987-e991-4dfd-be1a-a57464b9d697",
                    Name = "12 Б",
                    School = "ППМГ Никола Обрешков"
                }
            };

            Assert.That(expectedResult[0].Id, Is.EqualTo(result[0].Id));
            Assert.That(expectedResult[0].School, Is.EqualTo(result[0].School));
            Assert.That(expectedResult[0].Name, Is.EqualTo(result[0].Name));
        }

        [Test]
        public async Task GetClassIdByStudentUserIdAsyncShouldReturnCorrectResult()
        {
            string studentUserId = "bae65efa-6885-4144-9786-0719b0e2ebc4";

            var result = await classService.GetClassIdByStudentUserIdAsync(studentUserId);

            string expected = "90bd5987-e991-4dfd-be1a-a57464b9d697";

            Assert.That(result, Is.EqualTo(expected));

        }

        [Test]
        [TestCase("28a172eb-6e0d-43ed-9a42-fb28025e1659")]
        [TestCase("eb8fc718-655e-4d32-9a0a-d905fa3956e7")]
        public async Task GetClassIdByStudentUserIdAsyncShouldReturnNull(string studentUserId)
        {
            var result = await classService.GetClassIdByStudentUserIdAsync(studentUserId);

            Assert.That(result, Is.Null);

        }

        [Test]
        public async Task GetClassIdByTeacherUserIdAsyncShouldReturnCorrectResult()
        {
            string teacherUserId = "28a172eb-6e0d-43ed-9a42-fb28025e1659";

            var result = await classService.GetClassIdByTeacherUserIdAsync(teacherUserId);

            string expected = "90bd5987-e991-4dfd-be1a-a57464b9d697";

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2")]
        [TestCase("90bd5987-e991-4dfd-be1a-a57464b9d697")]
        public async Task GetClassIdByTeacherUserIdAsyncShouldReturnNull(string teacherUserId)
        {
            var result = await classService.GetClassIdByTeacherUserIdAsync(teacherUserId);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetClassIdsByCompanyUserIdAsyncShouldReturnCorrectResult()
        {
            string companyUserId = "eb8fc718-655e-4d32-9a0a-d905fa3956e7";

            var result = await classService.GetClassIdsByCompanyUserIdAsync(companyUserId);

            var expected = new List<string>() { "90bd5987-e991-4dfd-be1a-a57464b9d697" };

            CollectionAssert.AreEquivalent(expected, result);

        }

        [Test]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2")]
        [TestCase("90bd5987-e991-4dfd-be1a-a57464b9d697")]
        public async Task GetClassIdsByCompanyUserIdAsyncShouldReturnEmptyCollection(string companyUserId)
        {
            var result = await classService.GetClassIdsByCompanyUserIdAsync(companyUserId);

            CollectionAssert.IsEmpty(result);


        }

        [Test]
        public async Task GetAllCompanyClassesAsyncShouldReturnCorrectResult()
        {
            string companyId = "7493d4c1-251f-4e9a-aaba-c11d5c4da798";

            var result = await classService.GetAllCompanyClassesAsync(companyId);

            var expected = new List<ClassViewModel>()
            {
                new ClassViewModel()
                {
                    Id = "90bd5987-e991-4dfd-be1a-a57464b9d697",
                    Name = "12 Б",
                    School = "ППМГ Никола Обрешков",
                    Teacher = "Учител Учителов",
                    Students = 1,
                    TeacherId = "28a172eb-6e0d-43ed-9a42-fb28025e1659"
                }
            };


            Assert.Multiple(() =>
            {
                Assert.That(result[0].Id, Is.EqualTo(expected[0].Id));
                Assert.That(result[0].Name, Is.EqualTo(expected[0].Name));
                Assert.That(result[0].School, Is.EqualTo(expected[0].School));
                Assert.That(result[0].Teacher, Is.EqualTo(expected[0].Teacher));
                Assert.That(result[0].Students, Is.EqualTo(expected[0].Students));
            });

        }

        [Test]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2")]
        [TestCase("90bd5987-e991-4dfd-be1a-a57464b9d697")]
        public async Task GetAllCompanyClassesAsyncShouldReturnEmptyCollection(string companyId)
        {
            var result = await classService.GetAllCompanyClassesAsync(companyId);

            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public async Task CreateAsyncShouldCreateNewClass()
        {
            string className = "12 В";
            string speciality = "Метематика и информатика";
            int schoolId = 1;

            await classService.CreateAsync(className, speciality, schoolId);

            var isExists = await repo.All<Class>().AnyAsync(x => x.Grade == className);

            Assert.That(isExists, Is.True);
        }

        [Test]
        public async Task GetClassIdShouldReturnCorrectResult()
        {
            string requestId = "bf13bfe6-b1be-4dc8-b8e8-2a0e3ff2af4a";

            var result = await classService.GetClassIdAsync(requestId);

            string expected = "90bd5987-e991-4dfd-be1a-a57464b9d697";

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("90bd5987-e991-4dfd-be1a-a57464b9d697")]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2")]
        [TestCase("28a172eb-6e0d-43ed-9a42-fb28025e1659")]
        public async Task GetClassIdShouldReturnCorrectResult(string requestId)
        {

            var result = await classService.GetClassIdAsync(requestId);

            Assert.That(result, Is.Null);
        }

        [Test]
        [TestCase("12б", "ППМГ Никола Обрешков")]
        [TestCase("12 б", "ППМГНикола обрешков")]
        [TestCase("12 Б", "ППМГ НиколаОбрешков")]
        public void GetClassIdIfExistsAsyncShouldReturnCorrectResult(string className, string school)
        {
            var result = classService.GetClassIdIfExistsAsync(className, school);

            string expected = "90bd5987-e991-4dfd-be1a-a57464b9d697";

            Assert.That(result, Is.EqualTo(expected));

        }
        [Test]
        [TestCase("12я", "ППгд Никола Обрешков")]
        [TestCase("12 а", "ОУ Георги Кирков")]
        [TestCase("12 а", "ППМГ НиколаОбрешков")]
        public void GetClassIdIfExistsAsyncShouldReturnNull(string className, string school)
        {
            var result = classService.GetClassIdIfExistsAsync(className, school);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task UpdateAsyncShouldUpdateClassTeacher()
        {
            string classId = "90bd5987-e991-4dfd-be1a-a57464b9d697";

            await repo.AddAsync<Teacher>(new Teacher()
            {
                Id = "4c6fb0f5-bfb9-43c6-935a-11132042eb26",
                User = new User()
                {

                    Id = "608924f2-e51d-4686-b1eb-1f33b5dd6aa7",
                    UserName = "newTeacher",
                    NormalizedUserName = "NEWTEACHER",
                    Email = "newTeacher@abv.bg",
                    NormalizedEmail = "NEWTEACHER@ABV.BG",
                    PhoneNumber = "0887654521",
                    Name = "Нов Учител",
                    City = "Казанлък",
                    Country = "България",
                    Address = "ул. Ал. Стамболийски 28 ет.2 ап.8",
                    Gender = Gender.Мъж.ToString(),
                    RegisteredOn = DateTime.UtcNow,
                    BirthDate = DateTime.ParseExact("1978-02-08 11:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                    ProfilePictureUrl = null,
                    IsApproved = false,
                    IsActive = true
                }
            });

            await classService.UpdateAsync(classId, "4c6fb0f5-bfb9-43c6-935a-11132042eb26");

            var result = await repo.All<Class>()
                .FirstOrDefaultAsync(x => x.Id == classId);

            Assert.That(result!.TeacherId, Is.EqualTo("4c6fb0f5-bfb9-43c6-935a-11132042eb26"));

        }

        [Test]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2")]
        [TestCase("28a172eb-6e0d-43ed-9a42-fb28025e1659")]
        [TestCase("608924f2-e51d-4686-b1eb-1f33b5dd6aa7")]
        public async Task UpdateAsyncShouldDoNothingWithWrongClassId(string classId)
        {
            await classService.UpdateAsync(classId, "4c6fb0f5-bfb9-43c6-935a-11132042eb26");

            var result = await repo.All<Class>()
               .FirstOrDefaultAsync(x => x.Id == classId);

            Assert.That(result, Is.Null);
        }

        [Test]
        [TestCase("12б", "ППМГ Никола Обрешков")]
        [TestCase("12 б", "ППМГНикола обрешков")]
        [TestCase("12 Б", "ППМГ НиколаОбрешков")]
        public void ExistsClassByNameAndSchoolAsyncShouldReturnTrue(string className, string school)
        {
            var result = classService.ExistsClassByNameAndSchoolAsync(className, school);

            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase("12я", "ППгд Никола Обрешков")]
        [TestCase("12 а", "ОУ Георги Кирков")]
        [TestCase("12 а", "ППМГ НиколаОбрешков")]
        public void ExistsClassByNameAndSchoolAsyncShouldReturnFalse(string className, string school)
        {
            var result = classService.ExistsClassByNameAndSchoolAsync(className, school);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task GetClassIdByClassNameAsyncShouldReturnCorrectResult()
        {
            string className = "12 Б";
            string school = "ППМГ Никола Обрешков";

            var result = await classService.GetClassIdByClassNameAsync(className, school);

            string expected = "90bd5987-e991-4dfd-be1a-a57464b9d697";

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("12я", "ППгд Никола Обрешков")]
        [TestCase("12 а", "ОУ Георги Кирков")]
        [TestCase("12 а", "ППМГ НиколаОбрешков")]
        public async Task GetClassIdByClassNameAsyncShouldReturnNull(string className, string school)
        {
            var result = await classService.GetClassIdByClassNameAsync(className, school);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetClassMeetingAsyncShouldReturnCorrectResult()
        {
            string companyId = "7493d4c1-251f-4e9a-aaba-c11d5c4da798";

            var result = await classService.GetClassMeetingAsync(companyId);

            var expected = new List<ClassMeetingViewModel>()
            {
                new ClassMeetingViewModel()
                {
                    Grade = "12 Б",
                    Id = "90bd5987-e991-4dfd-be1a-a57464b9d697",
                    School = "ППМГ Никола Обрешков"
                }

            };

            Assert.Multiple(() =>
            {
                Assert.That(result[0].Grade, Is.EqualTo(expected[0].Grade));
                Assert.That(result[0].Id, Is.EqualTo(expected[0].Id));
                Assert.That(result[0].School, Is.EqualTo(expected[0].School));
            });
        }

        [Test]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2")]
        [TestCase("28a172eb-6e0d-43ed-9a42-fb28025e1659")]
        [TestCase("608924f2-e51d-4686-b1eb-1f33b5dd6aa7")]
        public async Task GetClassMeetingAsyncShouldReturnEmptyCollection(string companyId)
        {
            var result = await classService.GetClassMeetingAsync(companyId);


            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public async Task GetAllClassesAsyncShouldReturnCorrectResult()
        {
            var result = await classService.GetAllClassesAsync();

            var expected = new List<ClassViewModel>()
            {
                new ClassViewModel()
                {
                    Id = "90bd5987-e991-4dfd-be1a-a57464b9d697",
                    Name = "12 Б",
                    School = "ППМГ Никола Обрешков",
                    Teacher = "Учител Учителов",
                    Students = 1,
                    TeacherId = "28a172eb-6e0d-43ed-9a42-fb28025e1659"
                }
            };


            CollectionAssert.IsNotEmpty(result);

            Assert.Multiple(() =>
            {
                Assert.That(result[0].Id, Is.EqualTo(expected[0].Id));
                Assert.That(result[0].Name, Is.EqualTo(expected[0].Name));
                Assert.That(result[0].School, Is.EqualTo(expected[0].School));
                Assert.That(result[0].Teacher, Is.EqualTo(expected[0].Teacher));
                Assert.That(result[0].TeacherId, Is.EqualTo(expected[0].TeacherId));

            });

        }

        [Test]
        public async Task GetClassStudentsAsyncShouldReturnCorrectResult()
        {
            string classId = "90bd5987-e991-4dfd-be1a-a57464b9d697";

            var result = await classService.GetClassStudentsAsync(classId);

            var expected = new List<StudentViewModel>()
            {
                new StudentViewModel()
                {
                    Id = "bae65efa-6885-4144-9786-0719b0e2ebc4",
                    ProfilePictureUrl = null,
                    Name = "Студент Студентов",
                    Abilities = new List<string>() { "C#", "JS", "ASP.NET" }
                }
            };

            CollectionAssert.IsNotEmpty(result);
            Assert.Multiple(() =>
            {
                Assert.That(result[0].Id, Is.EqualTo(expected[0].Id));
                Assert.That(result[0].Name, Is.EqualTo(expected[0].Name));
                CollectionAssert.AreEquivalent(result[0].Abilities, expected[0].Abilities);

            });
        }

        [Test]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2")]
        [TestCase("28a172eb-6e0d-43ed-9a42-fb28025e1659")]
        [TestCase("608924f2-e51d-4686-b1eb-1f33b5dd6aa7")]
        public async Task GetClassStudentsAsyncShouldReturnEmptyCollection(string classId)
        {
            var result = await classService.GetClassStudentsAsync(classId);

            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public async Task IsClassExistsByIdAsyncShouldReturnTrue()
        {
            string classId = "90bd5987-e991-4dfd-be1a-a57464b9d697";

            var result = await classService.IsClassExistsByIdAsync(classId);

            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase("17cd4d78-a621-4bf3-a4a4-9d7d3af085d2")]
        [TestCase("28a172eb-6e0d-43ed-9a42-fb28025e1659")]
        [TestCase("608924f2-e51d-4686-b1eb-1f33b5dd6aa7")]
        public async Task IsClassExistsByIdAsyncShouldReturnFalse(string classId)
        {
            var result = await classService.IsClassExistsByIdAsync(classId);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task DeleteAsyncShouldDeleteClass()
        {
            string classId = "90bd5987-e991-4dfd-be1a-a57464b9d697";

            await classService.DeleteAsync(classId);

            var isExists = await repo.All<Class>()
                .AnyAsync(c => c.Id == classId);

            Assert.That(isExists, Is.False);

        }

        [Test]
        public async Task DeleteAsyncShouldDeleteStudents()
        {
            string classId = "90bd5987-e991-4dfd-be1a-a57464b9d697";

            await classService.DeleteAsync(classId);

            var isExists = await repo.All<Student>()
                .Include(s => s.User)
                .AnyAsync(s => s.ClassId == classId && s.User.IsActive);

            Assert.That(isExists, Is.False);

        }

        [Test]
        public async Task DeleteAsyncShouldDeleteTeacher()
        {
            string classId = "90bd5987-e991-4dfd-be1a-a57464b9d697";

            await classService.DeleteAsync(classId);

            var isExists = await repo.All<Teacher>()
                .Include(t => t.User)
                .AnyAsync(t => t.ClassId == classId && t.User.IsActive);

            Assert.That(isExists, Is.False);

        }
        [Test]
        public async Task DeleteAsyncShouldDeleteClassFromCompany()
        {
            string classId = "90bd5987-e991-4dfd-be1a-a57464b9d697";

            await classService.DeleteAsync(classId);

            var isExists = await repo.All<Company>()
                .Include(c => c.User)
                .Include(c => c.Classes)
                .AnyAsync(c => c.Classes.Any(c => c.Id == classId) && c.User.IsActive);

            Assert.That(isExists, Is.False);

        }


    }
}
