using BenchmarkDotNet.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class ValueEnumerableBenchmarks
    {
        RangeEnumerable source;

        [Params(0, 1_000, 100_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            source = new RangeEnumerable(Count);
        }

        [Benchmark(Baseline = true)]
        public int Enumerator() => 
            CountEnumerable<RangeEnumerable, RangeEnumerable.Enumerator, int>(source, _ => true);

        [Benchmark]
        public int ValueEnumerator() => 
            CountValueEnumerable<RangeEnumerable, RangeEnumerable.ValueEnumerator, int>(source, _ => true);

        [Benchmark]
        public int BenValueEnumerator() => 
            CountBenValueEnumerable<RangeEnumerable, RangeEnumerable.BenValueEnumerator, int>(source, _ => true);

        static int CountEnumerable<TEnumerable, TEnumerator, TSource>(TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator: IEnumerator<TSource>
        {
            var count = 0;
            using(var enumerator = (TEnumerator)source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (predicate(enumerator.Current))
                        count++;
                }
            }
            return count;
        }        

        static int CountValueEnumerable<TEnumerable, TEnumerator, TSource>(TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            var count = 0;
            using (var enumerator = source.GetValueEnumerator())
            {
                while (enumerator.TryMoveNext(out var current))
                {
                    if (predicate(current))
                        count++;
                }
            }
            return count;
        }

        static int CountBenValueEnumerable<TEnumerable, TEnumerator, TSource>(TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IBenValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IBenValueEnumerator<TSource>
        {
            var count = 0;
            using (var enumerator = source.GetValueEnumerator())
            {
                var current = enumerator.TryMoveNext(out var success);
                while (success)
                {
                    if (predicate(current))
                        count++;

                    current = enumerator.TryMoveNext(out success);
                }
            }
            return count;
        }

        public interface IBenValueEnumerator : IDisposable
        {
            bool TryMoveNext();
        }

        public interface IBenValueEnumerator<T> : IValueEnumerator
        {
            T TryMoveNext(out bool success);
        }

        public interface IBenValueEnumerable<TEnumerator>
            where TEnumerator : struct, IBenValueEnumerator
        {
            TEnumerator GetValueEnumerator();
        }

        public interface IBenValueEnumerable<T, TEnumerator>
            where TEnumerator : struct, IBenValueEnumerator<T>
        {
            TEnumerator GetValueEnumerator();
        }

        public readonly struct RangeEnumerable
            : IEnumerable<int>
            , IValueEnumerable<int, RangeEnumerable.ValueEnumerator>
            , IBenValueEnumerable<int, RangeEnumerable.BenValueEnumerator>
        {
            readonly int count;

            internal RangeEnumerable(int count)
            {
                this.count = count;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            IEnumerator<int> IEnumerable<int>.GetEnumerator() => new Enumerator(in this);
            IEnumerator IEnumerable.GetEnumerator() => new Enumerator(in this);
            ValueEnumerator IValueEnumerable<int, RangeEnumerable.ValueEnumerator>.GetValueEnumerator() => new ValueEnumerator(in this);
            BenValueEnumerator IBenValueEnumerable<int, RangeEnumerable.BenValueEnumerator>.GetValueEnumerator() => new BenValueEnumerator(in this);

            public struct Enumerator : IEnumerator<int>
            {
                readonly int count;
                int current;

                internal Enumerator(in RangeEnumerable enumerable)
                {
                    count = enumerable.count;
                    current = -1;
                }

                public int Current => current;
                object IEnumerator.Current => current;

                public bool MoveNext() => ++current < count;

                public void Reset() => throw new NotSupportedException();

                public void Dispose() { }
            }

            public struct ValueEnumerator
                : IValueEnumerator<int>
            {
                readonly int count;
                int current;

                internal ValueEnumerator(in RangeEnumerable enumerable)
                {
                    count = enumerable.count;
                    current = -1;
                }

                public bool TryMoveNext(out int current)
                {
                    current = this.current++;
                    return current < count;
                }

                public bool TryMoveNext() => ++current < count;

                public void Dispose() { }
            }

            public struct BenValueEnumerator
                : IBenValueEnumerator<int>
            {
                readonly int count;
                int current;

                internal BenValueEnumerator(in RangeEnumerable enumerable)
                {
                    count = enumerable.count;
                    current = -1;
                }

                public int TryMoveNext(out bool success)
                {
                    success = ++current < count;
                    return current;
                }

                public bool TryMoveNext() => ++current < count;

                public void Dispose() { }
            }
        }
    }
}
