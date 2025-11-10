using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Locator;
using Microsoft.EntityFrameworkCore;
using PerreteAPI.Appication.Infrastructure.Repositories;
using PerreteAPI.Application.Infrastructure;
using PerreteAPI.Application.Infrastructure.Repositories;
using PerreteAPI.Application.Infrastructure.UnitOfWork;
using PerreteAPI.Features.Perretes.Create;
using PerreteAPI.Features.Perretes.Get;
using PerreteAPI.Features.Perretes.Update;
using Wolverine;
using Wolverine.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configuracion dbContext
var connectionString = builder.Configuration.GetConnectionString("ConexionSql");

builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Perrete.API")));

//builder de Wolverine necesario al usar bus e interactuar con commands, etc.
builder.Services.AddWolverine(wolverineOptions =>
{
    wolverineOptions.Discovery.IncludeAssembly(typeof(DiscoveryType).Assembly);
});

//todo lo que introducimos en el constructor debe declararse sí o sí en este contenedor de dependencias.
builder.Services.AddScoped<IPerreteRepository, PerreteRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IValidator<CreatePerreteCommand>, CreatePerreteCommandValidator>();
builder.Services.AddScoped<IValidator<UpdatePerreteCommand>, UpdatePerreteCommandValidator>();
builder.Services.AddScoped<IValidator<GetPerreteQuery>, GetPerreteQueryValidator>();

//configuración de CORS para el front
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorDev", policy =>
    {
        policy
            .WithOrigins("https://localhost:7195")
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

app.UseCors("AllowBlazorDev");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
