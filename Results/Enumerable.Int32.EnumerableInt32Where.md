## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|                     Linq |   100 |    584.9 ns |   8.85 ns |   7.85 ns |  1.00 |    0.00 |  0.0458 |     - |     - |      96 B |
|                   LinqAF |   100 |    589.8 ns |   5.02 ns |   4.70 ns |  1.01 |    0.02 |  0.0191 |     - |     - |      40 B |
|            LinqOptimizer |   100 | 41,995.0 ns | 363.04 ns | 339.59 ns | 71.83 |    1.42 | 13.9160 |     - |     - |  29,235 B |
|                  Streams |   100 |  1,569.3 ns |   7.82 ns |   6.53 ns |  2.69 |    0.04 |  0.2823 |     - |     - |     592 B |
|               StructLinq |   100 |    454.4 ns |   6.27 ns |   5.24 ns |  0.78 |    0.02 |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |    364.6 ns |   2.34 ns |   2.08 ns |  0.62 |    0.01 |  0.0191 |     - |     - |      40 B |
|                Hyperlinq |   100 |    503.4 ns |   2.96 ns |   2.77 ns |  0.86 |    0.01 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_ValueDelegate |   100 |    419.1 ns |   3.35 ns |   2.80 ns |  0.72 |    0.01 |  0.0191 |     - |     - |      40 B |
