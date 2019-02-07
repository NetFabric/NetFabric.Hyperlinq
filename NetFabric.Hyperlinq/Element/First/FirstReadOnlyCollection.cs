using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static TSource First<TReadOnlyCollection, TEnumerator, TSource>(this TReadOnlyCollection source) 
            where TReadOnlyCollection : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowSourceNull();
            if (source.Count == 0) ThrowEmptySequence();

            using (var enumerator = (TEnumerator)source.GetEnumerator())
            {
                enumerator.MoveNext();
                return enumerator.Current;
            }

            void ThrowSourceNull() => throw new ArgumentNullException(nameof(source));
            void ThrowEmptySequence() => throw new InvalidOperationException(Resource.EmptySequence);
        }
    }
}
