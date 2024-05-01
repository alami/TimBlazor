using BlazingPizza.Data;
using BlazingPizza.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza.Controllers
{
    [Route("my")]
    [ApiController]
    public class MyController : Controller
    {
        private readonly PizzaStoreContext _db;
        public MyController(PizzaStoreContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<ActionResult<List<PizzaSpecial>>> GetMy()
        {
            var tmp = (await _db.Specials.ToListAsync()).OrderBy(s => s.BasePrice).ToList();
            return tmp;
        }
    }
}
