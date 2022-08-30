using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DataAccess.Configuration
{
    public class TagConfiguration : EntityConfiguration<Tag>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);

            builder.HasMany(t=>t.TagPosts).WithOne(tp=>tp.Tag).HasForeignKey(tp=>tp.TagId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
