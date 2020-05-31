using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Identity
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder?.HasMany(u => u.JwtTokens)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);

            builder?.HasMany(u => u.Passwords)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);

            builder?.HasMany(u => u.Messages)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);
        }
    }
}
