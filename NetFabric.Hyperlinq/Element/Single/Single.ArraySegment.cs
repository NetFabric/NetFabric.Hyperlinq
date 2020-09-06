using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> Single<TSource>(this in ArraySegment<TSource> source)
            => (source.Count == 1 && source.Array is object)
                ? Option.Some(source.Array[source.Offset])
                : Option.None;

        static Option<TSource> Single<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IPredicate<TSource>
        {
            var array = source.Array;
            var end = source.Offset + source.Count - 1;
            for (var index = source.Offset; index <= end; index++)
            {
                if (predicate.Invoke(array![index]))
                {
                    ref readonly var first = ref array![index];

                    for (index++; index <= end; index++)
                    {
                        if (predicate.Invoke(array![index]))
                            return Option.None;
                    }

                    return Option.Some(first);
                }
            }
            return Option.None;
        }


        static Option<TSource> SingleAt<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IPredicateAt<TSource>
        {
            if (source.Offset == 0)
            {
                var array = source.Array;
                var end = source.Count - 1;
                for (var index = 0; index <= end; index++)
                {
                    if (predicate.Invoke(array![index], index))
                    {
                        ref readonly var first = ref array![index];

                        for (index++; index <= end; index++)
                        {
                            if (predicate.Invoke(array![index], index))
                                return Option.None;
                        }

                        return Option.Some(first);
                    }
                }
            }
            else
            {
                var array = source.Array;
                var offset = source.Offset;
                var end = source.Count - 1;
                for (var index = 0; index <= end; index++)
                {
                    if (predicate.Invoke(array![index + offset], index))
                    {
                        ref readonly var first = ref array![index + offset];

                        for (index++; index <= end; index++)
                        {
                            if (predicate.Invoke(array![index + offset], index))
                                return Option.None;
                        }

                        return Option.Some(first);
                    }
                }
            }
            return Option.None;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult?> Single<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelector<TSource, TResult> selector)
            => (source.Count == 1 && source.Array is object)
                ? Option.Some(selector(source.Array[source.Offset]))
                : Option.None;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult?> Single<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelectorAt<TSource, TResult> selector)
            => (source.Count == 1 && source.Array is object)
                ? Option.Some(selector(source.Array[source.Offset], 0))
                : Option.None;


        static Option<TResult?> Single<TSource, TResult, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate, NullableSelector<TSource, TResult> selector)
            where TPredicate : struct, IPredicate<TSource>
        {
            var array = source.Array;
            var end = source.Offset + source.Count - 1;
            for (var index = source.Offset; index <= end; index++)
            {
                if (predicate.Invoke(array![index]))
                {
                    ref readonly var first = ref array![index];

                    for (index++; index <= end; index++)
                    {
                        if (predicate.Invoke(array![index]))
                            return Option.None;
                    }

                    return Option.Some(selector(first));
                }
            }
            return Option.None;
        }
    }
}
