using JustCook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JustCook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesAPIController : ControllerBase
    {
        
        private readonly RecipesDbContext _context;

        public RecipesAPIController(RecipesDbContext context)
        {
            _context = context;
        }


        // get all recipes
        [HttpGet]
        public async Task<IActionResult> GetRecipes()
        {
            var recipes = await _context.Recipes.Include(r => r.User).ToListAsync();
            return Ok(recipes);
        }


        //get a recipe by a specific id 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipeById(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }


        //Add a new recipe
        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe([FromBody] Recipe recipe)
        {
            if (recipe == null)
            {
                return BadRequest();
            }

            
            recipe.CreatedAt = DateTime.UtcNow;

            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecipeById), new { id = recipe.RecipeId }, recipe);
        }


        //update an exisiting recipe
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(int id, [FromBody] Recipe updatedRecipe)
        {
            if (id != updatedRecipe.RecipeId)
            {
                return BadRequest("Recipe ID mismatch.");
            }

            var existingRecipe = await _context.Recipes.FindAsync(id);
            if (existingRecipe == null)
            {
                return NotFound();
            }

            // Update only fields that should change
            existingRecipe.Title = updatedRecipe.Title;
            existingRecipe.Description = updatedRecipe.Description;
            existingRecipe.ImageUrl = updatedRecipe.ImageUrl;
            existingRecipe.UserId = updatedRecipe.UserId;
            

            await _context.SaveChangesAsync();

            return NoContent();
        }



        // delete a recipe
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();

            return NoContent(); // 204 Success
        }



    }
}
