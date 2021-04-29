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
|              ForeachLoop | 1000 |   100 |  2.768 μs | 0.0098 μs | 0.0076 μs |  1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                     Linq | 1000 |   100 |  2.949 μs | 0.0194 μs | 0.0162 μs |  1.07 |    0.01 |  0.0992 |     - |     - |     208 B |
|                   LinqAF | 1000 |   100 |  3.430 μs | 0.0165 μs | 0.0154 μs |  1.24 |    0.01 |  0.0191 |     - |     - |      40 B |
|            LinqOptimizer | 1000 |   100 | 49.139 μs | 0.2203 μs | 0.1840 μs | 17.75 |    0.06 | 15.5640 |     - |     - |  32,618 B |
|                  Streams | 1000 |   100 |  7.713 μs | 0.0347 μs | 0.0290 μs |  2.79 |    0.02 |  0.4272 |     - |     - |     920 B |
|               StructLinq | 1000 |   100 |  3.500 μs | 0.0174 μs | 0.0145 μs |  1.26 |    0.01 |  0.0610 |     - |     - |     128 B |
| StructLinq_ValueDelegate | 1000 |   100 |  3.478 μs | 0.0586 μs | 0.0575 μs |  1.25 |    0.02 |  0.0191 |     - |     - |      40 B |
|                Hyperlinq | 1000 |   100 |  3.755 μs | 0.0204 μs | 0.0191 μs |  1.36 |    0.01 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  3.671 μs | 0.0149 μs | 0.0124 μs |  1.33 |    0.01 |  0.0191 |     - |     - |      40 B |
