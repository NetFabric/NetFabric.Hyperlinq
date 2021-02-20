## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|              **ForLoop** |    **10** |     **37.26 ns** |   **0.086 ns** |   **0.076 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     48.77 ns |   0.096 ns |   0.080 ns |  1.31 |    0.00 |       - |     - |     - |         - |
|                 Linq |    10 |    138.62 ns |   0.446 ns |   0.395 ns |  3.72 |    0.01 |  0.1032 |     - |     - |     216 B |
|           LinqFaster |    10 |    105.19 ns |   0.501 ns |   0.445 ns |  2.82 |    0.01 |  0.3901 |     - |     - |     816 B |
|               LinqAF |    10 |    184.72 ns |   3.235 ns |   2.868 ns |  4.96 |    0.08 |       - |     - |     - |         - |
|           StructLinq |    10 |     87.21 ns |   0.234 ns |   0.218 ns |  2.34 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |     81.31 ns |   0.157 ns |   0.139 ns |  2.18 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |    10 |     78.29 ns |   0.295 ns |   0.262 ns |  2.10 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     65.46 ns |   0.233 ns |   0.195 ns |  1.76 |    0.01 |       - |     - |     - |         - |
|                      |       |              |            |            |       |         |         |       |       |           |
|              **ForLoop** |  **1000** |  **8,487.68 ns** |  **19.217 ns** |  **16.047 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 12,390.78 ns |  23.052 ns |  20.435 ns |  1.46 |    0.00 |       - |     - |     - |         - |
|                 Linq |  1000 | 23,186.73 ns |  51.891 ns |  46.000 ns |  2.73 |    0.01 |  0.0916 |     - |     - |     216 B |
|           LinqFaster |  1000 | 17,484.43 ns | 101.389 ns |  89.879 ns |  2.06 |    0.01 | 45.4407 |     - |     - |   96240 B |
|               LinqAF |  1000 | 22,048.22 ns | 263.338 ns | 246.327 ns |  2.60 |    0.03 |       - |     - |     - |         - |
|           StructLinq |  1000 | 12,548.89 ns |  31.253 ns |  29.234 ns |  1.48 |    0.00 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |  9,627.33 ns |  31.051 ns |  29.045 ns |  1.13 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq |  1000 | 11,203.88 ns |  36.932 ns |  34.546 ns |  1.32 |    0.00 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  8,598.06 ns |  23.374 ns |  20.721 ns |  1.01 |    0.00 |       - |     - |     - |         - |
