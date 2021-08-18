using System.Threading.Tasks;

namespace DependencyInversion
{
    public interface ICoffeeMachine
    {
        Task<Coffee> MakeCoffee(CoffeeBean bean, Milk milk);
    }
}