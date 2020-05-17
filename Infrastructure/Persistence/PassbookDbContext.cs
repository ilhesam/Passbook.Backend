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
        public DbSet<UserJwtToken> UserJwtTokens { get; set; }

        public PassbookDbContext(DbContextOptions<PassbookDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder?.ApplyConfiguration<UserJwtToken>(new UserJwtTokenConfiguration());

            modelBuilder?.ApplyConfiguration<AppUser>(new AppUserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
