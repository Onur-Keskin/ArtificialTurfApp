﻿using App.Application.Features.Cities;
using App.Application.Features.FootballFieds;
using App.Application.Features.Reservations;
using App.Application.Features.Towns;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace App.Application.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);//.Net' in kendi filter yapısını disable etmek
            
            services.AddScoped<IFootballFieldService, FootballFieldService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<ITownService, TownService>();
            services.AddScoped<ICityService, CityService>();
            //services.AddScoped<IRegisterService, RegisterService>();
            //services.AddScoped<IUserService, UserService>();

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
