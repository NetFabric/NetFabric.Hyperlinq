## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

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
|               Method | Count |        Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** |    **10** |    **61.67 ns** |   **0.561 ns** |   **0.600 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |    92.44 ns |   0.485 ns |   0.378 ns |  1.50 |    0.02 | 0.0191 |     - |     - |      40 B |
|               LinqAF |    10 |   103.86 ns |   2.068 ns |   1.833 ns |  1.68 |    0.03 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |   122.86 ns |   1.327 ns |   1.771 ns |  1.99 |    0.04 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |    10 |    73.90 ns |   0.697 ns |   0.582 ns |  1.20 |    0.02 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    88.58 ns |   1.806 ns |   2.472 ns |  1.45 |    0.03 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |    10 |    60.76 ns |   0.423 ns |   0.396 ns |  0.98 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |       |             |            |            |       |         |        |       |       |           |
|          **ForeachLoop** |  **1000** | **4,545.76 ns** |  **22.751 ns** |  **20.168 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 6,288.39 ns |  42.117 ns |  37.336 ns |  1.38 |    0.01 | 0.0153 |     - |     - |      40 B |
|               LinqAF |  1000 | 6,346.74 ns | 113.603 ns | 106.264 ns |  1.40 |    0.03 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 6,661.48 ns |  37.137 ns |  31.011 ns |  1.47 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |  1000 | 4,765.86 ns |  27.121 ns |  25.369 ns |  1.05 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 5,714.60 ns |  27.874 ns |  26.073 ns |  1.26 |    0.01 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction |  1000 | 4,555.65 ns |  15.634 ns |  13.055 ns |  1.00 |    0.01 | 0.0153 |     - |     - |      40 B |
