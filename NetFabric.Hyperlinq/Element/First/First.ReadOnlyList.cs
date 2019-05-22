using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource First<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
            => TryFirst<TEnumerable, TSource>(source).ThrowOnEmpty();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource FirstOrDefault<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
            => TryFirst<TEnumerable, TSource>(source).DefaultOnEmpty();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource First<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
            => TryFirst<TEnumerable, TSource>(source, predicate).ThrowOnEmpty();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource FirstOrDefault<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
            => TryFirst<TEnumerable, TSource>(source, predicate).DefaultOnEmpty();

        public static (ElementResult Success, TSource Value) TryFirst<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            switch (source.Count)
            {
                case 0:
                    return (ElementResult.Empty, default);
                default:
                    return (ElementResult.Success, source[0]);
            }
        }

        public static (ElementResult Success, TSource Value) TryFirst<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            var count = source.Count;
            for (var index = 0; index < count; index++)
            {
                if (predicate(source[index]))
                    return (ElementResult.Success, source[index]);
            }

            return (ElementResult.Empty, default);
        }

        public static (int Index, TSource Value) TryFirst<TEnumerable, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            var count = source.Count;
            for (var index = 0; index < count; index++)
            {
                if (predicate(source[index], index))
                    return (index, source[index]);
            }

            return ((int)ElementResult.Empty,  default);
        }
    }
}
