using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class PasswordConfiguration : EntityConfiguration<Password>
    {
        public override void Configure(EntityTypeBuilder<Password> builder)
        {
            base.Configure(builder);

            builder?.Property(p => p.UserName)
                .HasMaxLength(256);

            builder?.Property(p => p.EmailAddress)
                .HasMaxLength(256);

            builder?.Property(p => p.PasswordHash)
                .IsRequired();

            builder?.Property(p => p.UsedIn)
                .IsRequired()
                .HasMaxLength(1000);

            builder?.HasOne(p => p.User)
                .WithMany(p => p.Passwords)
                .HasForeignKey(p => p.UserId)
                .IsRequired();
        }
    }
}
