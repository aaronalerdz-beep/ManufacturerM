using System.Security.Cryptography.X509Certificates;
using Core.Entities;
using Core.Interfeces;
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
    public class PartsController(IPartRepository repo) : ControllerBase
    {
        
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Parts>>> GetParts(string ? material, string? sort)
        {
            return Ok(await repo.GetPartsAsync(material, sort));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Parts>> GetParts(int id)
        {
            var parts = await repo.GEtPartsByIdAsync(id);
            if(parts == null) return NotFound();
            return parts;
        }

        [HttpPost]
        public async Task<ActionResult<Parts>> CreatPart(Parts part)
        {
            
            repo.AddParts(part);

           if(await repo.SaveChangesAsync())
           {
                return CreatedAtAction("GetParts", new {id = part.IdSeq}, part);
           }

            return BadRequest("Bad Request");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdatePart(int id, Parts part)
        {
            if(part.IdSeq != id || !PartExists(id))
                return BadRequest("Bad Request");

            repo.UpdatePart(part);
            if(await repo.SaveChangesAsync())
           {
                return NoContent();
           }

            return BadRequest("Problem Update");
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletedPart(int id)
        {
            var part = await repo.GEtPartsByIdAsync(id);

            if(part == null) return NotFound();

            repo.DeletePart(part);

            if(await repo.SaveChangesAsync())
           {
                return NoContent();
           }

            return BadRequest("Problem delete");
        }

        [HttpGet("material")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetMaterial()
        {
            return Ok(await repo.GetMaterialAsync());
        }
        private bool PartExists(int id)
        {
            return repo.PartsExist(id);
        }
    }
}
