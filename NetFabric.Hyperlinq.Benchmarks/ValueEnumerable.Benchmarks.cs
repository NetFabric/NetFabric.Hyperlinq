using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
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

        [BenchmarkCategory("Count")]
        [Benchmark(Baseline = true)]
        public int Enumerator() => 
            CountEnumerable<RangeEnumerable, RangeEnumerable.Enumerator, int>(source);

        [BenchmarkCategory("Count_Predicate")]
        [Benchmark(Baseline = true)]
        public int Enumerator_Predicate() => 
            CountEnumerable<RangeEnumerable, RangeEnumerable.Enumerator, int>(source, _ => true);

        [BenchmarkCategory("Count")]
        [Benchmark]
        public int MyEnumerator() => 
            CountMyEnumerable<RangeEnumerable, RangeEnumerable.MyEnumerator, int>(source);

        [BenchmarkCategory("Count_Predicate")]
        [Benchmark]
        public int MyEnumerator_Predicate() => 
            CountMyEnumerable<RangeEnumerable, RangeEnumerable.MyEnumerator, int>(source, _ => true);

        [BenchmarkCategory("Count")]
        [Benchmark]
        public int BenValueEnumerator() => 
            CountBenValueEnumerable<RangeEnumerable, RangeEnumerable.BenValueEnumerator, int>(source);

        [BenchmarkCategory("Count_Predicate")]
        [Benchmark]
        public int BenValueEnumerator_Predicate() => 
            CountBenValueEnumerable<RangeEnumerable, RangeEnumerable.BenValueEnumerator, int>(source, _ => true);

        [BenchmarkCategory("Count")]
        [Benchmark]
        public int MyValueEnumerator() => 
            CountMyValueEnumerable<RangeEnumerable, RangeEnumerable.MyValueEnumerator, int>(source);

        [BenchmarkCategory("Count_Predicate")]
        [Benchmark]
        public int MyValueEnumerator_Predicate() => 
            CountMyValueEnumerable<RangeEnumerable, RangeEnumerable.MyValueEnumerator, int>(source, _ => true);

        static int CountEnumerable<TEnumerable, TEnumerator, TSource>(TEnumerable source)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            var count = 0;
            using(var enumerator = (TEnumerator)source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                    count++;
            }
            return count;
        }        

        static int CountEnumerable<TEnumerable, TEnumerator, TSource>(TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IEnumerable<TSource>
            where TEnumerator : IEnumerator<TSource>
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

        static int CountMyEnumerable<TEnumerable, TEnumerator, TSource>(TEnumerable source)
            where TEnumerable : IMyEnumerable<TSource>
            where TEnumerator : IMyEnumerator<TSource>
        {
            var count = 0;
            var enumerator = (TEnumerator)source.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                    count++;
            }
            finally
            {
                enumerator.Dispose();
            }
            return count;
        }        

        static int CountMyEnumerable<TEnumerable, TEnumerator, TSource>(TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IMyEnumerable<TSource>
            where TEnumerator : IMyEnumerator<TSource>
        {
            var count = 0;
            var enumerator = (TEnumerator)source.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    if (predicate(enumerator.Current))
                        count++;
                }
            }
            finally
            {
                enumerator.Dispose();
            }
            return count;
        }        

        static int CountBenValueEnumerable<TEnumerable, TEnumerator, TSource>(TEnumerable source)
            where TEnumerable : IBenValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IBenValueEnumerator<TSource>
        {
            var count = 0;
            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.TryMoveNext())
                    count++;
            }
            return count;
        }

        static int CountBenValueEnumerable<TEnumerable, TEnumerator, TSource>(TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IBenValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IBenValueEnumerator<TSource>
        {
            var count = 0;
            using (var enumerator = source.GetEnumerator())
            {
                var current = enumerator.TryGetNext(out var success);
                while (success)
                {
                    if (predicate(current))
                        count++;

                    current = enumerator.TryGetNext(out success);
                }
            }
            return count;
        }

        static int CountMyValueEnumerable<TEnumerable, TEnumerator, TSource>(TEnumerable source)
            where TEnumerable : IMyValueEnumerable<TEnumerator, TSource>
            where TEnumerator : struct, IMyValueEnumerator<TSource>
        {
            var count = 0;
            using(var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                    count++;
            }
            return count;
        }

        static int CountMyValueEnumerable<TEnumerable, TEnumerator, TSource>(TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IMyValueEnumerable<TEnumerator, TSource>
            where TEnumerator : struct, IMyValueEnumerator<TSource>
        {
            var count = 0;
            using(var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (predicate(enumerator.Current))
                        count++;
                }
            }
            return count;
        }

        public interface IMyEnumerator<T> : IDisposable
        {
            T Current { get; }
            bool MoveNext();
        }

        public interface IMyEnumerable<T>
        {
            IMyEnumerator<T> GetEnumerator();
        }

        public interface IBenValueEnumerator : IDisposable
        {
            bool TryMoveNext();
        }

        public interface IBenValueEnumerator<T> : IBenValueEnumerator
        {
            T TryGetNext(out bool success);
        }

        public interface IBenValueEnumerable<TEnumerator>
            where TEnumerator : struct, IBenValueEnumerator
        {
            TEnumerator GetEnumerator();
        }

        public interface IBenValueEnumerable<T, TEnumerator>
            where TEnumerator : struct, IBenValueEnumerator<T>
        {
            TEnumerator GetEnumerator();
        }

        public interface IMyValueEnumerator<out T> : IDisposable
        {
            T Current { get; }
            bool MoveNext();
        }

        public interface IMyValueEnumerable<TEnumerator, out T>
            where TEnumerator : struct, IMyValueEnumerator<T>
        {
            TEnumerator GetEnumerator();
        }

        public readonly struct RangeEnumerable
            : IEnumerable<int>
            , IMyEnumerable<int>
            , IBenValueEnumerable<int, RangeEnumerable.BenValueEnumerator>
            , IMyValueEnumerable<RangeEnumerable.MyValueEnumerator, int>
        {
            readonly int count;

            internal RangeEnumerable(int count)
            {
                this.count = count;
            }

            readonly IEnumerator<int> IEnumerable<int>.GetEnumerator() => new Enumerator(count);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(count);

            readonly IMyEnumerator<int> IMyEnumerable<int>.GetEnumerator() => new MyEnumerator(count);

            readonly BenValueEnumerator IBenValueEnumerable<int, RangeEnumerable.BenValueEnumerator>.GetEnumerator() => new BenValueEnumerator(count);

            readonly MyValueEnumerator IMyValueEnumerable<RangeEnumerable.MyValueEnumerator, int>.GetEnumerator() => new MyValueEnumerator(count);

            public struct Enumerator : IEnumerator<int>
            {
                readonly int count;
                int current;

                internal Enumerator(int count)
                {
                    this.count = count;
                    current = -1;
                }

                public readonly int Current => current;
                readonly object IEnumerator.Current => current;

                public bool MoveNext() => ++current < count;

                public readonly void Reset() => throw new NotSupportedException();

                public readonly void Dispose() { }
            }

            public struct MyEnumerator : IMyEnumerator<int>
            {
                readonly int count;
                int current;

                internal MyEnumerator(int count)
                {
                    this.count = count;
                    current = -1;
                }

                public readonly int Current => current;

                public bool MoveNext() => ++current < count;

                public readonly void Dispose() { }
            }

            public struct BenValueEnumerator : IBenValueEnumerator<int>
            {
                readonly int count;
                int current;

                internal BenValueEnumerator(int count)
                {
                    this.count = count;
                    current = -1;
                }

                public bool TryMoveNext() => ++current < count;

                public int TryGetNext(out bool success)
                {
                    success = ++current < count;
                    if (success) 
                        return current;

                    return default;
                }

                public readonly void Dispose() { }
            }

            public struct MyValueEnumerator : IMyValueEnumerator<int>
            {
                readonly int count;
                int current;

                internal MyValueEnumerator(int count)
                {
                    this.count = count;
                    current = -1;
                }

                public readonly int Current => current;

                public bool MoveNext() => ++current < count;

                public readonly void Dispose() { }
            }
        }
    }
}
