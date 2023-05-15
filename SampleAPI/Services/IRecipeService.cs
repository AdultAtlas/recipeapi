using Shared.DTOs;
using System.Runtime.CompilerServices;

namespace RecipeAPI.Services
{
    public interface IRecipeService
    {
        public Task<RecipeDTO> GetRecipe(int id);
        public Task UpdateRecipe(RecipeDTO recipe);
        public Task DeleteRecipe(int id);
        public Task CreateRecipe(RecipeDTO recipeDTO);
        public Task<List<RecipeDTO>> GetAllRecipes();
    }
}
