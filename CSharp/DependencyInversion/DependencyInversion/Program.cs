using System;
using System.Threading.Tasks;

namespace DependencyInversion
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ICoffeeMachine coffeeMachine = new CoffeeMachine();

            IToaster toaster = new Toaster();

            CoffeeBean coffeeBean = new CoffeeBean();

            Milk milk = new Milk();

            Bread bread = new Bread();

            BreakfastMaker breakfastMaker = new BreakfastMaker(coffeeMachine, toaster, coffeeBean, milk, bread);

            var breakfast = await breakfastMaker.MakeBreakfast();
        }
    }
}
