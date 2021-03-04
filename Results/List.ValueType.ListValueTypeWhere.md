## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|              **ForLoop** |    **10** |     **32.99 ns** |   **0.141 ns** |   **0.125 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     65.78 ns |   0.549 ns |   0.486 ns |  1.99 |    0.02 |       - |     - |     - |         - |
|                 Linq |    10 |    153.12 ns |   1.390 ns |   1.161 ns |  4.64 |    0.04 |  0.0880 |     - |     - |     184 B |
|           LinqFaster |    10 |     77.29 ns |   0.370 ns |   0.309 ns |  2.34 |    0.01 |  0.1491 |     - |     - |     312 B |
|               LinqAF |    10 |    227.21 ns |   3.247 ns |   2.878 ns |  6.89 |    0.09 |       - |     - |     - |         - |
|           StructLinq |    10 |     59.15 ns |   0.497 ns |   0.415 ns |  1.79 |    0.02 |  0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |    10 |     57.16 ns |   0.164 ns |   0.154 ns |  1.73 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |    10 |    112.18 ns |   0.197 ns |   0.175 ns |  3.40 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     75.70 ns |   0.117 ns |   0.091 ns |  2.29 |    0.01 |       - |     - |     - |         - |
|                      |       |              |            |            |       |         |         |       |       |           |
|              **ForLoop** |  **1000** |  **6,251.08 ns** |  **28.205 ns** |  **26.383 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  8,604.29 ns |  42.071 ns |  39.353 ns |  1.38 |    0.01 |       - |     - |     - |         - |
|                 Linq |  1000 | 16,291.33 ns |  75.695 ns |  67.102 ns |  2.61 |    0.02 |  0.0610 |     - |     - |     184 B |
|           LinqFaster |  1000 | 14,085.79 ns |  38.250 ns |  31.940 ns |  2.25 |    0.01 | 31.2347 |     - |     - |  65,504 B |
|               LinqAF |  1000 | 20,467.53 ns | 344.881 ns | 322.602 ns |  3.27 |    0.06 |       - |     - |     - |         - |
|           StructLinq |  1000 |  7,813.07 ns |  17.842 ns |  14.899 ns |  1.25 |    0.01 |  0.0153 |     - |     - |      40 B |
| StructLinq_IFunction |  1000 |  5,113.00 ns |  38.842 ns |  36.333 ns |  0.82 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |  1000 | 11,351.31 ns |  71.768 ns |  63.620 ns |  1.82 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 10,195.69 ns |  21.457 ns |  19.021 ns |  1.63 |    0.01 |       - |     - |     - |         - |
