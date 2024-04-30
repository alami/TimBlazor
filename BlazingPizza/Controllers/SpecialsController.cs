using BlazingPizza.Data;
using BlazingPizza.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza.Controllers
{
    [Route("specials")]
    [ApiController]
    public class SpecialsController : Controller
    {
        private readonly PizzaStoreContext _db;
        public SpecialsController(PizzaStoreContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<ActionResult<List<PizzaSpecial>>> GetSpecials()
        {
            var tmp = (await _db.Specials.ToListAsync()).OrderByDescending(s => s.BasePrice).ToList();
            return tmp;
        }
        [HttpPost]
        public async Task<ActionResult<int>> PostSpecials(Order order)
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
