using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;
using Tesnem.Api.Data;
using Tesnem.Api.Data.Repository;
using Tesnem.Api.Domain.Auth;
using Tesnem.Api.Domain.Repository;
using Tesnem.Api.Domain.Services;
using Tesnem.Api.Middleware;
using Tesnem.Api.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
// Normal DB context + Identity context
services.AddDbContext<AppDbContext>(opt => opt.UseMySql(builder.Configuration.GetConnectionString("TesnemContext"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("TesnemContext"))));
services.AddDbContext<IdentityDbContext>(opt => opt.UseMySql(builder.Configuration.GetConnectionString("TesnemContext"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("TesnemContext"))));

// Identity
services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.Password.RequiredLength = 8;
    opt.Password.RequireDigit = false;
    opt.Password.RequireUppercase = false;

}).AddEntityFrameworkStores<IdentityDbContext>();

services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = configuration["IdentityServer"];

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
    });

services.AddAuthorization(options =>
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "ApiUser");
    })
);

// Services DI
services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
services.AddScoped<IProfessorRepository, ProfessorRepository>();
services.AddScoped<IStudentRepository, StudentRepository>();
services.AddScoped<IStudentService, StudentService>();
services.AddScoped<IEnrollmentService, EnrollmentService>();
services.AddScoped<IProfessorService, ProfessorService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers().RequireAuthorization("ApiScope");

app.Run();
