using RecipeBlogApp.Data;
using RecipeBlogApp.Interfaces;
using RecipeBlogApp.Models;
using System;

namespace RecipeBlogApp.Repositories
{
    public class RecipeCardRepository : Repository<RecipeCard, Recipe>, IRecipeCardRepository
    {
        public RecipeCardRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

    
    }
}
