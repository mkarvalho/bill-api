using BillReminder.Domain.Entities;
using BillReminder.Infra.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillReminder.API.Controllers
{
    [ApiController]
    [Route("v1/bills")]
    public class BillController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public async Task<ActionResult<List<Bill>>> Get(
            [FromServices] DataContext context
        )
        {
            return await context.Bills.ToListAsync();
        }

        [Route("{id:guid}")]
        [HttpGet]
        public async Task<ActionResult<Bill>> GetById(
            Guid id,
           [FromServices] DataContext context
        )
        {
            return await context.Bills.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        [Route("")]
        [HttpPost]
        public async Task<ActionResult<Bill>> Create(
           [FromBody] Bill bill,
           [FromServices] DataContext context
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            context.Bills.Add(bill);
            await context.SaveChangesAsync();

            return Ok();
        }

        [Route("{date:datetime}")]
        [HttpGet]
        public async Task<ActionResult<Bill>> GetByPeriod(
            DateTime date,
           [FromServices] DataContext context
        )
        {
            return await context.Bills.AsNoTracking().FirstOrDefaultAsync(x => x.DueDate == date);
        }

        [Route("{id:guid}")]
        [HttpPut]
        public async Task<ActionResult<Bill>> Update(
            Guid id,
           [FromBody] Bill bill,
           [FromServices] DataContext context
        )
        {
            var item = await context.Bills.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            item = bill;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            context.Entry(item).State = EntityState.Modified;
            await context.SaveChangesAsync();
    

            return Ok(item);
        }


        [Route("{id:guid}")]
        [HttpDelete]
        public async Task<ActionResult<Bill>> Delete(
            Guid id,
           [FromServices] DataContext context
        )
        {
            var item = await context.Bills.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            context.Bills.Remove(item);
            await context.SaveChangesAsync();


            return NoContent();
        }

    }
}
