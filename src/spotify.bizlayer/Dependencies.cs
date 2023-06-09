﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using spotify.bizlayer.Mapping;
using spotify.bizlayer.Services;
using spotify.datalayer.Options;

namespace spotify.bizlayer;
public static class Dependencies
{
    public static IServiceCollection AddBizLayer(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(MappingProfiles));

        services.AddScoped<IPasswordHasher, PasswordHasher>();

        services.Configure<JwtOptions>(configuration.GetSection("JwtSettings"));
        services.AddTransient<IJwtTokenHandler, JwtTokenHandler>();

        return services;
    }
}
