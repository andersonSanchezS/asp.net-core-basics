using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAuthors.Controllers.entities;

namespace WebApiAuthors.Controllers
{
    [ApiController]
    [Route("/api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AuthorsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Author>>> Get()
        {
            return await context.Authors.Include(x => x.books).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Author Author)
        {
            context.Add(Author);
            await context.SaveChangesAsync();
            return Ok("autor creado");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Author Author, int id)
        {
            var existe = await context.Authors.AnyAsync(x => x.id == id);
            if (!existe) return NotFound("el autor con este id no existe");

            context.Update(Author);

            await context.SaveChangesAsync();

            return Ok("autor actualizado");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Authors.AnyAsync(x => x.id == id);
            if (!existe) return NotFound("el autor con este id no existe");

            context.Remove(new Author() { id = id });

            await context.SaveChangesAsync();

            return Ok("autor eliminado");
        }
    }
}
