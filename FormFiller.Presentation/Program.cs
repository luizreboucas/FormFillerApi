using FormFiller.Application.UseCases;
using FormFiller.Domain.Entities;
using FormFiller.Domain.Interfaces;
using FormFiller.Infrasctructure.Repositories;
using FormFiller.Infrasctructure.Utils;
using FormFiller.Presentation;
using FormFiller.Presentation.Validators;
using Microsoft.AspNetCore.Identity;

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
