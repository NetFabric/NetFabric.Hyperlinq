## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Skip | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 |  Gen 1 | Allocated |
|------------------------- |----- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|-------:|----------:|
|                  ForLoop | 1000 |   100 |    528.3 ns |   0.88 ns |   0.82 ns |       baseline |         |       - |      - |         - |
|                     Linq | 1000 |   100 |  1,256.2 ns |   4.17 ns |   3.70 ns |   2.38x slower |   0.01x |  0.1526 |      - |     320 B |
|               LinqFaster | 1000 |   100 |  3,648.1 ns |  45.39 ns |  40.24 ns |   6.91x slower |   0.07x | 10.0327 |      - |  21,000 B |
|             LinqFasterer | 1000 |   100 |  7,233.4 ns |  69.12 ns |  64.66 ns |  13.69x slower |   0.12x | 37.0331 |      - |  80,168 B |
|                   LinqAF | 1000 |   100 |  8,354.4 ns |  29.99 ns |  28.05 ns |  15.81x slower |   0.05x |       - |      - |         - |
|            LinqOptimizer | 1000 |   100 | 76,360.4 ns | 386.38 ns | 361.42 ns | 144.53x slower |   0.73x | 73.9746 | 0.2441 | 158,856 B |
|                 SpanLinq | 1000 |   100 |    746.0 ns |   1.69 ns |   1.49 ns |   1.41x slower |   0.00x |       - |      - |         - |
|                  Streams | 1000 |   100 | 10,037.9 ns |  34.12 ns |  31.91 ns |  19.00x slower |   0.07x |  0.5493 |      - |   1,176 B |
|               StructLinq | 1000 |   100 |    642.0 ns |   1.61 ns |   1.43 ns |   1.22x slower |   0.00x |  0.0572 |      - |     120 B |
| StructLinq_ValueDelegate | 1000 |   100 |    566.6 ns |   0.81 ns |   0.68 ns |   1.07x slower |   0.00x |       - |      - |         - |
|                Hyperlinq | 1000 |   100 |    956.9 ns |   0.86 ns |   0.67 ns |   1.81x slower |   0.00x |       - |      - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    792.9 ns |   1.75 ns |   1.55 ns |   1.50x slower |   0.00x |       - |      - |         - |
