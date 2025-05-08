using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AntiAge.Data;
using AntiAge.Data.Entities;
using AntiAge.Controllers.Dto;

namespace AntiAge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthGoalsController : ControllerBase
    {
        private readonly AntiAgeContext _context;

        public HealthGoalsController(AntiAgeContext context)
        {
            _context = context;
        }

        
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<HealthGoal>>> GetHealthGoalsByUser(int userId)
        {
            var healthGoals = await _context.HealthGoals
                .Where(hg => hg.UserId == userId)
                .ToListAsync();

            if (healthGoals == null || !healthGoals.Any())
            {
                return NotFound();
            }

            return healthGoals;
        }

        [HttpGet("{userId}/{goalId}")]
        public async Task<ActionResult<HealthGoal>> GetSpecificHealthGoal(int userId, int goalId)
        {
            var healthGoal = await _context.HealthGoals
                .FirstOrDefaultAsync(h => h.UserId == userId && h.GoalId == goalId);

            if (healthGoal == null)
            {
                return NotFound();
            }

            return healthGoal;
        }


        [HttpPost()]
        public async Task<ActionResult<HealthGoalDto>> PostHealthGoal(HealthGoalDto dto)
        {
            var healthGoal = new HealthGoal
            {
                UserId = dto.UserId,
                GoalType = dto.GoalType,
                TargetValue = dto.TargetValue,
                StartDate = dto.StartDate,
                TargetDate = dto.TargetDate,
                Status = dto.Status,
                Notes = dto.Notes
            };
            
            _context.HealthGoals.Add(healthGoal);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSpecificHealthGoal),
                           new { userId = healthGoal.UserId, goalId = healthGoal.GoalId },
                           healthGoal);
        }


        [HttpDelete("{userId}/{goalId}")]
        public async Task<IActionResult> DeleteHealthGoal(int userId, int goalId)
        {
            var healthGoal = await _context.HealthGoals
                .FirstOrDefaultAsync(hg => hg.UserId == userId && hg.GoalId == goalId);

            if (healthGoal == null)
            {
                return NotFound();
            }

            _context.HealthGoals.Remove(healthGoal);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}