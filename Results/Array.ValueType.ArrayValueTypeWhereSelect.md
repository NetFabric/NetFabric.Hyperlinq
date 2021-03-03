## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **38.06 ns** |   **0.080 ns** |   **0.071 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     50.70 ns |   0.184 ns |   0.163 ns |  1.33 |    0.00 |       - |     - |     - |         - |
|                 Linq |    10 |    134.95 ns |   1.129 ns |   1.056 ns |  3.55 |    0.03 |  0.1032 |     - |     - |     216 B |
|           LinqFaster |    10 |    104.69 ns |   0.810 ns |   0.718 ns |  2.75 |    0.02 |  0.3901 |     - |     - |     816 B |
|               LinqAF |    10 |    183.06 ns |   3.478 ns |   3.866 ns |  4.83 |    0.11 |       - |     - |     - |         - |
|           StructLinq |    10 |     87.50 ns |   0.224 ns |   0.199 ns |  2.30 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |     81.66 ns |   0.092 ns |   0.086 ns |  2.15 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |    10 |    128.43 ns |   0.208 ns |   0.184 ns |  3.37 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    105.33 ns |   0.119 ns |   0.105 ns |  2.77 |    0.01 |       - |     - |     - |         - |
|                      |       |              |            |            |       |         |         |       |       |           |
|              **ForLoop** |  **1000** |  **8,498.59 ns** |  **18.606 ns** |  **16.494 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  9,421.28 ns |  21.122 ns |  17.638 ns |  1.11 |    0.00 |       - |     - |     - |         - |
|                 Linq |  1000 | 16,148.66 ns |  46.740 ns |  41.434 ns |  1.90 |    0.00 |  0.0916 |     - |     - |     216 B |
|           LinqFaster |  1000 | 16,088.38 ns |  66.136 ns |  61.864 ns |  1.89 |    0.01 | 45.4407 |     - |     - |  96,240 B |
|               LinqAF |  1000 | 22,218.58 ns | 299.534 ns | 280.184 ns |  2.61 |    0.03 |       - |     - |     - |         - |
|           StructLinq |  1000 | 13,221.66 ns |  22.142 ns |  19.628 ns |  1.56 |    0.00 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |  9,569.55 ns |  46.151 ns |  36.031 ns |  1.13 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq |  1000 | 15,043.76 ns |  30.157 ns |  26.733 ns |  1.77 |    0.00 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 12,158.66 ns |  23.097 ns |  20.475 ns |  1.43 |    0.00 |       - |     - |     - |         - |
