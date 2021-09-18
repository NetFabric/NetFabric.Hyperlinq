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
|                   Method | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |  Gen 1 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|-------:|----------:|
|                  ForLoop |   100 |  1.187 μs | 0.0053 μs | 0.0047 μs |      baseline |         |  3.8605 |      - |      8 KB |
|              ForeachLoop |   100 |  1.286 μs | 0.0048 μs | 0.0042 μs |  1.08x slower |   0.01x |  3.8605 |      - |      8 KB |
|                     Linq |   100 |  1.731 μs | 0.0029 μs | 0.0024 μs |  1.46x slower |   0.00x |  3.9673 |      - |      8 KB |
|               LinqFaster |   100 |  1.861 μs | 0.0153 μs | 0.0143 μs |  1.57x slower |   0.01x |  6.4087 |      - |     13 KB |
|             LinqFasterer |   100 |  3.150 μs | 0.0113 μs | 0.0095 μs |  2.65x slower |   0.01x |  9.0332 |      - |     18 KB |
|                   LinqAF |   100 |  2.495 μs | 0.0085 μs | 0.0071 μs |  2.10x slower |   0.01x |  3.8605 |      - |      8 KB |
|            LinqOptimizer |   100 | 59.698 μs | 0.2915 μs | 0.2434 μs | 50.30x slower |   0.15x | 74.7070 | 5.7373 |    157 KB |
|                 SpanLinq |   100 |  2.005 μs | 0.0056 μs | 0.0053 μs |  1.69x slower |   0.01x |  3.8605 |      - |      8 KB |
|                  Streams |   100 |  2.765 μs | 0.0042 μs | 0.0038 μs |  2.33x slower |   0.01x |  4.1275 |      - |      8 KB |
|               StructLinq |   100 |  1.564 μs | 0.0059 μs | 0.0056 μs |  1.32x slower |   0.01x |  1.7281 |      - |      4 KB |
| StructLinq_ValueDelegate |   100 |  1.129 μs | 0.0020 μs | 0.0019 μs |  1.05x faster |   0.00x |  1.6804 |      - |      3 KB |
|                Hyperlinq |   100 |  1.801 μs | 0.0025 μs | 0.0023 μs |  1.52x slower |   0.01x |  1.6804 |      - |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.447 μs | 0.0014 μs | 0.0012 μs |  1.22x slower |   0.00x |  1.6804 |      - |      3 KB |
