using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    static partial class ValueReadOnlyCollectionExtensions
    {
        public static int IndexOf<TEnumerable, TEnumerator, TSource>(TEnumerable source, TSource item)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            if (source.Count is 0)
                return -1;

            using var enumerator = source.GetEnumerator();
            if (Utils.IsValueType<TSource>())
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                {
                    var current = enumerator.Current;
                    if (EqualityComparer<TSource>.Default.Equals(current, item))
                        return index;
                }
            }
            else
            {
                var defaultComparer = EqualityComparer<TSource>.Default;
                for (var index = 0; enumerator.MoveNext(); index++)
                {
                    var current = enumerator.Current;
                    if (defaultComparer.Equals(current, item))
                        return index;
                }
            }

            return -1;
        }

        public static int IndexOf<TEnumerable, TEnumerator, TSource, TResult, TSelector>(TEnumerable source, TResult item, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, TResult>
        {
            if (source.Count is 0)
                return -1;

            using var enumerator = source.GetEnumerator();
            if (Utils.IsValueType<TSource>())
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                {
                    var current = enumerator.Current;
                    if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(current), item))
                        return index;
                }
            }
            else
            {
                var defaultComparer = EqualityComparer<TResult>.Default;
                for (var index = 0; enumerator.MoveNext(); index++)
                {
                    var current = enumerator.Current;
                    if (defaultComparer.Equals(selector.Invoke(current), item))
                        return index;
                }
            }

            return -1;
        }


        public static int IndexOfAt<TEnumerable, TEnumerator, TSource, TResult, TSelector>(TEnumerable source, TResult item, TSelector selector)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            where TSelector : struct, IFunction<TSource, int, TResult>
        {
            if (source.Count is 0)
                return -1;

            using var enumerator = source.GetEnumerator();
            if (Utils.IsValueType<TResult>())
            {
                for (var index = 0; enumerator.MoveNext(); index++)
                {
                    var current = enumerator.Current;
                    if (EqualityComparer<TResult>.Default.Equals(selector.Invoke(current, index), item))
                        return index;
                }
            }
            else
            {
                var defaultComparer = EqualityComparer<TResult>.Default;

                for (var index = 0; enumerator.MoveNext(); index++)
                {
                    var current = enumerator.Current;
                    if (defaultComparer.Equals(selector.Invoke(current, index), item))
                        return index;
                }
            }
            return -1;
        }
    }
}
