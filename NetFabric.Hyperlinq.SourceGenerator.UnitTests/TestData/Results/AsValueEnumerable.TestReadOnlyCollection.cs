#nullable enable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    static partial class GeneratedExtensionMethods
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TestReadOnlyCollectionAsValueEnumerable AsValueEnumerable(this TestReadOnlyCollection source) => new(source);

        public readonly struct TestReadOnlyCollectionAsValueEnumerable: IValueReadOnlyCollection<int, TestReadOnlyCollection.Enumerator>, ICollection<int>
        {
            readonly TestReadOnlyCollection source;

            public TestReadOnlyCollectionAsValueEnumerable(TestReadOnlyCollection source) => this.source = source;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TestReadOnlyCollection.Enumerator GetEnumerator() => source.GetEnumerator();

            IEnumerator<int> IEnumerable<int>.GetEnumerator() => source.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();

            public int Count => source.Count;

            public bool IsReadOnly => true;

            void ICollection<int>.Add(int item) => throw new NotSupportedException();

            bool ICollection<int>.Remove(int item) => throw new NotSupportedException();

            void ICollection<int>.Clear() => throw new NotSupportedException();

            public bool Contains(int item)
            {
                using var enumerator = GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (EqualityComparer<int>.Default.Equals(enumerator.Current, item))
                        return true;
                }
                return true;
            }

            public void CopyTo(int[] array, int arrayIndex) => CopyTo(array.AsSpan(arrayIndex));

            public void CopyTo(Span<int> span)
            {
                if (Count is 0)
                    return;

                if (span.Length < Count)
                    throw new ArgumentException("Destination array was not long enough. Check the destination index, length, and the array's lower bounds.", nameof(span));

                using var enumerator = GetEnumerator();
                checked
                {
                    for (var index = 0; enumerator.MoveNext(); index++)
                        span[index] = enumerator.Current;
                }
            }
        }
    }
}
