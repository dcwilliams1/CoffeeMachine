using CoffeeMachine.Server.Domain.Interfaces;

namespace CoffeeMachine.Server.Domain.Models
{
    public abstract class CoffeeMachineBase : ICoffeeMachine
    {
        public virtual string Brew()
        {
            return Constants.Messages.BREW_FINISHED;
        }
    }
}
