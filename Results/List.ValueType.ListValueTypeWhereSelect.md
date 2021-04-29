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
|                   Method | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|                  ForLoop |   100 |  1.042 μs | 0.0062 μs | 0.0052 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|              ForeachLoop |   100 |  1.230 μs | 0.0065 μs | 0.0061 μs |  1.18 |    0.01 |       - |       - |     - |         - |
|                     Linq |   100 |  1.947 μs | 0.0152 μs | 0.0143 μs |  1.87 |    0.02 |  0.1793 |       - |     - |     376 B |
|               LinqFaster |   100 |  2.419 μs | 0.0349 μs | 0.0327 μs |  2.32 |    0.03 |  3.8605 |       - |     - |   8,088 B |
|             LinqFasterer |   100 |  3.124 μs | 0.0447 μs | 0.0396 μs |  2.99 |    0.04 |  6.4087 |       - |     - |  13,416 B |
|                   LinqAF |   100 |  2.741 μs | 0.0430 μs | 0.0403 μs |  2.63 |    0.03 |       - |       - |     - |         - |
|            LinqOptimizer |   100 | 57.542 μs | 0.3714 μs | 0.3474 μs | 55.14 |    0.31 | 57.6782 | 19.2261 |     - | 157,299 B |
|                  Streams |   100 |  8.223 μs | 0.0419 μs | 0.0350 μs |  7.89 |    0.05 |  0.4730 |       - |     - |   1,000 B |
|               StructLinq |   100 |  1.222 μs | 0.0058 μs | 0.0054 μs |  1.17 |    0.01 |  0.0343 |       - |     - |      72 B |
| StructLinq_ValueDelegate |   100 |  1.117 μs | 0.0039 μs | 0.0035 μs |  1.07 |    0.01 |       - |       - |     - |         - |
|                Hyperlinq |   100 |  1.572 μs | 0.0072 μs | 0.0060 μs |  1.51 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1.309 μs | 0.0055 μs | 0.0046 μs |  1.26 |    0.01 |       - |       - |     - |         - |
