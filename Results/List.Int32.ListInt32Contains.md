## List.Int32.ListInt32Contains

### Source
[ListInt32Contains.cs](../LinqBenchmarks/List/Int32/ListInt32Contains.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta42](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta42)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |         Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |    **10.104 ns** | **0.0215 ns** | **0.0190 ns** |  **1.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    24.459 ns | 0.0888 ns | 0.0741 ns |  2.42 |      - |     - |     - |         - |
|                 Linq |    10 |    11.406 ns | 0.0471 ns | 0.0393 ns |  1.13 |      - |     - |     - |         - |
|           LinqFaster |    10 |     7.806 ns | 0.0324 ns | 0.0303 ns |  0.77 |      - |     - |     - |         - |
|               LinqAF |    10 |     7.784 ns | 0.0339 ns | 0.0317 ns |  0.77 |      - |     - |     - |         - |
|           StructLinq |    10 |    15.943 ns | 0.0829 ns | 0.0735 ns |  1.58 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    10.019 ns | 0.0184 ns | 0.0153 ns |  0.99 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    11.752 ns | 0.0331 ns | 0.0277 ns |  1.16 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |    10 |    16.632 ns | 0.0323 ns | 0.0286 ns |  1.65 |      - |     - |     - |         - |
|                      |       |              |           |           |       |        |       |       |           |
|              **ForLoop** |  **1000** | **1,037.307 ns** | **2.3942 ns** | **2.1224 ns** |  **1.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 2,081.776 ns | 4.6437 ns | 4.1165 ns |  2.01 |      - |     - |     - |         - |
|                 Linq |  1000 |   232.750 ns | 0.3341 ns | 0.2790 ns |  0.22 |      - |     - |     - |         - |
|           LinqFaster |  1000 |   237.781 ns | 0.6200 ns | 0.5799 ns |  0.23 |      - |     - |     - |         - |
|               LinqAF |  1000 |   228.746 ns | 0.3940 ns | 0.3290 ns |  0.22 |      - |     - |     - |         - |
|           StructLinq |  1000 |   533.790 ns | 1.2957 ns | 1.1486 ns |  0.51 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |   783.193 ns | 1.0957 ns | 0.9713 ns |  0.76 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |   239.673 ns | 0.6263 ns | 0.5230 ns |  0.23 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |  1000 |   107.317 ns | 0.1666 ns | 0.1477 ns |  0.10 |      - |     - |     - |         - |
