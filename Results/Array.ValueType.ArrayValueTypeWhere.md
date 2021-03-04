## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta43](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta43)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **21.85 ns** |   **0.081 ns** |   **0.076 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     36.74 ns |   0.137 ns |   0.128 ns |  1.68 |    0.01 |       - |     - |     - |         - |
|                 Linq |    10 |     96.79 ns |   1.710 ns |   1.516 ns |  4.43 |    0.07 |  0.0497 |     - |     - |     104 B |
|           LinqFaster |    10 |     89.60 ns |   0.966 ns |   0.857 ns |  4.10 |    0.04 |  0.3901 |     - |     - |     816 B |
|               LinqAF |    10 |    144.30 ns |   2.823 ns |   3.466 ns |  6.56 |    0.17 |       - |     - |     - |         - |
|           StructLinq |    10 |     58.02 ns |   0.300 ns |   0.280 ns |  2.66 |    0.02 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     53.03 ns |   0.131 ns |   0.116 ns |  2.43 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |    10 |    205.66 ns |   0.254 ns |   0.237 ns |  9.41 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     77.03 ns |   0.404 ns |   0.358 ns |  3.53 |    0.03 |       - |     - |     - |         - |
|                      |       |              |            |            |       |         |         |       |       |           |
|              **ForLoop** |  **1000** |  **4,481.87 ns** |  **21.855 ns** |  **20.443 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  5,793.79 ns |  13.696 ns |  12.141 ns |  1.29 |    0.01 |       - |     - |     - |         - |
|                 Linq |  1000 | 13,015.96 ns |  37.408 ns |  33.161 ns |  2.91 |    0.01 |  0.0458 |     - |     - |     104 B |
|           LinqFaster |  1000 | 13,615.77 ns |  81.009 ns |  71.812 ns |  3.04 |    0.02 | 45.4407 |     - |     - |  96,240 B |
|               LinqAF |  1000 | 15,153.62 ns | 267.558 ns | 250.274 ns |  3.38 |    0.06 |       - |     - |     - |         - |
|           StructLinq |  1000 |  9,784.12 ns |  31.351 ns |  29.326 ns |  2.18 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |  6,946.85 ns |  32.458 ns |  27.104 ns |  1.55 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |  1000 | 11,756.53 ns |  21.053 ns |  17.580 ns |  2.62 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  8,045.59 ns |  51.829 ns |  45.945 ns |  1.80 |    0.02 |       - |     - |     - |         - |
