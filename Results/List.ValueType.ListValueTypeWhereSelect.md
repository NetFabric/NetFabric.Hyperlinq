## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|              **ForLoop** |    **10** |     **46.17 ns** |   **0.103 ns** |   **0.081 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     78.33 ns |   0.281 ns |   0.249 ns |  1.70 |    0.01 |       - |     - |     - |         - |
|                 Linq |    10 |    180.86 ns |   0.958 ns |   0.897 ns |  3.92 |    0.02 |  0.1798 |     - |     - |     376 B |
|           LinqFaster |    10 |    111.52 ns |   1.494 ns |   1.397 ns |  2.41 |    0.03 |  0.1491 |     - |     - |     312 B |
|               LinqAF |    10 |    259.45 ns |   5.124 ns |   5.901 ns |  5.63 |    0.15 |       - |     - |     - |         - |
|           StructLinq |    10 |     89.43 ns |   0.374 ns |   0.312 ns |  1.94 |    0.01 |  0.0343 |     - |     - |      72 B |
| StructLinq_IFunction |    10 |     89.52 ns |   0.199 ns |   0.177 ns |  1.94 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |    10 |     78.40 ns |   0.215 ns |   0.191 ns |  1.70 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     91.87 ns |   0.209 ns |   0.185 ns |  1.99 |    0.01 |       - |     - |     - |         - |
|                      |       |              |            |            |       |         |         |       |       |           |
|              **ForLoop** |  **1000** |  **8,930.86 ns** |  **69.752 ns** |  **65.246 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 11,188.12 ns |  44.740 ns |  37.360 ns |  1.25 |    0.01 |       - |     - |     - |         - |
|                 Linq |  1000 | 19,144.37 ns |  97.245 ns |  90.963 ns |  2.14 |    0.02 |  0.1526 |     - |     - |     376 B |
|           LinqFaster |  1000 | 22,065.17 ns | 215.966 ns | 191.449 ns |  2.47 |    0.03 | 31.2195 |     - |     - |   65504 B |
|               LinqAF |  1000 | 27,038.91 ns | 385.034 ns | 360.161 ns |  3.03 |    0.05 |       - |     - |     - |         - |
|           StructLinq |  1000 | 12,997.35 ns |  19.994 ns |  16.696 ns |  1.46 |    0.01 |  0.0305 |     - |     - |      72 B |
| StructLinq_IFunction |  1000 |  9,745.19 ns |  21.587 ns |  19.136 ns |  1.09 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |  1000 | 10,493.02 ns |  25.158 ns |  22.302 ns |  1.17 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 11,235.67 ns |  33.134 ns |  30.993 ns |  1.26 |    0.01 |       - |     - |     - |         - |
