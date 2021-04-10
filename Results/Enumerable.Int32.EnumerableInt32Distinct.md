## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

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
|               Method | Count |        Mean |     Error |      StdDev |      Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|------------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|          **ForeachLoop** |    **10** |    **248.7 ns** |   **3.14 ns** |     **2.45 ns** |    **248.1 ns** |  **1.00** |    **0.00** |  **0.3405** |     **-** |     **-** |     **712 B** |
|                 Linq |    10 |    354.5 ns |   6.83 ns |    15.56 ns |    346.3 ns |  1.54 |    0.02 |  0.2942 |     - |     - |     616 B |
|               LinqAF |    10 |    500.8 ns |   5.49 ns |     5.13 ns |    501.9 ns |  2.01 |    0.03 |  0.2942 |     - |     - |     616 B |
|           StructLinq |    10 |    358.3 ns |   2.31 ns |     1.93 ns |    358.5 ns |  1.44 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    364.2 ns |   1.47 ns |     1.30 ns |    364.2 ns |  1.47 |    0.02 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    282.1 ns |   3.68 ns |     3.27 ns |    281.3 ns |  1.14 |    0.01 |  0.0191 |     - |     - |      40 B |
|                      |       |             |           |             |             |       |         |         |       |       |           |
|          **ForeachLoop** |  **1000** | **18,760.9 ns** | **516.09 ns** | **1,497.28 ns** | **17,655.1 ns** |  **1.00** |    **0.00** | **27.7710** |     **-** |     **-** |  **58,712 B** |
|                 Linq |  1000 | 26,367.2 ns | 524.76 ns | 1,316.51 ns | 25,552.7 ns |  1.42 |    0.08 | 15.7776 |     - |     - |  33,112 B |
|               LinqAF |  1000 | 35,203.2 ns | 168.52 ns |   149.39 ns | 35,186.2 ns |  1.79 |    0.09 | 19.5923 |     - |     - |  41,224 B |
|           StructLinq |  1000 | 19,265.1 ns |  84.09 ns |    70.22 ns | 19,267.8 ns |  0.98 |    0.05 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 18,620.4 ns |  90.84 ns |    75.86 ns | 18,605.7 ns |  0.95 |    0.05 |       - |     - |     - |      40 B |
|            Hyperlinq |  1000 | 17,874.5 ns | 114.26 ns |   101.29 ns | 17,866.7 ns |  0.91 |    0.04 |       - |     - |     - |      40 B |
