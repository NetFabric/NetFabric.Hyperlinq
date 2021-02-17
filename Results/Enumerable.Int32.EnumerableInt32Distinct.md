## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

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
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|          **ForeachLoop** |     **0** |     **20.39 ns** |   **0.145 ns** |   **0.136 ns** |  **1.00** |    **0.00** |  **0.0536** |     **-** |     **-** |     **112 B** |
|                 Linq |     0 |     47.02 ns |   0.488 ns |   0.381 ns |  2.30 |    0.02 |  0.0497 |     - |     - |     104 B |
|               LinqAF |     0 |     99.99 ns |   0.483 ns |   0.403 ns |  4.90 |    0.04 |  0.1185 |     - |     - |     248 B |
|           StructLinq |     0 |    106.98 ns |   0.633 ns |   0.561 ns |  5.25 |    0.05 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |     0 |    102.35 ns |   0.564 ns |   0.500 ns |  5.02 |    0.05 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq |     0 |     50.80 ns |   0.586 ns |   0.549 ns |  2.49 |    0.03 |  0.0191 |     - |     - |      40 B |
|                      |       |              |            |            |       |         |         |       |       |           |
|          **ForeachLoop** |    **10** |    **265.12 ns** |   **1.639 ns** |   **1.368 ns** |  **1.00** |    **0.00** |  **0.3405** |     **-** |     **-** |     **712 B** |
|                 Linq |    10 |    358.68 ns |   1.897 ns |   1.682 ns |  1.35 |    0.01 |  0.2942 |     - |     - |     616 B |
|               LinqAF |    10 |    508.19 ns |   3.918 ns |   3.665 ns |  1.92 |    0.01 |  0.2937 |     - |     - |     616 B |
|           StructLinq |    10 |    432.04 ns |   8.681 ns |   9.997 ns |  1.63 |    0.04 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    435.99 ns |   8.643 ns |   9.248 ns |  1.64 |    0.04 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    387.47 ns |   7.695 ns |  11.750 ns |  1.48 |    0.04 |  0.0191 |     - |     - |      40 B |
|                      |       |              |            |            |       |         |         |       |       |           |
|          **ForeachLoop** |  **1000** | **17,697.96 ns** |  **97.826 ns** |  **91.507 ns** |  **1.00** |    **0.00** | **27.7710** |     **-** |     **-** |   **58712 B** |
|                 Linq |  1000 | 26,681.85 ns | 134.041 ns | 104.651 ns |  1.51 |    0.01 | 15.7776 |     - |     - |   33112 B |
|               LinqAF |  1000 | 35,259.95 ns | 464.250 ns | 387.670 ns |  1.99 |    0.02 | 19.5923 |     - |     - |   41224 B |
|           StructLinq |  1000 | 24,609.99 ns | 480.903 ns | 734.389 ns |  1.39 |    0.05 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 23,335.66 ns | 411.224 ns | 615.500 ns |  1.32 |    0.04 |       - |     - |     - |      40 B |
|            Hyperlinq |  1000 | 25,356.48 ns | 504.333 ns | 971.678 ns |  1.44 |    0.07 |       - |     - |     - |      40 B |
