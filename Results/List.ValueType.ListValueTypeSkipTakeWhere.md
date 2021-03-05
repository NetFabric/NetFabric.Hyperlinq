## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Skip | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** | **1000** |    **10** |     **58.52 ns** |   **0.161 ns** |   **0.150 ns** |   **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  4,138.34 ns |   8.250 ns |   7.717 ns |  70.72 |    0.25 |  0.0458 |     - |     - |      96 B |
|                 Linq | 1000 |    10 |    252.60 ns |   0.936 ns |   0.830 ns |   4.32 |    0.01 |  0.1526 |     - |     - |     320 B |
|           LinqFaster | 1000 |    10 |    324.88 ns |   3.146 ns |   2.942 ns |   5.55 |    0.04 |  1.0710 |     - |     - |   2,240 B |
|               LinqAF | 1000 |    10 |  8,615.14 ns | 170.455 ns | 280.062 ns | 147.80 |    4.35 |       - |     - |     - |         - |
|           StructLinq | 1000 |    10 |    123.84 ns |   0.488 ns |   0.381 ns |   2.12 |    0.01 |  0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |    10 |    101.14 ns |   0.225 ns |   0.200 ns |   1.73 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |    142.60 ns |   0.259 ns |   0.217 ns |   2.44 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |    119.79 ns |   0.232 ns |   0.205 ns |   2.05 |    0.01 |       - |     - |     - |         - |
|                      |      |       |              |            |            |        |         |         |       |       |           |
|              **ForLoop** | **1000** |  **1000** |  **6,067.81 ns** |  **10.131 ns** |   **8.981 ns** |   **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 |  8,948.95 ns |  16.571 ns |  13.837 ns |   1.47 |    0.00 |  0.0458 |     - |     - |      96 B |
|                 Linq | 1000 |  1000 | 20,386.91 ns |  35.794 ns |  33.482 ns |   3.36 |    0.01 |  0.1526 |     - |     - |     320 B |
|           LinqFaster | 1000 |  1000 | 32,398.66 ns | 570.362 ns | 533.517 ns |   5.34 |    0.09 | 90.8813 |     - |     - | 193,616 B |
|               LinqAF | 1000 |  1000 | 36,701.67 ns | 473.926 ns | 420.123 ns |   6.05 |    0.07 |       - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  8,215.54 ns |  24.229 ns |  21.479 ns |   1.35 |    0.00 |  0.0458 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |  1000 |  6,657.04 ns |  16.895 ns |  14.977 ns |   1.10 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 | 13,703.16 ns |  22.460 ns |  21.009 ns |   2.26 |    0.00 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  8,917.16 ns |  30.410 ns |  28.445 ns |   1.47 |    0.01 |       - |     - |     - |         - |
