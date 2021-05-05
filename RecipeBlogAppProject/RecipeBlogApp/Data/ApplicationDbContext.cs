using Microsoft.EntityFrameworkCore;
using RecipeBlogLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBlogApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeCard> RecipeCards { get; set; }
    }
}
