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
|                   Method | Count |         Mean |        Error |       StdDev |       Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-------------:|-------------:|-------------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |     66.80 ns |     0.414 ns |     0.367 ns |     66.84 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |     66.94 ns |     0.395 ns |     0.330 ns |     67.00 ns |   1.00 |    0.01 |       - |     - |     - |         - |
|                     Linq |   100 |    502.64 ns |     4.805 ns |     4.495 ns |    503.52 ns |   7.53 |    0.07 |  0.0229 |     - |     - |      48 B |
|               LinqFaster |   100 |    319.65 ns |     6.414 ns |    11.401 ns |    324.64 ns |   4.60 |    0.17 |  0.3171 |     - |     - |     664 B |
|             LinqFasterer |   100 |    662.76 ns |     3.172 ns |     2.967 ns |    662.50 ns |   9.92 |    0.07 |  0.1984 |     - |     - |     416 B |
|                   LinqAF |   100 |    315.85 ns |     1.574 ns |     1.473 ns |    315.54 ns |   4.73 |    0.02 |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 39,057.25 ns | 1,099.857 ns | 3,242.953 ns | 37,113.69 ns | 628.24 |   41.01 | 13.3057 |     - |     - |  27,846 B |
|                  Streams |   100 |  1,360.82 ns |     7.102 ns |     6.296 ns |  1,361.68 ns |  20.37 |    0.15 |  0.2785 |     - |     - |     584 B |
|               StructLinq |   100 |    290.92 ns |     3.660 ns |     3.423 ns |    290.93 ns |   4.36 |    0.05 |  0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    166.29 ns |     0.870 ns |     0.727 ns |    166.30 ns |   2.49 |    0.02 |       - |     - |     - |         - |
|                Hyperlinq |   100 |    300.71 ns |     5.370 ns |     5.023 ns |    299.44 ns |   4.51 |    0.08 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    206.91 ns |     0.692 ns |     0.647 ns |    206.96 ns |   3.10 |    0.02 |       - |     - |     - |         - |
