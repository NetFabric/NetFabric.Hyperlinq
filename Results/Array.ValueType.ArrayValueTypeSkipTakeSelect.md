## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|                   Method | Skip | Count |      Mean |     Error |    StdDev |    Median |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |----------:|----------:|----------:|----------:|--------------:|--------:|--------:|--------:|------:|----------:|
|                  ForLoop | 1000 |   100 |  2.244 μs | 0.0157 μs | 0.0147 μs |  2.241 μs |      baseline |         |       - |       - |     - |         - |
|                     Linq | 1000 |   100 |  2.664 μs | 0.0143 μs | 0.0134 μs |  2.665 μs |  1.19x slower |   0.01x |  0.1526 |       - |     - |     320 B |
|               LinqFaster | 1000 |   100 |  3.419 μs | 0.0562 μs | 0.0526 μs |  3.407 μs |  1.52x slower |   0.03x |  9.2010 |       - |     - |  19,272 B |
|             LinqFasterer | 1000 |   100 |  3.662 μs | 0.1255 μs | 0.3699 μs |  3.436 μs |  1.90x slower |   0.12x |  6.1531 |       - |     - |  12,880 B |
|                   LinqAF | 1000 |   100 |  8.383 μs | 0.1644 μs | 0.1759 μs |  8.317 μs |  3.75x slower |   0.07x |       - |       - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 59.447 μs | 1.1044 μs | 2.6247 μs | 58.488 μs | 26.64x slower |   1.32x | 72.6929 | 18.1274 |     - | 160,689 B |
|                 SpanLinq | 1000 |   100 |  2.285 μs | 0.0320 μs | 0.0299 μs |  2.274 μs |  1.02x slower |   0.02x |       - |       - |     - |         - |
|                  Streams | 1000 |   100 | 18.694 μs | 0.1299 μs | 0.1152 μs | 18.689 μs |  8.33x slower |   0.08x |  0.5493 |       - |     - |   1,152 B |
|               StructLinq | 1000 |   100 |  1.970 μs | 0.0106 μs | 0.0100 μs |  1.974 μs |  1.14x faster |   0.01x |  0.0458 |       - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |  1.853 μs | 0.0113 μs | 0.0106 μs |  1.853 μs |  1.21x faster |   0.01x |       - |       - |     - |         - |
|                Hyperlinq | 1000 |   100 |  2.062 μs | 0.0112 μs | 0.0099 μs |  2.062 μs |  1.09x faster |   0.01x |       - |       - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  1.812 μs | 0.0122 μs | 0.0108 μs |  1.808 μs |  1.24x faster |   0.01x |       - |       - |     - |         - |
