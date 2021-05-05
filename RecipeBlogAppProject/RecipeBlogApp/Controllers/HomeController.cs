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
        public IActionResult CreateRecipe(AddRecipeBindingModel bindingModel)
        {
            var recipeToCreate = new Recipe
            {
                Title = bindingModel.Title,
                ImageURL = bindingModel.ImageURL,
                Ingredients = bindingModel.Ingredients,
                Method = bindingModel.Method,
                Servings = bindingModel.Servings,
            };
            var recipeCardToCreate = new RecipeCard
            {
                Title = bindingModel.Title,
                ImageURL = bindingModel.ImageURL,
            };
            dbContext.RecipeCards.Add(recipeCardToCreate);
            dbContext.SaveChanges();
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
