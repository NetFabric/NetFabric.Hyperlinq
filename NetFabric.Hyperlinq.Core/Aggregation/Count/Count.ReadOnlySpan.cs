using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(ReadOnlySpan<TSource> source)
            => source.Length;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(ReadOnlySpan<TSource> source, Func<TSource, bool> predicate)
            => source.Count(new FunctionWrapper<TSource, bool>(predicate));

        public static int Count<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate = default)
            where TPredicate: struct, IFunction<TSource, bool>
        {
            var counter = 0;
            foreach (var item in source)
            {
                counter += predicate.Invoke(item).AsByte();
            }
            return counter;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this ReadOnlySpan<TSource> source, Func<TSource, int, bool> predicate)
            => source.CountAt(new FunctionWrapper<TSource, int, bool>(predicate));

        public static int CountAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, TPredicate predicate = default)
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
    }
}

