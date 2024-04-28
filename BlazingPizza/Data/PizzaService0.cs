using BlazingPizza.Components.Pages;
using BlazingPizza.Model;
using System.Xml.Linq;

namespace BlazingPizza.Data
{
    public class PizzaService0
    {
        public Task<Pizza0[]> GetPizzasAsync()
        {
            // Call your data access technology here
            Pizza0[] a = new Pizza0[]
            {
                new Pizza0()
                {
                    PizzaId = 1,Name="Buffalo chicken",Description="Spicy chicken, hot sauce and bleu cheese, guaranteed to warm you up",
                    Price=20,Vegan=true,Vegetarian=true,
                },
                new Pizza0()
                {
                    PizzaId = 2,Name="Basic Cheese Pizza",Description="It's cheesy and delicious. Why wouldn''t you want one?",
                    Price=9,Vegan=false,Vegetarian=true,
                },
                new Pizza0()
                {
                    PizzaId = 3,Name="Classic pepperoni",Description="It's the pizza you grew up with, but Blazing hot!",
                    Price=10,Vegan=false,Vegetarian=true,
                },
                new Pizza0()
                {
                    PizzaId = 4,Name="Mushroom Lovers",Description="It has mushrooms. Isn't that obvious?",
                    Price=11,Vegan=false,Vegetarian=true,
                },
            };
            return Task.FromResult(a);
            //throw new Exception();            
        }
    }
}
