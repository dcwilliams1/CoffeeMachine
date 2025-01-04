using CoffeeMachine.Server.Domain.Interfaces;
using CoffeeMachine.Server.Domain.Models;

namespace CoffeeMachine.Server.Domain.Services
{
    public class MachineFactoryService : IMachineFactoryService
    {
        private readonly IServiceProvider _serviceProvider;

        public MachineFactoryService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICoffeeMachine CreateCoffeeMachine(string machineModel)
        {
            switch (machineModel)
            {
                case Constants.MachineTypes.STANDARD:
                    return new StandardMachine();
                case Constants.MachineTypes.GRINDING:
                    return new GrindingMachine();
                default:
                    throw new Exception(Constants.Messages.MACHINE_TYPE_NOT_FOUND);
            }

        }
    }
}
