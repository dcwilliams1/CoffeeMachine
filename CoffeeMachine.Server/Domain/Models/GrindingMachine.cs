using CoffeeMachine.Server.Domain.Interfaces;

namespace CoffeeMachine.Server.Domain.Models
{
    public class GrindingMachine : CoffeeMachineBase
    {
        public override string Brew()
        {
            return Constants.Messages.GRINDING_FINISHED;
        }
    }
}
