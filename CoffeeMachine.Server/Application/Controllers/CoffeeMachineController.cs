using CoffeeMachine.Server.Domain.Interfaces;
using CoffeeMachine.Server.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace CoffeeMachine.Server.Controllers
{
    [ApiController]
    [Route("getCoffee")]
    public class CoffeeMachineController : ControllerBase
    {
        private readonly ILogger<CoffeeMachineController> _logger;
        private readonly IMachineFactoryService _machineFactory;

        public CoffeeMachineController(IMachineFactoryService machineFactory, ILogger<CoffeeMachineController> logger)
        {
            _logger = logger;
            _machineFactory = machineFactory;
        }

        [HttpGet(Name = "GetCoffee")]
        public IActionResult GetCoffee(string machineType)
        {
            try
            {
                var coffeeMachine = _machineFactory.CreateCoffeeMachine(machineType);
                var coffeeResponse = new { Message = coffeeMachine.Brew() };
                return new JsonResult(coffeeResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
