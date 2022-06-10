using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAuthors.Controllers.entities;

namespace WebApiAuthors.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController:ControllerBase
    {
        private readonly ApplicationDbContext context;

        public BooksController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<book>>> Get()
        {
            return await context.books.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<book>> Get(int id)
        {
            return await context.books.Include(x => x.Author).FirstOrDefaultAsync(x => x.id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(book book)
        {
            var authorExist = await context.Authors.AnyAsync(x => x.id == book.AuthorId);
            if (!authorExist) return BadRequest($"el autor de id { book.AuthorId } no existe");

            context.books.Add(book);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
