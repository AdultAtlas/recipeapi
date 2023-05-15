using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using RecipeAPI.Services;
using Shared.DTOs;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : Controller
    {
        private ILogger<RecipeController> _logger;
        private IRecipeService _recipeService;

        
        public RecipeController(ILogger<RecipeController> logger, IRecipeService recipeService)
        {
            _logger = logger;
            _recipeService = recipeService;
        }

        [Route("get/all")]
        [HttpGet]
        public async Task<ActionResult> GetAllRecipes()
        {
            try
            {
                _logger.LogInformation($"");

                return Ok(await _recipeService.GetAllRecipes());
            } catch (Exception ex)
            {
                _logger.LogError("");
                return BadRequest($"Could not get all recipes. Exception: {ex.Message}");
            }
        }

        [Route("get/{id?}")]
        [HttpGet]
        public async Task<ActionResult> GetRecipe(int id)
        {
            try
            {
                _logger.LogInformation("");
                if (id == 0) { return BadRequest($"Could not get associated Recipe because no recipe was provided");  }
                
                return Ok(await _recipeService.GetRecipe(id));

            } catch (Exception ex)
            {
                _logger.LogError("");
                return BadRequest($"Could not grab record for recipe matching id of {id}. Exception: {ex.Message}");
            }
            
        }

        [Route("update")]
        [HttpPost]
        public async Task<ActionResult> UpdateRecipe([FromBody] RecipeDTO? recipeDTO)
        {
            try
            {
                if (recipeDTO == null) { return BadRequest($"");  }
                await _recipeService.UpdateRecipe(recipeDTO);
                return Ok();
            } catch(Exception ex)
            {
                _logger.LogError("");
                return BadRequest($"Could not update recipe from given DTO: {recipeDTO}. Exception: {ex.Message}");
            }
        }

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult> CreateRecipe([FromBody] RecipeDTO? recipeDTO)
        {
            try
            {
                _logger.LogInformation("");

                if (recipeDTO == null) { return BadRequest($"");  }
                await _recipeService.CreateRecipe(recipeDTO);
                return Ok();
            } catch (Exception ex)
            {
                _logger.LogError("");
                return BadRequest($"Could not create recipe from associated DTO: {recipeDTO}. Exception: {ex.Message}");
            }
            
        }



    }
}
