using Shared.DTOs;

namespace RecipeAPI.Services
{
    public class RecipeService : IRecipeService
    {

        private ILogger<RecipeService> _logger;


        public RecipeService(ILogger<RecipeService> logger)
        {
            _logger = logger;
        }

        public async Task CreateRecipe(RecipeDTO recipeDTO)
        {
            
        }

        public async Task DeleteRecipe(int id)
        {
            
        }

        public async Task<RecipeDTO> GetRecipe(int id)
        {


            WeightDTO ingredientWeightDTO = new WeightDTO(1, "lb");

            IngredientDTO ingredientDTO = new IngredientDTO("ground beef", 1, ingredientWeightDTO);

            List<IngredientDTO> dtoList = new List<IngredientDTO> { ingredientDTO };

            RecipeDTO testRecipeDTO = new RecipeDTO("Test", "A test recipe", dtoList, 60);

            return testRecipeDTO;

        }

        public async Task<List<RecipeDTO>> GetAllRecipes()
        {
            WeightDTO ingredientWeightDTO = new WeightDTO(1, "lb");

            IngredientDTO ingredientDTO = new IngredientDTO("ground beef", 1, ingredientWeightDTO);

            List<IngredientDTO> dtoList = new List<IngredientDTO> { ingredientDTO };

            RecipeDTO testRecipeDTO = new RecipeDTO("Test", "A test recipe", dtoList, 60);

            return new List<RecipeDTO> { testRecipeDTO };
        }

        public async Task UpdateRecipe(RecipeDTO recipe)
        {
            
        }
    }
}
