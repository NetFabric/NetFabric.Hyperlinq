using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> SkipTake<TEnumerable, TEnumerator, TSource>(this TEnumerable source, long skipCount, long takeCount)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => new SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>(in source, skipCount, takeCount);

        [GenericsTypeMapping("TEnumerable", typeof(SkipTakeEnumerable<,,>))]
        [GenericsTypeMapping("TEnumerator", typeof(SkipTakeEnumerable<,,>.Enumerator))]
        public readonly struct SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>
            : IValueReadOnlyCollection<TSource, SkipTakeEnumerable<TEnumerable, TEnumerator, TSource>.Enumerator>
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly long skipCount;
            readonly long takeCount;

            internal SkipTakeEnumerable(in TEnumerable source, long skipCount, long takeCount)
            {
                this.source = source;
                (this.skipCount, this.takeCount) = Utils.SkipTake(source.Count, skipCount, takeCount);
            }

            public long Count => takeCount;

            public Enumerator GetEnumerator() => new Enumerator(in this);

            public struct Enumerator
                : IValueEnumerator<TSource>
            {
                readonly TEnumerable source;
                EnumeratorState state;
                TEnumerator enumerator;
                long skipCounter;
                long takeCounter;

                internal Enumerator(in SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> enumerable)
                {
                    source = enumerable.source;
                    skipCounter = enumerable.skipCount;
                    takeCounter = enumerable.takeCount;
                    enumerator = default;
                    state = takeCounter > 0 ? EnumeratorState.Uninitialized : EnumeratorState.Complete;
                }

                public TSource Current
                    => enumerator.Current;

                public bool MoveNext()
                {
                    switch (state)
                    {
                        case EnumeratorState.Uninitialized:
                            enumerator = (TEnumerator)source.GetEnumerator();
                            while (skipCounter > 0)
                            {
                                if (enumerator.MoveNext())
                                {
                                    skipCounter--;
                                }
                                else
                                {
                                    state = EnumeratorState.Complete;
                                    goto case EnumeratorState.Complete;
                                }
                            }                
                            state = EnumeratorState.Enumerating;
                            goto case EnumeratorState.Enumerating;
                            
                        case EnumeratorState.Enumerating:
                            if (enumerator.MoveNext())
                            {
                                takeCounter--;
                                if (takeCounter == 0)
                                    state = EnumeratorState.Complete;

                                return true;
                            }
                            state = EnumeratorState.Complete;
                            goto case EnumeratorState.Complete;

                        case EnumeratorState.Complete:
                        default:
                            return false;
                    }
                }

                public void Dispose() => enumerator.Dispose();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> Take(long count)
                => ValueReadOnlyCollection.SkipTake<TEnumerable, TEnumerator, TSource>(source, skipCount, Math.Min(takeCount, count));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Count<TEnumerable, TEnumerator, TSource>(this SkipTakeEnumerable<TEnumerable, TEnumerator, TSource> source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
            => source.Count;
    }
}