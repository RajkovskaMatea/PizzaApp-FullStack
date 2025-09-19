using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Services.Interfaces;

namespace PizzaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private IPizzaService _pizzaService;

        public PizzaController(IPizzaService service)
        {
            _pizzaService = service;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _pizzaService.GetAllPizzas();
            return Ok(result);
        }
    }
}
