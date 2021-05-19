## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |     66.01 ns |   0.262 ns |   0.245 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |     66.17 ns |   0.585 ns |   0.547 ns |   1.00 |    0.01 |       - |     - |     - |         - |
|                     Linq |   100 |    495.22 ns |   3.751 ns |   3.508 ns |   7.50 |    0.06 |  0.0229 |     - |     - |      48 B |
|               LinqFaster |   100 |    294.81 ns |   4.007 ns |   3.128 ns |   4.47 |    0.05 |  0.3171 |     - |     - |     664 B |
|             LinqFasterer |   100 |    530.48 ns |   3.527 ns |   3.299 ns |   8.04 |    0.07 |  0.2136 |     - |     - |     448 B |
|                   LinqAF |   100 |    393.94 ns |   1.978 ns |   1.754 ns |   5.97 |    0.02 |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 37,171.22 ns | 380.513 ns | 337.315 ns | 563.07 |    6.10 | 13.3057 |     - |     - |  27,846 B |
|                 SpanLinq |   100 |    312.82 ns |   2.117 ns |   1.768 ns |   4.74 |    0.03 |       - |     - |     - |         - |
|                  Streams |   100 |  1,331.81 ns |  20.309 ns |  23.388 ns |  20.25 |    0.38 |  0.2785 |     - |     - |     584 B |
|               StructLinq |   100 |    292.56 ns |   5.819 ns |   5.158 ns |   4.43 |    0.08 |  0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    166.03 ns |   0.806 ns |   0.673 ns |   2.52 |    0.02 |       - |     - |     - |         - |
|                Hyperlinq |   100 |    282.35 ns |   5.673 ns |   5.307 ns |   4.28 |    0.08 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    215.62 ns |   0.560 ns |   0.496 ns |   3.27 |    0.02 |       - |     - |     - |         - |
