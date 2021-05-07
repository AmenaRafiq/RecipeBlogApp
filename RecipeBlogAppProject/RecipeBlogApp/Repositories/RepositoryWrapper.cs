using RecipeBlogApp.Data;
using RecipeBlogApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBlogApp.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        ApplicationDbContext _repoContext;
        public RepositoryWrapper(ApplicationDbContext repoContext)
        {
            _repoContext = repoContext;
        }

        IRecipeRepository _recipes;

        IRecipeCardRepository _recipeCards;

        public IRecipeRepository Recipes
        {
            get
            {
                if (_recipes == null)
                {
                    _recipes = new RecipeRepository(_repoContext);
                }
                return _recipes;
            }
        }

        public IRecipeCardRepository RecipeCards
        {
            get
            {
                if (_recipeCards == null)
                {
                    _recipeCards = new RecipeCardRepository(_repoContext);
                }
                return _recipeCards;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
