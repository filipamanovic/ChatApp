using DataAccess.Configurations;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Context : IdentityDbContext<User, Role, int>
    {
        public DbSet<Message> Messages { get; set; }

        public Context(DbContextOptions<Context> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new MessageConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
