using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DataAccess.Configuration
{
    public class CommentConfiguration : EntityConfiguration<Comment>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.PostId).IsRequired();

            builder.Property(x => x.UserId).IsRequired();

            builder.Property(x => x.Content).IsRequired().HasMaxLength(500);

            builder.HasMany(c => c.ChildComments).WithOne(c => c.ParentComment).HasForeignKey(c => c.ParentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
