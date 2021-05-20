## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |      Mean |     Error |    StdDev |    Median |         Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|----------:|--------------:|--------:|--------:|-------:|------:|----------:|
|                  ForLoop |   100 |  1.391 μs | 0.0273 μs | 0.0315 μs |  1.380 μs |      baseline |         |  3.8605 |      - |     - |      8 KB |
|              ForeachLoop |   100 |  1.656 μs | 0.0446 μs | 0.1315 μs |  1.567 μs |  1.29x slower |   0.06x |  3.8605 |      - |     - |      8 KB |
|                     Linq |   100 |  1.814 μs | 0.0203 μs | 0.0190 μs |  1.814 μs |  1.30x slower |   0.03x |  4.0436 |      - |     - |      8 KB |
|               LinqFaster |   100 |  2.368 μs | 0.0183 μs | 0.0153 μs |  2.371 μs |  1.70x slower |   0.04x |  5.5389 |      - |     - |     11 KB |
|             LinqFasterer |   100 |  2.332 μs | 0.0416 μs | 0.0389 μs |  2.320 μs |  1.67x slower |   0.04x |  8.0643 |      - |     - |     16 KB |
|                   LinqAF |   100 |  3.250 μs | 0.0444 μs | 0.0393 μs |  3.243 μs |  2.33x slower |   0.06x |  3.8605 |      - |     - |      8 KB |
|            LinqOptimizer |   100 | 64.226 μs | 1.1798 μs | 1.2116 μs | 64.407 μs | 46.23x slower |   1.52x | 76.7822 | 0.1221 |     - |    158 KB |
|                 SpanLinq |   100 |  2.083 μs | 0.0582 μs | 0.1716 μs |  1.981 μs |  1.64x slower |   0.09x |  3.8605 |      - |     - |      8 KB |
|                  Streams |   100 |  9.466 μs | 0.1834 μs | 0.3704 μs |  9.286 μs |  7.01x slower |   0.29x |  4.1199 |      - |     - |      8 KB |
|               StructLinq |   100 |  1.562 μs | 0.0363 μs | 0.1041 μs |  1.506 μs |  1.10x slower |   0.08x |  1.7262 |      - |     - |      4 KB |
| StructLinq_ValueDelegate |   100 |  1.655 μs | 0.0638 μs | 0.1681 μs |  1.728 μs |  1.01x faster |   0.08x |  1.6766 |      - |     - |      3 KB |
|                Hyperlinq |   100 |  1.878 μs | 0.0507 μs | 0.1370 μs |  1.811 μs |  1.49x slower |   0.08x |  1.6747 |      - |     - |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  2.204 μs | 0.0245 μs | 0.0218 μs |  2.201 μs |  1.58x slower |   0.04x |  1.6747 |      - |     - |      3 KB |
