## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

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

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Skip | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|------:|------:|----------:|
|                     Linq | 1000 |   100 |  3.278 μs | 0.0230 μs | 0.0192 μs |      baseline |         |  0.0992 |     - |     - |     208 B |
|                   LinqAF | 1000 |   100 |  3.507 μs | 0.0343 μs | 0.0321 μs |  1.07x slower |   0.01x |  0.0191 |     - |     - |      40 B |
|            LinqOptimizer | 1000 |   100 | 57.809 μs | 0.5301 μs | 0.4427 μs | 17.64x slower |   0.16x | 15.9302 |     - |     - |  33,421 B |
|                  Streams | 1000 |   100 |  8.606 μs | 0.0839 μs | 0.0744 μs |  2.63x slower |   0.02x |  0.4272 |     - |     - |     920 B |
|               StructLinq | 1000 |   100 |  3.039 μs | 0.0250 μs | 0.0222 μs |  1.08x faster |   0.01x |  0.0610 |     - |     - |     128 B |
| StructLinq_ValueDelegate | 1000 |   100 |  2.519 μs | 0.0301 μs | 0.0252 μs |  1.30x faster |   0.02x |  0.0191 |     - |     - |      40 B |
|                Hyperlinq | 1000 |   100 |  2.858 μs | 0.0381 μs | 0.0318 μs |  1.15x faster |   0.01x |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  3.560 μs | 0.0249 μs | 0.0221 μs |  1.09x slower |   0.01x |  0.0191 |     - |     - |      40 B |
