using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBlogApp.Interfaces
{
    public interface IRecipe
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Ingredients { get; set; }
        public string Method { get; set; }
        public int Servings { get; set; }
    }
}
