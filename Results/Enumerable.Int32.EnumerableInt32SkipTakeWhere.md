## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

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
|              ForeachLoop | 1000 |   100 |  2.841 μs | 0.0086 μs | 0.0080 μs |  1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                     Linq | 1000 |   100 |  3.664 μs | 0.0103 μs | 0.0091 μs |  1.29 |    0.01 |  0.0992 |     - |     - |     208 B |
|                   LinqAF | 1000 |   100 |  3.585 μs | 0.0365 μs | 0.0620 μs |  1.27 |    0.03 |  0.0191 |     - |     - |      40 B |
|            LinqOptimizer | 1000 |   100 | 54.206 μs | 0.2634 μs | 0.2335 μs | 19.07 |    0.11 | 15.9302 |     - |     - |  33,421 B |
|                  Streams | 1000 |   100 |  8.436 μs | 0.0570 μs | 0.0533 μs |  2.97 |    0.02 |  0.4272 |     - |     - |     920 B |
|               StructLinq | 1000 |   100 |  2.950 μs | 0.0123 μs | 0.0103 μs |  1.04 |    0.00 |  0.0610 |     - |     - |     128 B |
| StructLinq_ValueDelegate | 1000 |   100 |  2.948 μs | 0.0164 μs | 0.0145 μs |  1.04 |    0.01 |  0.0191 |     - |     - |      40 B |
|                Hyperlinq | 1000 |   100 |  2.576 μs | 0.0177 μs | 0.0165 μs |  0.91 |    0.01 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  2.623 μs | 0.0109 μs | 0.0102 μs |  0.92 |    0.00 |  0.0191 |     - |     - |      40 B |
