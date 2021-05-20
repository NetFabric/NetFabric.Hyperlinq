## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

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
|                   Method | Count |      Mean |     Error |    StdDev |    Median |         Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|----------:|--------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |  1.917 μs | 0.0377 μs | 0.0353 μs |  1.925 μs |      baseline |         |  5.5237 |     - |     - |     11 KB |
|              ForeachLoop |   100 |  1.827 μs | 0.0310 μs | 0.0290 μs |  1.821 μs |  1.05x faster |   0.02x |  5.5237 |     - |     - |     11 KB |
|                     Linq |   100 |  1.766 μs | 0.0303 μs | 0.0748 μs |  1.745 μs |  1.04x faster |   0.06x |  4.0035 |     - |     - |      8 KB |
|               LinqFaster |   100 |  2.953 μs | 0.0344 μs | 0.0305 μs |  2.948 μs |  1.54x slower |   0.03x |  5.5237 |     - |     - |     11 KB |
|             LinqFasterer |   100 |  2.019 μs | 0.0407 μs | 0.1121 μs |  1.968 μs |  1.10x slower |   0.05x |  6.3934 |     - |     - |     13 KB |
|                   LinqAF |   100 |  3.448 μs | 0.0381 μs | 0.0570 μs |  3.438 μs |  1.81x slower |   0.06x |  5.5084 |     - |     - |     11 KB |
|            LinqOptimizer |   100 | 75.268 μs | 0.7218 μs | 0.5635 μs | 75.337 μs | 39.36x slower |   0.93x | 73.9746 |     - |     - |    155 KB |
|                 SpanLinq |   100 |  2.270 μs | 0.0204 μs | 0.0181 μs |  2.269 μs |  1.19x slower |   0.03x |  5.5237 |     - |     - |     11 KB |
|                  Streams |   100 |  7.817 μs | 0.0956 μs | 0.0894 μs |  7.779 μs |  4.08x slower |   0.07x |  5.7678 |     - |     - |     12 KB |
|               StructLinq |   100 |  1.520 μs | 0.0169 μs | 0.0158 μs |  1.517 μs |  1.26x faster |   0.02x |  1.7109 |     - |     - |      4 KB |
| StructLinq_ValueDelegate |   100 |  1.332 μs | 0.0347 μs | 0.1023 μs |  1.304 μs |  1.40x faster |   0.09x |  1.6575 |     - |     - |      3 KB |
|                Hyperlinq |   100 |  1.806 μs | 0.0270 μs | 0.0252 μs |  1.803 μs |  1.06x faster |   0.03x |  1.6632 |     - |     - |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.454 μs | 0.0208 μs | 0.0174 μs |  1.451 μs |  1.32x faster |   0.04x |  1.6632 |     - |     - |      3 KB |
