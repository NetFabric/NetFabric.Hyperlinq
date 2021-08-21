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
|                   Method | Skip | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|-------:|------:|----------:|
|                  ForLoop | 1000 |   100 |    529.3 ns |   0.56 ns |   0.47 ns |       baseline |         |       - |      - |     - |         - |
|                     Linq | 1000 |   100 |  1,274.0 ns |   8.64 ns |   8.09 ns |   2.40x slower |   0.01x |  0.1526 |      - |     - |     320 B |
|               LinqFaster | 1000 |   100 |  3,646.3 ns |  11.69 ns |  10.37 ns |   6.89x slower |   0.02x | 10.0327 |      - |     - |  21,000 B |
|             LinqFasterer | 1000 |   100 |  7,316.5 ns |  27.24 ns |  21.27 ns |  13.82x slower |   0.04x | 37.0331 |      - |     - |  80,168 B |
|                   LinqAF | 1000 |   100 |  8,520.0 ns |  18.33 ns |  17.15 ns |  16.10x slower |   0.03x |       - |      - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 75,205.9 ns | 330.44 ns | 292.93 ns | 142.09x slower |   0.57x | 73.9746 | 0.1221 |     - | 158,856 B |
|                 SpanLinq | 1000 |   100 |    745.3 ns |   1.26 ns |   1.18 ns |   1.41x slower |   0.00x |       - |      - |     - |         - |
|                  Streams | 1000 |   100 | 10,049.8 ns |   6.66 ns |   5.20 ns |  18.99x slower |   0.02x |  0.5493 |      - |     - |   1,176 B |
|               StructLinq | 1000 |   100 |    639.6 ns |   0.35 ns |   0.31 ns |   1.21x slower |   0.00x |  0.0572 |      - |     - |     120 B |
| StructLinq_ValueDelegate | 1000 |   100 |    564.0 ns |   0.19 ns |   0.17 ns |   1.07x slower |   0.00x |       - |      - |     - |         - |
|                Hyperlinq | 1000 |   100 |  1,008.4 ns |   5.82 ns |   5.45 ns |   1.90x slower |   0.01x |       - |      - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    874.7 ns |   0.37 ns |   0.35 ns |   1.65x slower |   0.00x |       - |      - |     - |         - |
