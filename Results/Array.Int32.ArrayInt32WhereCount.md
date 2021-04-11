## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|               Method |      Job |  Runtime | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |     **6.270 ns** |  **0.0477 ns** |  **0.0423 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |     6.216 ns |  0.0332 ns |  0.0294 ns |  0.99 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |    65.283 ns |  0.3137 ns |  0.2781 ns | 10.41 |    0.09 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |    10 |    22.871 ns |  0.0617 ns |  0.0547 ns |  3.65 |    0.03 |      - |     - |     - |         - |
|               LinqAF | .NET 5.0 | .NET 5.0 |    10 |    36.007 ns |  0.1828 ns |  0.1621 ns |  5.74 |    0.05 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |    51.472 ns |  0.2615 ns |  0.2319 ns |  8.21 |    0.06 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    25.470 ns |  0.1928 ns |  0.1610 ns |  4.06 |    0.04 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    31.010 ns |  0.2795 ns |  0.2478 ns |  4.95 |    0.05 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    25.875 ns |  0.0465 ns |  0.0413 ns |  4.13 |    0.03 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |    10 |     7.716 ns |  0.0313 ns |  0.0244 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |     7.452 ns |  0.0142 ns |  0.0118 ns |  0.97 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |    75.642 ns |  0.3405 ns |  0.3019 ns |  9.81 |    0.05 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |    10 |    23.417 ns |  0.1017 ns |  0.0901 ns |  3.03 |    0.02 |      - |     - |     - |         - |
|               LinqAF | .NET 6.0 | .NET 6.0 |    10 |    33.297 ns |  0.1036 ns |  0.0865 ns |  4.31 |    0.02 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |    55.679 ns |  0.7944 ns |  0.6634 ns |  7.22 |    0.09 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    24.825 ns |  0.0798 ns |  0.0746 ns |  3.22 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    30.646 ns |  0.1672 ns |  0.1482 ns |  3.97 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    24.460 ns |  0.2555 ns |  0.2265 ns |  3.17 |    0.03 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** |   **609.121 ns** |  **2.8429 ns** |  **2.6592 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 | 2,806.164 ns |  8.0547 ns |  7.1403 ns |  4.61 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 | 8,929.908 ns | 60.9419 ns | 50.8892 ns | 14.67 |    0.10 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |  1000 | 3,081.566 ns | 12.2978 ns | 10.9017 ns |  5.06 |    0.03 |      - |     - |     - |         - |
|               LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 3,686.964 ns | 13.9693 ns | 11.6650 ns |  6.06 |    0.03 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 3,273.634 ns | 16.7687 ns | 14.0026 ns |  5.38 |    0.04 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |   712.336 ns |  6.1778 ns |  5.4765 ns |  1.17 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 | 1,829.571 ns |  4.2496 ns |  3.5486 ns |  3.00 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |   695.211 ns |  2.9514 ns |  2.6163 ns |  1.14 |    0.01 |      - |     - |     - |         - |
|                      |          |          |       |              |            |            |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |  1000 |   736.184 ns |  3.0381 ns |  2.6932 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 |   737.414 ns |  4.2640 ns |  3.9885 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 | 9,138.348 ns | 39.4208 ns | 34.9455 ns | 12.41 |    0.06 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |  1000 | 3,856.950 ns | 15.7033 ns | 13.9206 ns |  5.24 |    0.03 |      - |     - |     - |         - |
|               LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 3,198.326 ns | 16.8128 ns | 14.0394 ns |  4.34 |    0.03 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 3,193.082 ns | 12.1858 ns | 10.1757 ns |  4.34 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |   707.721 ns |  3.4208 ns |  3.0325 ns |  0.96 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 | 1,587.735 ns |  7.3885 ns |  6.1697 ns |  2.16 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |   719.019 ns |  7.7073 ns |  6.8323 ns |  0.98 |    0.01 |      - |     - |     - |         - |
