using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using NetFabric.Hyperlinq;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main()
        {
            await Test();

            Console.WriteLine("Done");
        }

        public static async Task Test() => _ = await Observable.Range(0, 100)
            .AsValueObservable() 
            .Count()
            .Do(value => Console.WriteLine(value));
    }
}
