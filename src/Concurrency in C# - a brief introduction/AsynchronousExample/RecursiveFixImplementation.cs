using System;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsynchronousTest
{
    class RecursiveFixImplementation
    {
        static RecursiveFixImplementation()
        {
        }

        public static void ShowPrimeCountsAsync(Stopwatch watcher, int iteration = 0)
        {

            var awaiter = GetPrimesCountAsync(iteration * 100000 + 2, 10000000).GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                Console.WriteLine($"{awaiter.GetResult()} primes between {iteration * 100000} and {(iteration + 1) * 10000000 - 1}");
                if (++iteration < 10)
                {
                    ShowPrimeCountsAsync(watcher, iteration);
                }
                else
                {
                    watcher.Stop();
                    Console.WriteLine("Done");
                    Console.WriteLine($"Takes {(watcher.ElapsedMilliseconds / 1000)} seconds");
                }
            });

        }

        private static Task<int> GetPrimesCountAsync(int start, int end)
        {
            return Task.Run(() => ParallelEnumerable.Range(start, end)
                .Count(n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        }
    }
}