using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource First<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => TryFirst<TEnumerable, TEnumerator, TSource>(source).ThrowOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource FirstOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => TryFirst<TEnumerable, TEnumerator, TSource>(source).DefaultOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource First<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate).ThrowOnEmpty();

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource FirstOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => TryFirst<TEnumerable, TEnumerator, TSource>(source, predicate).DefaultOnEmpty();

        [Pure]
        public static (ElementResult Success, TSource Value) TryFirst<TEnumerable, TEnumerator, TSource>(this TEnumerable source) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using (var enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext())
                    return (ElementResult.Success, enumerator.Current);
            }   

            return (ElementResult.Empty, default);
        }

        [Pure]
        public static (ElementResult Success, TSource Value) TryFirst<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (predicate(enumerator.Current))
                        return (ElementResult.Success, enumerator.Current);
                }
            }   

            return (ElementResult.Empty, default);
        }

        [Pure]
        public static (int Index, TSource Value) TryFirst<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, bool> predicate) 
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            using (var enumerator = source.GetEnumerator())
            {
                checked
                {
                    for (var index = 0; enumerator.MoveNext(); index++)
                    {
                        if (predicate(enumerator.Current, index))
                            return (index, enumerator.Current);
                    }
                }
            }   

            return ((int)ElementResult.Empty,  default);
        }    
    }
}
