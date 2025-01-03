using CoffeeMachine.Server.Domain.Interfaces;

namespace CoffeeMachine.Server.Domain.Services
{
    public interface IMachineFactoryService
    {
        ICoffeeMachine CreateCoffeeMachine(string machineModel);
            
    }
}
