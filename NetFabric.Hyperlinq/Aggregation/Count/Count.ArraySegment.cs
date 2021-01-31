using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Count<TSource>(this in ArraySegment<TSource> source)
            => source.Count;

        static int Count<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate: struct, IFunction<TSource, bool>
        {
            var counter = 0;
            if (source.Any())
            {
                var array = source.Array!;
                var start = source.Offset;
                var end = start + source.Count;
                for (var index = start; index < end; index++)
                {
                    var item = array[index];
                    counter += predicate.Invoke(item).AsByte();
                }
            }
            return counter;
        }

        static int CountRef<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunctionIn<TSource, bool>
        {
            var counter = 0;
            if (source.Any())
            {
                var array = source.Array!;
                var start = source.Offset;
                var end = start + source.Count;
                for (var index = start; index < end; index++)
                {
                    var item = array[index];
                    counter += predicate.Invoke(in item).AsByte();
                }
            }
            return counter;
        }

        static int CountAt<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate: struct, IFunction<TSource, int, bool>
        {
            var counter = 0;
            if (source.Any())
            {
                var array = source.Array!;
                var start = source.Offset;
                var end = source.Count;
                if (start is 0)
                {
                    for (var index = 0; index < end; index++)
                    {
                        var item = array[index];
                        counter += predicate.Invoke(item, index).AsByte();
                    }
                }
                else
                {
                    for (var index = 0; index < end; index++)
                    {
                        var item = array[index + start];
                        counter += predicate.Invoke(item, index).AsByte();
                    }
                }
            }
            return counter;
        }

        static int CountAtRef<TSource, TPredicate>(this in ArraySegment<TSource> source, TPredicate predicate)
            where TPredicate : struct, IFunctionIn<TSource, int, bool>
        {
            var counter = 0;
            if (source.Any())
            {
                var array = source.Array!;
                var start = source.Offset;
                var end = source.Count;
                if (start is 0)
                {
                    for (var index = 0; index < end; index++)
                    {
                        var item = array[index];
                        counter += predicate.Invoke(in item, index).AsByte();
                    }
                }
                else
                {
                    for (var index = 0; index < end; index++)
                    {
                        var item = array[index + start];
                        counter += predicate.Invoke(in item, index).AsByte();
                    }
                }
            }
            return counter;
        }
    }
}

