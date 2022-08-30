using Blog.DataAccess.Configuration;
using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Blog.DataAccess
{
    public class BlogContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-2EF7AAD\SQLEXPRESS;Initial Catalog=Blog;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            modelBuilder.Entity<TagPost>().HasKey(x => new { x.TagId, x.PostId });
            modelBuilder.Entity<CategoryPost>().HasKey(x => new { x.CategoryId, x.PostId });
            modelBuilder.Entity<ExceptionLog>().HasKey(x => x.Guid);
            modelBuilder.Entity<UserUseCase>().HasKey(x => new { x.UserId, x.UseCaseId });

            modelBuilder.Entity<Role>().HasData(new List<Role>{
                new Role { Id = 1, Name = "Admin"},
                new Role { Id = 2, Name = "User"}
            });

            modelBuilder.Entity<User>().HasData(new List<User>{
                new User { Id = 1, Name = "Mark", Username = "mark86", Email = "mark@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("Sifra1!"), RoleId = 2 },
                new User { Id = 2, Name = "Elenore", Username = "elenore86", Email = "elenore@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("Sifra1!"), RoleId = 2 },
                new User { Id = 3, Name = "Admin", Username = "admin", Email = "admin@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("Sifra1!"), RoleId = 1 }
            });

            modelBuilder.Entity<Category>().HasData(new List<Category>{
                new Category { Id = 1, Name = "Training"},
                new Category { Id = 2, Name = "Search Engine Optimization"},
                new Category { Id = 3, Name = "Food"},
                new Category { Id = 4, Name = "Travel"},
                new Category { Id = 5, Name = "Fashion"},
                new Category { Id = 6, Name = "Personal"},
                new Category { Id = 7, Name = "Art"},
                new Category { Id = 8, Name = "Photography"},
                new Category { Id = 9, Name = "Cookbooks"}
            });

            modelBuilder.Entity<Tag>().HasData(new List<Tag>{
                new Tag { Id = 1, Name = "Pies"},
                new Tag { Id = 2, Name = "Cookies"},
                new Tag { Id = 3, Name = "Pasta"},
                new Tag { Id = 4, Name = "Web Design"},
                new Tag { Id = 5, Name = "Software"},
                new Tag { Id = 6, Name = "Legs"},
                new Tag { Id = 7, Name = "Back"},
                new Tag { Id = 8, Name = "Siberian cat"},
                new Tag { Id = 9, Name = "Sunset"},
                new Tag { Id = 10, Name = "Sunrise"},
                new Tag { Id = 11, Name = "Cheese"},
                new Tag { Id = 12, Name = "Soft"},
            });

            modelBuilder.Entity<Post>().HasData(new List<Post> {
                new Post { Id = 1, Title = "Mom's cheese pie", Content = "In a large bowl, combine the cheeses, confectioners' sugar, cornstarch, vanilla, salt and egg mixture. Pour into prepared pastry.", UserId = 1 },
                new Post { Id = 2, Title = "Welcome to everyone", Content = "In a large bowl, combine the cheeses, confectioners' sugar, cornstarch, vanilla, salt and egg mixture. Pour into prepared pastry.", UserId = 1 },
                new Post { Id = 3, Title = "Spongebob Squarepants", Content = "In a large bowl, combine the cheeses, confectioners' sugar, cornstarch, vanilla, salt and egg mixture. Pour into prepared pastry.", UserId = 1 },
                new Post { Id = 4, Title = "New York City", Content = "In a large bowl, combine the cheeses, confectioners' sugar, cornstarch, vanilla, salt and egg mixture. Pour into prepared pastry.", UserId = 1 },
                new Post { Id = 5, Title = "Sunset behind the rock", Content = "In a large bowl, combine the cheeses, confectioners' sugar, cornstarch, vanilla, salt and egg mixture. Pour into prepared pastry.", UserId = 2 },
                new Post { Id = 6, Title = "Long live the king", Content = "In a large bowl, combine the cheeses, confectioners' sugar, cornstarch, vanilla, salt and egg mixture. Pour into prepared pastry.", UserId = 2 }
            });

            modelBuilder.Entity<Comment>().HasData(new List<Comment>
            {
                new Comment { Id = 1, Content = "Helpful", PostId = 1, UserId = 1},
                new Comment { Id = 2, Content = "Good", PostId = 1, UserId = 1},
                new Comment { Id = 3, Content = "For me too", PostId = 1, UserId = 2, ParentId = 1},
                new Comment { Id = 4, Content = "Cool!", PostId = 1, UserId = 2, ParentId = 3},
                new Comment { Id = 5, Content = "Great", PostId = 1, UserId = 2, ParentId = 2},
                new Comment { Id = 6, Content = "Ok", PostId = 1, UserId = 2},
                new Comment { Id = 7, Content = "!!", PostId = 1, UserId = 2, ParentId = 3},
                new Comment { Id = 8, Content = "Hello", PostId = 2, UserId = 2},
                new Comment { Id = 9, Content = "Share more", PostId = 2, UserId = 2},
                new Comment { Id = 10, Content = "Cool.", PostId = 2, UserId = 2, ParentId = 9},
                new Comment { Id = 11, Content = "Thanks", PostId = 5, UserId = 2},
                new Comment { Id = 12, Content = "Wonderful", PostId = 6, UserId = 2},
                new Comment { Id = 13, Content = "Saved", PostId = 6, UserId = 2},
            });

            modelBuilder.Entity<TagPost>().HasData(new List<TagPost> {
                new TagPost{ PostId = 1, TagId = 1},
                new TagPost{ PostId = 1, TagId = 2},
                new TagPost{ PostId = 1, TagId = 3},

                new TagPost{ PostId = 2, TagId = 11},
                new TagPost{ PostId = 2, TagId = 12},
                new TagPost{ PostId = 2, TagId = 9},
                new TagPost{ PostId = 3, TagId = 9},
                new TagPost{ PostId = 4, TagId = 5},
                new TagPost{ PostId = 4, TagId = 6},
                new TagPost{ PostId = 5, TagId = 7},
                new TagPost{ PostId = 6, TagId = 11},
                new TagPost{ PostId = 6, TagId = 2},
                new TagPost{ PostId = 6, TagId = 9},
                new TagPost{ PostId = 6, TagId = 10},
            });

            modelBuilder.Entity<CategoryPost>().HasData(new List<CategoryPost> {
                new CategoryPost{ PostId = 1, CategoryId = 1},
                new CategoryPost{ PostId = 1, CategoryId = 3},
                new CategoryPost{ PostId = 1, CategoryId = 4},

                new CategoryPost{ PostId = 2, CategoryId = 2},
                new CategoryPost{ PostId = 2, CategoryId = 7},
                new CategoryPost{ PostId = 3, CategoryId = 2},
                new CategoryPost{ PostId = 4, CategoryId = 9},
                new CategoryPost{ PostId = 5, CategoryId = 8},
                new CategoryPost{ PostId = 5, CategoryId = 6},
                new CategoryPost{ PostId = 6, CategoryId = 5},
                new CategoryPost{ PostId = 6, CategoryId = 1}
            });

            modelBuilder.Entity<UserUseCase>().HasData(new List<UserUseCase>
            {
                new UserUseCase{ UserId = 3, UseCaseId = 1},
                new UserUseCase{ UserId = 3, UseCaseId = 2},
                new UserUseCase{ UserId = 3, UseCaseId = 3},
                new UserUseCase{ UserId = 3, UseCaseId = 4},
                new UserUseCase{ UserId = 3, UseCaseId = 5},
                new UserUseCase{ UserId = 3, UseCaseId = 6},
                new UserUseCase{ UserId = 3, UseCaseId = 7},
                new UserUseCase{ UserId = 3, UseCaseId = 8},
                new UserUseCase{ UserId = 3, UseCaseId = 9},
                new UserUseCase{ UserId = 3, UseCaseId = 10},
                new UserUseCase{ UserId = 3, UseCaseId = 11},
                new UserUseCase{ UserId = 3, UseCaseId = 12},
                new UserUseCase{ UserId = 3, UseCaseId = 13},
                new UserUseCase{ UserId = 3, UseCaseId = 14},
                new UserUseCase{ UserId = 3, UseCaseId = 15},
                new UserUseCase{ UserId = 3, UseCaseId = 16},
                new UserUseCase{ UserId = 3, UseCaseId = 17},
                new UserUseCase{ UserId = 3, UseCaseId = 18},
                new UserUseCase{ UserId = 3, UseCaseId = 20},
                new UserUseCase{ UserId = 3, UseCaseId = 23},
                new UserUseCase{ UserId = 3, UseCaseId = 25},
                new UserUseCase{ UserId = 3, UseCaseId = 26},
                new UserUseCase{ UserId = 3, UseCaseId = 27},

                new UserUseCase{ UserId = 1, UseCaseId = 1},
                new UserUseCase{ UserId = 1, UseCaseId = 2},
                new UserUseCase{ UserId = 1, UseCaseId = 3},
                new UserUseCase{ UserId = 1, UseCaseId = 4},
                new UserUseCase{ UserId = 1, UseCaseId = 5},
                new UserUseCase{ UserId = 1, UseCaseId = 6},
                new UserUseCase{ UserId = 1, UseCaseId = 7},
                new UserUseCase{ UserId = 1, UseCaseId = 11},
                new UserUseCase{ UserId = 1, UseCaseId = 12},
                new UserUseCase{ UserId = 1, UseCaseId = 16},
                new UserUseCase{ UserId = 1, UseCaseId = 17},
                new UserUseCase{ UserId = 1, UseCaseId = 18},
                new UserUseCase{ UserId = 1, UseCaseId = 20},
                new UserUseCase{ UserId = 1, UseCaseId = 23},
                new UserUseCase{ UserId = 1, UseCaseId = 25},

                new UserUseCase{ UserId = 2, UseCaseId = 3},
                new UserUseCase{ UserId = 2, UseCaseId = 4},
                new UserUseCase{ UserId = 2, UseCaseId = 5},
                new UserUseCase{ UserId = 2, UseCaseId = 16},
                new UserUseCase{ UserId = 2, UseCaseId = 17}

            });
        }

        public override int SaveChanges()
        {

            foreach (var entry in ChangeTracker.Entries())
            { 
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.CreatedAt = DateTime.Now;
                            e.ModifiedAt = null;
                            e.ModifiedBy = null;
                            e.DeletedAt = null;
                            e.DeletedBy = null;
                            e.IsActive = true;
                            break;

                        case EntityState.Modified:
                            e.ModifiedAt = DateTime.Now;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagPost> TagPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryPost> CategoryPosts { get; set; }


        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
        public DbSet<ExceptionLog> ExceptionLogs { get; set; }


        public DbSet<UserUseCase> UserUseCases { get; set; }

    }
}
