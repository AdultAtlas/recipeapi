using Newtonsoft.Json;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSyncData.Models
{
    public class Recipe
    {

        public string Name { get; set; }
        public int Id { get; private set; }
        public string Description { get; private set; }
        public string Ingredients { get; private set; }
        public int ApproximateTime { get; private set; }

        public Recipe(string name, string description, string ingredients, int approximateTime)
        {
            Name = name;
            Description = description;
            Ingredients = ingredients;
            ApproximateTime = approximateTime;
            
        }

        public static Recipe FromDTO(RecipeDTO recipeDTO)
        {
            string ingredientString = JsonConvert.SerializeObject(recipeDTO);
            
            return new Recipe(recipeDTO.Name, recipeDTO.Description, ingredientString, recipeDTO.ApproximateTime);
        }

        public RecipeDTO ToDTO()
        {

            if (this.Ingredients != null)
            {
                List<IngredientDTO> ingredients = JsonConvert.DeserializeObject<List<IngredientDTO>>(this.Ingredients);
                return new RecipeDTO(this.Name, this.Description, ingredients, this.ApproximateTime);
            } else
            {
                return null;
            }
        }
    }
}
