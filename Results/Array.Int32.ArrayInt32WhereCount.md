## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |     65.95 ns |   0.182 ns |   0.142 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |     66.79 ns |   0.455 ns |   0.404 ns |   1.01 |    0.01 |      - |     - |     - |         - |
|                     Linq |   100 |    311.74 ns |   2.154 ns |   1.799 ns |   4.73 |    0.03 | 0.0153 |     - |     - |      32 B |
|               LinqFaster |   100 |    235.78 ns |   1.068 ns |   0.947 ns |   3.57 |    0.02 |      - |     - |     - |         - |
|             LinqFasterer |   100 |    247.69 ns |   0.722 ns |   0.564 ns |   3.76 |    0.01 |      - |     - |     - |         - |
|                   LinqAF |   100 |    226.05 ns |   1.520 ns |   1.347 ns |   3.42 |    0.01 |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 30,838.47 ns | 360.988 ns | 301.441 ns | 468.21 |    4.40 | 9.0942 |     - |     - |  19,066 B |
|                 SpanLinq |   100 |    285.21 ns |   1.967 ns |   1.743 ns |   4.32 |    0.03 |      - |     - |     - |         - |
|                  Streams |   100 |    566.24 ns |   9.481 ns |   8.405 ns |   8.58 |    0.15 | 0.1717 |     - |     - |     360 B |
|               StructLinq |   100 |    248.65 ns |   5.013 ns |   7.349 ns |   3.86 |    0.09 | 0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |     90.44 ns |   0.286 ns |   0.268 ns |   1.37 |    0.01 |      - |     - |     - |         - |
|                Hyperlinq |   100 |    200.71 ns |   1.337 ns |   1.186 ns |   3.05 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |     94.40 ns |   0.378 ns |   0.335 ns |   1.43 |    0.01 |      - |     - |     - |         - |
