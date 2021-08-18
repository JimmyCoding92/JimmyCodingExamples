using System;
using System.Threading.Tasks;

namespace DependencyInversion
{
    public class BreakfastMaker
    {
        private ICoffeeMachine coffeeMachine;

        private IToaster toaster;

        private CoffeeBean coffeeBean;

        private Milk milk;

        private Bread bread;

        public BreakfastMaker(ICoffeeMachine coffeeMachine, IToaster toaster, CoffeeBean coffeeBean, Milk milk, Bread bread)
        {
            this.coffeeMachine = coffeeMachine;
            this.toaster = toaster;
            this.coffeeBean = coffeeBean;
            this.milk = milk;
            this.bread = bread;
        }

        public async Task<Breakfast> MakeBreakfast()
        {
            Console.WriteLine("Start to prepare breakfast.");

            Task<Coffee> coffeeTask = coffeeMachine.MakeCoffee(coffeeBean, milk);
            Task<Bread> breadTask = toaster.ToastBread(bread);

            Coffee coffee = await coffeeTask;
            Bread newBread = await breadTask;

            Console.WriteLine("Breakfast is ready.");

            return new Breakfast()
            {
                Coffee = coffee,
                Bread = newBread
            };
        }
    }
}
