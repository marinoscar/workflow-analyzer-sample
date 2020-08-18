using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wa.sample.rules
{
    internal static class CollectionExtensions
    {

        public static IEnumerable<T> Flatten<T>(
              this IEnumerable<T> e
            , Func<T, IEnumerable<T>> f
                ) => e.SelectMany(c => f(c).Flatten(f)).Concat(e);
    }
}
