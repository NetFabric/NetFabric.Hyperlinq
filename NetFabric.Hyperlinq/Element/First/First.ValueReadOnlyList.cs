using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyListExtensions
    {

        [GeneratorIgnore(false)]
        internal static Option<TSource> First<TList, TSource>(this TList source)
            where TList : struct, IReadOnlyList<TSource>
            => source.First<TList, TSource>(0, source.Count);

        static Option<TSource> First<TList, TSource>(this TList source, int offset, int count) 
            where TList : struct, IReadOnlyList<TSource>
            => count switch
            {
                0 => Option.None,
                _ => Option.Some(source[offset]),
            };


        static Option<TSource> First<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            var end = offset + count;
            for (var index = offset; index < end; index++)
            {
                var item = source[index];
                if (predicate.Invoke(item))
                    return Option.Some(item);
            }
            return Option.None;
        }


        static Option<TSource> FirstAt<TList, TSource, TPredicate>(this TList source, TPredicate predicate, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            if (offset is 0)
            {
                for (var index = 0; index < count; index++)
                {
                    var item = source[index];
                    if (predicate.Invoke(item, index))
                        return Option.Some(item);
                }
            }
            else
            {
                for (var index = 0; index < count; index++)
                {
                    var item = source[index + offset];
                    if (predicate.Invoke(item, index))
                        return Option.Some(item);
                }
            }
            return Option.None;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> First<TList, TSource, TResult, TSelector>(this TList source, TSelector selector, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => count switch
            {
                0 => Option.None,
                _ => Option.Some(selector.Invoke(source[offset])),
            };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult> FirstAt<TList, TSource, TResult, TSelector>(this TList source, TSelector selector, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            => count switch
            {
                0 => Option.None,
                _ => Option.Some(selector.Invoke(source[offset], 0)),
            };


        static Option<TResult> First<TList, TSource, TResult, TPredicate, TSelector>(this TList source, TPredicate predicate, TSelector selector, int offset, int count)
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            var end = offset + count;
            for (var index = offset; index < end; index++)
            {
                if (predicate.Invoke(source[index]))
                    return Option.Some(selector.Invoke(source[index]));
            }
            return Option.None;
        }
    }
}
