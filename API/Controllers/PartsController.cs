using API.Controllers;
using API.RequestHelpers;
using Core.Entities;
using Core.Interfeces;
using Core.Specifications;

using Microsoft.AspNetCore.Mvc;


namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController(IGenericRepository<Part> repo) : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Part>>> GetParts([FromQuery]SpecParams specParams)
        {
            var spec = new PartSpecification(specParams);
            return await CreatePagedResult(repo, spec, specParams.PageIndex,specParams.PageSize);
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
