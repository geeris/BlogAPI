using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DataAccess.Configuration
{
    public class UserConfiguration : EntityConfiguration<User>
    {
        protected override void ConfigureRules(EntityTypeBuilder<User> builder)
        {
            builder.HasAlternateKey(x => x.Username);
            builder.Property(x => x.Username).IsRequired().HasMaxLength(40);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Email).IsRequired();

            builder.Property(x => x.Password).IsRequired();

            builder.HasMany(u => u.Posts).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Comments).WithOne(c => c.User).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.UseCases).WithOne(uc => uc.User).HasForeignKey(uc => uc.UserId);
        }
    }
}
