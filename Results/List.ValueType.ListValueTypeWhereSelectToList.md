## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|                   Method | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|                  ForLoop |   100 |  1.374 μs | 0.0313 μs | 0.0922 μs |  1.324 μs |  1.00 |    0.00 |  3.8605 |       - |     - |      8 KB |
|              ForeachLoop |   100 |  1.510 μs | 0.0204 μs | 0.0280 μs |  1.512 μs |  1.01 |    0.06 |  3.8605 |       - |     - |      8 KB |
|                     Linq |   100 |  1.818 μs | 0.0362 μs | 0.0985 μs |  1.842 μs |  1.32 |    0.09 |  4.0436 |       - |     - |      8 KB |
|               LinqFaster |   100 |  1.979 μs | 0.0214 μs | 0.0189 μs |  1.983 μs |  1.33 |    0.08 |  5.5389 |       - |     - |     11 KB |
|                   LinqAF |   100 |  3.067 μs | 0.0527 μs | 0.0467 μs |  3.063 μs |  2.07 |    0.12 |  3.8605 |       - |     - |      8 KB |
|            LinqOptimizer |   100 | 63.171 μs | 2.0544 μs | 6.0574 μs | 59.109 μs | 46.09 |    4.65 | 58.0444 | 14.4653 |     - |    158 KB |
|                  Streams |   100 |  7.293 μs | 0.1348 μs | 0.3204 μs |  7.116 μs |  5.25 |    0.24 |  4.1199 |       - |     - |      8 KB |
|               StructLinq |   100 |  1.618 μs | 0.0061 μs | 0.0048 μs |  1.619 μs |  1.10 |    0.07 |  1.7262 |       - |     - |      4 KB |
| StructLinq_ValueDelegate |   100 |  1.175 μs | 0.0103 μs | 0.0092 μs |  1.173 μs |  0.79 |    0.05 |  1.6766 |       - |     - |      3 KB |
|                Hyperlinq |   100 |  2.775 μs | 0.0101 μs | 0.0089 μs |  2.775 μs |  1.87 |    0.12 |  1.6747 |       - |     - |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.373 μs | 0.0137 μs | 0.0128 μs |  1.374 μs |  0.92 |    0.06 |  1.6766 |       - |     - |      3 KB |
