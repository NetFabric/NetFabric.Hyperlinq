## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|                   Method | Skip | Count |        Mean |       Error |      StdDev |  Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |------------:|------------:|------------:|-------:|--------:|--------:|--------:|------:|----------:|
|                  ForLoop | 1000 |   100 |    494.8 ns |     2.42 ns |     2.14 ns |   1.00 |    0.00 |       - |       - |     - |         - |
|              ForeachLoop | 1000 |   100 |  1,972.7 ns |     9.67 ns |     8.58 ns |   3.99 |    0.03 |  0.0153 |       - |     - |      32 B |
|                     Linq | 1000 |   100 |  1,845.3 ns |    19.45 ns |    17.24 ns |   3.73 |    0.04 |  0.1526 |       - |     - |     320 B |
|               LinqFaster | 1000 |   100 |  2,219.0 ns |    31.48 ns |    26.29 ns |   4.48 |    0.04 | 10.7803 |       - |     - |  22,560 B |
|             LinqFasterer | 1000 |   100 |  1,888.0 ns |    22.76 ns |    21.29 ns |   3.81 |    0.04 |  4.6387 |       - |     - |   9,712 B |
|                   LinqAF | 1000 |   100 |  7,145.0 ns |   141.43 ns |   132.29 ns |  14.40 |    0.26 |       - |       - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 69,981.1 ns | 1,119.03 ns | 1,046.74 ns | 141.35 |    2.15 | 65.0635 | 17.8223 |     - | 157,958 B |
|                  Streams | 1000 |   100 |  8,176.9 ns |    48.90 ns |    40.83 ns |  16.52 |    0.09 |  0.5493 |       - |     - |   1,152 B |
|               StructLinq | 1000 |   100 |    672.2 ns |     3.13 ns |     2.77 ns |   1.36 |    0.01 |  0.0458 |       - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    558.1 ns |     2.35 ns |     2.20 ns |   1.13 |    0.01 |       - |       - |     - |         - |
|                Hyperlinq | 1000 |   100 |  1,123.7 ns |     3.50 ns |     3.27 ns |   2.27 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    802.1 ns |     1.85 ns |     1.44 ns |   1.62 |    0.01 |       - |       - |     - |         - |
