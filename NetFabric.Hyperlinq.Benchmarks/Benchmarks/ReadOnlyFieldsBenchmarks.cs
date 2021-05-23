using BenchmarkDotNet.Attributes;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NetFabric.Hyperlinq.Benchmarks.Benchmarks
{
    public class ReadOnlyFieldsBenchmarks
    {
        const int seed = 2982;
        int[]? array;

        [Params(1_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup() 
            => array = Utils.GetRandomValues(seed, Count);

        [Benchmark(Baseline = true)]
        public int Baseline()
        {
            var enumerator = new Enumerator<int>(array!);
            var sum = 0;
            while (enumerator.MoveNext())
                sum += enumerator.Current;
            return sum;
        }

        [Benchmark]
        public int ReadOnlyCurrent()
        {
            var enumerator = new ReadOnlyCurrentEnumerator<int>(array!);
            var sum = 0;
            while (enumerator.MoveNext())
                sum += enumerator.Current;
            return sum;
        }

        [Benchmark]
        public int ReadOnlyField()
        {
            var enumerator = new ReadOnlyFieldEnumerator<int>(array!);
            var sum = 0;
            while (enumerator.MoveNext())
                sum += enumerator.Current;
            return sum;
        }
        
        [StructLayout(LayoutKind.Auto)]
        public struct Enumerator<TSource>
        {
            // ReSharper disable once FieldCanBeMadeReadOnly.Local
            TSource[] source;
            int index;

            public Enumerator(TSource[] source) 
            {
                this.source = source;
                index = -1;
            }

            public TSource Current
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext()
                => ++index < source.Length;
        } 
        
        [StructLayout(LayoutKind.Auto)]
        public struct ReadOnlyCurrentEnumerator<TSource>
        {
            // ReSharper disable once FieldCanBeMadeReadOnly.Local
            TSource[] source;
            int index;

            public ReadOnlyCurrentEnumerator(TSource[] source) 
            {
                this.source = source;
                index = -1;
            }

            public readonly TSource Current
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext()
                => ++index < source.Length;
        } 
        
        [StructLayout(LayoutKind.Auto)]
        public struct ReadOnlyFieldEnumerator<TSource>
        {
            readonly TSource[] source;
            int index;

            public ReadOnlyFieldEnumerator(TSource[] source) 
            {
                this.source = source;
                index = -1;
            }

            public readonly TSource Current
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext()
                => ++index < source.Length;
        } 
    }
}