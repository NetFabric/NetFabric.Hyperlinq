## List.Int32.ListInt32Contains

### Source
[ListInt32Contains.cs](../LinqBenchmarks/List/Int32/ListInt32Contains.cs)

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
|               Method | Count |         Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **9.980 ns** | **0.0280 ns** | **0.0262 ns** |  **1.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    24.155 ns | 0.1109 ns | 0.0983 ns |  2.42 |      - |     - |     - |         - |
|                 Linq |    10 |    11.279 ns | 0.0332 ns | 0.0310 ns |  1.13 |      - |     - |     - |         - |
|           LinqFaster |    10 |     7.430 ns | 0.0507 ns | 0.0396 ns |  0.74 |      - |     - |     - |         - |
|               LinqAF |    10 |     7.638 ns | 0.0232 ns | 0.0194 ns |  0.77 |      - |     - |     - |         - |
|           StructLinq |    10 |    17.288 ns | 0.0431 ns | 0.0382 ns |  1.73 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    10.239 ns | 0.0483 ns | 0.0451 ns |  1.03 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     6.482 ns | 0.0247 ns | 0.0219 ns |  0.65 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |    10 |    11.861 ns | 0.0318 ns | 0.0297 ns |  1.19 |      - |     - |     - |         - |
|                      |       |              |           |           |       |        |       |       |           |
|              **ForLoop** |  **1000** | **1,033.580 ns** | **2.5472 ns** | **2.3827 ns** |  **1.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 2,077.479 ns | 5.7655 ns | 5.3931 ns |  2.01 |      - |     - |     - |         - |
|                 Linq |  1000 |   232.026 ns | 0.7347 ns | 0.6872 ns |  0.22 |      - |     - |     - |         - |
|           LinqFaster |  1000 |   228.024 ns | 0.4227 ns | 0.3747 ns |  0.22 |      - |     - |     - |         - |
|               LinqAF |  1000 |   228.426 ns | 0.5006 ns | 0.4438 ns |  0.22 |      - |     - |     - |         - |
|           StructLinq |  1000 |   536.712 ns | 1.1511 ns | 1.0768 ns |  0.52 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |   779.300 ns | 1.6763 ns | 1.4860 ns |  0.75 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |   227.560 ns | 1.2426 ns | 1.0377 ns |  0.22 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |  1000 |   102.423 ns | 0.3437 ns | 0.3215 ns |  0.10 |      - |     - |     - |         - |
