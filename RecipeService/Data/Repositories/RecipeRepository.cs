using RecipeService.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeService.Data.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private RecipeContext _recipeContext;

        public RecipeRepository(RecipeContext recipeContext)
        {
            _recipeContext = recipeContext;
        }

        public async Task<List<Recipe>> GetAllRecipes()
        {
            return await _recipeContext.Recipes.ToListAsync();
        }

        public async Task<Recipe> GetRecipe(int id)
        {
            return await _recipeContext.Recipes.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Recipe> InsertRecipe(Recipe recipeNew)
        {
            _recipeContext.Recipes.Add(recipeNew);
            await _recipeContext.SaveChangesAsync();
            return recipeNew;
        }

        public async Task UpdateRecipe(Recipe recipe)
        {
            try
            {
                Recipe currentRecipe = await GetRecipe(recipe.Id);
                
                if (currentRecipe == null) { throw new Exception("Recipe not found!");  }

                currentRecipe.SetName(recipe.Name);
                currentRecipe.SetDescription(recipe.Description);
                currentRecipe.SetIngredients(recipe.Ingredients);

                await _recipeContext.SaveChangesAsync();

            } catch (Exception ex) {
                throw;
            }
        }

        public async Task DeleteRecipe(Recipe recipe)
        {
            try
            {
                _recipeContext.Recipes.Remove(recipe);

                await _recipeContext.SaveChangesAsync();
            } catch (Exception ex)
            {
                throw;
            }
        }
    }
}
