using CoffeeMachine.Server.Domain.Interfaces;
using CoffeeMachine.Server.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMachine.Server.Controllers
{
    [ApiController]
    [Route("getCoffee")]
    public class CoffeeMachineController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMachineFactoryService _machineFactory;

        public CoffeeMachineController(IMachineFactoryService machineFactory, ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _machineFactory = machineFactory;
        }

        [HttpGet(Name = "GetCoffee")]
        public string GetCoffee(string machineType)
        {
            var coffeeMachine = _machineFactory.CreateCoffeeMachine(machineType);
            return coffeeMachine.Brew();
        }
    }
}
