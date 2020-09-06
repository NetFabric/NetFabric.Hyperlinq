using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TSource> ElementAt<TSource>(this ReadOnlySpan<TSource> source, int index) 
            => index < 0 || index >= source.Length 
                ? Option.None 
                : Option.Some(source[index]);

        
        static Option<TSource> ElementAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, int index, TPredicate predicate) 
            where TPredicate : struct, IPredicate<TSource>
        {
            if (index >= 0)
            {
                for (var sourceIndex = 0; sourceIndex < source.Length; sourceIndex++)
                {
                    var item = source[sourceIndex];
                    if (predicate.Invoke(item) && index-- == 0)
                        return Option.Some(item);
                }
            }
            return Option.None;
        }

        
        static Option<TSource> ElementAtAt<TSource, TPredicate>(this ReadOnlySpan<TSource> source, int index, TPredicate predicate) 
            where TPredicate : struct, IPredicateAt<TSource>
        {
            if (index >= 0)
            {
                for (var sourceIndex = 0; sourceIndex < source.Length; sourceIndex++)
                {
                    var item = source[sourceIndex];
                    if (predicate.Invoke(item, sourceIndex) && index-- == 0)
                        return Option.Some(item);
                }
            }
            return Option.None;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Option<TResult?> ElementAt<TSource, TResult>(this ReadOnlySpan<TSource> source, int index, NullableSelector<TSource, TResult> selector) 
            => index < 0 || index >= source.Length 
                ? Option.None 
                : Option.Some(selector(source[index]));

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Option<TResult?> ElementAt<TSource, TResult>(this ReadOnlySpan<TSource> source, int index, NullableSelectorAt<TSource, TResult> selector) 
            => index < 0 || index >= source.Length 
                ? Option.None 
                : Option.Some(selector(source[index], index));

        
        static Option<TResult?> ElementAt<TSource, TResult, TPredicate>(this ReadOnlySpan<TSource> source, int index, TPredicate predicate, NullableSelector<TSource, TResult> selector) 
            where TPredicate : struct, IPredicate<TSource>
        {
            if (index >= 0)
            {
                for (var sourceIndex = 0; sourceIndex < source.Length; sourceIndex++)
                {
                    var item = source[sourceIndex];
                    if (predicate.Invoke(item) && index-- == 0)
                        return Option.Some(selector(item));
                }
            }
            return Option.None;
        }
    }
}
