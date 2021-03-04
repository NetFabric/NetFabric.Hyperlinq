## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|              **ForLoop** |    **10** |     **38.25 ns** |   **0.095 ns** |   **0.089 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     49.84 ns |   0.135 ns |   0.120 ns |  1.30 |    0.00 |       - |     - |     - |         - |
|                 Linq |    10 |    141.19 ns |   1.054 ns |   0.880 ns |  3.69 |    0.02 |  0.1032 |     - |     - |     216 B |
|           LinqFaster |    10 |    111.17 ns |   1.396 ns |   1.166 ns |  2.91 |    0.03 |  0.3901 |     - |     - |     816 B |
|               LinqAF |    10 |    198.67 ns |   3.159 ns |   2.955 ns |  5.19 |    0.08 |       - |     - |     - |         - |
|           StructLinq |    10 |     91.33 ns |   0.194 ns |   0.162 ns |  2.39 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |     83.92 ns |   0.211 ns |   0.197 ns |  2.19 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |    10 |    126.62 ns |   0.616 ns |   0.576 ns |  3.31 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    108.34 ns |   0.571 ns |   0.477 ns |  2.83 |    0.02 |       - |     - |     - |         - |
|                      |       |              |            |            |       |         |         |       |       |           |
|              **ForLoop** |  **1000** |  **8,471.02 ns** |  **30.500 ns** |  **27.037 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  9,471.72 ns |  37.774 ns |  33.485 ns |  1.12 |    0.01 |       - |     - |     - |         - |
|                 Linq |  1000 | 17,166.22 ns |  77.015 ns |  68.272 ns |  2.03 |    0.01 |  0.0916 |     - |     - |     216 B |
|           LinqFaster |  1000 | 19,300.28 ns | 104.679 ns |  92.795 ns |  2.28 |    0.01 | 45.4407 |     - |     - |  96,240 B |
|               LinqAF |  1000 | 23,402.85 ns | 135.899 ns | 120.471 ns |  2.76 |    0.02 |       - |     - |     - |         - |
|           StructLinq |  1000 | 12,935.90 ns |  33.761 ns |  31.580 ns |  1.53 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |  9,924.95 ns |  43.429 ns |  40.623 ns |  1.17 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |  1000 | 16,007.92 ns |  43.266 ns |  38.354 ns |  1.89 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 12,553.24 ns |  39.306 ns |  34.844 ns |  1.48 |    0.01 |       - |     - |     - |         - |
