using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class UserJwtTokenConfiguration : EntityConfiguration<UserJwtToken>
    {
        public override void Configure(EntityTypeBuilder<UserJwtToken> builder)
        {
            base.Configure(builder);

            builder?.Property(u => u.AccessTokenHash)
                .IsRequired()
                .HasMaxLength(256);

            builder?.Property(u => u.AccessTokenExpiresDateTime)
                .IsRequired();

            builder?.Property(u => u.TokenPlatform)
                .IsRequired();

            builder?.HasOne(u => u.User)
                .WithMany(u => u.JwtTokens)
                .HasForeignKey(u => u.UserId)
                .IsRequired();
        }
    }
}
