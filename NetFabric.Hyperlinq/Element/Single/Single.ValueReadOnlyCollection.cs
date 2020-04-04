using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        [Pure]
        public static Option<TSource> Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            switch (source.Count)
            {
                case 0:
                    return Option.None;

                case 1:
                    using (var enumerator = source.GetEnumerator())
                    {
                        if (enumerator.MoveNext())
                            return Option.Some(enumerator.Current);
                    }
                    return Option.None;

                default:
                    return Option.None;
            }
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TResult> Single<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Selector<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            switch (source.Count)
            {
                case 0:
                    return Option.None;

                case 1:
                    using (var enumerator = source.GetEnumerator())
                    {
                        if (enumerator.MoveNext())
                            return Option.Some(selector(enumerator.Current));
                    }
                    return Option.None;

                default:
                    return Option.None;
            }
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TResult> Single<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, SelectorAt<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            switch (source.Count)
            {
                case 0:
                    return Option.None;

                case 1:
                    using (var enumerator = source.GetEnumerator())
                    {
                        if (enumerator.MoveNext())
                            return Option.Some(selector(enumerator.Current, 0));
                    }
                    return Option.None;

                default:
                    return Option.None;
            }
        }
    }
}
