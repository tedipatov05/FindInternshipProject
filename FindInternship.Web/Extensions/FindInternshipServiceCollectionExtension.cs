using FindInternship.Core.Contracts;
using FindInternship.Core.Services;
using FindInternship.Data.Repository;

namespace FindInternship.Web.Extensions
{
    public static class FindInternshipServiceCollectionExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<ISchoolService, SchoolService>();
            services.AddScoped<IStatisticService, StatisticService>();
            services.AddScoped<IUserService, UserService>();  
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IAbilityService, AbilityService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IMeetingService, MeetingService>();
            services.AddScoped<IGroupService, GroupService>();

            return services;

        }
    }
}
