using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Infrastructure.Persistence.Configurations;
using Infrastructure.Persistence.Configurations.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class PassbookDbContext : IdentityDbContext
        <AppUser, AppRole, string, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        public virtual DbSet<UserJwtToken> UserJwtTokens { get; set; }

        public virtual DbSet<Password> Passwords { get; set; }

        public virtual DbSet<Message> Messages { get; set; }

        public PassbookDbContext(DbContextOptions<PassbookDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder?.ApplyConfiguration<UserJwtToken>(new UserJwtTokenConfiguration());

            modelBuilder?.ApplyConfiguration<AppUser>(new AppUserConfiguration());

            modelBuilder?.ApplyConfiguration<Password>(new PasswordConfiguration());

            modelBuilder?.ApplyConfiguration<Message>(new MessageConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
