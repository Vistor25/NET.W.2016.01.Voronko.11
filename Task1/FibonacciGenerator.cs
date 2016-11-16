using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class FibonacciGenerator
    {
        public static IEnumerable<int> GenerateFibonacci(int n)
        {
            if (n <= 0) throw new ArgumentOutOfRangeException(nameof(n));
            int F0 = 0;
            int F1 = 1;
            for (int i = 0; i < n; i++)
            {
                int F = F0 + F1;
                F0 = F1;
                F1 = F;
                yield return F;
            }
        }
    }
}
