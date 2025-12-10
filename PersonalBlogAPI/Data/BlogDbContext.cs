using Microsoft.EntityFrameworkCore;
using PersonalBlogAPI.Model;

namespace PersonalBlogAPI.Data
{
    public class BlogDbContext(DbContextOptions<BlogDbContext> options): DbContext(options)
    {
        public DbSet<Blog> Blogs => Set<Blog>();
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Blog>().HasData(
                new Blog
                {
                    Id = 1,
                    Title = "Introduction to C#",
                    Content = "This post explains the basics of C# programming."
                },
                new Blog
                {
                    Id = 2,
                    Title = "Working with ASP.NET",
                    Content = "Learn how to build web applications using ASP.NET."
                },
                new Blog
                {
                    Id = 3,
                    Title = "Entity Framework Core",
                    Content = "A guide to using EF Core for data access in .NET applications."
                }
            );
        }
    }
}
