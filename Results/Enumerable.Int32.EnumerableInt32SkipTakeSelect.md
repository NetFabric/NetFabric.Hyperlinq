## Enumerable.Int32.EnumerableInt32SkipTakeSelect

### Source
[EnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeSelect.cs)

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
|                   Method | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                     Linq | 1000 |   100 |  3.651 μs | 0.0298 μs | 0.0264 μs |  1.00 |    0.00 |  0.0992 |     - |     - |     208 B |
|                   LinqAF | 1000 |   100 |  3.417 μs | 0.0164 μs | 0.0137 μs |  0.94 |    0.01 |  0.0191 |     - |     - |      40 B |
|            LinqOptimizer | 1000 |   100 | 51.096 μs | 0.3520 μs | 0.3120 μs | 14.00 |    0.11 | 15.5640 |     - |     - |  32,618 B |
|                  Streams | 1000 |   100 |  8.440 μs | 0.0628 μs | 0.0524 μs |  2.31 |    0.02 |  0.4272 |     - |     - |     920 B |
|               StructLinq | 1000 |   100 |  2.713 μs | 0.0141 μs | 0.0132 μs |  0.74 |    0.01 |  0.0610 |     - |     - |     128 B |
| StructLinq_ValueDelegate | 1000 |   100 |  3.396 μs | 0.0141 μs | 0.0125 μs |  0.93 |    0.01 |  0.0191 |     - |     - |      40 B |
|                Hyperlinq | 1000 |   100 |  2.512 μs | 0.0131 μs | 0.0116 μs |  0.69 |    0.01 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  3.415 μs | 0.0217 μs | 0.0203 μs |  0.94 |    0.01 |  0.0191 |     - |     - |      40 B |
