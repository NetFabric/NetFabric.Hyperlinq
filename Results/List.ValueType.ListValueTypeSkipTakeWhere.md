## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|               Method | Skip | Count |          Mean |       Error |      StdDev |    Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |--------------:|------------:|------------:|---------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** | **1000** |     **0** |      **1.661 ns** |   **0.0210 ns** |   **0.0187 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |     0 |  3,974.449 ns |  12.3149 ns |  10.9169 ns | 2,392.99 |   30.12 |  0.0305 |     - |     - |      72 B |
|                 Linq | 1000 |     0 |     68.553 ns |   0.3032 ns |   0.2836 ns |    41.27 |    0.53 |  0.0802 |     - |     - |     168 B |
|           LinqFaster | 1000 |     0 |     26.665 ns |   0.1375 ns |   0.1286 ns |    16.05 |    0.20 |  0.0459 |     - |     - |      96 B |
|               LinqAF | 1000 |     0 |    199.658 ns |   0.6252 ns |   0.5542 ns |   120.21 |    1.28 |       - |     - |     - |         - |
|           StructLinq | 1000 |     0 |     60.388 ns |   0.2200 ns |   0.1950 ns |    36.36 |    0.36 |  0.0573 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |     0 |     42.356 ns |   0.0743 ns |   0.0658 ns |    25.50 |    0.29 |       - |     - |     - |         - |
|            Hyperlinq | 1000 |     0 |     22.991 ns |   0.0659 ns |   0.0584 ns |    13.84 |    0.17 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |     0 |     20.264 ns |   0.0675 ns |   0.0599 ns |    12.20 |    0.13 |       - |     - |     - |         - |
|                      |      |       |               |             |             |          |         |         |       |       |           |
|              **ForLoop** | **1000** |    **10** |     **47.974 ns** |   **0.1219 ns** |   **0.1081 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  5,081.667 ns |  14.0228 ns |  13.1170 ns |   105.94 |    0.38 |  0.0305 |     - |     - |      72 B |
|                 Linq | 1000 |    10 |    248.551 ns |   0.5798 ns |   0.5140 ns |     5.18 |    0.02 |  0.1183 |     - |     - |     248 B |
|           LinqFaster | 1000 |    10 |    266.055 ns |   0.6477 ns |   0.5408 ns |     5.55 |    0.02 |  0.7038 |     - |     - |    1472 B |
|               LinqAF | 1000 |    10 |  6,910.504 ns | 134.9915 ns | 126.2711 ns |   144.18 |    2.64 |       - |     - |     - |         - |
|           StructLinq | 1000 |    10 |    121.221 ns |   0.5090 ns |   0.4762 ns |     2.53 |    0.01 |  0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |    10 |     95.738 ns |   0.1412 ns |   0.1252 ns |     2.00 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |     79.234 ns |   0.3385 ns |   0.3167 ns |     1.65 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |     67.893 ns |   0.1996 ns |   0.1769 ns |     1.42 |    0.01 |       - |     - |     - |         - |
|                      |      |       |               |             |             |          |         |         |       |       |           |
|              **ForLoop** | **1000** |  **1000** |  **4,762.703 ns** |   **7.1173 ns** |   **6.6575 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 |  8,425.357 ns |  34.9155 ns |  32.6600 ns |     1.77 |    0.01 |  0.0305 |     - |     - |      72 B |
|                 Linq | 1000 |  1000 | 19,348.786 ns | 104.5363 ns |  92.6687 ns |     4.06 |    0.02 |  0.0916 |     - |     - |     248 B |
|           LinqFaster | 1000 |  1000 | 24,036.678 ns | 142.9042 ns | 126.6808 ns |     5.05 |    0.03 | 57.6782 |     - |     - |  121136 B |
|               LinqAF | 1000 |  1000 | 33,197.472 ns | 324.6894 ns | 303.7146 ns |     6.97 |    0.07 |       - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  6,424.719 ns |  15.8415 ns |  14.0431 ns |     1.35 |    0.00 |  0.0534 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |  1000 |  4,880.655 ns |  12.8785 ns |  10.7542 ns |     1.02 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 |  5,853.663 ns |  18.8783 ns |  16.7351 ns |     1.23 |    0.00 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  4,819.770 ns |  14.6624 ns |  12.9978 ns |     1.01 |    0.00 |       - |     - |     - |         - |
