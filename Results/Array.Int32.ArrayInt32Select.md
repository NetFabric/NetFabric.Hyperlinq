## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta42](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta42)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                      Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                     **ForLoop** |    **10** |     **5.137 ns** |  **0.0154 ns** |  **0.0128 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |    10 |     3.109 ns |  0.0207 ns |  0.0184 ns |  0.61 |    0.00 |      - |     - |     - |         - |
|                        Linq |    10 |   113.569 ns |  0.3082 ns |  0.2574 ns | 22.11 |    0.07 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster |    10 |    29.672 ns |  0.1046 ns |  0.0874 ns |  5.78 |    0.02 | 0.0306 |     - |     - |      64 B |
|             LinqFaster_SIMD |    10 |    19.810 ns |  0.0365 ns |  0.0305 ns |  3.86 |    0.01 | 0.0306 |     - |     - |      64 B |
|                      LinqAF |    10 |    69.011 ns |  0.2037 ns |  0.1701 ns | 13.43 |    0.04 |      - |     - |     - |         - |
|                  StructLinq |    10 |    40.636 ns |  0.1157 ns |  0.0966 ns |  7.91 |    0.03 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |    10 |    36.630 ns |  0.0690 ns |  0.0612 ns |  7.13 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |    10 |    42.133 ns |  0.1397 ns |  0.1167 ns |  8.20 |    0.03 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |    10 |    40.303 ns |  0.0628 ns |  0.0557 ns |  7.84 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For |    10 |    32.407 ns |  0.1616 ns |  0.1350 ns |  6.31 |    0.03 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |    10 |    22.180 ns |  0.0363 ns |  0.0303 ns |  4.32 |    0.01 |      - |     - |     - |         - |
|                             |       |              |            |            |       |         |        |       |       |           |
|                     **ForLoop** |  **1000** |   **524.362 ns** |  **0.9610 ns** |  **0.8519 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop |  1000 |   524.369 ns |  1.8118 ns |  1.5129 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                        Linq |  1000 | 6,364.268 ns | 16.5741 ns | 14.6925 ns | 12.14 |    0.04 | 0.0229 |     - |     - |      48 B |
|                  LinqFaster |  1000 | 2,669.277 ns | 20.0759 ns | 17.7968 ns |  5.09 |    0.04 | 1.9226 |     - |     - |   4,024 B |
|             LinqFaster_SIMD |  1000 |   885.175 ns |  5.6141 ns |  4.6880 ns |  1.69 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|                      LinqAF |  1000 | 3,919.796 ns |  8.6388 ns |  7.6581 ns |  7.48 |    0.02 |      - |     - |     - |         - |
|                  StructLinq |  1000 | 1,865.466 ns |  5.9431 ns |  5.2684 ns |  3.56 |    0.01 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |  1000 | 1,393.435 ns |  2.0284 ns |  1.6938 ns |  2.66 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |  1000 | 2,110.420 ns |  5.5004 ns |  4.5931 ns |  4.03 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_IFunction_Foreach |  1000 | 1,453.031 ns |  2.1966 ns |  1.8342 ns |  2.77 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For |  1000 | 2,093.778 ns |  6.5917 ns |  5.8434 ns |  3.99 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_IFunction_For |  1000 |   790.435 ns |  2.3285 ns |  2.0641 ns |  1.51 |    0.01 |      - |     - |     - |         - |
