using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Auth;

namespace Tesnem.Api.Data
{
    public class IdentityDbContext : IdentityDbContext<User>
    {
            public IdentityDbContext(DbContextOptions options)
            : base(options)
            {
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

    }
}
