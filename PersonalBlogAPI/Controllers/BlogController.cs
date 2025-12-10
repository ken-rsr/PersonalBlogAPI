using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalBlogAPI.Data;
using PersonalBlogAPI.Model;

namespace PersonalBlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlogDbContext _context;

        public BlogController(BlogDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Blog>>> GetBlogs()
        {
            return Ok(await _context.Blogs.ToListAsync());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlogById(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog is null)
                return NotFound();

            return Ok(blog);
        }

        [HttpPost]
        public async Task<ActionResult<Blog>> AddBlog(Blog newBlog)
        {
            if (newBlog is null)
            {
                return BadRequest();
            }

            _context.Blogs.Add(newBlog);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBlogById), new { id = newBlog.Id }, newBlog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlog(int id, Blog updatedBlog)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog is null)
                return NotFound();

            blog.Title = updatedBlog.Title;
            blog.Content = updatedBlog.Content;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog is null)
                return NotFound();

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
