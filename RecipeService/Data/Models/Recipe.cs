using Newtonsoft.Json;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeService.Data.Models
{
    public class Recipe
    {

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Ingredients { get; private set; }

        public Recipe(string name, string description, string ingredientsList)
        {
            Name = name;
            Description = description;
            Ingredients = ingredientsList;
        }

        public static Recipe FromDTO(RecipeDTO dto)
        {
            string ingredients = JsonConvert.SerializeObject(dto.Ingredients);
            return new Recipe(dto.Name, dto.Description, ingredients);
        }

        public void SetName(string name) { Name = name; }
        public void SetDescription(string description) {  Description = description; }
        public void SetIngredients(string ingredients) { Ingredients = ingredients;  }
    }
}
