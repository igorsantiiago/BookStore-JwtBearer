﻿using BookStore.Core;
using BookStore.Infra.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookStore.Api.Extensions;

public static class BuilderExtension
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        Configuration.Database.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        Configuration.Secrets.ApiKey = builder.Configuration.GetSection("Secrets").GetValue<string>("ApiKey") ?? string.Empty;
        Configuration.Secrets.JwtPrivateKey = builder.Configuration.GetSection("Secrets").GetValue<string>("JwtPrivateKey") ?? string.Empty;
        Configuration.Secrets.PasswordSaltKey = builder.Configuration.GetSection("Secrets").GetValue<string>("PasswordSaltKey") ?? string.Empty;
    }

    public static void AddDatabase(this WebApplicationBuilder builder)
        => builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
            Configuration.Database.ConnectionString, assembly => assembly.MigrationsAssembly("BookStore.Api")));

    public static void AddJwtAuthentication(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.Secrets.JwtPrivateKey)),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        });

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", x => x.RequireRole("Admin"));
            options.AddPolicy("Employee", x => x.RequireRole("Employee"));
            options.AddPolicy("Manager", x => x.RequireRole("Manager"));
        });
    }

    public static void AddMediatr(this WebApplicationBuilder builder)
        => builder.Services.AddMediatR(options => options.RegisterServicesFromAssembly(typeof(Configuration).Assembly));
}
