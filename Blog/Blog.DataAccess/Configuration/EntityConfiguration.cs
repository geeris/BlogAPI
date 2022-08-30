using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DataAccess.Configuration
{
    public abstract class EntityConfiguration<EntityT> : IEntityTypeConfiguration<EntityT>
        where EntityT : Entity
    {
        public void Configure(EntityTypeBuilder<EntityT> builder)
        {
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.DeletedBy).HasMaxLength(40);

            builder.Property(x => x.ModifiedBy).HasMaxLength(40);

            builder.Property(x => x.IsActive).HasDefaultValue(true);

            ConfigureRules(builder);
        }

        protected abstract void ConfigureRules(EntityTypeBuilder<EntityT> builder);
    }
}
