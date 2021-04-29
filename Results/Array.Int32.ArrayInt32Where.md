## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |     69.01 ns |   0.900 ns |   0.842 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |     68.98 ns |   0.826 ns |   0.773 ns |   1.00 |    0.02 |       - |     - |     - |         - |
|                     Linq |   100 |    633.93 ns |   3.586 ns |   2.994 ns |   9.17 |    0.12 |  0.0229 |     - |     - |      48 B |
|               LinqFaster |   100 |    297.42 ns |   3.025 ns |   2.526 ns |   4.30 |    0.07 |  0.3171 |     - |     - |     664 B |
|             LinqFasterer |   100 |    470.82 ns |   4.606 ns |   4.309 ns |   6.82 |    0.12 |  0.2141 |     - |     - |     448 B |
|                   LinqAF |   100 |    320.56 ns |   1.609 ns |   1.505 ns |   4.65 |    0.06 |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 36,548.17 ns | 253.286 ns | 236.923 ns | 529.71 |    6.82 | 13.3057 |     - |     - |  27,846 B |
|                  Streams |   100 |  1,310.60 ns |   4.258 ns |   3.983 ns |  19.00 |    0.27 |  0.2785 |     - |     - |     584 B |
|               StructLinq |   100 |    306.96 ns |   4.321 ns |   3.608 ns |   4.44 |    0.07 |  0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    169.20 ns |   0.839 ns |   0.785 ns |   2.45 |    0.03 |       - |     - |     - |         - |
|                Hyperlinq |   100 |    375.49 ns |   5.268 ns |   4.928 ns |   5.44 |    0.12 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    211.47 ns |   3.704 ns |   3.093 ns |   3.06 |    0.06 |       - |     - |     - |         - |
