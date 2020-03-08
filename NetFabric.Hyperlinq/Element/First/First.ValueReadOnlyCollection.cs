using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        [Pure]
        public static TSource First<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                if (enumerator.MoveNext())
                    return enumerator.Current;
            }
            return Throw.EmptySequence<TSource>();
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult First<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Selector<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                if (enumerator.MoveNext())
                    return selector(enumerator.Current);
            }
            return Throw.EmptySequence<TResult>();
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult First<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, SelectorAt<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                if (enumerator.MoveNext())
                    return selector(enumerator.Current, 0);
            }
            return Throw.EmptySequence<TResult>();
        }

        /////////////////////////
        // FirstOrDefault

        [Pure]
        public static TSource FirstOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                if (enumerator.MoveNext())
                    return enumerator.Current;
            }
            return default;
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult FirstOrDefault<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Selector<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                if (enumerator.MoveNext())
                    return selector(enumerator.Current);
            }
            return default;
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult FirstOrDefault<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, SelectorAt<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count != 0)
            {
                using var enumerator = source.GetEnumerator();
                if (enumerator.MoveNext())
                    return selector(enumerator.Current, 0);
            }
            return default;
        }
    }
}
