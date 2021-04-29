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
|                   Method | Count |        Mean |     Error |    StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    217.3 ns |   2.31 ns |   2.16 ns |   1.00 |    0.00 |  0.3097 |     - |     - |     648 B |
|              ForeachLoop |   100 |    217.0 ns |   1.53 ns |   1.28 ns |   1.00 |    0.01 |  0.3097 |     - |     - |     648 B |
|                     Linq |   100 |    453.6 ns |   6.16 ns |   5.76 ns |   2.09 |    0.03 |  0.3595 |     - |     - |     752 B |
|               LinqFaster |   100 |    492.3 ns |   3.94 ns |   3.68 ns |   2.27 |    0.03 |  0.4473 |     - |     - |     936 B |
|             LinqFasterer |   100 |    632.9 ns |   4.90 ns |   4.58 ns |   2.91 |    0.03 |  0.6113 |     - |     - |   1,280 B |
|                   LinqAF |   100 |    612.3 ns |   6.04 ns |   5.36 ns |   2.82 |    0.04 |  0.3090 |     - |     - |     648 B |
|            LinqOptimizer |   100 | 45,236.1 ns | 232.89 ns | 217.84 ns | 208.15 |    2.20 | 14.6484 |     - |     - |  30,760 B |
|                  Streams |   100 |  1,252.7 ns |   6.72 ns |   6.28 ns |   5.76 |    0.07 |  0.5684 |     - |     - |   1,192 B |
|               StructLinq |   100 |    571.3 ns |   4.63 ns |   4.11 ns |   2.63 |    0.03 |  0.1755 |     - |     - |     368 B |
| StructLinq_ValueDelegate |   100 |    324.1 ns |   1.74 ns |   1.62 ns |   1.49 |    0.02 |  0.1297 |     - |     - |     272 B |
|                Hyperlinq |   100 |    580.3 ns |   3.05 ns |   2.55 ns |   2.68 |    0.02 |  0.1297 |     - |     - |     272 B |
|  Hyperlinq_ValueDelegate |   100 |    375.5 ns |   4.34 ns |   4.06 ns |   1.73 |    0.03 |  0.1297 |     - |     - |     272 B |
