using RecipeBlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBlogApp.Interfaces
{
    public interface IRecipeRepository : IRepository<Recipe, RecipeCard>
    {
       
    }
}
