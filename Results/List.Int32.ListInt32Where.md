## List.Int32.ListInt32Where

### Source
[ListInt32Where.cs](../LinqBenchmarks/List/Int32/ListInt32Where.cs)

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

BenchmarkDotNet=v0.13.0, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |     93.17 ns |   0.097 ns |   0.091 ns |       baseline |         |       - |     - |     - |         - |
|              ForeachLoop |   100 |    126.03 ns |   0.337 ns |   0.298 ns |   1.35x slower |   0.00x |       - |     - |     - |         - |
|                     Linq |   100 |    656.43 ns |   3.846 ns |   3.597 ns |   7.05x slower |   0.04x |  0.0343 |     - |     - |      72 B |
|               LinqFaster |   100 |    443.14 ns |   0.468 ns |   0.437 ns |   4.76x slower |   0.01x |  0.3095 |     - |     - |     648 B |
|             LinqFasterer |   100 |    453.23 ns |   0.701 ns |   0.622 ns |   4.86x slower |   0.01x |  0.3328 |     - |     - |     696 B |
|                   LinqAF |   100 |    472.33 ns |   3.142 ns |   2.939 ns |   5.07x slower |   0.03x |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 45,868.76 ns | 123.197 ns | 115.239 ns | 492.32x slower |   1.39x | 13.6719 |     - |     - |  28,650 B |
|                 SpanLinq |   100 |    359.45 ns |   0.558 ns |   0.522 ns |   3.86x slower |   0.01x |       - |     - |     - |         - |
|                  Streams |   100 |  1,169.04 ns |   1.514 ns |   1.342 ns |  12.55x slower |   0.02x |  0.2899 |     - |     - |     608 B |
|               StructLinq |   100 |    366.39 ns |   3.165 ns |   2.806 ns |   3.93x slower |   0.03x |  0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    182.50 ns |   0.056 ns |   0.044 ns |   1.96x slower |   0.00x |       - |     - |     - |         - |
|                Hyperlinq |   100 |    302.71 ns |   4.508 ns |   4.217 ns |   3.25x slower |   0.05x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    220.49 ns |   0.788 ns |   0.658 ns |   2.37x slower |   0.01x |       - |     - |     - |         - |
