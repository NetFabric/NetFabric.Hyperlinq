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

BenchmarkDotNet=v0.13.0, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|--------:|------:|----------:|
|                  ForLoop |   100 |  1.356 μs | 0.0042 μs | 0.0035 μs |      baseline |         |  3.8605 |       - |     - |      8 KB |
|              ForeachLoop |   100 |  1.466 μs | 0.0048 μs | 0.0045 μs |  1.08x slower |   0.00x |  3.8605 |       - |     - |      8 KB |
|                     Linq |   100 |  1.761 μs | 0.0053 μs | 0.0047 μs |  1.30x slower |   0.01x |  4.0455 |       - |     - |      8 KB |
|               LinqFaster |   100 |  2.150 μs | 0.0062 μs | 0.0052 μs |  1.59x slower |   0.00x |  5.5428 |       - |     - |     11 KB |
|             LinqFasterer |   100 |  2.374 μs | 0.0129 μs | 0.0121 μs |  1.75x slower |   0.01x |  8.0643 |       - |     - |     16 KB |
|                   LinqAF |   100 |  2.671 μs | 0.0107 μs | 0.0095 μs |  1.97x slower |   0.01x |  3.8605 |       - |     - |      8 KB |
|            LinqOptimizer |   100 | 63.222 μs | 0.2057 μs | 0.1924 μs | 46.60x slower |   0.16x | 74.0967 | 16.2354 |     - |    158 KB |
|                 SpanLinq |   100 |  2.024 μs | 0.0057 μs | 0.0054 μs |  1.49x slower |   0.01x |  3.8605 |       - |     - |      8 KB |
|                  Streams |   100 |  3.063 μs | 0.0050 μs | 0.0041 μs |  2.26x slower |   0.01x |  4.1275 |       - |     - |      8 KB |
|               StructLinq |   100 |  1.492 μs | 0.0027 μs | 0.0024 μs |  1.10x slower |   0.00x |  1.7300 |       - |     - |      4 KB |
| StructLinq_ValueDelegate |   100 |  1.126 μs | 0.0028 μs | 0.0024 μs |  1.20x faster |   0.00x |  1.6804 |       - |     - |      3 KB |
|                Hyperlinq |   100 |  1.878 μs | 0.0086 μs | 0.0072 μs |  1.39x slower |   0.01x |  1.6766 |       - |     - |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.434 μs | 0.0107 μs | 0.0094 μs |  1.06x slower |   0.01x |  1.6766 |       - |     - |      3 KB |
