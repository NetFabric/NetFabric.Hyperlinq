namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static AsValueReadOnlyListEnumerable<TSource> AsValueReadOnlyList<TSource>(this TSource[] source)
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            return new AsValueReadOnlyListEnumerable<TSource>(source);
        }

        public readonly struct AsValueReadOnlyListEnumerable<TSource>
            : IValueReadOnlyList<TSource, AsValueReadOnlyListEnumerable<TSource>.Enumerator>
        {
            readonly TSource[] source;

            internal AsValueReadOnlyListEnumerable(TSource[] source)
            {
                this.source = source;
            }

            public Enumerator GetValueEnumerator() => new Enumerator(this);

            public int Count() => source.Length;

            public ref readonly TSource this[int index] => ref source[index];
            TSource IValueReadOnlyList<TSource, AsValueReadOnlyListEnumerable<TSource>.Enumerator>.this[int index] => source[index];

            public struct Enumerator
                : IValueEnumerator<TSource>
            {
                readonly TSource[] source;
                readonly int count;
                int index;

                internal Enumerator(AsValueReadOnlyListEnumerable<TSource> enumerable)
                {
                    this.source = enumerable.source;
                    count = this.source.Length;
                    index = -1;
                }

                public bool TryMoveNext(out TSource current)
                {
                    if (++index < count)
                    {
                        current = source[index];
                        return true;
                    }
                    current = default;
                    return false;
                }

                public bool TryMoveNext() => ++index < count;

                public void Dispose() { }
            }
        }
    }
}
