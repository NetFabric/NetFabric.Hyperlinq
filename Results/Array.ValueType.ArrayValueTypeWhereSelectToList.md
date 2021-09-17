## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|                   Method | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |  Gen 1 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|-------:|----------:|
|                  ForLoop |   100 |  1.191 μs | 0.0070 μs | 0.0058 μs |      baseline |         |  3.8605 |      - |      8 KB |
|              ForeachLoop |   100 |  1.284 μs | 0.0113 μs | 0.0106 μs |  1.08x slower |   0.01x |  3.8605 |      - |      8 KB |
|                     Linq |   100 |  1.737 μs | 0.0120 μs | 0.0112 μs |  1.46x slower |   0.01x |  3.9673 |      - |      8 KB |
|               LinqFaster |   100 |  1.861 μs | 0.0140 μs | 0.0131 μs |  1.56x slower |   0.01x |  6.4087 |      - |     13 KB |
|             LinqFasterer |   100 |  3.109 μs | 0.0176 μs | 0.0165 μs |  2.61x slower |   0.02x |  9.0332 |      - |     18 KB |
|                   LinqAF |   100 |  2.483 μs | 0.0180 μs | 0.0168 μs |  2.08x slower |   0.02x |  3.8605 |      - |      8 KB |
|            LinqOptimizer |   100 | 59.170 μs | 0.3695 μs | 0.3456 μs | 49.65x slower |   0.36x | 74.7070 | 5.7373 |    157 KB |
|                 SpanLinq |   100 |  1.997 μs | 0.0110 μs | 0.0098 μs |  1.68x slower |   0.01x |  3.8605 |      - |      8 KB |
|                  Streams |   100 |  2.773 μs | 0.0192 μs | 0.0160 μs |  2.33x slower |   0.02x |  4.1275 |      - |      8 KB |
|               StructLinq |   100 |  1.550 μs | 0.0142 μs | 0.0126 μs |  1.30x slower |   0.01x |  1.7281 |      - |      4 KB |
| StructLinq_ValueDelegate |   100 |  1.116 μs | 0.0080 μs | 0.0071 μs |  1.07x faster |   0.01x |  1.6804 |      - |      3 KB |
|                Hyperlinq |   100 |  1.795 μs | 0.0144 μs | 0.0135 μs |  1.51x slower |   0.01x |  1.6766 |      - |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.403 μs | 0.0117 μs | 0.0109 μs |  1.18x slower |   0.01x |  1.6766 |      - |      3 KB |
