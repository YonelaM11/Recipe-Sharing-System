using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recipe_Management_System
{
    class Recipe
    {
       public string Name { get;set;}
       public string Ingredients { get; set; }
       public string Instructions { get; set; }
       public   string Category{ get; set; }
        public List<int> Ratings { get;set;}

        public Recipe(string name, string ingredients, string instructions, string category)
        {
            Name = name;
            Ingredients = ingredients;
            Instructions = instructions;
            Category = category;
            Ratings = new List<int>();
        }
        public double AverageRating()
        {
            return Ratings.Count > 0 ? Ratings.Average() : 0;
        }
        public override string ToString()
        {
            return "Name:" + Name + " \nCategory :" + Category + "\nIgredients:" + Ingredients + "\nInstructions:" + Instructions + "\nAverageRating:" + AverageRating();
        }
    }
}
