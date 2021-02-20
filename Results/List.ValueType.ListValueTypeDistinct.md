## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |           Mean |        Error |       StdDev |         Median | Ratio | RatioSD |    Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|--------------------- |----------- |------ |---------------:|-------------:|-------------:|---------------:|------:|--------:|---------:|--------:|--------:|----------:|
|              **ForLoop** |          **4** |    **10** |     **1,275.5 ns** |      **4.46 ns** |      **3.96 ns** |     **1,274.8 ns** |  **1.00** |    **0.00** |   **1.0891** |       **-** |       **-** |    **2280 B** |
|          ForeachLoop |          4 |    10 |     1,341.1 ns |      3.60 ns |      3.01 ns |     1,340.6 ns |  1.05 |    0.00 |   1.0891 |       - |       - |    2280 B |
|                 Linq |          4 |    10 |     1,688.2 ns |      2.92 ns |      2.73 ns |     1,688.3 ns |  1.32 |    0.00 |   0.9747 |       - |       - |    2040 B |
|           LinqFaster |          4 |    10 |       233.5 ns |      4.61 ns |      4.94 ns |       234.9 ns |  0.18 |    0.00 |   0.0114 |       - |       - |      24 B |
|               LinqAF |          4 |    10 |     3,315.0 ns |     26.13 ns |     20.40 ns |     3,308.0 ns |  2.60 |    0.01 |   2.1706 |       - |       - |    4544 B |
|           StructLinq |          4 |    10 |     1,476.8 ns |      4.04 ns |      3.58 ns |     1,476.4 ns |  1.16 |    0.00 |   0.0305 |       - |       - |      64 B |
| StructLinq_IFunction |          4 |    10 |       587.4 ns |      2.63 ns |      2.33 ns |       586.6 ns |  0.46 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq |          4 |    10 |     1,243.2 ns |      6.34 ns |      5.30 ns |     1,242.7 ns |  0.97 |    0.00 |        - |       - |       - |         - |
|                      |            |       |                |              |              |                |       |         |          |         |         |           |
|              **ForLoop** |          **4** |  **1000** |   **197,679.0 ns** |  **1,733.33 ns** |  **1,621.36 ns** |   **197,259.6 ns** |  **1.00** |    **0.00** |  **86.9141** | **43.4570** | **43.4570** |  **276496 B** |
|          ForeachLoop |          4 |  1000 |   203,613.7 ns |  1,326.52 ns |  1,240.83 ns |   203,407.8 ns |  1.03 |    0.01 |  86.9141 | 43.4570 | 43.4570 |  276496 B |
|                 Linq |          4 |  1000 |   192,043.0 ns |    478.31 ns |    399.41 ns |   192,020.9 ns |  0.97 |    0.01 |  73.9746 |       - |       - |  155112 B |
|           LinqFaster |          4 |  1000 |    33,997.9 ns |     80.84 ns |     71.66 ns |    33,965.8 ns |  0.17 |    0.00 |        - |       - |       - |      24 B |
|               LinqAF |          4 |  1000 | 1,006,655.0 ns | 20,108.20 ns | 52,973.05 ns | 1,026,729.7 ns |  4.63 |    0.37 | 185.5469 |       - |       - |  390784 B |
|           StructLinq |          4 |  1000 |   149,132.5 ns |    456.26 ns |    381.00 ns |   149,053.4 ns |  0.75 |    0.01 |        - |       - |       - |      64 B |
| StructLinq_IFunction |          4 |  1000 |    45,517.8 ns |    100.22 ns |     88.84 ns |    45,530.0 ns |  0.23 |    0.00 |        - |       - |       - |         - |
|            Hyperlinq |          4 |  1000 |   151,251.4 ns |  1,055.48 ns |    987.29 ns |   151,376.2 ns |  0.77 |    0.01 |        - |       - |       - |         - |
