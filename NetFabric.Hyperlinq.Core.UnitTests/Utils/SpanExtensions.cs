using System;
using System.Buffers;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.UnitTests
{
    static class SpanExtensions
    {
        public static bool SequenceEqual<T>(this IMemoryOwner<T> first, IEnumerable<T> second, IEqualityComparer<T>? comparer = default)
            => SequenceEqual((ReadOnlySpan<T>)first.Memory.Span, second, comparer);

        public static bool SequenceEqual<T>(this Memory<T> first, IEnumerable<T> second, IEqualityComparer<T>? comparer = default)
            => SequenceEqual((ReadOnlySpan<T>)first.Span, second, comparer);

        public static bool SequenceEqual<T>(this ReadOnlyMemory<T> first, IEnumerable<T> second, IEqualityComparer<T>? comparer = default)
            => SequenceEqual(first.Span, second, comparer);

        public static bool SequenceEqual<T>(this Span<T> first, IEnumerable<T> second, IEqualityComparer<T>? comparer = default)
            => SequenceEqual((ReadOnlySpan<T>)first, second, comparer);

        public static bool SequenceEqual<T>(this ReadOnlySpan<T> first, IEnumerable<T> second, IEqualityComparer<T>? comparer = default)
        {
            if (Utils.IsValueType<T>() && comparer.UseDefaultComparer())
            {
                using var enumerator = second.GetEnumerator();
                for (var index = 0; true; index++)
                {
                    var resultEnded = index == first.Length;
                    var expectedEnded = !enumerator.MoveNext();

                    if (resultEnded != expectedEnded)
                        return false;

                    if (resultEnded)
                        return true;

                    if (!EqualityComparer<T>.Default.Equals(first[index], enumerator.Current))
                        return false;
                }
            }
            else
            {
                comparer ??= EqualityComparer<T>.Default;

                using var enumerator = second.GetEnumerator();
                for (var index = 0; true; index++)
                {
                    var resultEnded = index == first.Length;
                    var expectedEnded = !enumerator.MoveNext();

                    if (resultEnded != expectedEnded)
                        return false;

                    if (resultEnded)
                        return true;

                    if (!comparer.Equals(first[index], enumerator.Current))
                        return false;
                }
            }
        }
    }
}
