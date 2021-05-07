using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBlogApp.Interfaces
{
    public interface IRepositoryWrapper
    {
        IRecipeRepository Recipes { get; }
        IRecipeCardRepository RecipeCards { get; }
        
        void Save();
    }
}
