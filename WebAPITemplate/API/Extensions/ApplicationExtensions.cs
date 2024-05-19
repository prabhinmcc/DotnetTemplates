using Application.Activities;
using Application.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Persistence;
using Microsoft.EntityFrameworkCore;
namespace WebAPITemplate.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
            //-----------------------Database  services
            services.AddDbContext<DataContext>(opt =>
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                opt.UseSqlite(connectionString);
            });
            //-----------------------CORS Policies  services
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy1", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
                });
            });
            //-----------------------API  services
            services.AddControllers();

            //-----------------------Logger  services
             //services.AddLogging();


            //----------------------- Add Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddLogging(logging =>
            {
                logging.AddConsole();

            });
            ////----------------------- Mediator 
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies((typeof(List.Handler).Assembly)));
            //----------------------- Add AutoMapper
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            return services;
        }
    }

}
