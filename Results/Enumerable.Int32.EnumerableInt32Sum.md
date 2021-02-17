## Enumerable.Int32.EnumerableInt32Sum

### Source
[EnumerableInt32Sum.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Sum.cs)

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
|               Method | Count |        Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** |     **0** |    **14.10 ns** |   **0.176 ns** |   **0.156 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |     0 |    17.85 ns |   0.214 ns |   0.200 ns |  1.27 |    0.02 | 0.0191 |     - |     - |      40 B |
|               LinqAF |     0 |    40.08 ns |   0.608 ns |   0.539 ns |  2.84 |    0.05 | 0.0191 |     - |     - |      40 B |
|           StructLinq |     0 |    32.96 ns |   0.420 ns |   0.350 ns |  2.34 |    0.04 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |     0 |    20.63 ns |   0.169 ns |   0.150 ns |  1.46 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |     0 |    16.35 ns |   0.087 ns |   0.073 ns |  1.16 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |       |             |            |            |       |         |        |       |       |           |
|          **ForeachLoop** |    **10** |    **68.63 ns** |   **1.409 ns** |   **1.623 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |    79.98 ns |   1.629 ns |   1.743 ns |  1.17 |    0.04 | 0.0191 |     - |     - |      40 B |
|               LinqAF |    10 |   103.37 ns |   1.539 ns |   1.439 ns |  1.51 |    0.05 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |    86.07 ns |   1.182 ns |   0.987 ns |  1.26 |    0.03 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    81.26 ns |   1.614 ns |   2.209 ns |  1.19 |    0.04 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    76.67 ns |   1.535 ns |   1.436 ns |  1.12 |    0.04 | 0.0191 |     - |     - |      40 B |
|                      |       |             |            |            |       |         |        |       |       |           |
|          **ForeachLoop** |  **1000** | **6,948.05 ns** | **138.095 ns** | **351.496 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 7,219.40 ns | 143.861 ns | 223.975 ns |  1.04 |    0.06 | 0.0153 |     - |     - |      40 B |
|               LinqAF |  1000 | 7,620.78 ns | 150.446 ns | 267.418 ns |  1.10 |    0.07 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 7,605.78 ns | 149.412 ns | 305.209 ns |  1.10 |    0.08 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 7,593.83 ns | 150.442 ns | 327.049 ns |  1.10 |    0.08 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 7,530.23 ns | 149.900 ns | 332.168 ns |  1.09 |    0.07 | 0.0153 |     - |     - |      40 B |
