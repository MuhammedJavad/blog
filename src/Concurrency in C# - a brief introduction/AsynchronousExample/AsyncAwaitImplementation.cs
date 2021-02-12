using System;
using System.Linq;
using System.Threading.Tasks;

namespace AsynchronousTest
{
    class AsyncAwaitImplementation
    {
        public static async Task ShowPrimeCountsAsync()
        {
            for (int i = 0; i < 10; i++)
            {
                var result = await GetPrimesCountAsync(i * 100000 + 2, 100000);
                Console.WriteLine($"{result} primes between {i * 100000} and {(i + 1) * 100000 - 1}");
            }

            Console.WriteLine("Done");
        }

        private static Task<int> GetPrimesCountAsync(int start, int end)
        {
            return Task.Run(() => ParallelEnumerable.Range(start, end)
                .Count(n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        }

    }
}