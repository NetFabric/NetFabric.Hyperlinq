## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|                  ForLoop |   100 |  1.023 μs | 0.0024 μs | 0.0020 μs |  1.024 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|              ForeachLoop |   100 |  1.202 μs | 0.0041 μs | 0.0038 μs |  1.203 μs |  1.17 |    0.00 |       - |       - |     - |         - |
|                     Linq |   100 |  1.968 μs | 0.0124 μs | 0.0110 μs |  1.964 μs |  1.92 |    0.01 |  0.1793 |       - |     - |     376 B |
|               LinqFaster |   100 |  2.795 μs | 0.0484 μs | 0.0378 μs |  2.798 μs |  2.73 |    0.04 |  3.8605 |       - |     - |   8,088 B |
|                   LinqAF |   100 |  2.674 μs | 0.0192 μs | 0.0180 μs |  2.672 μs |  2.61 |    0.01 |       - |       - |     - |         - |
|            LinqOptimizer |   100 | 62.790 μs | 2.0820 μs | 6.1390 μs | 58.466 μs | 61.70 |    5.79 | 57.6782 | 19.2261 |     - | 157,298 B |
|                  Streams |   100 |  7.085 μs | 0.1336 μs | 0.1250 μs |  7.016 μs |  6.91 |    0.13 |  0.4730 |       - |     - |   1,000 B |
|               StructLinq |   100 |  1.199 μs | 0.0030 μs | 0.0024 μs |  1.200 μs |  1.17 |    0.00 |  0.0343 |       - |     - |      72 B |
| StructLinq_ValueDelegate |   100 |  1.088 μs | 0.0051 μs | 0.0048 μs |  1.087 μs |  1.06 |    0.00 |       - |       - |     - |         - |
|                Hyperlinq |   100 |  1.515 μs | 0.0075 μs | 0.0066 μs |  1.513 μs |  1.48 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1.291 μs | 0.0073 μs | 0.0057 μs |  1.293 μs |  1.26 |    0.01 |       - |       - |     - |         - |
