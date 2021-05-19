## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [1.0.0](https://www.nuget.org/packages/SpanLinq/1.0.0)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1538-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |        Mean |       Error |      StdDev |      Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|------------:|------------:|------------:|------:|--------:|--------:|--------:|------:|----------:|
|                  ForLoop |   100 |    509.4 ns |     3.88 ns |     3.44 ns |    509.0 ns |  1.00 |    0.00 |       - |       - |     - |         - |
|              ForeachLoop |   100 |    585.3 ns |     2.13 ns |     1.89 ns |    584.6 ns |  1.15 |    0.01 |       - |       - |     - |         - |
|                     Linq |   100 |  1,038.2 ns |    16.26 ns |    14.41 ns |  1,034.3 ns |  2.04 |    0.03 |  0.0496 |       - |     - |     104 B |
|               LinqFaster |   100 |  1,484.6 ns |    29.68 ns |    87.04 ns |  1,466.4 ns |  2.96 |    0.17 |  4.7264 |       - |     - |   9,904 B |
|             LinqFasterer |   100 |  2,086.0 ns |    12.16 ns |    10.15 ns |  2,083.2 ns |  4.09 |    0.04 |  3.0174 |       - |     - |   6,328 B |
|                   LinqAF |   100 |  1,425.8 ns |    17.49 ns |    15.50 ns |  1,425.4 ns |  2.80 |    0.03 |       - |       - |     - |         - |
|            LinqOptimizer |   100 | 47,251.5 ns | 1,456.59 ns | 4,248.94 ns | 44,666.5 ns | 94.73 |    9.16 | 68.1763 | 22.7051 |     - | 154,077 B |
|                 SpanLinq |   100 |    770.6 ns |     7.78 ns |     6.49 ns |    772.3 ns |  1.51 |    0.01 |       - |       - |     - |         - |
|                  Streams |   100 |  1,973.3 ns |    17.21 ns |    15.26 ns |  1,972.8 ns |  3.87 |    0.04 |  0.3929 |       - |     - |     824 B |
|               StructLinq |   100 |    685.2 ns |     5.56 ns |     4.93 ns |    684.9 ns |  1.35 |    0.01 |  0.0153 |       - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    609.2 ns |     4.27 ns |     3.99 ns |    609.4 ns |  1.20 |    0.01 |       - |       - |     - |         - |
|                Hyperlinq |   100 |  1,089.5 ns |     5.20 ns |    11.07 ns |  1,086.5 ns |  2.13 |    0.02 |       - |       - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    817.2 ns |     2.74 ns |     2.43 ns |    817.1 ns |  1.60 |    0.01 |       - |       - |     - |         - |
