using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DependencyInversion
{
    public class Toaster : IToaster
    {
        public async Task<Bread> ToastBread(Bread bread)
        {
            Console.WriteLine("Start to toast a bread");

            await Task.Delay(1000);

            Console.WriteLine("bread is ready");

            return bread;
        }
    }
}
