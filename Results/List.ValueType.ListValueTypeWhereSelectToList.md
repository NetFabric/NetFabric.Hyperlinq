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
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
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
|                   Method | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |   100 |  1.365 μs | 0.0106 μs | 0.0099 μs |      baseline |         |  3.8605 |       - |      8 KB |
|              ForeachLoop |   100 |  1.464 μs | 0.0119 μs | 0.0111 μs |  1.07x slower |   0.01x |  3.8605 |       - |      8 KB |
|                     Linq |   100 |  1.769 μs | 0.0141 μs | 0.0132 μs |  1.30x slower |   0.01x |  4.0455 |       - |      8 KB |
|               LinqFaster |   100 |  2.137 μs | 0.0125 μs | 0.0117 μs |  1.57x slower |   0.01x |  5.5428 |       - |     11 KB |
|             LinqFasterer |   100 |  2.358 μs | 0.0208 μs | 0.0195 μs |  1.73x slower |   0.02x |  8.0643 |       - |     16 KB |
|                   LinqAF |   100 |  2.667 μs | 0.0195 μs | 0.0173 μs |  1.95x slower |   0.01x |  3.8605 |       - |      8 KB |
|            LinqOptimizer |   100 | 63.607 μs | 0.5360 μs | 0.4476 μs | 46.60x slower |   0.49x | 74.2188 | 16.3574 |    158 KB |
|                 SpanLinq |   100 |  1.977 μs | 0.0098 μs | 0.0082 μs |  1.45x slower |   0.01x |  3.8605 |       - |      8 KB |
|                  Streams |   100 |  3.062 μs | 0.0264 μs | 0.0247 μs |  2.24x slower |   0.02x |  4.1275 |       - |      8 KB |
|               StructLinq |   100 |  1.512 μs | 0.0173 μs | 0.0162 μs |  1.11x slower |   0.02x |  1.7300 |       - |      4 KB |
| StructLinq_ValueDelegate |   100 |  1.121 μs | 0.0037 μs | 0.0031 μs |  1.22x faster |   0.01x |  1.6804 |       - |      3 KB |
|                Hyperlinq |   100 |  1.777 μs | 0.0126 μs | 0.0112 μs |  1.30x slower |   0.01x |  1.6766 |       - |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.388 μs | 0.0102 μs | 0.0096 μs |  1.02x slower |   0.01x |  1.6766 |       - |      3 KB |
