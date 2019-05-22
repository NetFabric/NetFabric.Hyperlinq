using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyList
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
            => TrySingle<TEnumerable, TSource>(source).ThrowOnEmpty();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource SingleOrDefault<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
            => TrySingle<TEnumerable, TSource>(source).DefaultOnEmpty();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource Single<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
            => TrySingle<TEnumerable, TSource>(source, predicate).ThrowOnEmpty();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource SingleOrDefault<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
            => TrySingle<TEnumerable, TSource>(source, predicate).DefaultOnEmpty();

        public static (ElementResult Success, TSource Value) TrySingle<TEnumerable, TSource>(this TEnumerable source) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            switch(source.Count)
            {
                case 0:
                    return (ElementResult.Empty, default);
                case 1:
                    return (ElementResult.Success, source[0]);
                default:
                    return (ElementResult.NotSingle, default);
            }
        }

        public static (ElementResult Success, TSource Value) TrySingle<TEnumerable, TSource>(this TEnumerable source, Func<TSource, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            var count = source.Count;
            for (var index = 0; index < count; index++)
            {
                if (predicate(source[index]))
                {
                    var value = source[index];

                    for (index++; index < count; index++)
                    {
                        if (predicate(source[index]))
                            return (ElementResult.NotSingle, default);
                    }

                    return (ElementResult.Success, value);
                }
            }

            return (ElementResult.Empty, default);
        }    

        public static (int Index, TSource Value) TrySingle<TEnumerable, TSource>(this TEnumerable source, Func<TSource, long, bool> predicate) 
            where TEnumerable : IReadOnlyList<TSource>
        {
            var count = source.Count;
            for (var index = 0; index < count; index++)
            {
                if (predicate(source[index], index))
                {
                    var value = (index, source[index]);

                    for (index++; index < count; index++)
                    {
                        if (predicate(source[index], index))
                            return ((int)ElementResult.NotSingle, default);
                    }

                    return value;
                }
            }

            return ((int)ElementResult.Empty, default);
        }    
    }
}
