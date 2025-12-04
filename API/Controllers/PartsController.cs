using System.Security.Cryptography.X509Certificates;
using Core.Entities;
using Core.Interfeces;
using Core.Specifications;
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
    public class PartsController(IGenericRepository<Part> repo) : ControllerBase
    {
        
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Part>>> GetParts(string ? material, string? sort)
        {
            var spec = new PartSpecification(material, sort);

            var part = await repo.ListAsync(spec);
            return Ok(part);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Part>> GetParts(int id)
        {
            var parts = await repo.GetByIdAsync(id);
            if(parts == null) return NotFound();
            return parts;
        }

        [HttpPost]
        public async Task<ActionResult<Part>> CreatPart(Part part)
        {
            
            repo.Add(part);

           if(await repo.SaveAllAsync())
           {
                return CreatedAtAction("GetParts", new {id = part.IdSeq}, part);
           }

            return BadRequest("Bad Request");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdatePart(int id, Part part)
        {
            if(part.IdSeq != id || !PartExists(id))
                return BadRequest("Bad Request");

            repo.Update(part);
            if(await repo.SaveAllAsync())
           {
                return NoContent();
           }

            return BadRequest("Problem Update");
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletedPart(int id)
        {
            var part = await repo.GetByIdAsync(id);

            if(part == null) return NotFound();

            repo.Remove(part);

            if(await repo.SaveAllAsync())
           {
                return NoContent();
           }

            return BadRequest("Problem delete");
        }

        [HttpGet("material")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetMaterial()
        {
            var spec = new MaterialListSpecification();   
            return Ok(await repo.ListAsync(spec));
        }
        private bool PartExists(int id)
        {
            return repo.Exists(id);
        }
    }
}
