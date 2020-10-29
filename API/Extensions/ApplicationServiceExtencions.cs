using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using API.Helpers;

namespace API.Extensions
{
    public static class ApplicationServiceExtencions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // Auth midleware
            services.AddScoped<ITokenService, TokenServices>();

            // Repository Pattern 
            services.AddScoped<IUserRepository, UserRepository>();

            // Repository Pattern 
            services.AddScoped<ILikesRepository, LikesRepository>();

            // Auto Mapper Helps to Cast the Entity on a new Interface or works as a  DTO implementation
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            // Coonect database
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            // Cloudinary 
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));

            // IPhoto
            services.AddScoped<IPhotoService, PhotoService>();

            // No se    
            services.AddScoped<LogUserActivity>();

            return services;
        }
    }
}