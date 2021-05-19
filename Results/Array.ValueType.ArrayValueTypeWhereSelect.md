## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|                   Method | Count |        Mean |     Error |      StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    906.6 ns |   2.56 ns |     2.27 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |  1,010.0 ns |   6.14 ns |     5.45 ns |  1.11 |    0.01 |       - |     - |     - |         - |
|                     Linq |   100 |  1,604.2 ns |  22.67 ns |    21.21 ns |  1.77 |    0.02 |  0.1030 |     - |     - |     216 B |
|               LinqFaster |   100 |  1,867.7 ns |  23.65 ns |    20.97 ns |  2.06 |    0.02 |  4.7264 |     - |     - |   9,904 B |
|             LinqFasterer |   100 |  3,556.2 ns |  36.67 ns |    34.30 ns |  3.92 |    0.04 |  6.0234 |     - |     - |  12,624 B |
|                   LinqAF |   100 |  2,267.6 ns |  20.75 ns |    19.41 ns |  2.50 |    0.02 |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 53,061.9 ns | 592.94 ns | 1,038.48 ns | 58.69 |    1.07 | 73.9746 |     - |     - | 156,351 B |
|                 SpanLinq |   100 |  1,560.5 ns |   6.93 ns |     6.14 ns |  1.72 |    0.01 |       - |     - |     - |         - |
|                  Streams |   100 |  7,468.0 ns | 120.47 ns |   106.79 ns |  8.24 |    0.12 |  0.4654 |     - |     - |     976 B |
|               StructLinq |   100 |  1,239.7 ns |  13.46 ns |    12.59 ns |  1.37 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |  1,079.5 ns |   3.50 ns |     3.10 ns |  1.19 |    0.01 |       - |     - |     - |         - |
|                Hyperlinq |   100 |  1,537.5 ns |  12.88 ns |    11.42 ns |  1.70 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1,302.6 ns |   7.28 ns |     6.81 ns |  1.44 |    0.01 |       - |     - |     - |         - |
