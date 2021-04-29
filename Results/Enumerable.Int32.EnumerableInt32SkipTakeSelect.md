## Enumerable.Int32.EnumerableInt32SkipTakeSelect

### Source
[EnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeSelect.cs)

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
|                   Method | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|              ForeachLoop | 1000 |   100 |  2.717 μs | 0.0106 μs | 0.0094 μs |  1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                     Linq | 1000 |   100 |  2.969 μs | 0.0097 μs | 0.0086 μs |  1.09 |    0.01 |  0.0992 |     - |     - |     208 B |
|                   LinqAF | 1000 |   100 |  3.669 μs | 0.0305 μs | 0.0255 μs |  1.35 |    0.01 |  0.0191 |     - |     - |      40 B |
|            LinqOptimizer | 1000 |   100 | 50.521 μs | 0.3251 μs | 0.2715 μs | 18.59 |    0.11 | 15.5640 |     - |     - |  32,618 B |
|                  Streams | 1000 |   100 |  7.648 μs | 0.0280 μs | 0.0248 μs |  2.81 |    0.01 |  0.4272 |     - |     - |     920 B |
|               StructLinq | 1000 |   100 |  2.712 μs | 0.0127 μs | 0.0113 μs |  1.00 |    0.00 |  0.0610 |     - |     - |     128 B |
| StructLinq_ValueDelegate | 1000 |   100 |  3.388 μs | 0.0150 μs | 0.0125 μs |  1.25 |    0.01 |  0.0191 |     - |     - |      40 B |
|                Hyperlinq | 1000 |   100 |  3.695 μs | 0.0104 μs | 0.0092 μs |  1.36 |    0.01 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  3.631 μs | 0.0104 μs | 0.0092 μs |  1.34 |    0.01 |  0.0191 |     - |     - |      40 B |
