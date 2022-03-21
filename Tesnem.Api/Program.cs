using Microsoft.EntityFrameworkCore;
using Tesnem.Api.Data;
using Tesnem.Api.Data.Repository;
using Tesnem.Api.Domain.Repository;
using Tesnem.Api.Domain.Services;
using Tesnem.Api.Middleware;
using Tesnem.Api.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseMySql(builder.Configuration.GetConnectionString("TesnemContext"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("TesnemContext"))));

services.AddScoped<IProfessorRepository, ProfessorRepository>();
services.AddScoped<IStudentRepository, StudentRepository>();
services.AddScoped<IStudentService, StudentService>();
services.AddScoped<IProfessorService, ProfessorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
