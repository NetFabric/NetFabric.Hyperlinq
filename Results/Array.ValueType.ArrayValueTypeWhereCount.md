## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
|               Method | Count |           Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |     **0** |      **0.5057 ns** |  **0.0113 ns** |  **0.0100 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |      0.5232 ns |  0.0064 ns |  0.0056 ns |  1.03 |    0.02 |      - |     - |     - |         - |
|                 Linq |     0 |      7.5611 ns |  0.0362 ns |  0.0321 ns | 14.96 |    0.30 |      - |     - |     - |         - |
|           LinqFaster |     0 |      1.8778 ns |  0.0132 ns |  0.0117 ns |  3.71 |    0.08 |      - |     - |     - |         - |
|               LinqAF |     0 |     20.4325 ns |  0.0999 ns |  0.0834 ns | 40.41 |    0.78 |      - |     - |     - |         - |
|           StructLinq |     0 |     24.4344 ns |  0.1208 ns |  0.1009 ns | 48.32 |    0.89 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |     0 |     23.0168 ns |  0.0551 ns |  0.0515 ns | 45.52 |    0.88 |      - |     - |     - |         - |
|            Hyperlinq |     0 |     11.8479 ns |  0.0182 ns |  0.0152 ns | 23.43 |    0.48 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |      9.4770 ns |  0.0137 ns |  0.0115 ns | 18.74 |    0.38 |      - |     - |     - |         - |
|                      |       |                |            |            |       |         |        |       |       |           |
|              **ForLoop** |    **10** |      **9.0912 ns** |  **0.1000 ns** |  **0.0935 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |      9.4441 ns |  0.0475 ns |  0.0371 ns |  1.04 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |     71.9927 ns |  0.2774 ns |  0.2595 ns |  7.92 |    0.09 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |     27.2218 ns |  0.1227 ns |  0.1088 ns |  2.99 |    0.04 |      - |     - |     - |         - |
|               LinqAF |    10 |     75.3699 ns |  0.7858 ns |  0.6966 ns |  8.29 |    0.11 |      - |     - |     - |         - |
|           StructLinq |    10 |     48.3942 ns |  0.1550 ns |  0.1294 ns |  5.32 |    0.06 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |     39.8730 ns |  0.0510 ns |  0.0452 ns |  4.38 |    0.05 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     25.5942 ns |  0.0693 ns |  0.0615 ns |  2.81 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     16.8536 ns |  0.0502 ns |  0.0445 ns |  1.85 |    0.02 |      - |     - |     - |         - |
|                      |       |                |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |    **821.9234 ns** |  **2.7935 ns** |  **2.3327 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  1,278.0184 ns |  7.4534 ns |  6.9719 ns |  1.55 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 10,211.5982 ns | 32.9947 ns | 30.8633 ns | 12.42 |    0.05 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 |  3,408.7701 ns | 13.1752 ns | 11.0019 ns |  4.15 |    0.01 |      - |     - |     - |         - |
|               LinqAF |  1000 | 11,533.1089 ns | 32.7491 ns | 27.3470 ns | 14.03 |    0.05 |      - |     - |     - |         - |
|           StructLinq |  1000 |  4,888.6196 ns | 37.1051 ns | 32.8927 ns |  5.95 |    0.04 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |  1,766.0547 ns |  8.8090 ns |  7.8089 ns |  2.15 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |  1,840.5954 ns |  6.1211 ns |  5.4262 ns |  2.24 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  1,050.1456 ns |  4.0181 ns |  3.5620 ns |  1.28 |    0.01 |      - |     - |     - |         - |
