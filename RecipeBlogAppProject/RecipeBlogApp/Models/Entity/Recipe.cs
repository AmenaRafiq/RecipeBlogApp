using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBlogApp.Models
{

    public class Recipe
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Image { get; set; }
        [Required]
        public string Ingredients { get; set; }
        [Required]
        public string Method { get; set; }
        [Required]
        public int Servings { get; set; }

    }

}
