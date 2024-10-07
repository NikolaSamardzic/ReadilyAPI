using FluentAssertions.Common;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using NuGet.Protocol.Resources;
using ReadilyAPI.API.DTO.Configuration;
using ReadilyAPI.API.Extensions;
using ReadilyAPI.API.Jwt;
using ReadilyAPI.API.Jwt.TokenStorage;
using ReadilyAPI.API.Middleware;
using ReadilyAPI.Application.Logging;
using ReadilyAPI.Application.Notification;
using ReadilyAPI.Application.Uploads;
using ReadilyAPI.Application.UseCaseHandling;
using ReadilyAPI.Application.UseCaseHandling.Command;
using ReadilyAPI.Application.UseCaseHandling.Query;
using ReadilyAPI.Application.UseCases.Commands.Categories;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Implementation;
using ReadilyAPI.Implementation.Logging;
using ReadilyAPI.Implementation.Uploads;
using ReadilyAPI.Implementation.UseCases;
using ReadilyAPI.Implementation.UseCases.Commands;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Add Security Definition for JWT Bearer
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\""
    });

    // Add Security Requirement
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
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
    }});
});

builder.Services.AddTransient<ReadilyContext>();
builder.Services.AddAutoMapper(typeof(UseCaseInfo).Assembly);

var appSettings = new AppSettings();
builder.Configuration.Bind(appSettings);
var smtpSettings = new SmtpSettings();
builder.Configuration.Bind(smtpSettings);

builder.Services.AddTransient<ITokenStorage,InMemoryTokenStorage>();
builder.Services.AddTransient<JwtManager>(x =>
{
    var context = x.GetService<ReadilyContext>();
    var tokenStorage = x.GetService<ITokenStorage>();
    return new JwtManager(context, appSettings.Jwt.Issuer, appSettings.Jwt.DurationSeconds,   tokenStorage, appSettings.Jwt.SecretKey);
});
builder.Services.AddTransient<IBase64FileUploader, Base64FileUploader>();
builder.Services.AddScoped<IUseCaseLogger, EfUseCaseLogger>();

// Extension methods
builder.Services.AddActorProvider();
builder.Services.AddCommandHandler();
builder.Services.AddQueryHandler();
builder.Services.AddCommands();
builder.Services.AddQueries();
builder.Services.AddValidators();
builder.Services.AddLogger();
builder.Services.AddNotification(appSettings);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
