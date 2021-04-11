## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

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
|                      Method |      Job |  Runtime | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |--------- |--------- |------ |------------:|----------:|----------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |    **163.7 ns** |   **0.69 ns** |   **0.61 ns** |    **163.7 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5.0 | .NET 5.0 |    10 |    180.4 ns |   0.83 ns |   0.69 ns |    180.2 ns |  1.10 |    0.01 |       - |     - |     - |         - |
|                        Linq | .NET 5.0 | .NET 5.0 |    10 |    267.7 ns |   0.83 ns |   0.69 ns |    267.7 ns |  1.64 |    0.01 |  0.0496 |     - |     - |     104 B |
|                  LinqFaster | .NET 5.0 | .NET 5.0 |    10 |    253.4 ns |   5.08 ns |  10.15 ns |    258.2 ns |  1.46 |    0.05 |  0.3171 |     - |     - |     664 B |
|                      LinqAF | .NET 5.0 | .NET 5.0 |    10 |    342.4 ns |   2.16 ns |   2.02 ns |    342.3 ns |  2.09 |    0.01 |       - |     - |     - |         - |
|                  StructLinq | .NET 5.0 | .NET 5.0 |    10 |    216.9 ns |   0.83 ns |   0.78 ns |    217.2 ns |  1.32 |    0.01 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    211.8 ns |   0.46 ns |   0.41 ns |    211.7 ns |  1.29 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5.0 | .NET 5.0 |    10 |    239.6 ns |   2.31 ns |   2.16 ns |    239.2 ns |  1.46 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5.0 | .NET 5.0 |    10 |    199.6 ns |   0.49 ns |   0.41 ns |    199.6 ns |  1.22 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5.0 | .NET 5.0 |    10 |    216.2 ns |   0.50 ns |   0.45 ns |    216.1 ns |  1.32 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5.0 | .NET 5.0 |    10 |    192.6 ns |   0.81 ns |   0.71 ns |    192.7 ns |  1.18 |    0.00 |       - |     - |     - |         - |
|                             |          |          |       |             |           |           |             |       |         |         |       |       |           |
|                     ForLoop | .NET 6.0 | .NET 6.0 |    10 |    166.4 ns |   0.79 ns |   0.70 ns |    166.3 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |    177.2 ns |   0.37 ns |   0.35 ns |    177.4 ns |  1.06 |    0.00 |       - |     - |     - |         - |
|                        Linq | .NET 6.0 | .NET 6.0 |    10 |    261.6 ns |   0.78 ns |   0.73 ns |    261.6 ns |  1.57 |    0.01 |  0.0496 |     - |     - |     104 B |
|                  LinqFaster | .NET 6.0 | .NET 6.0 |    10 |    243.3 ns |   4.88 ns |  10.49 ns |    238.4 ns |  1.45 |    0.05 |  0.3173 |     - |     - |     664 B |
|                      LinqAF | .NET 6.0 | .NET 6.0 |    10 |    343.9 ns |   1.41 ns |   1.25 ns |    343.9 ns |  2.07 |    0.01 |       - |     - |     - |         - |
|                  StructLinq | .NET 6.0 | .NET 6.0 |    10 |    215.0 ns |   2.31 ns |   2.05 ns |    215.9 ns |  1.29 |    0.01 |  0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    212.2 ns |   0.38 ns |   0.34 ns |    212.1 ns |  1.28 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6.0 | .NET 6.0 |    10 |    225.2 ns |   0.43 ns |   0.36 ns |    225.3 ns |  1.35 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6.0 | .NET 6.0 |    10 |    202.4 ns |   0.43 ns |   0.38 ns |    202.5 ns |  1.22 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6.0 | .NET 6.0 |    10 |    215.4 ns |   0.61 ns |   0.54 ns |    215.2 ns |  1.29 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6.0 | .NET 6.0 |    10 |    192.0 ns |   0.51 ns |   0.46 ns |    192.0 ns |  1.15 |    0.01 |       - |     - |     - |         - |
|                             |          |          |       |             |           |           |             |       |         |         |       |       |           |
|                     **ForLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** | **16,298.7 ns** |  **24.28 ns** |  **20.28 ns** | **16,305.7 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | .NET 5.0 | .NET 5.0 |  1000 | 17,869.1 ns |  35.70 ns |  33.39 ns | 17,868.9 ns |  1.10 |    0.00 |       - |     - |     - |         - |
|                        Linq | .NET 5.0 | .NET 5.0 |  1000 | 22,678.2 ns | 223.98 ns | 198.55 ns | 22,596.2 ns |  1.39 |    0.01 |  0.0305 |     - |     - |     104 B |
|                  LinqFaster | .NET 5.0 | .NET 5.0 |  1000 | 24,457.3 ns | 201.51 ns | 319.61 ns | 24,477.4 ns |  1.51 |    0.02 | 30.2734 |     - |     - |  64,024 B |
|                      LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 28,820.5 ns |  93.82 ns |  87.76 ns | 28,784.7 ns |  1.77 |    0.01 |       - |     - |     - |         - |
|                  StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 18,554.7 ns |  89.17 ns |  79.05 ns | 18,542.0 ns |  1.14 |    0.01 |       - |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 18,116.1 ns |  70.27 ns |  62.29 ns | 18,124.4 ns |  1.11 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5.0 | .NET 5.0 |  1000 | 19,536.2 ns |  42.17 ns |  37.38 ns | 19,525.8 ns |  1.20 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 17,189.4 ns |  55.86 ns |  46.65 ns | 17,182.7 ns |  1.05 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5.0 | .NET 5.0 |  1000 | 19,501.6 ns |  72.22 ns |  64.02 ns | 19,489.8 ns |  1.20 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 17,445.9 ns |  61.06 ns |  54.13 ns | 17,456.7 ns |  1.07 |    0.00 |       - |     - |     - |         - |
|                             |          |          |       |             |           |           |             |       |         |         |       |       |           |
|                     ForLoop | .NET 6.0 | .NET 6.0 |  1000 | 16,378.3 ns |  41.85 ns |  34.95 ns | 16,385.9 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 | 17,917.4 ns |  42.19 ns |  37.40 ns | 17,919.6 ns |  1.09 |    0.00 |       - |     - |     - |         - |
|                        Linq | .NET 6.0 | .NET 6.0 |  1000 | 22,517.2 ns |  67.43 ns |  59.78 ns | 22,525.4 ns |  1.37 |    0.00 |  0.0305 |     - |     - |     104 B |
|                  LinqFaster | .NET 6.0 | .NET 6.0 |  1000 | 24,506.3 ns | 410.53 ns | 342.81 ns | 24,588.7 ns |  1.50 |    0.02 | 30.2734 |     - |     - |  64,024 B |
|                      LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 29,052.8 ns |  94.77 ns |  84.02 ns | 29,054.5 ns |  1.77 |    0.01 |       - |     - |     - |         - |
|                  StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 18,777.9 ns |  38.12 ns |  33.80 ns | 18,772.9 ns |  1.15 |    0.00 |       - |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 18,345.9 ns |  65.38 ns |  57.96 ns | 18,331.3 ns |  1.12 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6.0 | .NET 6.0 |  1000 | 19,660.9 ns |  75.70 ns |  67.11 ns | 19,656.9 ns |  1.20 |    0.01 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 17,271.5 ns |  53.99 ns |  47.86 ns | 17,265.5 ns |  1.05 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6.0 | .NET 6.0 |  1000 | 19,530.1 ns |  43.99 ns |  36.74 ns | 19,532.1 ns |  1.19 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 17,204.4 ns |  76.59 ns |  63.95 ns | 17,188.8 ns |  1.05 |    0.00 |       - |     - |     - |         - |
