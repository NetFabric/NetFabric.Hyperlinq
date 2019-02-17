using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

#if EXPRESSION_TREES
            return ToArrayMethod<TEnumerable, TSource>.Invoke(source);
#else
            var count = source.Count;
            var array = new TSource[count];
            var index = 0;
            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    array[index] = enumerator.Current;
                    index++;
                }
            }
            return array;
#endif
        }

        static class ToArrayMethod<TEnumerable, TSource>
            where TEnumerable : IEnumerable<TSource>
        {
            public static Func<TEnumerable, TSource[]> Invoke { get; } = Create();

            public static Func<TEnumerable, TSource[]> Create()
            {
                var enumerable = Expression.Parameter(typeof(TEnumerable), "enumerable");
                var count = Expression.Variable(typeof(int), "count");
                var array = Expression.Variable(typeof(TSource[]), "array");
                var index = Expression.Variable(typeof(int), "index");
                var current = Expression.Variable(typeof(TSource), "current");

                var body = Expression.Block(new[] { enumerable, count, array, index, current },
                    Expression.Assign(count, Expression.Property(enumerable, "Count")),
                    Expression.Assign(array, Expression.NewArrayBounds(typeof(TSource), count)),
                    Expression.Assign(index, Expression.Constant(0)),
                    ExpressionEx.ForEach( enumerable, current,
                        Expression.Block(new[] { index, current }, 
                            Expression.Assign(Expression.ArrayIndex(array, index), current),
                            Expression.Assign(index, Expression.Increment(index)))),
                    array);

                return Expression.Lambda<Func<TEnumerable, TSource[]>>(body, enumerable).Compile();        
            }
        }
    }
}
