
using mariamikhailovakt_42_20.Interfaces;

namespace mariamikhailovakt_42_20.ServiceInterfaces
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ILessonsService, LessonService>();

            return services;
        }
    }
}