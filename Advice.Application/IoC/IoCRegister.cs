using Advice.Data.DbContext;
using Advice.Data.IUnitOfWork.Interfaces;
using Advice.Data.IUnitOfWork.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Configuration;
using System.Reflection;
using System.Text;

namespace Advice.IoC
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            AddRegisterDataContext(services, configuration);
            AddRegisterServices(services, configuration);
            AddRegisterRepositories(services);
            AddRegisterPolicies(services);

            return services;
        }

        public static IServiceCollection AddRegisterServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

          

            return services;
        }

        public static IApplicationBuilder AddRegistration(WebApplication app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

            return app;
        }

        public static IServiceCollection AddRegisterDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionStringSection = configuration.GetSection("ConnectionStrings:Advice_APIContext");

            services.Configure<ConnectionStringSettings>(connectionStringSection);
            var connectionString = connectionStringSection.Value;

            services.AddDbContext<AdviceDbContext>(options => options.UseSqlServer(connectionString: connectionString));
            services.AddTransient<IAdviceDbContext, AdviceDbContext>();

            return services;
        }

        public static IServiceCollection AddRegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISchoolRepository, SchoolRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();

            return services;
        }

        public static IServiceCollection AddRegisterPolicies(this IServiceCollection services)
        {
            // Agregando las Politicas para la autorizacion           
            return services;
        }
    }
}