using RecipeBlogApp.Data;
using RecipeBlogApp.Interfaces;
using RecipeBlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBlogApp.Repositories
{
    public class RecipeRepository : Repository<Recipe, RecipeCard>, IRecipeRepository
    {
        public RecipeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
