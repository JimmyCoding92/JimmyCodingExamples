using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion
{
    public class CoffeeMachine : ICoffeeMachine
    {
        public Task<Coffee> MakeCoffee(CoffeeBean bean, Milk milk)
        {
            Console.WriteLine("Start to make a coffee");

            var coffee = new Coffee();

            Console.WriteLine("Coffee is ready");

            return Task.FromResult<Coffee>(coffee);
        }
    }
}
