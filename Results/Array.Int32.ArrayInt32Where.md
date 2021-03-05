## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **6.825 ns** |  **0.0279 ns** |  **0.0233 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     7.649 ns |  0.0283 ns |  0.0251 ns |  1.12 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    59.613 ns |  0.2431 ns |  0.2274 ns |  8.74 |    0.05 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |    10 |    38.107 ns |  0.2017 ns |  0.1685 ns |  5.58 |    0.03 | 0.0459 |     - |     - |      96 B |
|               LinqAF |    10 |    49.378 ns |  0.1158 ns |  0.1026 ns |  7.24 |    0.03 |      - |     - |     - |         - |
|           StructLinq |    10 |    39.773 ns |  0.0993 ns |  0.0929 ns |  5.83 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    36.142 ns |  0.0665 ns |  0.0623 ns |  5.30 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    41.249 ns |  0.0955 ns |  0.0893 ns |  6.04 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    38.221 ns |  0.0547 ns |  0.0511 ns |  5.60 |    0.02 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** | **1,385.415 ns** |  **3.7240 ns** |  **3.3013 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   745.706 ns |  2.6851 ns |  2.3803 ns |  0.54 |    0.00 |      - |     - |     - |         - |
|                 Linq |  1000 | 6,276.290 ns | 19.0348 ns | 16.8739 ns |  4.53 |    0.02 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |  1000 | 3,821.219 ns | 18.9225 ns | 17.7002 ns |  2.76 |    0.02 | 2.8915 |     - |     - |   6,064 B |
|               LinqAF |  1000 | 6,173.482 ns | 10.4934 ns |  9.3021 ns |  4.46 |    0.01 |      - |     - |     - |         - |
|           StructLinq |  1000 | 5,862.826 ns | 25.7825 ns | 24.1170 ns |  4.23 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 1,791.706 ns |  5.8687 ns |  5.2024 ns |  1.29 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 5,205.071 ns | 12.6201 ns | 11.1874 ns |  3.76 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 1,903.716 ns |  4.8553 ns |  4.3041 ns |  1.37 |    0.01 |      - |     - |     - |         - |
