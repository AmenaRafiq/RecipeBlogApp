using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeBlogApp.Data;
using RecipeBlogApp.Models;
using RecipeBlogLibrary.Models;
using RecipeBlogLibrary.Models.Binding;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        //[Route("")]
        public IActionResult Index()
        {
            var allCards = dbContext.RecipeCards.ToList();
            return View(allCards);
        }

        //[Route("AddImage/{RecipeID:int}")]
        //public IActionResult AddImage(int RecipeID)
        //{
        //    var recipeByID = dbContext.Recipes.FirstOrDefault(r => r.ID == RecipeID);
        //    return View(recipeByID);
        //}
        //[HttpPost("AddImage/{RecipeID:int}")]
        //public async Task<IActionResult> AddImageAsync(AddRecipeCardBindingModel recipeCardBindingModel, IFormFile fileUpload, int RecipeID)
        //{
            
        //    var file = fileUpload;
        //    using var ms = new MemoryStream();
        //    await file.CopyToAsync(ms);
        //    var bytes = ms.ToArray();
        //    var base64String = Convert.ToBase64String(bytes);

        //    var recipeByID = dbContext.Recipes.FirstOrDefault(r => r.ID == RecipeID);
        //    recipeByID.ImageURL = base64String;
        //    dbContext.SaveChanges();

        //    return RedirectToAction("Index");

        //}

        //CREATE
        [Route("CreateRecipe")]
        public IActionResult CreateRecipe()
        {
            return View();
        }
        [HttpPost("CreateRecipe")]
        public async Task<IActionResult> CreateRecipeAsync(AddRecipeBindingModel recipeBindingModel, IFormFile ImageURL)
        {

            var file = ImageURL;
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            var bytes = ms.ToArray();
            var base64String = Convert.ToBase64String(bytes);

            //create an entry in the recipes table
            var recipeToCreate = new Recipe
            {
                Title = recipeBindingModel.Title,
                ImageURL = base64String,
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
                ImageURL = base64String,
            };
            dbContext.RecipeCards.Add(recipeCardToCreate);
            dbContext.SaveChanges();

            //go to form to add image
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
