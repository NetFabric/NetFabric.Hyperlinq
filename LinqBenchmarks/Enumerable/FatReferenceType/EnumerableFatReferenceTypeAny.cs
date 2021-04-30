﻿using BenchmarkDotNet.Attributes;
using NetFabric.Hyperlinq;
using StructLinq;
using System.Linq;

namespace LinqBenchmarks.Enumerable.FatReferenceType
{
    public class EnumerableFatReferenceTypeAny: EnumerableFatReferenceTypeBenchmarkBase
    {
        [Benchmark(Baseline = true)]
        public bool Linq()
            => source.Any();

        [Benchmark]
        public bool LinqAF()
            => global::LinqAF.IEnumerableExtensionMethods.Any(source);

        [Benchmark]
        public bool StructLinq()
            => source
                .ToStructEnumerable()
                .Any();

        [Benchmark]
        public bool StructLinq_ValueDelegate()
            => source
                .ToStructEnumerable()
                .Any();

        [Benchmark]
        public bool Hyperlinq()
            => source
                .AsValueEnumerable()
                .Any();
    }
}
