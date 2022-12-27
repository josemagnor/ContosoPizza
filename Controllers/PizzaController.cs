

namespace ContosoPizza.Controllers
{  
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<Pizza>> getAll()
        {
            return PizzaService.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Pizza>  getOne(int id)
        {
            var result = PizzaService.GetOne(id);
            if(result == null)
                return NotFound();
            
            return result;
        }
        [HttpPost]
        public IActionResult create(Pizza pizza)
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(create), new{id = pizza.Id},pizza);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult update(int id, Pizza pizza)
        {
            if (id != pizza.Id)
                return BadRequest();
            
            var result = PizzaService.GetOne(id);
            if(result is null)
                return NotFound();

            PizzaService.Update(pizza);
            return Ok("Pizza was updated");
        }

         [HttpDelete]
         [Route("{id}")]
         public IActionResult delete(int id)
         {
            var pizza = PizzaService.GetOne(id);
            if (pizza is null)
                return NotFound("Pizza not Found in DataBase");

            PizzaService.Delete(id);
            return Ok("Pizza was deleted");
         }
         [HttpDelete]
         public IActionResult deleteAll()
         {
            PizzaService.DeleteAll();
            return Ok("All pizzas was deleted");
         }
        
        //UPDATE
        //DELETE

    }
}