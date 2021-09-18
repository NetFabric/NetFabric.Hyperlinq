## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta46](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta46)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1417) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.1.21458.32
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |  1.649 μs | 0.0185 μs | 0.0154 μs |      baseline |         |  5.5237 |     11 KB |
|              ForeachLoop |   100 |  1.766 μs | 0.0100 μs | 0.0093 μs |  1.07x slower |   0.01x |  5.5237 |     11 KB |
|                     Linq |   100 |  1.924 μs | 0.0084 μs | 0.0079 μs |  1.17x slower |   0.01x |  4.0035 |      8 KB |
|               LinqFaster |   100 |  2.123 μs | 0.0130 μs | 0.0121 μs |  1.29x slower |   0.01x |  5.5237 |     11 KB |
|             LinqFasterer |   100 |  2.056 μs | 0.0141 μs | 0.0132 μs |  1.25x slower |   0.02x |  6.3934 |     13 KB |
|                   LinqAF |   100 |  3.132 μs | 0.0226 μs | 0.0211 μs |  1.90x slower |   0.02x |  5.5122 |     11 KB |
|            LinqOptimizer |   100 | 62.038 μs | 0.6779 μs | 0.6009 μs | 37.62x slower |   0.56x | 73.9746 |    155 KB |
|                 SpanLinq |   100 |  2.368 μs | 0.0177 μs | 0.0165 μs |  1.44x slower |   0.02x |  5.5237 |     11 KB |
|                  Streams |   100 |  2.829 μs | 0.0158 μs | 0.0132 μs |  1.72x slower |   0.02x |  5.7716 |     12 KB |
|               StructLinq |   100 |  1.507 μs | 0.0215 μs | 0.0201 μs |  1.10x faster |   0.02x |  1.7109 |      4 KB |
| StructLinq_ValueDelegate |   100 |  1.116 μs | 0.0023 μs | 0.0018 μs |  1.48x faster |   0.01x |  1.6575 |      3 KB |
|                Hyperlinq |   100 |  1.812 μs | 0.0142 μs | 0.0126 μs |  1.10x slower |   0.01x |  1.6575 |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.363 μs | 0.0132 μs | 0.0110 μs |  1.21x faster |   0.02x |  1.6575 |      3 KB |
