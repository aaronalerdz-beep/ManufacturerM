using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private readonly MContext context;
        public PartsController(MContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parts>>> GetParts()
        {
            return await context.Parts.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Parts>> GetParts(int id)
        {
            var parts = await context.Parts.FindAsync(id);
            if(parts == null) return NotFound();
            return parts;
        }

        [HttpPost]
        public async Task<ActionResult<Parts>> CreatPart(Parts parts)
        {
            context.Parts.Add(parts);

            await context.SaveChangesAsync();

            return parts;
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdatePart(int id, Parts part)
        {
            if(part.IdSeq != id || !PartExists(id))
                return BadRequest("Bad Request");

            context.Entry(part).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }
        public async Task<ActionResult> DeletedPart(int id)
        {
            var part = await context.Parts.FindAsync(id);

            if(part == null) return NotFound();

            context.Parts.Remove(part);
            await context.SaveChangesAsync();

            return NoContent();
        }


        private bool PartExists(int id)
        {
            return context.Parts.Any(x => x.IdSeq == id);
        }
    }
}
