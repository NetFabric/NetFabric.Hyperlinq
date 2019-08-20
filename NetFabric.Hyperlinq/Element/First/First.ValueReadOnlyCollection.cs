using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource First<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => TryFirst<TEnumerable, TEnumerator, TSource>(source).ThrowOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource FirstOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => TryFirst<TEnumerable, TEnumerator, TSource>(source).DefaultOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource First<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate).ThrowOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource FirstOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate).DefaultOnEmpty();

        [Pure]
        public static (ElementResult Success, TSource Value) TryFirst<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source.Count != 0)
            {
                foreach (var item in source)
                    return (ElementResult.Success, item);
            }

            return (ElementResult.Empty, default);
        }

        [Pure]
        public static (ElementResult Success, TSource Value) TryFirst<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source.Count != 0)
            {
                foreach (var item in source)
                {
                    if (predicate(item))
                        return (ElementResult.Success, item);
                }
            }

            return (ElementResult.Empty, default);
        }

        [Pure]
        public static (int Index, TSource Value) TryFirst<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate) 
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source.Count != 0)
            {
                var index = 0;
                foreach (var item in source)
                {
                    if (predicate(item, index))
                        return (index, item);

                    checked { index++; }
                }
            }

            return ((int)ElementResult.Empty,  default);
        }    
    }
}