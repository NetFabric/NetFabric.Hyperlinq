## Enumerable.Int32.EnumerableInt32WhereSelectToArray

### Source
[EnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToArray.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|              ForeachLoop |   100 |    532.8 ns |   4.47 ns |   3.96 ns |  1.00 |    0.00 |  0.7877 |     - |     - |   1,648 B |
|                     Linq |   100 |    880.8 ns |   8.75 ns |   6.83 ns |  1.65 |    0.02 |  0.6266 |     - |     - |   1,312 B |
|                   LinqAF |   100 |  1,103.3 ns |  21.65 ns |  37.92 ns |  2.00 |    0.08 |  0.7725 |     - |     - |   1,616 B |
|            LinqOptimizer |   100 | 50,547.3 ns | 329.12 ns | 307.86 ns | 94.91 |    1.00 | 15.3809 |     - |     - |  32,189 B |
|                  Streams |   100 |  1,566.9 ns |   9.23 ns |   8.18 ns |  2.94 |    0.03 |  1.0319 |     - |     - |   2,160 B |
|               StructLinq |   100 |  1,034.9 ns |   4.19 ns |   3.92 ns |  1.94 |    0.02 |  0.2632 |     - |     - |     552 B |
| StructLinq_ValueDelegate |   100 |    644.4 ns |   1.67 ns |   1.39 ns |  1.21 |    0.01 |  0.2213 |     - |     - |     464 B |
|                Hyperlinq |   100 |    928.1 ns |   8.29 ns |   6.92 ns |  1.74 |    0.02 |  0.2213 |     - |     - |     464 B |
|  Hyperlinq_ValueDelegate |   100 |    668.8 ns |   4.99 ns |   4.17 ns |  1.25 |    0.01 |  0.2213 |     - |     - |     464 B |
