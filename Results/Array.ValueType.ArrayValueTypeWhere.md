## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **21.29 ns** |   **0.041 ns** |   **0.034 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     32.40 ns |   0.063 ns |   0.059 ns |  1.52 |    0.00 |       - |     - |     - |         - |
|                 Linq |    10 |     92.87 ns |   0.864 ns |   0.808 ns |  4.36 |    0.04 |  0.0497 |     - |     - |     104 B |
|           LinqFaster |    10 |     88.49 ns |   0.346 ns |   0.289 ns |  4.16 |    0.01 |  0.3901 |     - |     - |     816 B |
|               LinqAF |    10 |    142.32 ns |   2.786 ns |   2.606 ns |  6.67 |    0.13 |       - |     - |     - |         - |
|           StructLinq |    10 |     65.52 ns |   0.147 ns |   0.123 ns |  3.08 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     50.89 ns |   0.118 ns |   0.105 ns |  2.39 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |    10 |     50.94 ns |   0.084 ns |   0.070 ns |  2.39 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     42.66 ns |   0.064 ns |   0.056 ns |  2.00 |    0.00 |       - |     - |     - |         - |
|                      |       |              |            |            |       |         |         |       |       |           |
|              **ForLoop** |  **1000** |  **4,459.80 ns** |  **21.919 ns** |  **20.503 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  5,377.87 ns |   7.009 ns |   6.213 ns |  1.21 |    0.01 |       - |     - |     - |         - |
|                 Linq |  1000 | 11,714.58 ns |  46.610 ns |  41.319 ns |  2.63 |    0.02 |  0.0458 |     - |     - |     104 B |
|           LinqFaster |  1000 | 16,462.91 ns |  83.389 ns |  78.002 ns |  3.69 |    0.02 | 45.4407 |     - |     - |   96240 B |
|               LinqAF |  1000 | 15,843.41 ns | 315.305 ns | 294.937 ns |  3.55 |    0.06 |       - |     - |     - |         - |
|           StructLinq |  1000 |  8,082.08 ns |  24.507 ns |  22.924 ns |  1.81 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |  5,067.92 ns |  13.448 ns |  12.580 ns |  1.14 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |  1000 |  6,908.08 ns |  21.884 ns |  19.400 ns |  1.55 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  5,057.43 ns |  15.146 ns |  13.426 ns |  1.13 |    0.01 |       - |     - |     - |         - |
