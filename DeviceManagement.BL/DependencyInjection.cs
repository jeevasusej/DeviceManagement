using AutoMapper;
using DeviceManagement.BL.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using DeviceManagement.BL.MappingProfile;
using FluentValidation;
using DeviceManagement.BL.Modal;
using FluentValidation.AspNetCore;

namespace DeviceManagement.BL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBLDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc().AddFluentValidation(fv =>
            {
                fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            }); 
            ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;
            services.AddTransient<IValidator<RegisterModal>, RegisterModalValidator>();
            // Inject BL 
            services.AddScoped<IAuthBL, AuthBL>();
            return services;
        }
    }
}
