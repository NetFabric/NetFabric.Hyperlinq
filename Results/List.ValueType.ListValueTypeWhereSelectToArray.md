## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

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
|                   Method | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|-------:|------:|----------:|
|                  ForLoop |   100 |  2.223 μs | 0.0150 μs | 0.0141 μs |  2.220 μs |  1.00 |    0.00 |  5.5237 |      - |     - |     11 KB |
|              ForeachLoop |   100 |  1.726 μs | 0.0105 μs | 0.0087 μs |  1.729 μs |  0.78 |    0.01 |  5.5237 |      - |     - |     11 KB |
|                     Linq |   100 |  1.759 μs | 0.0147 μs | 0.0137 μs |  1.758 μs |  0.79 |    0.01 |  4.0035 |      - |     - |      8 KB |
|               LinqFaster |   100 |  1.929 μs | 0.0127 μs | 0.0119 μs |  1.932 μs |  0.87 |    0.01 |  5.5237 |      - |     - |     11 KB |
|             LinqFasterer |   100 |  1.907 μs | 0.0126 μs | 0.0105 μs |  1.909 μs |  0.86 |    0.01 |  6.3934 |      - |     - |     13 KB |
|                   LinqAF |   100 |  3.295 μs | 0.0283 μs | 0.0251 μs |  3.285 μs |  1.48 |    0.02 |  5.5084 |      - |     - |     11 KB |
|            LinqOptimizer |   100 | 56.969 μs | 0.2931 μs | 0.2742 μs | 56.960 μs | 25.62 |    0.21 | 74.0356 | 0.0610 |     - |    155 KB |
|                  Streams |   100 |  7.377 μs | 0.1304 μs | 0.2179 μs |  7.254 μs |  3.41 |    0.10 |  5.7678 |      - |     - |     12 KB |
|               StructLinq |   100 |  1.469 μs | 0.0291 μs | 0.0369 μs |  1.461 μs |  0.67 |    0.02 |  1.7109 |      - |     - |      4 KB |
| StructLinq_ValueDelegate |   100 |  1.158 μs | 0.0064 μs | 0.0060 μs |  1.157 μs |  0.52 |    0.01 |  1.6575 |      - |     - |      3 KB |
|                Hyperlinq |   100 |  1.820 μs | 0.0358 μs | 0.0352 μs |  1.826 μs |  0.82 |    0.02 |  1.6632 |      - |     - |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.401 μs | 0.0096 μs | 0.0081 μs |  1.402 μs |  0.63 |    0.01 |  1.6632 |      - |     - |      3 KB |
