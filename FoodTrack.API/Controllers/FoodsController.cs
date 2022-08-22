using FoodTrack.API.Data;
using FoodTrack.API.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public FoodsController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Food>>> GetFoods()
        {
            if (_context.Foods == null)
            {
                return NotFound();
            }
            return await _context.Foods.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Food>> GetFood(int id)
        {
            if (_context.Foods == null)
            {
                return NotFound();
            }
            var food = await _context.Foods.FindAsync(id);

            if (food == null)
            {
                return NotFound();
            }

            return food;
        }

        [HttpGet("SearchByName")]
        public async Task<ActionResult<IEnumerable<Food>>> SearchByName(string name)
        {
            if (_context.Foods == null)
            {
                return NotFound();
            }
            List<Food>? result = await _context.Foods.Where(t => t.Name.ToLower().Contains(name.ToLower())).ToListAsync();

            if (result.Any())
            {
                return result;
            }

            return NotFound("No foods have name with the provided input.");
        }

        [HttpPost]
        public async Task<ActionResult<Food>> CreateFood(Food inputModel)
        {
            Food food = new()
            {
                Name = inputModel.Name,
                Price = inputModel.Price,
                Unit = inputModel.Unit,
            };

            try
            {
                _context.Foods.Add(food);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetFood", new { id = food.FoodId }, food);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }
    }
}
