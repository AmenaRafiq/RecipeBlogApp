﻿using Microsoft.AspNetCore.Http;
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
        public IActionResult CreateRecipeAsync(AddRecipeBindingModel recipeBindingModel, IFormFile ImageURL)
        {
            //create an entry in the recipes table - empty image for now
            var recipeToCreate = new Recipe
            {
                Title = recipeBindingModel.Title,
                Image = "",
                Ingredients = recipeBindingModel.Ingredients,
                Method = recipeBindingModel.Method,
                Servings = recipeBindingModel.Servings,
            };
            dbContext.Recipes.Add(recipeToCreate);
            dbContext.SaveChanges();

            //go to separate method to add image - just to make it faster
            //when adding image method was inside this method, it took very long to create a post
            return RedirectToAction("AddImage", new { id = recipeToCreate.ID });
        }

        [Route("addimage/{id:int}")]
        public IActionResult AddImage(int id)
        {
            var recipeByID = dbContext.Recipes.FirstOrDefault(r => r.ID == id);
            return View(recipeByID);
        }
        [HttpPost("addimage/{id:int}")]
        public async Task<IActionResult> AddImageAsync(IFormFile fileUpload, int id)
        {
            //IForm code here was created using the example shown at https://code-maze.com/file-upload-aspnetcore-mvc/, alongside a discussion with an SME.
            var file = fileUpload;
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            var bytes = ms.ToArray();
            var base64String = Convert.ToBase64String(bytes);

            //find and update that recipe's Image 
            var recipeByID = dbContext.Recipes.FirstOrDefault(r => r.ID == id);
            recipeByID.Image = base64String;
            dbContext.SaveChanges();

            //create an entry in the recipe cards table
            var recipeCardToCreate = new RecipeCard
            {
                Recipe = recipeByID,
                Title = recipeByID.Title,
                Image = base64String,
            };
            dbContext.RecipeCards.Add(recipeCardToCreate);
            dbContext.SaveChanges();

            return RedirectToAction("Index");

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