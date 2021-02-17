## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|               Method | Count |          Mean |       Error |      StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |--------------:|------------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |     **0** |      **2.561 ns** |   **0.0071 ns** |   **0.0067 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |     12.821 ns |   0.0387 ns |   0.0343 ns |  5.01 |    0.02 |       - |     - |     - |         - |
|                 Linq |     0 |     91.760 ns |   0.3675 ns |   0.3069 ns | 35.83 |    0.18 |  0.1339 |     - |     - |     280 B |
|           LinqFaster |     0 |      9.883 ns |   0.0827 ns |   0.0733 ns |  3.86 |    0.03 |  0.0153 |     - |     - |      32 B |
|               LinqAF |     0 |     93.886 ns |   0.2949 ns |   0.2759 ns | 36.66 |    0.16 |       - |     - |     - |         - |
|           StructLinq |     0 |     35.879 ns |   0.1990 ns |   0.1764 ns | 14.01 |    0.08 |  0.0344 |     - |     - |      72 B |
| StructLinq_IFunction |     0 |     48.495 ns |   0.1349 ns |   0.1196 ns | 18.94 |    0.07 |       - |     - |     - |         - |
|            Hyperlinq |     0 |     28.135 ns |   0.0903 ns |   0.0845 ns | 10.99 |    0.04 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |     28.824 ns |   0.0833 ns |   0.0696 ns | 11.26 |    0.05 |       - |     - |     - |         - |
|                      |       |               |             |             |       |         |         |       |       |           |
|              **ForLoop** |    **10** |     **42.997 ns** |   **0.0954 ns** |   **0.0845 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     74.300 ns |   0.1634 ns |   0.1448 ns |  1.73 |    0.01 |       - |     - |     - |         - |
|                 Linq |    10 |    168.677 ns |   1.4639 ns |   1.2224 ns |  3.92 |    0.03 |  0.1338 |     - |     - |     280 B |
|           LinqFaster |    10 |     92.608 ns |   0.6953 ns |   0.5806 ns |  2.15 |    0.01 |  0.1032 |     - |     - |     216 B |
|               LinqAF |    10 |    233.470 ns |   1.7709 ns |   1.6565 ns |  5.43 |    0.04 |       - |     - |     - |         - |
|           StructLinq |    10 |     90.356 ns |   0.5058 ns |   0.4224 ns |  2.10 |    0.01 |  0.0343 |     - |     - |      72 B |
| StructLinq_IFunction |    10 |     83.193 ns |   0.1409 ns |   0.1249 ns |  1.93 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |    10 |     79.866 ns |   0.2686 ns |   0.2381 ns |  1.86 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     88.882 ns |   0.2154 ns |   0.1910 ns |  2.07 |    0.01 |       - |     - |     - |         - |
|                      |       |               |             |             |       |         |         |       |       |           |
|              **ForLoop** |  **1000** |  **8,782.899 ns** |  **24.7105 ns** |  **23.1142 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 10,820.905 ns |  45.7446 ns |  40.5514 ns |  1.23 |    0.00 |       - |     - |     - |         - |
|                 Linq |  1000 | 18,227.178 ns |  47.3589 ns |  41.9824 ns |  2.07 |    0.01 |  0.1221 |     - |     - |     280 B |
|           LinqFaster |  1000 | 18,177.789 ns | 146.4399 ns | 122.2839 ns |  2.07 |    0.01 | 19.5923 |     - |     - |   41024 B |
|               LinqAF |  1000 | 25,849.638 ns | 147.7764 ns | 130.9999 ns |  2.94 |    0.02 |       - |     - |     - |         - |
|           StructLinq |  1000 | 11,992.776 ns |  31.6921 ns |  29.6448 ns |  1.37 |    0.00 |  0.0305 |     - |     - |      72 B |
| StructLinq_IFunction |  1000 |  8,652.411 ns |  17.0145 ns |  15.0829 ns |  0.98 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq |  1000 | 11,148.464 ns |  34.9902 ns |  31.0179 ns |  1.27 |    0.00 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 10,386.778 ns |  31.3459 ns |  26.1752 ns |  1.18 |    0.01 |       - |     - |     - |         - |
