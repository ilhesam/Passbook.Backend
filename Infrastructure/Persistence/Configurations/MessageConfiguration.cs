using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class MessageConfiguration : EntityConfiguration<Message>
    {
        public override void Configure(EntityTypeBuilder<Message> builder)
        {
            base.Configure(builder);

            builder?.Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(256);

            builder?.Property(m => m.Body)
                .IsRequired()
                .HasMaxLength(1024);

            builder?.HasOne(m => m.User)
                .WithMany(m => m.Messages)
                .HasForeignKey(m => m.UserId)
                .IsRequired();
        }
    }
}
