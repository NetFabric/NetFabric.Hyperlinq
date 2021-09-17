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
|                   Method | Skip | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |----- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop | 1000 |   100 |     74.56 ns |   0.262 ns |   0.245 ns |       baseline |         |       - |         - |
|                     Linq | 1000 |   100 |  1,006.26 ns |   1.385 ns |   1.081 ns |  13.49x slower |   0.05x |  0.0725 |     152 B |
|               LinqFaster | 1000 |   100 |    418.64 ns |   2.060 ns |   1.927 ns |   5.62x slower |   0.04x |  0.7191 |   1,504 B |
|             LinqFasterer | 1000 |   100 |    483.15 ns |   1.646 ns |   1.375 ns |   6.48x slower |   0.02x |  0.3281 |     688 B |
|                   LinqAF | 1000 |   100 |  2,612.68 ns |  16.824 ns |  14.914 ns |  35.04x slower |   0.24x |       - |         - |
|            LinqOptimizer | 1000 |   100 | 51,200.65 ns | 263.888 ns | 233.930 ns | 686.59x slower |   4.54x | 15.0757 |  31,640 B |
|                 SpanLinq | 1000 |   100 |    246.64 ns |   0.830 ns |   0.693 ns |   3.31x slower |   0.01x |       - |         - |
|                  Streams | 1000 |   100 |  6,180.10 ns |  27.696 ns |  25.907 ns |  82.89x slower |   0.50x |  0.4349 |     912 B |
|               StructLinq | 1000 |   100 |    333.02 ns |   3.326 ns |   3.111 ns |   4.47x slower |   0.05x |  0.0458 |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    203.56 ns |   0.674 ns |   0.630 ns |   2.73x slower |   0.01x |       - |         - |
|                Hyperlinq | 1000 |   100 |    460.45 ns |   1.965 ns |   1.641 ns |   6.18x slower |   0.03x |       - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    238.31 ns |   0.149 ns |   0.124 ns |   3.20x slower |   0.01x |       - |         - |
