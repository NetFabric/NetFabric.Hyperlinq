## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
|                   Method | Count |        Mean |       Error |      StdDev |      Median |  Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|------------:|------------:|------------:|-------:|--------:|--------:|--------:|------:|----------:|
|                  ForLoop |   100 |    513.4 ns |     1.75 ns |     1.64 ns |    512.9 ns |   1.00 |    0.00 |       - |       - |     - |         - |
|              ForeachLoop |   100 |    599.4 ns |     1.72 ns |     1.52 ns |    599.1 ns |   1.17 |    0.00 |       - |       - |     - |         - |
|                     Linq |   100 |  1,057.3 ns |     6.91 ns |     5.77 ns |  1,060.3 ns |   2.06 |    0.01 |  0.0496 |       - |     - |     104 B |
|               LinqFaster |   100 |  1,635.6 ns |    15.96 ns |    14.93 ns |  1,631.8 ns |   3.19 |    0.03 |  4.7264 |       - |     - |   9,904 B |
|             LinqFasterer |   100 |  2,138.2 ns |    25.64 ns |    21.41 ns |  2,134.9 ns |   4.17 |    0.05 |  3.0174 |       - |     - |   6,328 B |
|                   LinqAF |   100 |  1,484.8 ns |    29.54 ns |    29.02 ns |  1,477.0 ns |   2.89 |    0.06 |       - |       - |     - |         - |
|            LinqOptimizer |   100 | 49,798.9 ns | 1,609.69 ns | 4,746.21 ns | 46,243.0 ns | 106.27 |    4.08 | 68.1763 | 22.7051 |     - | 154,077 B |
|                  Streams |   100 |  2,042.8 ns |    11.67 ns |    10.35 ns |  2,043.3 ns |   3.98 |    0.03 |  0.3929 |       - |     - |     824 B |
|               StructLinq |   100 |    687.8 ns |     8.33 ns |     7.79 ns |    686.7 ns |   1.34 |    0.01 |  0.0153 |       - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    602.1 ns |     3.15 ns |     2.79 ns |    602.1 ns |   1.17 |    0.01 |       - |       - |     - |         - |
|                Hyperlinq |   100 |  2,091.0 ns |     7.42 ns |     6.94 ns |  2,090.8 ns |   4.07 |    0.02 |       - |       - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    846.5 ns |     2.94 ns |     2.60 ns |    846.5 ns |   1.65 |    0.01 |       - |       - |     - |         - |
