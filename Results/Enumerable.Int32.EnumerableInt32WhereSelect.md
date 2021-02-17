## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta38](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta38)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |         Mean |      Error |       StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** |     **0** |     **15.13 ns** |   **0.059 ns** |     **0.050 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |     0 |     96.87 ns |   0.605 ns |     0.505 ns |  6.40 |    0.05 | 0.0764 |     - |     - |     160 B |
|               LinqAF |     0 |     62.99 ns |   0.724 ns |     0.642 ns |  4.16 |    0.05 | 0.0191 |     - |     - |      40 B |
|           StructLinq |     0 |     42.65 ns |   0.346 ns |     0.306 ns |  2.82 |    0.02 | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction |     0 |     35.12 ns |   0.145 ns |     0.136 ns |  2.32 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |     0 |     24.39 ns |   0.265 ns |     0.235 ns |  1.61 |    0.02 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |     0 |     33.54 ns |   0.089 ns |     0.084 ns |  2.22 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |       |              |            |              |       |         |        |       |       |           |
|          **ForeachLoop** |    **10** |     **75.87 ns** |   **1.361 ns** |     **1.137 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |    237.86 ns |   2.902 ns |     2.573 ns |  3.14 |    0.05 | 0.0763 |     - |     - |     160 B |
|               LinqAF |    10 |    144.08 ns |   0.474 ns |     0.420 ns |  1.90 |    0.03 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |    160.45 ns |   1.636 ns |     1.366 ns |  2.12 |    0.03 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |    10 |    100.77 ns |   2.041 ns |     2.507 ns |  1.33 |    0.04 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    161.60 ns |   3.265 ns |     8.486 ns |  2.15 |    0.10 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |    10 |     97.42 ns |   1.965 ns |     1.838 ns |  1.28 |    0.03 | 0.0191 |     - |     - |      40 B |
|                      |       |              |            |              |       |         |        |       |       |           |
|          **ForeachLoop** |  **1000** |  **7,234.20 ns** | **147.990 ns** |   **436.351 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 17,442.75 ns | 360.392 ns | 1,062.624 ns |  2.42 |    0.24 | 0.0610 |     - |     - |     160 B |
|               LinqAF |  1000 | 15,890.35 ns | 314.077 ns |   695.973 ns |  2.21 |    0.24 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 15,122.38 ns | 302.323 ns |   862.544 ns |  2.10 |    0.19 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |  1000 |  9,364.76 ns | 184.523 ns |   532.391 ns |  1.30 |    0.12 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 15,214.57 ns | 303.892 ns |   789.855 ns |  2.12 |    0.20 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction |  1000 |  9,180.68 ns | 182.142 ns |   513.733 ns |  1.28 |    0.12 | 0.0153 |     - |     - |      40 B |
