using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class IngredientDTO
    {
        public string Name { get; private set; }
        public int Amount { get; private set; }
        public WeightDTO? Weight { get; private set; }


        public IngredientDTO(string name, int amount, WeightDTO? weight = null)
        {
            Name = name;
            Amount = amount;
            Weight = weight;
        }
    }
}
