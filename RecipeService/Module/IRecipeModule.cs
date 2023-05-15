using RecipeService.Data.Models;

namespace RecipeService.Module
{
    public interface IRecipeModule
    {

        public Task<Recipe> GetRecipe(int id);
        public Task UpdateRecipe(Recipe recipe);
        public Task DeleteRecipe(int id);
        public Task CreateRecipe(Recipe recipe);
        public Task<List<Recipe>> GetAllRecipes();
    }
}
