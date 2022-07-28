using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaprimesFinder.Engine
{
    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> values, int chunkSize)
        {
            while (values.Any())
            {
                yield return values.Take(chunkSize).ToList();
                values = values.Skip(chunkSize).ToList();
            }
        }
    }
}
