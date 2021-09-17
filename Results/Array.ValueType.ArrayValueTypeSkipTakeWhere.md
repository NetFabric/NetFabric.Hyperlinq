## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|                   Method | Skip | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |----- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop | 1000 |   100 |    443.7 ns |   0.82 ns |   0.76 ns |       baseline |         |       - |         - |
|                     Linq | 1000 |   100 |  1,573.1 ns |  25.33 ns |  21.15 ns |   3.55x slower |   0.05x |  0.1526 |     320 B |
|               LinqFaster | 1000 |   100 |  2,547.4 ns |  38.65 ns |  37.96 ns |   5.74x slower |   0.09x | 10.7803 |  22,560 B |
|             LinqFasterer | 1000 |   100 |  1,838.8 ns |  10.94 ns |   9.70 ns |   4.14x slower |   0.03x |  4.6501 |   9,744 B |
|                   LinqAF | 1000 |   100 |  6,347.9 ns |  58.70 ns |  52.03 ns |  14.31x slower |   0.12x |       - |         - |
|            LinqOptimizer | 1000 |   100 | 60,650.1 ns | 783.33 ns | 732.73 ns | 136.70x slower |   1.56x | 74.0356 | 157,823 B |
|                 SpanLinq | 1000 |   100 |    746.2 ns |   1.69 ns |   1.50 ns |   1.68x slower |   0.01x |       - |         - |
|                  Streams | 1000 |   100 |  8,947.5 ns |  30.97 ns |  25.86 ns |  20.17x slower |   0.06x |  0.5493 |   1,152 B |
|               StructLinq | 1000 |   100 |    632.0 ns |   1.69 ns |   1.58 ns |   1.42x slower |   0.00x |  0.0458 |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    541.2 ns |   0.83 ns |   0.69 ns |   1.22x slower |   0.00x |       - |         - |
|                Hyperlinq | 1000 |   100 |    981.0 ns |   3.77 ns |   3.52 ns |   2.21x slower |   0.01x |       - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    874.7 ns |   1.91 ns |   1.69 ns |   1.97x slower |   0.01x |       - |         - |
