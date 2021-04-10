## List.Int32.ListInt32Contains

### Source
[ListInt32Contains.cs](../LinqBenchmarks/List/Int32/ListInt32Contains.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |    **10.496 ns** |  **0.1263 ns** |  **0.1182 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    27.421 ns |  0.1808 ns |  0.1510 ns |  2.61 |    0.03 |      - |     - |     - |         - |
|                 Linq |    10 |    11.888 ns |  0.1109 ns |  0.0983 ns |  1.13 |    0.02 |      - |     - |     - |         - |
|           LinqFaster |    10 |     8.434 ns |  0.0688 ns |  0.0643 ns |  0.80 |    0.01 |      - |     - |     - |         - |
|               LinqAF |    10 |     7.960 ns |  0.0527 ns |  0.0440 ns |  0.76 |    0.01 |      - |     - |     - |         - |
|           StructLinq |    10 |    19.024 ns |  0.1738 ns |  0.1541 ns |  1.81 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     9.953 ns |  0.0521 ns |  0.0435 ns |  0.95 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    13.752 ns |  0.1410 ns |  0.1319 ns |  1.31 |    0.02 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |    10 |    18.922 ns |  0.2951 ns |  0.2760 ns |  1.80 |    0.04 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** | **1,066.383 ns** |  **4.6274 ns** |  **4.3284 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 1,906.682 ns | 19.0172 ns | 16.8583 ns |  1.79 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 |   252.498 ns |  1.9517 ns |  1.7301 ns |  0.24 |    0.00 |      - |     - |     - |         - |
|           LinqFaster |  1000 |   234.414 ns |  0.3352 ns |  0.2617 ns |  0.22 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 |   235.564 ns |  1.5535 ns |  1.4532 ns |  0.22 |    0.00 |      - |     - |     - |         - |
|           StructLinq |  1000 |   565.589 ns |  3.2042 ns |  2.9972 ns |  0.53 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |   801.350 ns |  2.3287 ns |  1.9445 ns |  0.75 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |   247.005 ns |  0.7917 ns |  0.7406 ns |  0.23 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |  1000 |   101.909 ns |  0.5171 ns |  0.4584 ns |  0.10 |    0.00 |      - |     - |     - |         - |
