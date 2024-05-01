using BlazingPizza.Data;
using BlazingPizza.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BlazingPizza.Controllers
{
    [Route("mypost")]
    [ApiController]
    public class MypostController : Controller
    {
        private readonly PizzaStoreContext _db;

        public MypostController(PizzaStoreContext db)
        {
            _db = db;
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(Order order)
        {
            order.CreatedTime = DateTime.Now;

            // Enforce existence of Pizza.SpecialId and Topping.ToppingId
            // in the database - prevent the submitter from making up
            // new specials and toppings
            foreach (var pizza in order.Pizzas)
            {
                pizza.SpecialId = pizza.Special.Id;
                pizza.Special = null;
            }

            _db.Orders.Attach(order);
            await _db.SaveChangesAsync();

            return order.OrderId;
        }
    }
}
