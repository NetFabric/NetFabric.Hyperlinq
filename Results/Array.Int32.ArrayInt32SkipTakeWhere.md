## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|                   Method | Skip | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |----- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop | 1000 |   100 |     74.82 ns |   0.123 ns |   0.103 ns |       baseline |         |       - |         - |
|                     Linq | 1000 |   100 |  1,011.09 ns |   1.480 ns |   1.384 ns |  13.51x slower |   0.03x |  0.0725 |     152 B |
|               LinqFaster | 1000 |   100 |    420.68 ns |   3.828 ns |   3.394 ns |   5.62x slower |   0.05x |  0.7191 |   1,504 B |
|             LinqFasterer | 1000 |   100 |    483.70 ns |   4.297 ns |   3.809 ns |   6.47x slower |   0.05x |  0.3281 |     688 B |
|                   LinqAF | 1000 |   100 |  2,644.89 ns |  16.747 ns |  15.665 ns |  35.35x slower |   0.23x |       - |         - |
|            LinqOptimizer | 1000 |   100 | 50,628.31 ns | 374.546 ns | 292.421 ns | 676.73x slower |   3.86x | 15.0757 |  31,640 B |
|                 SpanLinq | 1000 |   100 |    314.96 ns |   2.303 ns |   2.042 ns |   4.21x slower |   0.03x |       - |         - |
|                  Streams | 1000 |   100 |  6,145.49 ns |   9.611 ns |   8.519 ns |  82.15x slower |   0.17x |  0.4349 |     912 B |
|               StructLinq | 1000 |   100 |    326.57 ns |   4.078 ns |   3.815 ns |   4.37x slower |   0.05x |  0.0458 |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    203.44 ns |   0.188 ns |   0.167 ns |   2.72x slower |   0.01x |       - |         - |
|                Hyperlinq | 1000 |   100 |    282.00 ns |   0.480 ns |   0.449 ns |   3.77x slower |   0.01x |       - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    239.06 ns |   0.487 ns |   0.407 ns |   3.20x slower |   0.01x |       - |         - |
