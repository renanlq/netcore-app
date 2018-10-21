using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StoreOfBuild.Data;
using StoreOfBuild.Domain;

namespace StoreOfBuild.DI
{
    public class Bootstrap
    {
        public static void Configure(IServiceCollection services, string conn)
        {
            // Add context
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(conn));
            // Inject depedencies
            services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
            services.AddSingleton(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddSingleton(typeof(CategoryStorer));
        }
    }
}