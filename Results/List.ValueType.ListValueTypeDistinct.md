## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

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
|               Method | Duplicates | Count |               Mean |             Error |          StdDev | Ratio | RatioSD |       Gen 0 | Gen 1 | Gen 2 |   Allocated |
|--------------------- |----------- |------ |-------------------:|------------------:|----------------:|------:|--------:|------------:|------:|------:|------------:|
|              **ForLoop** |          **4** |     **0** |           **8.519 ns** |         **0.1380 ns** |       **0.1291 ns** |  **1.00** |    **0.00** |      **0.0344** |     **-** |     **-** |        **72 B** |
|          ForeachLoop |          4 |     0 |          18.804 ns |         0.1438 ns |       0.1275 ns |  2.21 |    0.04 |      0.0344 |     - |     - |        72 B |
|                 Linq |          4 |     0 |          61.033 ns |         0.3172 ns |       0.2812 ns |  7.16 |    0.12 |      0.0803 |     - |     - |       168 B |
|           LinqFaster |          4 |     0 |           2.981 ns |         0.0191 ns |       0.0169 ns |  0.35 |    0.01 |           - |     - |     - |           - |
|               LinqAF |          4 |     0 |         163.458 ns |         0.8740 ns |       0.8175 ns | 19.19 |    0.33 |      0.2370 |     - |     - |       496 B |
|           StructLinq |          4 |     0 |         106.542 ns |         0.5621 ns |       0.5258 ns | 12.51 |    0.21 |      0.0305 |     - |     - |        64 B |
| StructLinq_IFunction |          4 |     0 |          93.750 ns |         0.3442 ns |       0.3220 ns | 11.01 |    0.17 |           - |     - |     - |           - |
|            Hyperlinq |          4 |     0 |          30.505 ns |         0.1164 ns |       0.0972 ns |  3.57 |    0.05 |           - |     - |     - |           - |
|                      |            |       |                    |                   |                 |       |         |             |       |       |             |
|              **ForLoop** |          **4** |    **10** |       **7,370.492 ns** |        **47.8366 ns** |      **44.7464 ns** |  **1.00** |    **0.00** |     **13.0920** |     **-** |     **-** |     **27392 B** |
|          ForeachLoop |          4 |    10 |       7,489.349 ns |        47.2116 ns |      41.8518 ns |  1.02 |    0.01 |     13.0997 |     - |     - |     27392 B |
|                 Linq |          4 |    10 |       7,903.860 ns |        46.2921 ns |      41.0367 ns |  1.07 |    0.01 |     13.0157 |     - |     - |     27224 B |
|           LinqFaster |          4 |    10 |         186.856 ns |         2.7891 ns |       2.4724 ns |  0.03 |    0.00 |      0.0114 |     - |     - |        24 B |
|               LinqAF |          4 |    10 |      21,685.664 ns |       143.9266 ns |     127.5872 ns |  2.94 |    0.02 |     25.4822 |     - |     - |     53304 B |
|           StructLinq |          4 |    10 |       8,391.198 ns |        43.5143 ns |      33.9731 ns |  1.14 |    0.01 |     12.3444 |     - |     - |     25824 B |
| StructLinq_IFunction |          4 |    10 |         578.269 ns |         1.8196 ns |       1.5194 ns |  0.08 |    0.00 |           - |     - |     - |           - |
|            Hyperlinq |          4 |    10 |       7,470.422 ns |        46.3024 ns |      36.1499 ns |  1.01 |    0.01 |     12.3138 |     - |     - |     25760 B |
|                      |            |       |                    |                   |                 |       |         |             |       |       |             |
|              **ForLoop** |          **4** |  **1000** |  **51,274,541.818 ns** |   **223,472.1786 ns** | **209,036.0145 ns** | **1.000** |    **0.00** | **107272.7273** |     **-** |     **-** | **224525352 B** |
|          ForeachLoop |          4 |  1000 |  49,410,644.848 ns |   237,462.5236 ns | 222,122.5919 ns | 0.964 |    0.00 | 107272.7273 |     - |     - | 224525352 B |
|                 Linq |          4 |  1000 |  53,228,758.571 ns |   248,444.1129 ns | 220,239.2348 ns | 1.039 |    0.01 | 107300.0000 |     - |     - | 224442296 B |
|           LinqFaster |          4 |  1000 |      32,982.846 ns |        78.0162 ns |      69.1593 ns | 0.001 |    0.00 |           - |     - |     - |        24 B |
|               LinqAF |          4 |  1000 | 163,793,225.641 ns | 1,150,340.7621 ns | 960,586.6356 ns | 3.196 |    0.02 | 214333.3333 |     - |     - | 448864608 B |
|           StructLinq |          4 |  1000 |  57,142,771.111 ns |   451,150.7799 ns | 422,006.7194 ns | 1.114 |    0.01 | 107222.2222 |     - |     - | 224337076 B |
| StructLinq_IFunction |          4 |  1000 |      42,404.914 ns |       101.7800 ns |      90.2253 ns | 0.001 |    0.00 |           - |     - |     - |           - |
|            Hyperlinq |          4 |  1000 |  43,888,357.051 ns |   793,002.2896 ns | 662,192.8270 ns | 0.856 |    0.01 |  97333.3333 |     - |     - | 203541680 B |
