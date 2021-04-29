## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    922.1 ns |   2.05 ns |   1.71 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |  1,012.5 ns |   4.35 ns |   4.07 ns |  1.10 |    0.01 |       - |     - |     - |         - |
|                     Linq |   100 |  1,554.8 ns |   3.06 ns |   2.56 ns |  1.69 |    0.00 |  0.1030 |     - |     - |     216 B |
|               LinqFaster |   100 |  2,034.3 ns |  25.25 ns |  23.62 ns |  2.20 |    0.02 |  4.7264 |     - |     - |   9,904 B |
|             LinqFasterer |   100 |  3,666.7 ns |  73.12 ns |  64.82 ns |  3.98 |    0.06 |  6.0043 |     - |     - |  12,592 B |
|                   LinqAF |   100 |  2,190.9 ns |  20.69 ns |  19.35 ns |  2.37 |    0.02 |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 61,167.0 ns | 660.34 ns | 585.38 ns | 66.27 |    0.63 | 74.0356 |     - |     - | 156,351 B |
|                  Streams |   100 |  6,777.9 ns |  29.58 ns |  26.23 ns |  7.35 |    0.03 |  0.4654 |     - |     - |     976 B |
|               StructLinq |   100 |  1,186.8 ns |   5.59 ns |   5.23 ns |  1.29 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |  1,062.7 ns |   2.60 ns |   2.43 ns |  1.15 |    0.00 |       - |     - |     - |         - |
|                Hyperlinq |   100 |  1,515.7 ns |   5.28 ns |   4.68 ns |  1.64 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1,277.3 ns |   4.26 ns |   3.98 ns |  1.39 |    0.00 |       - |     - |     - |         - |
