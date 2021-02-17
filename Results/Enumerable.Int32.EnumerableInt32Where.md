## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                 **Linq** |     **0** |     **65.12 ns** |   **0.745 ns** |   **0.697 ns** |  **1.00** |    **0.00** | **0.0459** |     **-** |     **-** |      **96 B** |
|               LinqAF |     0 |     50.69 ns |   0.464 ns |   0.411 ns |  0.78 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq |     0 |     23.08 ns |   0.146 ns |   0.130 ns |  0.35 |    0.00 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |     0 |     24.65 ns |   0.083 ns |   0.070 ns |  0.38 |    0.00 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |     0 |     21.09 ns |   0.176 ns |   0.156 ns |  0.32 |    0.00 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |     0 |     24.53 ns |   0.113 ns |   0.106 ns |  0.38 |    0.00 | 0.0191 |     - |     - |      40 B |
|                      |       |              |            |            |       |         |        |       |       |           |
|                 **Linq** |    **10** |    **197.04 ns** |   **3.774 ns** |   **4.635 ns** |  **1.00** |    **0.00** | **0.0458** |     **-** |     **-** |      **96 B** |
|               LinqAF |    10 |    178.38 ns |   3.554 ns |   5.097 ns |  0.90 |    0.03 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |    132.50 ns |   2.574 ns |   2.643 ns |  0.67 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |     93.63 ns |   1.867 ns |   2.150 ns |  0.48 |    0.02 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    144.68 ns |   2.885 ns |   4.976 ns |  0.73 |    0.03 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |    10 |     89.97 ns |   1.807 ns |   2.009 ns |  0.46 |    0.02 | 0.0191 |     - |     - |      40 B |
|                      |       |              |            |            |       |         |        |       |       |           |
|                 **Linq** |  **1000** | **15,952.92 ns** | **319.021 ns** | **925.537 ns** |  **1.00** |    **0.00** | **0.0458** |     **-** |     **-** |      **96 B** |
|               LinqAF |  1000 | 13,201.14 ns | 251.082 ns | 652.595 ns |  0.83 |    0.07 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 13,159.41 ns | 260.448 ns | 672.300 ns |  0.83 |    0.05 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |  9,144.36 ns | 190.432 ns | 555.499 ns |  0.58 |    0.05 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 13,232.88 ns | 261.578 ns | 651.419 ns |  0.83 |    0.07 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction |  1000 |  9,164.72 ns | 181.820 ns | 527.494 ns |  0.58 |    0.05 | 0.0153 |     - |     - |      40 B |
