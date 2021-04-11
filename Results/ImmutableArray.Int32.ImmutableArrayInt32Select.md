## ImmutableArray.Int32.ImmutableArrayInt32Select

### Source
[ImmutableArrayInt32Select.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Select.cs)

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
|                      Method |      Job |  Runtime | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |--------- |--------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |     **6.232 ns** |  **0.0324 ns** |  **0.0303 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |     6.124 ns |  0.0372 ns |  0.0330 ns |  0.98 |    0.01 |      - |     - |     - |         - |
|                        Linq | .NET 5.0 | .NET 5.0 |    10 |   115.021 ns |  2.2806 ns |  2.2399 ns | 18.44 |    0.39 | 0.0229 |     - |     - |      48 B |
|                  StructLinq | .NET 5.0 | .NET 5.0 |    10 |    52.926 ns |  0.1456 ns |  0.1216 ns |  8.49 |    0.04 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    42.934 ns |  0.1538 ns |  0.1363 ns |  6.89 |    0.04 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5.0 | .NET 5.0 |    10 |    43.255 ns |  0.1928 ns |  0.1709 ns |  6.94 |    0.04 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 5.0 | .NET 5.0 |    10 |    42.846 ns |  0.0769 ns |  0.0720 ns |  6.88 |    0.04 |      - |     - |     - |         - |
|               Hyperlinq_For | .NET 5.0 | .NET 5.0 |    10 |    33.760 ns |  0.1307 ns |  0.1020 ns |  5.41 |    0.03 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 5.0 | .NET 5.0 |    10 |    24.340 ns |  0.0424 ns |  0.0376 ns |  3.90 |    0.02 |      - |     - |     - |         - |
|                             |          |          |       |              |            |            |       |         |        |       |       |           |
|                     ForLoop | .NET 6.0 | .NET 6.0 |    10 |     3.572 ns |  0.0219 ns |  0.0205 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |     4.905 ns |  0.0477 ns |  0.0398 ns |  1.37 |    0.01 |      - |     - |     - |         - |
|                        Linq | .NET 6.0 | .NET 6.0 |    10 |   103.727 ns |  0.5974 ns |  0.5588 ns | 29.04 |    0.20 | 0.0229 |     - |     - |      48 B |
|                  StructLinq | .NET 6.0 | .NET 6.0 |    10 |    42.893 ns |  0.2628 ns |  0.2330 ns | 12.01 |    0.09 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    36.440 ns |  0.1128 ns |  0.1000 ns | 10.20 |    0.07 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6.0 | .NET 6.0 |    10 |    42.857 ns |  0.2103 ns |  0.1864 ns | 12.00 |    0.09 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 6.0 | .NET 6.0 |    10 |    42.923 ns |  0.2191 ns |  0.1829 ns | 12.03 |    0.09 |      - |     - |     - |         - |
|               Hyperlinq_For | .NET 6.0 | .NET 6.0 |    10 |    32.694 ns |  0.1395 ns |  0.1237 ns |  9.15 |    0.05 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 6.0 | .NET 6.0 |    10 |    25.929 ns |  0.1164 ns |  0.1089 ns |  7.26 |    0.05 |      - |     - |     - |         - |
|                             |          |          |       |              |            |            |       |         |        |       |       |           |
|                     **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** |   **537.982 ns** |  **1.7991 ns** |  **1.5948 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 |   617.864 ns |  2.3211 ns |  2.1712 ns |  1.15 |    0.01 |      - |     - |     - |         - |
|                        Linq | .NET 5.0 | .NET 5.0 |  1000 | 5,853.988 ns | 30.5131 ns | 25.4799 ns | 10.88 |    0.07 | 0.0229 |     - |     - |      48 B |
|                  StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 2,921.581 ns | 11.9112 ns | 10.5590 ns |  5.43 |    0.02 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 2,242.918 ns |  8.7219 ns |  6.8095 ns |  4.17 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5.0 | .NET 5.0 |  1000 | 2,121.034 ns |  8.6291 ns |  7.6495 ns |  3.94 |    0.02 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 5.0 | .NET 5.0 |  1000 | 1,664.958 ns |  4.0207 ns |  3.7610 ns |  3.10 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For | .NET 5.0 | .NET 5.0 |  1000 | 1,846.556 ns |  4.3554 ns |  3.8609 ns |  3.43 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 5.0 | .NET 5.0 |  1000 |   804.642 ns |  2.3576 ns |  1.9687 ns |  1.50 |    0.01 |      - |     - |     - |         - |
|                             |          |          |       |              |            |            |       |         |        |       |       |           |
|                     ForLoop | .NET 6.0 | .NET 6.0 |  1000 |   549.956 ns |  2.0884 ns |  1.8513 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 |   624.751 ns |  3.2321 ns |  3.0234 ns |  1.14 |    0.01 |      - |     - |     - |         - |
|                        Linq | .NET 6.0 | .NET 6.0 |  1000 | 6,127.377 ns | 44.7768 ns | 41.8842 ns | 11.15 |    0.09 | 0.0229 |     - |     - |      48 B |
|                  StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 2,171.883 ns |  5.4550 ns |  5.1026 ns |  3.95 |    0.02 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 1,564.144 ns |  4.2711 ns |  3.9951 ns |  2.84 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6.0 | .NET 6.0 |  1000 | 2,380.985 ns | 10.1319 ns |  8.9816 ns |  4.33 |    0.02 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach | .NET 6.0 | .NET 6.0 |  1000 | 1,715.475 ns |  8.1963 ns |  7.6668 ns |  3.12 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For | .NET 6.0 | .NET 6.0 |  1000 | 1,584.430 ns |  6.9894 ns |  6.1959 ns |  2.88 |    0.02 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For | .NET 6.0 | .NET 6.0 |  1000 |   804.669 ns |  2.1563 ns |  1.8006 ns |  1.46 |    0.01 |      - |     - |     - |         - |
