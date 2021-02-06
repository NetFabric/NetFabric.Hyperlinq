using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this ReadOnlySpan<TSource> source)
            => source.Length;

        static int Count<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate: struct, IFunction<TSource, bool>
        {
            var counter = 0;
            foreach (var item in source)
            {
                counter += predicate.Invoke(item).AsByte();
            }
            return counter;
        }

        static int CountRef<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunctionIn<TSource, bool>
        {
            var counter = 0;
            foreach (ref readonly var item in source)
            {
                counter += predicate.Invoke(in item).AsByte();
            }
            return counter;
        }

        static int CountAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate: struct, IFunction<TSource, int, bool>
        {
            var counter = 0;
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                counter += predicate.Invoke(item, index).AsByte();
            }
            return counter;
        }

        static int CountAtRef<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
        {
            var counter = 0;
            for (var index = 0; index < source.Length; index++)
            {
                ref readonly var item = ref source[index];
                counter += predicate.Invoke(in item, index).AsByte();
            }
            return counter;
        }
    }
}

