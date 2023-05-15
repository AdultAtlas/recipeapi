using RecipeService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeService.Data.Repositories
{
    public interface IRecipeRepository
    {
        public Task<List<Recipe>> GetAllRecipes();
        public Task<Recipe> GetRecipe(int id);
        public Task<Recipe> InsertRecipe(Recipe recipeNew);
        public Task UpdateRecipe(Recipe recipe);
        public Task DeleteRecipe(Recipe recipe);
    }
}
