## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|               Method | Count |          Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |--------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |     **0** |      **1.468 ns** |  **0.0115 ns** |  **0.0102 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |      1.926 ns |  0.0081 ns |  0.0068 ns |  1.31 |    0.01 |       - |     - |     - |         - |
|                 Linq |     0 |     31.249 ns |  0.1203 ns |  0.1125 ns | 21.30 |    0.17 |       - |     - |     - |         - |
|           LinqFaster |     0 |     11.132 ns |  0.0676 ns |  0.0528 ns |  7.59 |    0.06 |  0.0115 |     - |     - |      24 B |
|               LinqAF |     0 |     55.104 ns |  0.1765 ns |  0.1565 ns | 37.54 |    0.28 |       - |     - |     - |         - |
|           StructLinq |     0 |     34.476 ns |  0.1325 ns |  0.1175 ns | 23.49 |    0.19 |  0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |     0 |     42.000 ns |  0.0782 ns |  0.0653 ns | 28.64 |    0.18 |       - |     - |     - |         - |
|            Hyperlinq |     0 |     28.642 ns |  0.0683 ns |  0.0639 ns | 19.51 |    0.13 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |     26.121 ns |  0.0454 ns |  0.0402 ns | 17.80 |    0.13 |       - |     - |     - |         - |
|                      |       |               |            |            |       |         |         |       |       |           |
|              **ForLoop** |    **10** |     **35.811 ns** |  **0.0741 ns** |  **0.0657 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     39.942 ns |  0.0881 ns |  0.0735 ns |  1.12 |    0.00 |       - |     - |     - |         - |
|                 Linq |    10 |    126.204 ns |  0.5359 ns |  0.4750 ns |  3.52 |    0.01 |  0.0801 |     - |     - |     168 B |
|           LinqFaster |    10 |     89.468 ns |  0.9259 ns |  0.7732 ns |  2.50 |    0.02 |  0.2524 |     - |     - |     528 B |
|               LinqAF |    10 |    159.214 ns |  1.5106 ns |  1.4130 ns |  4.45 |    0.04 |       - |     - |     - |         - |
|           StructLinq |    10 |     88.381 ns |  0.2279 ns |  0.1779 ns |  2.47 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |     77.488 ns |  0.1659 ns |  0.1470 ns |  2.16 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |    10 |     78.219 ns |  0.1943 ns |  0.1722 ns |  2.18 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     65.520 ns |  0.1634 ns |  0.1448 ns |  1.83 |    0.00 |       - |     - |     - |         - |
|                      |       |               |            |            |       |         |         |       |       |           |
|              **ForLoop** |  **1000** |  **7,961.143 ns** | **24.2319 ns** | **22.6666 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  8,583.191 ns | 17.3313 ns | 16.2117 ns |  1.08 |    0.00 |       - |     - |     - |         - |
|                 Linq |  1000 | 13,726.329 ns | 27.8188 ns | 24.6606 ns |  1.72 |    0.01 |  0.0763 |     - |     - |     168 B |
|           LinqFaster |  1000 | 13,925.260 ns | 62.2155 ns | 55.1524 ns |  1.75 |    0.01 | 28.5645 |     - |     - |   60168 B |
|               LinqAF |  1000 | 20,843.337 ns | 73.8881 ns | 65.4999 ns |  2.62 |    0.01 |       - |     - |     - |         - |
|           StructLinq |  1000 | 11,204.420 ns | 29.8187 ns | 26.4335 ns |  1.41 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |  8,758.927 ns | 16.6804 ns | 15.6028 ns |  1.10 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq |  1000 | 11,848.197 ns | 37.0883 ns | 32.8778 ns |  1.49 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  8,628.823 ns | 20.4509 ns | 18.1292 ns |  1.08 |    0.00 |       - |     - |     - |         - |
