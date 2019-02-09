using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static TSource SingleOrDefault<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();
            if (source.Count() == 0) return default;
            if (source.Count() > 1) ThrowNotSingleSequence();

            using (var enumerator = source.GetValueEnumerator())
            {
                enumerator.TryMoveNext(out var current);
                return current;
            }

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowNotSingleSequence() => throw new InvalidOperationException(Resource.NotSingleSequence);
        }
    }
}
