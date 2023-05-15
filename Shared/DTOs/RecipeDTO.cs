namespace Shared.DTOs
{
    public class RecipeDTO
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<IngredientDTO>? Ingredients { get; private set; }
        public int ApproximateTime { get; private set; }

        public RecipeDTO(string name, string description, List<IngredientDTO>? ingredients, int approximateTime)
        {
            Name = name;
            Description = description;
            Ingredients = ingredients;
            ApproximateTime = approximateTime;
        }
    }
}