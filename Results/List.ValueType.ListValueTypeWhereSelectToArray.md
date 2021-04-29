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
|                   Method | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |  1.622 μs | 0.0291 μs | 0.0272 μs |  1.616 μs |  1.00 |    0.00 |  5.5237 |     - |     - |     11 KB |
|              ForeachLoop |   100 |  1.836 μs | 0.0375 μs | 0.1099 μs |  1.774 μs |  1.18 |    0.08 |  5.5237 |     - |     - |     11 KB |
|                     Linq |   100 |  1.701 μs | 0.0301 μs | 0.0722 μs |  1.677 μs |  1.11 |    0.06 |  4.0035 |     - |     - |      8 KB |
|               LinqFaster |   100 |  2.115 μs | 0.0422 μs | 0.0706 μs |  2.127 μs |  1.29 |    0.07 |  5.5237 |     - |     - |     11 KB |
|                   LinqAF |   100 |  3.273 μs | 0.0405 μs | 0.0379 μs |  3.280 μs |  2.02 |    0.04 |  5.5084 |     - |     - |     11 KB |
|            LinqOptimizer |   100 | 61.324 μs | 1.7022 μs | 5.0189 μs | 58.243 μs | 42.06 |    1.06 | 74.0356 |     - |     - |    155 KB |
|                  Streams |   100 |  7.661 μs | 0.1530 μs | 0.3605 μs |  7.687 μs |  4.87 |    0.14 |  5.7678 |     - |     - |     12 KB |
|               StructLinq |   100 |  1.422 μs | 0.0095 μs | 0.0084 μs |  1.419 μs |  0.88 |    0.01 |  1.7109 |     - |     - |      4 KB |
| StructLinq_ValueDelegate |   100 |  1.169 μs | 0.0125 μs | 0.0111 μs |  1.166 μs |  0.72 |    0.01 |  1.6575 |     - |     - |      3 KB |
|                Hyperlinq |   100 |  1.721 μs | 0.0343 μs | 0.0773 μs |  1.694 μs |  1.12 |    0.05 |  1.6632 |     - |     - |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.363 μs | 0.0257 μs | 0.0352 μs |  1.351 μs |  0.85 |    0.02 |  1.6632 |     - |     - |      3 KB |
