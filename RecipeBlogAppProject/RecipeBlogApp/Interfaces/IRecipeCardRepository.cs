using RecipeBlogApp.Models;
using RecipeBlogApp.Repositories;
using System;
using System.Collections.Generic;

namespace RecipeBlogApp.Interfaces
{
    public interface IRecipeCardRepository : IRepository<RecipeCard, Recipe>
    {
      
    }
}
