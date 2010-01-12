using System;
using System.Linq;
using System.Text;

namespace System.Collections.Generic
{
    public static class ICollectionExtensions
    {
        public static int Remove<T>(this ICollection<T> collection, Func<T, bool> predicate)
        {
            var removals = collection.Where(predicate).ToList();
            removals.ForEach(r => collection.Remove(r));
            return removals.Count;
        }
    }
}
