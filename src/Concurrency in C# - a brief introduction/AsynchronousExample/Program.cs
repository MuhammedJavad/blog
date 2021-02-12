using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AsynchronousTest
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var watcher = new Stopwatch();
            watcher.Start();

            await AsyncAwaitImplementation.ShowPrimeCountsAsync();

            watcher.Stop();
            Console.WriteLine($"Takes {(watcher.ElapsedMilliseconds / 1000)} seconds");
            // Console.ReadLine();
        }

        private static void ShowPrimeCounts()
        {
            for (int i = 0; i < 10; i++)
            {
                var result = GetPrimesCount(i * 1000000 + 2, 10000000);
                Console.WriteLine($"{result} primes between {i * 1000000} and {(i + 1) * 1000000 - 1}");
            }
            Console.WriteLine("Done");
        }

        private static int GetPrimesCount(int start, int end)
        {
            return ParallelEnumerable.Range(start, end)
                 .Count(n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0));
        }
    }
}
