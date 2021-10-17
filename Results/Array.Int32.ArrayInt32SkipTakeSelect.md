## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                   Method | Skip | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |----- |------ |------------:|----------:|----------:|--------------:|--------:|-------:|----------:|
|                  ForLoop | 1000 |   100 |    69.55 ns |  0.269 ns |  0.210 ns |      baseline |         |      - |         - |
|                     Linq | 1000 |   100 |   775.02 ns |  3.563 ns |  3.333 ns | 11.15x slower |   0.06x | 0.0725 |     152 B |
|               LinqFaster | 1000 |   100 |   373.52 ns |  5.554 ns |  5.195 ns |  5.37x slower |   0.07x | 0.6080 |   1,272 B |
|             LinqFasterer | 1000 |   100 |   576.08 ns |  0.590 ns |  0.461 ns |  8.28x slower |   0.02x | 0.4206 |     880 B |
|                   LinqAF | 1000 |   100 | 2,704.62 ns |  3.234 ns |  2.525 ns | 38.89x slower |   0.13x |      - |         - |
|            LinqOptimizer | 1000 |   100 | 2,833.50 ns | 38.238 ns | 35.768 ns | 40.61x slower |   0.39x | 4.2343 |   8,866 B |
|                 SpanLinq | 1000 |   100 |   277.72 ns |  1.857 ns |  1.450 ns |  3.99x slower |   0.02x |      - |         - |
|                  Streams | 1000 |   100 | 6,442.66 ns | 26.626 ns | 24.906 ns | 92.63x slower |   0.38x | 0.4349 |     912 B |
|               StructLinq | 1000 |   100 |   254.31 ns |  1.324 ns |  1.106 ns |  3.66x slower |   0.02x | 0.0458 |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |   177.23 ns |  0.408 ns |  0.381 ns |  2.55x slower |   0.00x |      - |         - |
|                Hyperlinq | 1000 |   100 |   246.72 ns |  0.779 ns |  0.608 ns |  3.55x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |   222.17 ns |  0.463 ns |  0.410 ns |  3.19x slower |   0.01x |      - |         - |
