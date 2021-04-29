## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|                   Method | Count |        Mean |     Error |      StdDev |      Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|------------:|------------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    223.2 ns |   4.56 ns |    10.30 ns |    216.9 ns |   1.00 |    0.00 |  0.3097 |     - |     - |     648 B |
|              ForeachLoop |   100 |    226.0 ns |   1.87 ns |     1.75 ns |    225.6 ns |   0.96 |    0.02 |  0.3097 |     - |     - |     648 B |
|                     Linq |   100 |    450.7 ns |   2.87 ns |     2.24 ns |    450.8 ns |   1.93 |    0.06 |  0.3595 |     - |     - |     752 B |
|               LinqFaster |   100 |    472.5 ns |   9.48 ns |    20.61 ns |    460.5 ns |   2.11 |    0.07 |  0.4473 |     - |     - |     936 B |
|             LinqFasterer |   100 |    671.2 ns |   6.12 ns |     5.43 ns |    671.3 ns |   2.86 |    0.08 |  0.6113 |     - |     - |   1,280 B |
|                   LinqAF |   100 |    598.8 ns |   3.83 ns |     3.39 ns |    598.3 ns |   2.55 |    0.07 |  0.3090 |     - |     - |     648 B |
|            LinqOptimizer |   100 | 45,987.7 ns | 646.57 ns | 1,645.72 ns | 45,437.9 ns | 206.67 |    9.44 | 14.6484 |     - |     - |  30,760 B |
|                  Streams |   100 |  1,331.3 ns |  26.34 ns |    31.36 ns |  1,344.1 ns |   5.65 |    0.19 |  0.5684 |     - |     - |   1,192 B |
|               StructLinq |   100 |    551.2 ns |   2.67 ns |     2.50 ns |    551.5 ns |   2.35 |    0.07 |  0.1755 |     - |     - |     368 B |
| StructLinq_ValueDelegate |   100 |    322.1 ns |   1.91 ns |     1.59 ns |    322.3 ns |   1.38 |    0.04 |  0.1297 |     - |     - |     272 B |
|                Hyperlinq |   100 |    684.9 ns |   3.18 ns |     2.82 ns |    684.6 ns |   2.92 |    0.08 |  0.1297 |     - |     - |     272 B |
|  Hyperlinq_ValueDelegate |   100 |    368.9 ns |   0.94 ns |     0.88 ns |    369.2 ns |   1.57 |    0.04 |  0.1297 |     - |     - |     272 B |
