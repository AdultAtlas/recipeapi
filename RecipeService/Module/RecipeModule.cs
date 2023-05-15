using Microsoft.Extensions.Logging;
using RecipeService.Data;
using RecipeService.Data.Models;
using RecipeService.Data.Repositories;

namespace RecipeService.Module
{
    public class RecipeModule : IRecipeModule
    {

        private IRecipeRepository _repository;
        private ILogger<RecipeModule> _logger;

        public RecipeModule(IRecipeRepository repository, ILogger<RecipeModule> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task CreateRecipe(Recipe recipe)
        {
            try
            {

                await _repository.InsertRecipe(recipe);

            } catch (Exception ex) { throw; }
        }

        public async Task DeleteRecipe(int id)
        {
            try
            {
                Recipe recipeToDelete = await _repository.GetRecipe(id);

                if (recipeToDelete == null) {
                    _logger.LogInformation($"");
                    return;  
                }

                await _repository.DeleteRecipe(recipeToDelete);

            } catch (Exception ex) { throw; }

        }

        public async Task<List<Recipe>> GetAllRecipes()
        {
            try
            {
                List<Recipe> recipes = await _repository.GetAllRecipes();

                if (recipes == null) { throw new Exception("_repository.GetAllRecipes() returned null list!"); }

                return recipes;
                
            } catch (Exception ex) { throw; }
        }

        public async Task<Recipe> GetRecipe(int id)
        {
            try
            {
                Recipe recipe = await _repository.GetRecipe(id);

                if (recipe == null) { throw new Exception("_repository.GetRecipe() returned no recipe!");  }

                return recipe;
            } catch (Exception ex) { throw; }

        }

        public async Task UpdateRecipe(Recipe recipe)
        {
            try
            {
                await _repository.UpdateRecipe(recipe);
            } catch (Exception ex) { throw; }
        }
    }
}
