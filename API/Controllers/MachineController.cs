using Core.Entities;
using Core.Interfeces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController(IGenericRepository<Machine> repo) : BaseApiController
    {
        
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Machine>>> GetMachine([FromQuery]SpecParams specParams)
        {
            var spec = new MachineSpecification(specParams);
            return await CreatePagedResult(repo, spec, specParams.PageIndex,specParams.PageSize);
       
        }
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Machine>> GetMachines(int id)
        {
            var parts = await repo.GetByIdAsync(id);
            if(parts == null) return NotFound();
            return parts;
        }

        [HttpPost]
        public async Task<ActionResult<Machine>> CreatMachine(Machine machine)
        {
            
            repo.Add(machine);

           if(await repo.SaveAllAsync())
           {
                return CreatedAtAction("GetMachine", new {id = machine.IdSeq}, machine);
           }

            return BadRequest("Bad Request");
        }
        
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateMachine(int id, Machine machine)
        {
            if(machine.IdSeq != id || !MachineExists(id))
                return BadRequest("Bad Request");

            repo.Update(machine);
            if(await repo.SaveAllAsync())
           {
                return NoContent();
           }

            return BadRequest("Problem Update");
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletedMachine(int id)
        {
            var machine = await repo.GetByIdAsync(id);

            if(machine == null) return NotFound();

            repo.Remove(machine);

            if(await repo.SaveAllAsync())
           {
                return NoContent();
           }

            return BadRequest("Problem delete");
        }
        private bool MachineExists(int id)
        {
            return repo.Exists(id);
        }
    }
}
