﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBlogApp.Models.Binding
{
    public class AddRecipeCardBindingModel
    {
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public int RecipeID { get; set; }
    }
}