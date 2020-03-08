using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        [Pure]
        public static TSource Single<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            switch (source.Count)
            {
                case 0:
                    return Throw.EmptySequence<TSource>();

                case 1:
                    using (var enumerator = source.GetEnumerator())
                    {
                        if (enumerator.MoveNext())
                            return enumerator.Current;
                    }
                    goto case 0;

                default:
                    return Throw.NotSingleSequence<TSource>();
            }
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Single<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Selector<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            switch (source.Count)
            {
                case 0:
                    return Throw.EmptySequence<TResult>();

                case 1:
                    using (var enumerator = source.GetEnumerator())
                    {
                        if (enumerator.MoveNext())
                            return selector(enumerator.Current);
                    }
                    goto case 0;

                default:
                    return Throw.NotSingleSequence<TResult>();
            }
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Single<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, SelectorAt<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            switch (source.Count)
            {
                case 0:
                    return Throw.EmptySequence<TResult>();

                case 1:
                    using (var enumerator = source.GetEnumerator())
                    {
                        if (enumerator.MoveNext())
                            return selector(enumerator.Current, 0);
                    }
                    goto case 0;

                default:
                    return Throw.NotSingleSequence<TResult>();
            }
        }

        /////////////////////////
        // SingleOrDefault

        [Pure]
        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            switch (source.Count)
            {
                case 0:
                    return default;

                case 1:
                    using (var enumerator = source.GetEnumerator())
                    {
                        if (enumerator.MoveNext())
                            return enumerator.Current;
                    }
                    goto case 0;

                default:
                    return Throw.NotSingleSequence<TSource>();
            }
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult SingleOrDefault<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, Selector<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            switch (source.Count)
            {
                case 0:
                    return default;

                case 1:
                    using (var enumerator = source.GetEnumerator())
                    {
                        if (enumerator.MoveNext())
                            return selector(enumerator.Current);
                    }
                    goto case 0;

                default:
                    return Throw.NotSingleSequence<TResult>();
            }
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult SingleOrDefault<TEnumerable, TEnumerator, TSource, TResult>(this TEnumerable source, SelectorAt<TSource, TResult> selector) 
            where TEnumerable : notnull, IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            switch (source.Count)
            {
                case 0:
                    return default;

                case 1:
                    using (var enumerator = source.GetEnumerator())
                    {
                        if (enumerator.MoveNext())
                            return selector(enumerator.Current, 0);
                    }
                    goto case 0;

                default:
                    return Throw.NotSingleSequence<TResult>();
            }
        }
    }
}
