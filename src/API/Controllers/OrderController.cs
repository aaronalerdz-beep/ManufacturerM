using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IGenericRepository<Production_order> repo, IOrderStatsService _statsService)  
        : BaseApiController
    {
         
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Production_order>>> GetOrder([FromQuery]SpecParams specParams)
        {
            var spec = new ORderSoecification(specParams);
            return await CreatePagedResult(repo, spec, specParams.PageIndex,specParams.PageSize);
        
        }
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Production_order>> GetOrders(int id)
        {
            var parts = await repo.GetByIdAsync(id);
            if(parts == null) return NotFound();
            return parts;
        }

        [HttpPost] 
        public async Task<ActionResult<Production_order>> CreatOrder(ProductionOrderDto dto) {
             var order = new Production_order 
             { 
                PartIdSeq = dto.PartId,
                target_quantity = dto.Quantity,
                started_time = DateTime.UtcNow,
                status = "Created"
             };
              repo.Add(order); 
              if (await repo.SaveAllAsync()) 
              { 
                return CreatedAtAction("GetOrder", new { id = order.IdSeq }, order);
               } 
               return BadRequest("Bad Request"); 
        }
        
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateOrder(int id, Production_order order)
        {
            if(order.IdSeq != id || !OrderExists(id))
                return BadRequest("Bad Request");

            repo.Update(order);
            if(await repo.SaveAllAsync())
           {
                return NoContent();
           }

            return BadRequest("Problem Update");
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletedOrder(int id)
        {
            var order = await repo.GetByIdAsync(id);

            if(order == null) return NotFound();

            repo.Remove(order);

            if(await repo.SaveAllAsync())
           {
                return NoContent();
           }

            return BadRequest("Problem delete");
        }
        private bool OrderExists(int id)
        {
            return repo.Exists(id);
        }
    
        [HttpGet("stats/monthly")]
        public async Task<ActionResult> GetMonthlyStats()
        {
            var result = await _statsService.GetMonthlyStats();
            return Ok(result);
        }
        [HttpGet("count/parts")]
        public async Task<ActionResult> GetCount()
        {
            var result = await _statsService.GetPartStats();
            return Ok(result);
        }
        [HttpGet("status/created")]
        public async Task<ActionResult> GetCreatedOrders()
        {
            var result = await _statsService.GetStatusCreated();
            return Ok(result);
        }
        [HttpPut("{id:int}/status")]
        public async Task<ActionResult> UpdateStatusOrder(int id, UpdateOrderStatusDto dto)
        {
            var order = await repo.GetByIdAsync(id); 
            Console.WriteLine($"ID: {id}, Status: {dto.Status}, Qty: {dto.final_quantity}");
            if (order == null) return NotFound();

            order.status = dto.Status;
            order.final_quantity = dto.final_quantity;
            order.finished_time = DateTime.UtcNow;

            if (await repo.SaveAllAsync())
                return Ok(order);

            return BadRequest("Problem updating status");
        }
    }
}
