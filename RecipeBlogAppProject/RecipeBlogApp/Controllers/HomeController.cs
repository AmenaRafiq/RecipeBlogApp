using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeBlogApp.Data;
using RecipeBlogApp.Models;
using RecipeBlogApp.Models.Binding;
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
            var allCards = dbContext.RecipeCards.Include(r => r.Recipe).ToList();
            return View(allCards);
        }

        //READ
        [Route("details/{id:int}")]
        public IActionResult Details(int id)
        {
            var recipeByID = dbContext.Recipes.FirstOrDefault(r => r.ID == id);
            return View(recipeByID);
        }

        //CREATE
        [Route("createrecipe")]
        public IActionResult CreateRecipe()
        {
            return View();
        }
        [HttpPost("createrecipe")]
        public IActionResult CreateRecipeAsync(AddRecipeBindingModel recipeBindingModel, IFormFile fileUpload)
        {
            //get base64String of file
            string image = GetFileBase64Async(fileUpload).Result;

            //create an entry in the recipes table
            var recipeToCreate = new Recipe
            {
                Title = recipeBindingModel.Title,
                Image = image,
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
                Image = image,
            };
            dbContext.RecipeCards.Add(recipeCardToCreate);
            dbContext.SaveChanges();

            
            return RedirectToAction("Index");
        }

        //This method takes an IFormFile, converts it into base64String and returns the string
        public async Task<string> GetFileBase64Async(IFormFile fileUpload)
        {
            //IForm code here was created using the example shown at https://code-maze.com/file-upload-aspnetcore-mvc/, alongside a discussion with an SME.
            var file = fileUpload;
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            var bytes = ms.ToArray();
            string base64String = Convert.ToBase64String(bytes);

            return base64String;

        }

        //UPDATE
        [Route("update/{id:int}")]
        public IActionResult Update(int id)
        {
            var recipeById = dbContext.Recipes.FirstOrDefault(c => c.ID == id);
            return View(recipeById);
        }
        [HttpPost]
        [Route("update/{id:int}")]
        public IActionResult Update(Recipe recipe, int id, IFormFile fileUpload)
        {
            string image = null;
            //check if there is a new file to upload
            if (fileUpload != null)
            {
                //get new image
                image = GetFileBase64Async(fileUpload).Result;
            }

            //update the recipe
            var recipeToUpdate = dbContext.Recipes.FirstOrDefault(r => r.ID == id);
            recipeToUpdate.Title = recipe.Title;
            //only overwrite image if a new file was uploaded
            if (image != null)
            {
                recipeToUpdate.Image = image;
            }
            recipeToUpdate.Ingredients = recipe.Ingredients;
            recipeToUpdate.Method = recipe.Method;
            recipeToUpdate.Servings = recipe.Servings;
            dbContext.SaveChanges();

            //Update the Card
            var recipecardToUpdate = dbContext.RecipeCards.FirstOrDefault(r => r.Recipe == recipeToUpdate);
            recipecardToUpdate.Title = recipe.Title;
            //only overwrite image if a new file was uploaded
            if (image != null)
            {
                recipecardToUpdate.Image = image;
            }
            

            dbContext.SaveChanges();
            return RedirectToAction("Details", new { id = id });
        }

        //DELETE
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            //get the recipe
            var recipeToDelete = dbContext.Recipes.FirstOrDefault(r => r.ID == id);

            //use this to find the right card
            var recipeCardToDelete = dbContext.RecipeCards.FirstOrDefault(r => r.Recipe == recipeToDelete);

            //first delete the card due to the relation
            dbContext.RecipeCards.Remove(recipeCardToDelete);
            dbContext.SaveChanges();

            //delete the recipe from the recipes table
            dbContext.Recipes.Remove(recipeToDelete);
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