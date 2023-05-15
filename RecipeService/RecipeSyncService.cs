using Microsoft.Extensions.Hosting;
using RecipeService.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeService
{
    public class RecipeSyncService : BackgroundService
    {
        private IRecipeModule _recipeModule;


        public RecipeSyncService(IRecipeModule recipeModule)
        {
            _recipeModule = recipeModule;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}
