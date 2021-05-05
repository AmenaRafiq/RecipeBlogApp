using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBlogLibrary.Models.Binding
{
    public class AddRecipeBindingModel
    {
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public string Ingredients { get; set; }
        public string Method { get; set; }
        public int Servings { get; set; }
    }
}
