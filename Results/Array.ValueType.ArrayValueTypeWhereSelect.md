## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |        Mean |     Error |    StdDev |      Median |         Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------------:|--------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    939.3 ns |   4.58 ns |   4.29 ns |    938.9 ns |      baseline |         |       - |     - |     - |         - |
|              ForeachLoop |   100 |  1,035.6 ns |   9.94 ns |   8.81 ns |  1,035.3 ns |  1.10x slower |   0.01x |       - |     - |     - |         - |
|                     Linq |   100 |  1,662.6 ns |  13.87 ns |  12.30 ns |  1,663.8 ns |  1.77x slower |   0.02x |  0.1030 |     - |     - |     216 B |
|               LinqFaster |   100 |  1,910.8 ns |  11.20 ns |   9.93 ns |  1,909.5 ns |  2.04x slower |   0.01x |  4.7264 |     - |     - |   9,904 B |
|             LinqFasterer |   100 |  3,900.5 ns |  98.96 ns | 290.24 ns |  3,721.2 ns |  4.33x slower |   0.29x |  6.0234 |     - |     - |  12,624 B |
|                   LinqAF |   100 |  2,318.7 ns |  22.19 ns |  18.53 ns |  2,314.8 ns |  2.47x slower |   0.02x |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 55,666.4 ns | 616.07 ns | 546.13 ns | 55,696.2 ns | 59.30x slower |   0.54x | 74.0356 |     - |     - | 156,351 B |
|                 SpanLinq |   100 |  1,634.3 ns |   8.43 ns |   7.47 ns |  1,633.4 ns |  1.74x slower |   0.01x |       - |     - |     - |         - |
|                  Streams |   100 |  7,459.2 ns |  51.18 ns |  45.37 ns |  7,464.8 ns |  7.95x slower |   0.05x |  0.4654 |     - |     - |     976 B |
|               StructLinq |   100 |  1,248.7 ns |   6.27 ns |   5.23 ns |  1,247.1 ns |  1.33x slower |   0.01x |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |  1,126.5 ns |   5.92 ns |   5.25 ns |  1,126.4 ns |  1.20x slower |   0.01x |       - |     - |     - |         - |
|                Hyperlinq |   100 |  1,589.9 ns |   9.88 ns |   8.76 ns |  1,590.7 ns |  1.69x slower |   0.01x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1,333.1 ns |   8.35 ns |   7.81 ns |  1,335.2 ns |  1.42x slower |   0.01x |       - |     - |     - |         - |
