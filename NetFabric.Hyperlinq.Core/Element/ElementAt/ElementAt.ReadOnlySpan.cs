using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TSource> ElementAt<TSource>(this ReadOnlySpan<TSource> source, int index) 
            => index < 0 || index >= source.Length 
                ? Option.None 
                : Option.Some(source[index]);

        

        static Option<TSource> ElementAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, int index, TPredicate predicate) 
            where TPredicate : struct, IFunction<TSource, bool>
        {
            if (index >= 0)
            {
                foreach (var item in source)
                {
                    if (predicate.Invoke(item) && index-- is 0)
                        return Option.Some(item);
                }
            }
            return Option.None;
        }

        

        static Option<TSource> ElementAtAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, int index, TPredicate predicate) 
            where TPredicate : struct, IFunction<TSource, int, bool>
        {
            if (index >= 0)
            {
                for (var sourceIndex = 0; sourceIndex < source.Length; sourceIndex++)
                {
                    var item = source[sourceIndex];
                    if (predicate.Invoke(item, sourceIndex) && index-- is 0)
                        return Option.Some(item);
                }
            }
            return Option.None;
        }

        

        static Option<TResult> ElementAt<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, int index, TSelector selector) 
            where TSelector : struct, IFunction<TSource, TResult>
            => index < 0 || index >= source.Length 
                ? Option.None 
                : Option.Some(selector.Invoke(source[index]));

        

        static Option<TResult> ElementAtAt<TSource, TResult, TSelector>(this ReadOnlySpan<TSource> source, int index, TSelector selector) 
            where TSelector : struct, IFunction<TSource, int, TResult>
            => index < 0 || index >= source.Length 
                ? Option.None 
                : Option.Some(selector.Invoke(source[index], index));

        

        static Option<TResult> ElementAt<TSource, TResult, TPredicate, TSelector>(this ReadOnlySpan<TSource> source, int index, TPredicate predicate, TSelector selector) 
            where TPredicate : struct, IFunction<TSource, bool>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (index >= 0)
            {
                foreach (var item in source)
                {
                    if (predicate.Invoke(item) && index-- is 0)
                        return Option.Some(selector.Invoke(item));
                }
            }
            return Option.None;
        }
    }
}
