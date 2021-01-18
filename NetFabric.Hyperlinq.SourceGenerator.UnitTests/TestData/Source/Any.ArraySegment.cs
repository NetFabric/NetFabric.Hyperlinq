using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        public static bool Any<TSource>(this in ArraySegment<TSource> source)
            => source.Count != 0;

        public static bool Any<TSource>(this in ArraySegment<TSource> source, Func<TSource, bool> predicate)
            => source.Any(new FunctionWrapper<TSource, bool>(predicate));

        public static bool Any<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate = default)
            where TPredicate : struct, IFunction<TSource, bool>
            => default;
    }
}

