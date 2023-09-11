﻿using Donace_BE_Project.EntityFramework;
using Donace_BE_Project.Interfaces;
using Donace_BE_Project.Middlewares;
using Donace_BE_Project.Services;
using EntityFramework.Repository;
using System.Diagnostics;

namespace Donace_BE_Project.Extensions
{
    public static class RegisterServies
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton<PerformanceMiddleware>();
            services.AddSingleton<Stopwatch>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}
