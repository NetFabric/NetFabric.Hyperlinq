## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

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
|               Method |      Job |  Runtime | Count |         Mean |       Error |      StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |------ |-------------:|------------:|------------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |     **5.875 ns** |   **0.1454 ns** |   **0.2836 ns** |     **5.945 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |    18.307 ns |   1.6310 ns |   4.8090 ns |    16.366 ns |  3.01 |    0.59 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |    87.510 ns |   0.4931 ns |   0.4371 ns |    87.453 ns | 15.57 |    0.90 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |    10 |    32.181 ns |   0.1168 ns |   0.0976 ns |    32.212 ns |  5.74 |    0.35 |      - |     - |     - |         - |
|               LinqAF | .NET 5.0 | .NET 5.0 |    10 |    85.761 ns |   1.4247 ns |   1.9502 ns |    85.742 ns | 14.96 |    0.85 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |    29.890 ns |   0.1637 ns |   0.1451 ns |    29.922 ns |  5.32 |    0.33 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |     6.848 ns |   0.0372 ns |   0.0348 ns |     6.844 ns |  1.21 |    0.07 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    64.082 ns |   0.2301 ns |   0.2040 ns |    64.052 ns | 11.40 |    0.69 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    49.605 ns |   0.1008 ns |   0.0943 ns |    49.627 ns |  8.78 |    0.53 |      - |     - |     - |         - |
|                      |          |          |       |              |             |             |              |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |    10 |     4.595 ns |   0.0141 ns |   0.0125 ns |     4.596 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |    17.488 ns |   0.2272 ns |   0.2125 ns |    17.499 ns |  3.81 |    0.05 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |    91.377 ns |   0.4179 ns |   0.3910 ns |    91.331 ns | 19.88 |    0.11 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |    10 |    32.246 ns |   0.1761 ns |   0.1561 ns |    32.198 ns |  7.02 |    0.04 |      - |     - |     - |         - |
|               LinqAF | .NET 6.0 | .NET 6.0 |    10 |    83.254 ns |   1.6294 ns |   2.6312 ns |    83.436 ns | 18.05 |    0.71 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |    30.180 ns |   0.1334 ns |   0.1248 ns |    30.134 ns |  6.57 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |     7.798 ns |   0.0283 ns |   0.0251 ns |     7.798 ns |  1.70 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    63.969 ns |   0.3043 ns |   0.2541 ns |    63.921 ns | 13.92 |    0.06 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    49.864 ns |   0.1020 ns |   0.0904 ns |    49.854 ns | 10.85 |    0.04 |      - |     - |     - |         - |
|                      |          |          |       |              |             |             |              |       |         |        |       |       |           |
|              **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** |   **665.315 ns** |   **3.1912 ns** |   **2.6648 ns** |   **666.139 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 | 1,809.956 ns |   4.9763 ns |   4.4114 ns | 1,808.738 ns |  2.72 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 | 6,111.924 ns |  19.5170 ns |  16.2976 ns | 6,111.615 ns |  9.19 |    0.05 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 5.0 | .NET 5.0 |  1000 | 3,472.079 ns |   6.8347 ns |   5.7073 ns | 3,472.871 ns |  5.22 |    0.02 |      - |     - |     - |         - |
|               LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 7,268.320 ns | 144.1955 ns | 232.8489 ns | 7,292.526 ns | 10.86 |    0.39 |      - |     - |     - |         - |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 1,997.126 ns |  10.3635 ns |   9.6941 ns | 1,995.561 ns |  3.00 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 |   787.625 ns |   2.7654 ns |   2.4514 ns |   786.711 ns |  1.18 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 | 5,018.762 ns |  21.7224 ns |  20.3191 ns | 5,017.719 ns |  7.54 |    0.05 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 3,399.880 ns |   6.8741 ns |   5.7402 ns | 3,399.987 ns |  5.11 |    0.02 |      - |     - |     - |         - |
|                      |          |          |       |              |             |             |              |       |         |        |       |       |           |
|              ForLoop | .NET 6.0 | .NET 6.0 |  1000 |   754.538 ns |   6.6323 ns |   6.2039 ns |   756.671 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 | 1,790.014 ns |   5.5802 ns |   5.2197 ns | 1,788.920 ns |  2.37 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 | 6,298.537 ns |  25.2556 ns |  19.7179 ns | 6,300.831 ns |  8.36 |    0.08 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 6.0 | .NET 6.0 |  1000 | 3,309.525 ns |   7.4419 ns |   6.5971 ns | 3,309.883 ns |  4.39 |    0.04 |      - |     - |     - |         - |
|               LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 7,011.895 ns | 138.4240 ns | 249.6070 ns | 7,056.413 ns |  9.26 |    0.33 |      - |     - |     - |         - |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 2,021.439 ns |  12.2691 ns |  11.4766 ns | 2,021.984 ns |  2.68 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 |   793.928 ns |   1.9091 ns |   1.6923 ns |   794.294 ns |  1.05 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 | 4,697.425 ns |  19.6490 ns |  17.4183 ns | 4,697.015 ns |  6.23 |    0.06 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 3,654.213 ns |  23.1877 ns |  21.6898 ns | 3,651.565 ns |  4.84 |    0.06 |      - |     - |     - |         - |
