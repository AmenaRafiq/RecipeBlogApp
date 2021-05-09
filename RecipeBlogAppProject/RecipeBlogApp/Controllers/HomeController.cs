using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeBlogApp.Data;
using RecipeBlogApp.Interfaces;
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
        //this method makes the time to load the page longer so storing the string in a class now
        //Read from text file to get the binary for the placeholder image or the case where User does not upload an image file
        //private static string pathToNoImagePlaceholderFile = @"~/../Models/NoImagePlaceholderBinary64String.txt";
        //private readonly string NoImagePlaceholder = System.IO.File.ReadAllText(pathToNoImagePlaceholderFile);

        //Get binary for no image placeholder (to use if User does not upload a file) from the class
        private readonly string NoImagePlaceholder = NoImagePlaceHolder.Placeholder;

        private IRepositoryWrapper repo;
        public HomeController(IRepositoryWrapper repositorywrapper)
        {
            repo = repositorywrapper;
        }

        //READ
        //[Route("")]
        public IActionResult Index()
        {
            var allCards = repo.RecipeCards.FindAll(r => r.Recipe);
            return View(allCards);
        }

        //READ
        [Route("details/{id:int}")]
        public IActionResult Details(int id)
        {
            var recipeByID = repo.Recipes.FindByCondition(r => r.ID == id).FirstOrDefault();
            return View(recipeByID);
        }

        //CREATE
        [Route("createrecipe")]
        public IActionResult CreateRecipe()
        {
            return View();
        }
        [HttpPost("createrecipe")]
        public IActionResult CreateRecipe(AddRecipeBindingModel recipeBindingModel, IFormFile fileUpload)
        {
            //Quick Validation for file uploads to avoid errors
            string image;
            //check if there is a new file to upload
            if (fileUpload != null)
            {
                //get new image 
                image = GetFileBase64Async(fileUpload).Result;
            }
            else
            {
                //assign to placeholder's binary
                image = NoImagePlaceholder;
            }

            //Validation for empty input
            if (recipeBindingModel.Title != null || recipeBindingModel.Ingredients != null || recipeBindingModel.Method != null)
            {
                //create an entry in the recipes table
                var recipeToCreate = new Recipe
                {
                    Title = recipeBindingModel.Title,
                    Image = image,
                    Ingredients = recipeBindingModel.Ingredients,
                    Method = recipeBindingModel.Method,
                    Servings = recipeBindingModel.Servings,
                };
                repo.Recipes.Create(recipeToCreate);
                repo.Save();

                //create an entry in the recipe cards table
                var recipeCardToCreate = new RecipeCard
                {
                    Recipe = recipeToCreate,
                    Title = recipeToCreate.Title,
                    Image = image,
                };
                repo.RecipeCards.Create(recipeCardToCreate);
                repo.Save();

            }

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
            var recipeById = repo.Recipes.FindByCondition(r => r.ID == id).FirstOrDefault();
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
            var recipeToUpdate = repo.Recipes.FindByCondition(r => r.ID == id).FirstOrDefault();
            recipeToUpdate.Title = recipe.Title;
            //only overwrite image if a new file was uploaded
            if (image != null)
            {
                recipeToUpdate.Image = image;
            }
            recipeToUpdate.Ingredients = recipe.Ingredients;
            recipeToUpdate.Method = recipe.Method;
            recipeToUpdate.Servings = recipe.Servings;
            repo.Recipes.Update(recipeToUpdate);
            repo.Save();

            //Update the Card
            var recipecardToUpdate = repo.RecipeCards.FindByCondition(r => r.Recipe == recipeToUpdate).FirstOrDefault();
            recipecardToUpdate.Title = recipe.Title;
            //only overwrite image if a new file was uploaded
            if (image != null)
            {
                recipecardToUpdate.Image = image;
            }
            repo.RecipeCards.Update(recipecardToUpdate);
            repo.Save();
            return RedirectToAction("Details", new { id = recipe.ID });
        }

        //DELETE
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            //get the recipe
            var recipeToDelete = repo.Recipes.FindByCondition(r => r.ID == id).FirstOrDefault();

            //use this to find the right card
            var recipeCardToDelete = repo.RecipeCards.FindByCondition(r => r.Recipe == recipeToDelete).FirstOrDefault();

            //first delete the card due to the relation
            repo.RecipeCards.Delete(recipeCardToDelete);
            repo.Save();

            //delete the recipe from the recipes table
            repo.Recipes.Delete(recipeToDelete);
            repo.Save();
            return RedirectToAction("Index");
        }

        public IActionResult About()
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