## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
|              **ForLoop** |    **10** |     **21.36 ns** |   **0.055 ns** |   **0.051 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     31.67 ns |   0.088 ns |   0.073 ns |  1.48 |    0.00 |       - |     - |     - |         - |
|                 Linq |    10 |     91.40 ns |   1.473 ns |   1.306 ns |  4.28 |    0.06 |  0.0497 |     - |     - |     104 B |
|           LinqFaster |    10 |     89.92 ns |   0.664 ns |   0.589 ns |  4.21 |    0.04 |  0.3901 |     - |     - |     816 B |
|               LinqAF |    10 |    140.47 ns |   2.731 ns |   3.552 ns |  6.56 |    0.19 |       - |     - |     - |         - |
|           StructLinq |    10 |     56.50 ns |   0.214 ns |   0.190 ns |  2.65 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     61.33 ns |   0.096 ns |   0.075 ns |  2.87 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |    10 |    103.20 ns |   0.154 ns |   0.129 ns |  4.83 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     75.24 ns |   0.192 ns |   0.179 ns |  3.52 |    0.01 |       - |     - |     - |         - |
|                      |       |              |            |            |       |         |         |       |       |           |
|              **ForLoop** |  **1000** |  **4,367.68 ns** |  **12.335 ns** |  **11.538 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  9,059.77 ns |  13.237 ns |  11.734 ns |  2.07 |    0.01 |       - |     - |     - |         - |
|                 Linq |  1000 | 11,411.50 ns |  28.123 ns |  24.930 ns |  2.61 |    0.01 |  0.0458 |     - |     - |     104 B |
|           LinqFaster |  1000 | 12,782.34 ns |  44.865 ns |  41.967 ns |  2.93 |    0.01 | 45.4407 |     - |     - |  96,240 B |
|               LinqAF |  1000 | 15,040.45 ns | 189.642 ns | 168.112 ns |  3.44 |    0.04 |       - |     - |     - |         - |
|           StructLinq |  1000 |  8,371.75 ns |  17.139 ns |  15.194 ns |  1.92 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |  5,838.69 ns |  14.376 ns |  13.448 ns |  1.34 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq |  1000 | 11,156.43 ns |  20.652 ns |  18.308 ns |  2.55 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  9,977.95 ns |  16.984 ns |  15.887 ns |  2.28 |    0.01 |       - |     - |     - |         - |
