 using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using UndyingWorld.Web.Api.Jwt;
using UndyingWorld.Web.Api.Middlewares;
using UndyingWorld.Web.Services.Data;
using UndyingWorld.Web.Services.Impl.Data;

namespace UndyingWorld.Web.Api;

public class Program
{

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration.AddYamlFile("appsettings.yml", optional: true);

        builder.Configuration.AddEnvironmentVariables();

        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
            o.SaveToken = true;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = bool.Parse(builder.Configuration["JWT:ValidateIssuer"]),
                ValidateAudience = bool.Parse(builder.Configuration["JWT:ValidateAudience"]),
                ValidateLifetime = bool.Parse(builder.Configuration["JWT:ValidateLifetime"]),
                ValidateIssuerSigningKey = bool.Parse(builder.Configuration["JWT:ValidateIssuerSigningKey"]),
                ValidIssuer = builder.Configuration["JWT:Issuer"],
                ValidAudience = builder.Configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Key)
            };
        });

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "UndyingWorld.Api", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme."
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
                new string[] { }
                }
            });
        });

        builder.Services.AddSingleton<IJwtManagerRepository, JwtManagerRepository>();
        
        builder.Services.AddSingleton<IPlayerService, PlayerService>();

        var connection = builder.Configuration.GetConnectionString("MySQL");

        builder.Services.AddDbContextFactory<Data.MainContext>(o => o.UseMySql(connection, ServerVersion.Parse("8.0.29-mysql")));

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseLogMiddleware();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}