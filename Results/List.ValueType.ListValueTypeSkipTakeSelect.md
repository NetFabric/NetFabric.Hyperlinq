## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|                   Method | Skip | Count |      Mean |     Error |    StdDev |    Median |         Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |----------:|----------:|----------:|----------:|--------------:|--------:|--------:|-------:|------:|----------:|
|                  ForLoop | 1000 |   100 |  1.805 μs | 0.0089 μs | 0.0083 μs |  1.804 μs |      baseline |         |       - |      - |     - |         - |
|                     Linq | 1000 |   100 |  2.530 μs | 0.0201 μs | 0.0188 μs |  2.526 μs |  1.40x slower |   0.01x |  0.1526 |      - |     - |     320 B |
|               LinqFaster | 1000 |   100 |  5.064 μs | 0.0632 μs | 0.0561 μs |  5.069 μs |  2.81x slower |   0.03x |  9.2545 |      - |     - |  19,368 B |
|             LinqFasterer | 1000 |   100 |  8.726 μs | 0.1420 μs | 0.1186 μs |  8.766 μs |  4.84x slower |   0.08x | 38.4521 |      - |     - |  83,304 B |
|                   LinqAF | 1000 |   100 | 13.364 μs | 0.2661 μs | 0.3984 μs | 13.244 μs |  7.55x slower |   0.22x |       - |      - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 76.504 μs | 2.4676 μs | 7.2759 μs | 72.628 μs | 41.10x slower |   1.67x | 76.4160 | 0.9766 |     - | 161,837 B |
|                 SpanLinq | 1000 |   100 |  2.274 μs | 0.0089 μs | 0.0079 μs |  2.273 μs |  1.26x slower |   0.01x |       - |      - |     - |         - |
|                  Streams | 1000 |   100 | 21.725 μs | 0.3850 μs | 0.3602 μs | 21.726 μs | 12.04x slower |   0.21x |  0.5493 |      - |     - |   1,176 B |
|               StructLinq | 1000 |   100 |  1.977 μs | 0.0304 μs | 0.0338 μs |  1.970 μs |  1.10x slower |   0.02x |  0.0572 |      - |     - |     120 B |
| StructLinq_ValueDelegate | 1000 |   100 |  1.894 μs | 0.0088 μs | 0.0078 μs |  1.893 μs |  1.05x slower |   0.01x |       - |      - |     - |         - |
|                Hyperlinq | 1000 |   100 |  2.053 μs | 0.0103 μs | 0.0086 μs |  2.054 μs |  1.14x slower |   0.01x |       - |      - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  1.801 μs | 0.0086 μs | 0.0081 μs |  1.800 μs |  1.00x faster |   0.01x |       - |      - |     - |         - |
