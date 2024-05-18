using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Repositories;
using TimeSheets.Services.Auth;
using TimeSheets.Services.Interfaces;
using TimeSheets.Services.Logic;

public static class IServiceCollectionExtension
{
    public static void AddAndConfigSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "TimeSheets", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
        });
    }

    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICustomersRepository, CustomersRepository>();
        services.AddScoped<IEmployeesRepository, EmployeesRepository>();
        services.AddScoped<IJobRepository, JobRepository>();
        services.AddScoped<IContractsRepository, ContractsRepository>();
        services.AddScoped<IInvoicesRepository, InvoicesRepository>();
        services.AddScoped<ITimeSheetRepository, TimeSheetRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }

    public static void RegisterOtherServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IManagerService, ManagerService>();
    }

    public static void ConfigureServiceAuthenticate(this IServiceCollection services, Type service, Type implementation)
    {
        services.AddScoped(service, implementation);
        services.AddCors();
        services.AddAuthentication(_ =>
        {
            _.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            _.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(_ =>
        {
            _.RequireHttpsMetadata = false;
            _.SaveToken = true;
            _.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthService.SecretCode)),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };
        });
    }
}
