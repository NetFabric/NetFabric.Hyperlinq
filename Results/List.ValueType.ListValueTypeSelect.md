## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|                      Method | Count |          Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |--------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** |     **0** |      **1.936 ns** |  **0.0102 ns** |  **0.0096 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |     0 |     12.341 ns |  0.0286 ns |  0.0254 ns |  6.38 |    0.03 |       - |     - |     - |         - |
|                        Linq |     0 |     54.352 ns |  0.2683 ns |  0.2378 ns | 28.08 |    0.17 |  0.0650 |     - |     - |     136 B |
|                  LinqFaster |     0 |     12.722 ns |  0.0409 ns |  0.0383 ns |  6.57 |    0.04 |  0.0153 |     - |     - |      32 B |
|                      LinqAF |     0 |     84.635 ns |  0.3036 ns |  0.2840 ns | 43.71 |    0.27 |       - |     - |     - |         - |
|                  StructLinq |     0 |     21.663 ns |  0.0744 ns |  0.0660 ns | 11.19 |    0.07 |  0.0191 |     - |     - |      40 B |
|        StructLinq_IFunction |     0 |     31.187 ns |  0.0612 ns |  0.0511 ns | 16.12 |    0.07 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |     0 |     19.954 ns |  0.0632 ns |  0.0591 ns | 10.31 |    0.05 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |     0 |     19.106 ns |  0.0326 ns |  0.0305 ns |  9.87 |    0.05 |       - |     - |     - |         - |
|               Hyperlinq_For |     0 |     10.126 ns |  0.0410 ns |  0.0343 ns |  5.23 |    0.04 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |     0 |      8.296 ns |  0.0360 ns |  0.0301 ns |  4.29 |    0.03 |       - |     - |     - |         - |
|                             |       |               |            |            |       |         |         |       |       |           |
|                     **ForLoop** |    **10** |    **159.498 ns** |  **0.2730 ns** |  **0.2420 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |    192.845 ns |  0.3966 ns |  0.3516 ns |  1.21 |    0.00 |       - |     - |     - |         - |
|                        Linq |    10 |    295.642 ns |  0.6797 ns |  0.6358 ns |  1.85 |    0.00 |  0.0648 |     - |     - |     136 B |
|                  LinqFaster |    10 |    243.269 ns |  1.0312 ns |  0.9142 ns |  1.53 |    0.01 |  0.2179 |     - |     - |     456 B |
|                      LinqAF |    10 |    371.983 ns |  1.3021 ns |  1.2180 ns |  2.33 |    0.01 |       - |     - |     - |         - |
|                  StructLinq |    10 |    204.920 ns |  0.4250 ns |  0.3768 ns |  1.28 |    0.00 |  0.0191 |     - |     - |      40 B |
|        StructLinq_IFunction |    10 |    186.966 ns |  0.2825 ns |  0.2643 ns |  1.17 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    188.137 ns |  0.3634 ns |  0.3399 ns |  1.18 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |    10 |    171.037 ns |  0.3831 ns |  0.3396 ns |  1.07 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For |    10 |    178.385 ns |  0.4101 ns |  0.3635 ns |  1.12 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |    10 |    164.540 ns |  0.4227 ns |  0.3954 ns |  1.03 |    0.00 |       - |     - |     - |         - |
|                             |       |               |            |            |       |         |         |       |       |           |
|                     **ForLoop** |  **1000** | **16,043.721 ns** | **28.8156 ns** | **25.5443 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 | 17,926.095 ns | 24.4197 ns | 21.6474 ns |  1.12 |    0.00 |       - |     - |     - |         - |
|                        Linq |  1000 | 24,030.567 ns | 44.3748 ns | 39.3371 ns |  1.50 |    0.00 |  0.0610 |     - |     - |     136 B |
|                  LinqFaster |  1000 | 23,532.109 ns | 50.6610 ns | 44.9096 ns |  1.47 |    0.00 | 18.8599 |     - |     - |   40056 B |
|                      LinqAF |  1000 | 28,559.924 ns | 60.8877 ns | 53.9754 ns |  1.78 |    0.00 |       - |     - |     - |         - |
|                  StructLinq |  1000 | 18,005.471 ns | 35.5138 ns | 31.4821 ns |  1.12 |    0.00 |       - |     - |     - |      40 B |
|        StructLinq_IFunction |  1000 | 15,499.656 ns | 33.1379 ns | 30.9972 ns |  0.97 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 16,894.476 ns | 33.2156 ns | 29.4448 ns |  1.05 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |  1000 | 15,504.050 ns | 47.0010 ns | 41.6652 ns |  0.97 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 16,694.954 ns | 19.9896 ns | 17.7202 ns |  1.04 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction |  1000 | 15,227.125 ns | 25.1650 ns | 19.6472 ns |  0.95 |    0.00 |       - |     - |     - |         - |
