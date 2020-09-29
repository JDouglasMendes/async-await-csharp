using System;
using System.Threading.Tasks;

namespace Estudos
{
    class Program
    {
        static async Task Main()
        {
            ParrellForTest();
            await Test1();
            Console.Read();
        }       


        private  static void ParrellForTest()
        {
            var result = Parallel.For(1, 10, async (i) =>
            {
                await Task.Delay(i / 2 * 1000);
                Console.WriteLine(i);
            });
           
        }
        
        /// <summary>
        /// Rodou
        /// Com await
        /// Hello World!
        /// sem await
        /// </summary>
        /// <returns></returns>
        private static async Task Test1()
        {
            _ = Task.Run(async () =>
            {
                await Task.Delay(2000);
                Console.WriteLine("Rodou");
            });

            await TestAsync(6000, "com await");

            var t2 = TestAsync(500, "sem await");

            await Task.Factory.StartNew(async () =>
            {
                await Task.Delay(8000);
                Console.WriteLine("Factory");
            });
            
            Console.WriteLine("Hello World!");

            Task.WaitAll(t2);
        }

        private static async Task TestAsync(int time,  string message)
        {
            await Task.Delay(time);
            Console.WriteLine(message);
        }
    }
}
