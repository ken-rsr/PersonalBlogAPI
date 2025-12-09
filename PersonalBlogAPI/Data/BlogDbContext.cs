using Microsoft.EntityFrameworkCore;
using PersonalBlogAPI.Model;

namespace PersonalBlogAPI.Data
{
    public class BlogDbContext(DbContextOptions<BlogDbContext> options): DbContext(options)
    {
        public DbSet<Blog> Blogs => Set<Blog>();
    }
}
