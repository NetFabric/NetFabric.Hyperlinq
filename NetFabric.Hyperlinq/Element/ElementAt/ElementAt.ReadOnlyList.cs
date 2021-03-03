using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {

        static Option<TSource> ElementAt<TList, TSource>(this TList source, int index)
            where TList : struct, IReadOnlyList<TSource>
            => source.ElementAt<TList, TSource>(index,0, source.Count);

        static Option<TSource> ElementAt<TList, TSource>(this TList source, int index, int offset, int count) 
            where TList : struct, IReadOnlyList<TSource>
            => index < 0 || index >= count 
                ? Option.None 
                : Option.Some(source[index + offset]);


        static Option<TSource> ElementAt<TList, TSource, TPredicate>(this TList source, int index, TPredicate predicate, int offset, int count) 
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
        {
            if (index >= 0)
            {
                var end = offset + count;
                for (var sourceIndex = offset; sourceIndex < end; sourceIndex++)
                {
                    var item = source[sourceIndex];
                    if (predicate.Invoke(item) && index-- is 0)
                        return Option.Some(item);
                }
            }
            return Option.None;
        }
        
        static Option<TSource> ElementAtAt<TList, TSource, TPredicate>(this TList source, int index, TPredicate predicate, int offset, int count) 
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            if (index >= 0)
            {
                if (offset is 0)
                {
                    for (var sourceIndex = 0; sourceIndex < count; sourceIndex++)
                    {
                        var item = source[sourceIndex];
                        if (predicate.Invoke(item, sourceIndex) && index-- is 0)
                            return Option.Some(item);
                    }
                }
                else
                {
                    for (var sourceIndex = 0; sourceIndex < count; sourceIndex++)
                    {
                        var item = source[sourceIndex + offset];
                        if (predicate.Invoke(item, sourceIndex) && index-- is 0)
                            return Option.Some(item);
                    }
                }
            }
            return Option.None;
        }
        
        static Option<TResult> ElementAt<TList, TSource, TResult, TSelector>(this TList source, int index, TSelector selector, int offset, int count) 
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
            => index < 0 || index >= count 
                ? Option.None
                : Option.Some(selector.Invoke(source[index + offset]));


        static Option<TResult> ElementAtAt<TList, TSource, TResult, TSelector>(this TList source, int index, TSelector selector, int offset, int count) 
            where TList : struct, IReadOnlyList<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
            => index < 0 || index >= count 
                ? Option.None 
                : Option.Some(selector.Invoke(source[index + offset], index));

        static Option<TResult> ElementAt<TList, TSource, TResult, TPredicate, TSelector>(this TList source, int index, TPredicate predicate, TSelector selector, int offset, int count) 
            where TList : struct, IReadOnlyList<TSource>
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (index >= 0)
            {
                var end = offset + count;
                for (var sourceIndex = offset; sourceIndex < end; sourceIndex++)
                {
                    var item = source[sourceIndex];
                    if (predicate.Invoke(item) && index-- is 0)
                        return Option.Some(selector.Invoke(item));
                }
            }
            return Option.None;
        }
    }
}
