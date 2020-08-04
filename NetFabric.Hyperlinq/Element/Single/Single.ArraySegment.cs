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

        static Option<TSource> Single<TSource>(this in ArraySegment<TSource> source, Predicate<TSource> predicate)
        {
            var array = source.Array;
            var end = source.Offset + source.Count - 1;
            for (var index = source.Offset; index <= end; index++)
            {
                if (predicate(array![index]))
                {
                    ref readonly var first = ref array![index];

                    for (index++; index < end; index++)
                    {
                        if (predicate(array![index]))
                            return Option.None;
                    }

                    return Option.Some(first);
                }
            }
            return Option.None;
        }


        static Option<TSource> Single<TSource>(this in ArraySegment<TSource> source, PredicateAt<TSource> predicate)
        {
            var array = source.Array;
            var end = source.Offset + source.Count - 1;
            for (var index = source.Offset; index <= end; index++)
            {
                if (predicate(array![index], index))
                {
                    ref readonly var first = ref array![index];

                    for (index++; index < end; index++)
                    {
                        if (predicate(array![index], index))
                            return Option.None;
                    }

                    return Option.Some(first);
                }
            }
            return Option.None;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> Single<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelector<TSource, TResult> selector)
            => (source.Count == 1 && source.Array is object)
                ? Option.Some(selector(source.Array[source.Offset]))
                : Option.None;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> Single<TSource, TResult>(this in ArraySegment<TSource> source, NullableSelectorAt<TSource, TResult> selector)
            => (source.Count == 1 && source.Array is object)
                ? Option.Some(selector(source.Array[source.Offset], 0))
                : Option.None;


        static Option<TResult> Single<TSource, TResult>(this in ArraySegment<TSource> source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector)
        {
            var array = source.Array;
            var end = source.Offset + source.Count - 1;
            for (var index = source.Offset; index <= end; index++)
            {
                if (predicate(array![index]))
                {
                    ref readonly var first = ref array![index];

                    for (index++; index < end; index++)
                    {
                        if (predicate(array![index]))
                            return Option.None;
                    }

                    return Option.Some(selector(first));
                }
            }
            return Option.None;
        }
    }
}
