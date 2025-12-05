using Core.Entities;
using Core.Interfeces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CycleController(IGenericRepository<Cycle> repo)  : BaseApiController
    {
        
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Cycle>>> GetCycle([FromQuery]SpecParams specParams)
        {
            var spec = new CycleSpecification(specParams);
            return await CreatePagedResult(repo, spec, specParams.PageIndex,specParams.PageSize);

        }
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cycle>> GetCycles(int id)
        {
            var parts = await repo.GetByIdAsync(id);
            if(parts == null) return NotFound();
            return parts;
        }

        [HttpPost]
        public async Task<ActionResult<Cycle>> CreatCycle(Cycle cycle)
        {
            
            repo.Add(cycle);

           if(await repo.SaveAllAsync())
           {
                return CreatedAtAction("GetCycle", new {id = cycle.IdSeq}, cycle);
           }

            return BadRequest("Bad Request");
        }
        
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateCycle(int id, Cycle cycle)
        {
            if(cycle.IdSeq != id || !CycleExists(id))
                return BadRequest("Bad Request");

            repo.Update(cycle);
            if(await repo.SaveAllAsync())
           {
                return NoContent();
           }

            return BadRequest("Problem Update");
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletedCycle(int id)
        {
            var cycle = await repo.GetByIdAsync(id);

            if(cycle == null) return NotFound();

            repo.Remove(cycle);

            if(await repo.SaveAllAsync())
           {
                return NoContent();
           }

            return BadRequest("Problem delete");
        }
        private bool CycleExists(int id)
        {
            return repo.Exists(id);
        }
        
    }
}
