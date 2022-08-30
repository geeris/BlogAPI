using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DataAccess.Configuration
{
    public class PostConfiguration : EntityConfiguration<Post>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Content).IsRequired().HasMaxLength(2000);

            builder.HasMany(p => p.Comments).WithOne(c => c.Post).HasForeignKey(c => c.PostId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.TagPosts).WithOne(tp => tp.Post).HasForeignKey(tp => tp.PostId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.CategoryPosts).WithOne(cp => cp.Post).HasForeignKey(cp => cp.PostId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
