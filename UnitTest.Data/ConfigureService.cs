using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnitTest.Data.Data;
using UnitTest.Data.Repositorys;

namespace UnitTest.Data
{
    public static class ConfigureService
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRepository, Repository>();
            var conn = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<PersonDbContext>(provider => provider.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                buider => buider.MigrationsAssembly(typeof(PersonDbContext).Assembly.FullName)));
            //services.AddScoped<IPersonDbContext>(provider => provider.GetRequiredService<PersonDbContext>());
            return services;
        }
    }
}


