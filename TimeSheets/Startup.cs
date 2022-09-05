using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Repositories;
using TimeSheets.DAL.Repositories.Context;
using TimeSheets.Services.Auth;
using TimeSheets.Services.Interfaces;
using TimeSheets.Services.Logic;

namespace TimeSheets
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<DbContextRepository>(op => op.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            ConfigureServicesRepositories(services);
            ConfigureServicesLogic(services);
            ConfigureServicesAuthenticate(services);

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

        private void ConfigureServicesAuthenticate(IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
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

        private void ConfigureServicesRepositories(IServiceCollection services)
        {
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IEmployeesRepository, EmployeesRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IContractsRepository, ContractsRepository>();
            services.AddScoped<IInvoicesRepository, InvoicesRepository>();
            services.AddScoped<ITimeSheetRepository, TimeSheetRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        private void ConfigureServicesLogic(IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IManagerService, ManagerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TimeSheets v1");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(_ => _.SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
