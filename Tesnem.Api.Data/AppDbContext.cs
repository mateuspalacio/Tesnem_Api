using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Auth;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<PastCourses> PastCourses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<ProgramMajor> Majors { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
    }
}
