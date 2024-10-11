using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recipe_Management_System
{
    class Program
    {
        static List<User> users = new List<User>();
        static List<Recipe> recipes = new List<Recipe>();
        static User currentUser;
        
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("Recipe Sharing Platform");
                if(currentUser ==null)
                {
                    Console.WriteLine("1. Register");
                    Console.WriteLine("2. Login");

                }
                else
                {
                    Console.WriteLine("Logged in as:"+currentUser);
                    Console.WriteLine("1. Submit a Recipe");
                     Console.WriteLine("2. View Recipes");
                     Console.WriteLine("3. Rate Recipe");
                     Console.WriteLine("4. Create a Meal Plan");
                     Console.WriteLine("5. Logout");
                }
                Console.WriteLine("0.Exit");
                Console.WriteLine("Select an Option:");
                choice=int.Parse(Console.ReadLine());
            if(currentUser==null)
            {
                if (choice == 1)
                {
                    Register();
                }
                else if (choice == 2)
                {
                    Login();
                }
                }
                else
                {
                    switch(choice)
                    {
                    case 1:
                    SubmitRecipe();
                    break;
                case 2:
                    ViewRecipes();
                    break;
                case 3:
                    RateRecipe();
                    break;
                case 4:
                    CreateMealPlan();
                    break;
                case 5:
                    Logout();
                    break;
                    }
                  }
            
            }while(choice!=0);
        
            }

        static void  Register()
        {
            Console.Write("Enter username:");
            string username=Console.ReadLine();
            Console.Write("Enter password:");
            string password=Console.ReadLine();
            users.Add(new User(username,password));
            Console.WriteLine("User registered successfully!");
            Console.ReadKey();
        }
        static void Login()
        {
            Console.Write("Enter username:");
            string username = Console.ReadLine();
            Console.Write("Enter password:");
            string password = Console.ReadLine();
            currentUser = users.Find(u => u.Username == username && u.Password == password);
            if (currentUser != null)
            {
                Console.WriteLine("Login successful!");
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
            }
            Console.ReadKey();
        }

        static void Logout()
        {
            currentUser = null;
            Console.WriteLine("Logged out.");
            Console.ReadKey();
        }
        static void SubmitRecipe()
        {
            Console.Write("Enter recipe name:");
            string name=Console.ReadLine();
            Console.Write("Enter ingredients (comma-separated):");
            string ingredients=Console.ReadLine();
             Console.Write("Enter instructions:");
            string instructions=Console.ReadLine();
             Console.Write("Enter category(e.g. Breakfast,Lunch,Dessert):");
            string category=Console.ReadLine();
            recipes.Add(new Recipe(name,ingredients,instructions,category));
            Console.WriteLine("Recipe submitted successfully!");
            Console.ReadKey();

        }
        static void ViewRecipes()
           {
               Console.Clear();
               if (recipes.Count==0)
               {
                   Console.WriteLine("No recipes available.");
               }
               else
               {
                   foreach(var recipe in recipes)
                   {
                       Console.WriteLine(recipe.ToString());
                       Console.WriteLine(new string('-', 40));
                 
                   }

               }
               Console.ReadKey();
           }
        static void RateRecipe()
            {
                if (recipes.Count==0)
                {
                    Console.WriteLine("No recipe available to rate:");
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine("Enter the name of the recipe to rate:"); 
                string name = Console.ReadLine();
                var recip = recipes.Find(r=>r.Name.Equals(name,StringComparison.OrdinalIgnoreCase));
                if(recip!=null)
                {
                    Console.WriteLine("Enter a rating (1-5):");
                    int rating = int.Parse(Console.ReadLine());
                    if(rating>=1&&rating<=5)
                    {
                        recip.Ratings.Add(rating);
                        Console.WriteLine("Rating submitted!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid rating. Please enter a number between 1 and 5.");
                    }
                }
                else
                {
                    Console.WriteLine("Recipe not found.");
                }
                Console.ReadKey();
            }
        static void CreateMealPlan()
        {
            if(recipes.Count==0)
            {
                Console.WriteLine("No recipes available for meal planning.");
                Console.ReadKey();
                return;
            }
             List<Recipe>mealPlan= new List<Recipe>();
            Console.WriteLine("Creating a meal plan. Type 'done' when finished.");
            while(true)
            {
                Console.Write("Enter a recipe name to add to the meal plan:");
                string name = Console.ReadLine();
                if(name.ToLower()=="done")
                {
                    break;
                }
        var recip = recipes.Find(r =>r.Name.Equals(name,StringComparison.OrdinalIgnoreCase));
                if(recipes != null)
                {
                    mealPlan.Add(recip);
                    Console.WriteLine("Added :+recipe.name+ to the meal plan.");
                }
                else
                {
                    Console.WriteLine("Recipe not found.");
                }
            }
            Console.WriteLine("\nYour Meal Plan:");
            foreach(var recipe in mealPlan)
            {
                Console.WriteLine(recipe.Name);
            }
            Console.ReadKey();

                }
   }

}
        

           
        





    


