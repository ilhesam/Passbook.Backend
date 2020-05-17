using System;
using System.Collections.Generic;
using System.Text;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Common
{
    public class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder?.HasKey(e => e.Id);

            builder?.Property(e => e.CreateDateTime)
                .IsRequired();
        }
    }
}
