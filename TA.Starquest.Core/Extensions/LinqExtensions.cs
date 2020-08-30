using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Starquest.Core.Extensions
{
    public static class LinqExtensions
    {
    /// <summary>
    /// Gets a subset of <paramref name="items"/> where each member of the subset
    /// is distinct in the value of the specified property. That is, no two members
    /// of the result will have the same value for <paramref name="property"/>.
    /// in each group.
    /// </summary>
    /// <typeparam name="T">The type of the item being queried (usually inferred from usage).</typeparam>
    /// <typeparam name="TKey">The type of the property that will be used as the discriminator (usually inferred from usage).</typeparam>
    /// <param name="items">The items of type <typeparamref name="T"/> to be filtered.</param>
    /// <param name="property">An expression that selects the property to be used as the discriminator.</param>
    /// <returns>
    ///     A subset of <paramref name="items"/> where each element is distinct
    ///     based on the value of the discriminator <paramref name="property"/>.
    /// </returns>
    public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> items, Func<T, TKey> property)
        {
        return items.GroupBy(property).Select(x => x.First());
        }
    }
}
