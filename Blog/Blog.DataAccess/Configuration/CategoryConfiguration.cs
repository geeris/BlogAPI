using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DataAccess.Configuration
{
    public class CategoryConfiguration : EntityConfiguration<Category>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(60);

            builder.HasMany(c => c.CategoryPosts).WithOne(cp => cp.Category).HasForeignKey(cp => cp.CategoryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
