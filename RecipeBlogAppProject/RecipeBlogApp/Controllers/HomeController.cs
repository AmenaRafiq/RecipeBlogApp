using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeBlogApp.Data;
using RecipeBlogApp.Models;
using RecipeBlogLibrary.Models;
using RecipeBlogLibrary.Models.Binding;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBlogApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public HomeController(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }

        //READ
        [Route("")]
        public IActionResult Index()
        {
            var allCards = dbContext.RecipeCards.ToList();
            return View(allCards);
        }

        //CREATE
        [Route("CreateRecipe")]
        public IActionResult CreateRecipe()
        {
            return View();
        }
        [HttpPost("CreateRecipe")]
        public IActionResult CreateRecipe(AddRecipeBindingModel recipeBindingModel)
        {
            //create an entry in the recipes table
            var recipeToCreate = new Recipe
            {
                Title = recipeBindingModel.Title,
                ImageURL = recipeBindingModel.ImageURL,
                Ingredients = recipeBindingModel.Ingredients,
                Method = recipeBindingModel.Method,
                Servings = recipeBindingModel.Servings,
            };
            dbContext.Recipes.Add(recipeToCreate);
            dbContext.SaveChanges();

            //create an entry in the recipe cards table
            var recipeCardToCreate = new RecipeCard
            {
                Recipe = recipeToCreate,
                Title = recipeToCreate.Title,
                ImageURL = recipeToCreate.ImageURL,
            };
            dbContext.RecipeCards.Add(recipeCardToCreate);
            dbContext.SaveChanges();

            //go back to home page
            return RedirectToAction("Index");
        }








        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
