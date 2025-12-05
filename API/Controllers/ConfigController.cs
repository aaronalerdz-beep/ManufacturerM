using Core.Entities;
using Core.Interfeces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController(IGenericRepository<Machine_config> repo) : BaseApiController
    {
        
        
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Machine_config>>> GetConfiguration([FromQuery]SpecParams specParams)
        {
            var spec = new MachineConfigSpecification(specParams);

            var part = await repo.ListAsync(spec);
            return Ok(part);
        }
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Machine_config>> GetConfigurations(int id)
        {
            var parts = await repo.GetByIdAsync(id);
            if(parts == null) return NotFound();
            return parts;
        }

        [HttpPost]
        public async Task<ActionResult<Machine_config>> CreatConfiguration(Machine_config cofig)
        {
            
            repo.Add(cofig);

           if(await repo.SaveAllAsync())
           {
                return CreatedAtAction("GetMachine", new {id = cofig.IdSeq}, cofig);
           }

            return BadRequest("Bad Request");
        }
        
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateConfiguration(int id, Machine_config cofig)
        {
            if(cofig.IdSeq != id || !ConfigurationExists(id))
                return BadRequest("Bad Request");

            repo.Update(cofig);
            if(await repo.SaveAllAsync())
           {
                return NoContent();
           }

            return BadRequest("Problem Update");
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletedConfiguration(int id)
        {
            var config = await repo.GetByIdAsync(id);

            if(config == null) return NotFound();

            repo.Remove(config);

            if(await repo.SaveAllAsync())
           {
                return NoContent();
           }

            return BadRequest("Problem delete");
        }
        private bool ConfigurationExists(int id)
        {
            return repo.Exists(id);
        }
    }
}
