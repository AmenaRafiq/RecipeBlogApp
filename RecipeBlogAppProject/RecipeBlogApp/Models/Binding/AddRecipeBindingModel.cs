using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBlogApp.Models.Binding
{
    public class AddRecipeBindingModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Ingredients { get; set; }
        public string Method { get; set; }
        public int Servings { get; set; }
    }
}
