## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|              **ForLoop** |    **10** |     **32.54 ns** |   **0.172 ns** |   **0.152 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     63.35 ns |   0.660 ns |   0.585 ns |  1.95 |    0.02 |       - |     - |     - |         - |
|                 Linq |    10 |    136.69 ns |   0.978 ns |   0.816 ns |  4.20 |    0.03 |  0.0880 |     - |     - |     184 B |
|           LinqFaster |    10 |     76.26 ns |   0.255 ns |   0.199 ns |  2.35 |    0.01 |  0.1491 |     - |     - |     312 B |
|               LinqAF |    10 |    224.19 ns |   4.127 ns |   3.861 ns |  6.89 |    0.14 |       - |     - |     - |         - |
|           StructLinq |    10 |     56.74 ns |   0.135 ns |   0.119 ns |  1.74 |    0.01 |  0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |    10 |     56.17 ns |   0.124 ns |   0.097 ns |  1.73 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |    10 |     50.00 ns |   0.132 ns |   0.124 ns |  1.54 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     42.97 ns |   0.114 ns |   0.101 ns |  1.32 |    0.01 |       - |     - |     - |         - |
|                      |       |              |            |            |       |         |         |       |       |           |
|              **ForLoop** |  **1000** |  **5,225.62 ns** |  **13.106 ns** |  **11.618 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  8,147.36 ns |  36.145 ns |  32.042 ns |  1.56 |    0.01 |       - |     - |     - |         - |
|                 Linq |  1000 | 15,697.01 ns |  87.579 ns |  77.636 ns |  3.00 |    0.02 |  0.0610 |     - |     - |     184 B |
|           LinqFaster |  1000 | 15,197.63 ns |  44.101 ns |  36.827 ns |  2.91 |    0.01 | 31.2347 |     - |     - |   65504 B |
|               LinqAF |  1000 | 19,755.88 ns | 175.737 ns | 155.786 ns |  3.78 |    0.03 |       - |     - |     - |         - |
|           StructLinq |  1000 |  7,465.93 ns |  26.973 ns |  23.911 ns |  1.43 |    0.01 |  0.0153 |     - |     - |      40 B |
| StructLinq_IFunction |  1000 |  5,021.81 ns |  21.676 ns |  19.215 ns |  0.96 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq |  1000 |  7,836.62 ns |  18.527 ns |  17.330 ns |  1.50 |    0.00 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  5,060.80 ns |   9.807 ns |   8.694 ns |  0.97 |    0.00 |       - |     - |     - |         - |
