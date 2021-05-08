using RecipeBlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBlogApp.Interfaces
{
    public interface IRecipeCard
    {
        public int ID { get; set; }
        public Recipe Recipe { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
    }
}
