using FormFiller.Application.UseCases;
using FormFiller.Domain.Entities;
using FormFiller.Domain.Interfaces;
using FormFiller.Infrasctructure.Repositories;
using FormFiller.Infrasctructure.Utils;
using FormFiller.Presentation;
using FormFiller.Presentation.Validators;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISchemaRepository, SchemaRepository>();
builder.Services.AddScoped<IGeneratorRepository, GeneratorRepository>();
builder.Services.AddScoped<IParamRepository, ParamRepository>();
builder.Services.AddScoped<UserUseCases>();
builder.Services.AddScoped<SchemaUseCases>();
builder.Services.AddScoped<ParamUseCases>();
builder.Services.AddScoped<LoginUseCase>();
builder.Services.AddScoped<GeneratorUseCases>();
builder.Services.AddScoped<GeneratorRepository>();
builder.Services.AddScoped<UserCreateValidator>();
builder.Services.AddScoped<UserUpdateValidator>();
builder.Services.AddScoped<SchemaCreateValidator>();
builder.Services.AddScoped<ParamCreateValidator>();
builder.Services.AddScoped<LoginValidator>();
builder.Services.AddScoped<PasswordHasher<User>>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasherImpl>();
builder.Services.ConfigureDb(builder.Configuration);
builder.Services.AddAuthentication().AddBearerToken();
builder.Services.AddAuthorization();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "apinet8", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "Token",
        In = ParameterLocation.Header,
        Description = "Token Access",
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
                         new string[] {}
                    }
                });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCors", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
