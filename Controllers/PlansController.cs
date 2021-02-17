using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi1.Models;
using WebApi1.Data;

namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlansController : ControllerBase
    {
        private readonly ClientPlanContext _context;

        public PlansController(ClientPlanContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plan>>> GetPlans()
        {
            return await _context.Plans.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Plan>> GetPlan(long id)
        {
            var plan = await _context.Plans.FindAsync(id);

            if (plan == null)
            {
                return NotFound();
            }

            return plan;
        }

        [HttpPost]
        public async Task<ActionResult<Plan>> PostPlan(Plan plan)
        {
            plan.RegisterDate = DateTime.UtcNow;
            _context.Plans.Add(plan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlan", new { id = plan.Id }, plan);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlan(long id)
        {
            var plan = await _context.Plans.FindAsync(id);
            if (plan == null)
            {
                return NotFound();
            }

            _context.Plans.Remove(plan);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
