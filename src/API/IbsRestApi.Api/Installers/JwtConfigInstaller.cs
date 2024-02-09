﻿using IbsRestApi.Application.CommonModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace IbsRestApi.Api.Installers;

public class JwtConfigInstaller : IInstaller
{

    public void InstallServices(WebApplicationBuilder builder)
    {


        var jwtSettings = builder.Configuration.GetSection("JwtSettings");
        var secretKey = AppConstants.JWT_SECRET_KEY;
        builder.Services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = true;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                ValidAudience = jwtSettings.GetSection("validAudience").Value,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
            };
        });
    }
}
