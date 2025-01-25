
using API.Infrastructure.Configuration;
using API.Services;
using Common.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();
            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(new RequireHttpsAttribute());
                
            });

            builder.Services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                options.HttpsPort = 7251;
            });

            builder.WebHost.ConfigureKestrel(options =>
            {
                options.ListenLocalhost(5285); // HTTP
                options.ListenLocalhost(7251, listenOptions =>
                {
                    listenOptions.UseHttps(); // HTTPS
                });
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(opitons =>
            {
                opitons.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' followed by a space and your token."
                });

                opitons.AddSecurityRequirement(new OpenApiSecurityRequirement
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

                        new string[] {}
                    }
                });
            }
            );

            builder.Services.AddDbContext<BrawlstarsHelperDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("API")
                )
            );
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            var jwtSecretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY")
                       ?? throw new InvalidOperationException("Environment variable 'JWT_SECRET_KEY' is not set.");


            // Bind Jwt section from appsettings.json to JwtSettings
            builder.Services.Configure<JwtSettings>(options =>
            {
                builder.Configuration.GetSection("Jwt").Bind(options);
                options.Key = jwtSecretKey;
            });

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey));

            // Register JwtSettings as a singleton for direct access
            builder.Services.AddSingleton(key);


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = key
                };
            });

            builder.Services.AddScoped<TokenService>();
            builder.Services.AddScoped<IPasswordHasher, BcryptPasswordHasher>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("AllowAll");
            app.MapControllers();

            app.Run();
        }
    }
}
