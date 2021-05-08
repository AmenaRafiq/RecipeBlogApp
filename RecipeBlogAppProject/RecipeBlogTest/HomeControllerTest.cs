using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RecipeBlogApp.Controllers;
using RecipeBlogApp.Interfaces;
using RecipeBlogApp.Models;
using RecipeBlogApp.Models.Binding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace RecipeBlogTest
{
    public class HomeControllerTest
    {
        private Mock<IRepositoryWrapper> mockRepo;
        private HomeController homeController;
        private AddRecipeBindingModel addRecipe;
        private Recipe recipe;
        private List<Recipe> recipes;
        private Mock<IAddRecipe> addRecipeMock;
        private Mock<IRecipe> recipeMock;
        private List<IRecipe> recipesMock;
        private IFormFile file;

        public HomeControllerTest()
        {
            //mock setup
            recipeMock = new Mock<IRecipe>();
            recipesMock = new List<IRecipe> { recipeMock.Object };
            recipe = new Recipe();
            recipes = new List<Recipe>();
            addRecipeMock = new Mock<IAddRecipe>();

            //sample model
            addRecipe = new AddRecipeBindingModel { ID = 1, Title = "Cake", Image = "image", Ingredients = "list of ingredients", Method = "steps", Servings = 4 };

            //IFormFile setup
            //Idea to create an in-memory instance of a form file is from user harishr at:
            //https://stackoverflow.com/questions/36858542/how-to-mock-an-iformfile-for-a-unit-integration-test-in-asp-net-core-1-mvc-6/55953099
            //Idea to make "stream content" inside a string variable from user schlingel in the comments
            string fileContent = "hello";
            file = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes(fileContent)), 0, fileContent.Length, "Data", fileContent);

            //controller setup
            var recipeCardMock = new Mock<IRecipeCard>();
            var recipeCardsMock = new List<IRecipeCard>() { recipeCardMock.Object };
            //var courseResultsMock = new Mock<IActionResult>();

            mockRepo = new Mock<IRepositoryWrapper>();
            var allRecipes = GetRecipes();
            homeController = new HomeController(mockRepo.Object);

        }


        [Fact]
        public void GetAllRecipeCards_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.RecipeCards.FindAll(r => r.Recipe)).Returns(GetRecipeCards());
            //Act
            var controllerActionResult = homeController.Index();
            //Assert
            Assert.NotNull(controllerActionResult);
        }

        [Fact]
        public void GetAllRecipes_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Recipes.FindByCondition(r => r.ID == It.IsAny<int>())).Returns(GetRecipes());
            //Act
            var controllerActionResult = homeController.Details(It.IsAny<int>());
            //Assert
            Assert.NotNull(controllerActionResult);
        }

        [Fact]
        public void CreateRecipe_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Recipes.Create(It.IsAny<Recipe>())).Returns(It.IsAny<Recipe>());
            mockRepo.Setup(repo => repo.RecipeCards.Create(It.IsAny<RecipeCard>())).Returns(It.IsAny<RecipeCard>());

            //Act
            var controllerActionResult = homeController.CreateRecipe(addRecipe, file);

            //Assert
            Assert.NotNull(file);
            Assert.NotNull(addRecipe);

            Assert.NotNull(controllerActionResult);

        }

        

        //Methods to generate recipes quickly to make testing easier
        private IEnumerable<Recipe> GetRecipes()
        {
            var courses = new List<Recipe> {
            new Recipe(){ ID = 1, Title = "Recipe1", Image = "image1", Ingredients = "list of ingredients", Method = "steps", Servings = 1 },
            new Recipe(){ ID = 1, Title = "Recipe2", Image = "image2", Ingredients = "list of ingredients2", Method = "steps2", Servings = 2 }
            };
            return courses;
        }
        private Recipe GetRecipe()
        {
            return GetRecipes().ToList()[0];
        }

        private IEnumerable<RecipeCard> GetRecipeCards()
        {
            var courses = new List<RecipeCard> {
            new RecipeCard(){ ID = 1, Title = "RecipeCard1", Image = "image1", Recipe = GetRecipe() },
            new RecipeCard(){ ID = 1, Title = "RecipeCard2", Image = "image2", Recipe = GetRecipe() }
            };
            return courses;
        }
        private RecipeCard GetRecipeCard()
        {
            return GetRecipeCards().ToList()[0];
        }
    }
}
