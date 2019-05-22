using System;

namespace NetFabric.Hyperlinq
{
    public static partial class Utils
    {
        public static Func<TSource, bool> Combine<TSource>(Func<TSource, bool> first, Func<TSource, bool> second) => 
            item => first(item) && second(item);

        public static Func<TSource, long, bool> Combine<TSource>(Func<TSource, long, bool> first, Func<TSource, bool> second) => 
            (item, index) => first(item, index) && second(item);

        public static Func<TSource, long, bool> Combine<TSource>(Func<TSource, bool> first, Func<TSource, long, bool> second) => 
            (item, index) => first(item) && second(item, index);

        public static Func<TSource, long, bool> Combine<TSource>(Func<TSource, long, bool> first, Func<TSource, long, bool> second) => 
            (item, index) => first(item, index) && second(item, index);

        public static Func<TSource, TTarget> Combine<TSource, TMiddle, TTarget>(Func<TSource, TMiddle> first, Func<TMiddle, TTarget> second) => 
            item => second(first(item));

        public static Func<TSource, long, TTarget> Combine<TSource, TMiddle, TTarget>(Func<TSource, long, TMiddle> first, Func<TMiddle, TTarget> second) => 
            (item, index) => second(first(item, index));

        public static Func<TSource, long, TTarget> Combine<TSource, TMiddle, TTarget>(Func<TSource, TMiddle> first, Func<TMiddle, long, TTarget> second) => 
            (item, index) => second(first(item), index);

        public static Func<TSource, long, TTarget> Combine<TSource, TMiddle, TTarget>(Func<TSource, long, TMiddle> first, Func<TMiddle, long, TTarget> second) => 
            (item, index) => second(first(item, index), index);
    }
}