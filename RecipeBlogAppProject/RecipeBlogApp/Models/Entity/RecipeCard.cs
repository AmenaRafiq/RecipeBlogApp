using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBlogApp.Models
{
    public class RecipeCard
    {
        public int ID { get; set; }
        public virtual Recipe Recipe { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
    }
}
