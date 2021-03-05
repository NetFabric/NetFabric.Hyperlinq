## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|               Method | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **39.29 ns** |   **0.058 ns** |   **0.051 ns** |     **39.27 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     49.22 ns |   0.106 ns |   0.088 ns |     49.21 ns |  1.25 |    0.00 |       - |     - |     - |         - |
|                 Linq |    10 |    138.63 ns |   0.855 ns |   0.799 ns |    138.47 ns |  3.53 |    0.02 |  0.1032 |     - |     - |     216 B |
|           LinqFaster |    10 |    105.47 ns |   1.316 ns |   1.231 ns |    105.46 ns |  2.68 |    0.03 |  0.3901 |     - |     - |     816 B |
|               LinqAF |    10 |    184.65 ns |   3.594 ns |   3.995 ns |    184.25 ns |  4.72 |    0.10 |       - |     - |     - |         - |
|           StructLinq |    10 |     89.99 ns |   0.167 ns |   0.148 ns |     90.00 ns |  2.29 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |     84.66 ns |   0.157 ns |   0.139 ns |     84.61 ns |  2.15 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq |    10 |    123.52 ns |   0.292 ns |   0.273 ns |    123.44 ns |  3.14 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    103.80 ns |   0.141 ns |   0.125 ns |    103.79 ns |  2.64 |    0.00 |       - |     - |     - |         - |
|                      |       |              |            |            |              |       |         |         |       |       |           |
|              **ForLoop** |  **1000** |  **8,862.75 ns** |  **35.181 ns** |  **32.908 ns** |  **8,862.67 ns** |  **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 10,270.24 ns |  17.602 ns |  13.743 ns | 10,273.78 ns |  1.16 |    0.00 |       - |     - |     - |         - |
|                 Linq |  1000 | 16,306.70 ns |  59.127 ns |  55.308 ns | 16,305.12 ns |  1.84 |    0.01 |  0.0916 |     - |     - |     216 B |
|           LinqFaster |  1000 | 16,861.82 ns | 138.768 ns | 129.803 ns | 16,828.57 ns |  1.90 |    0.02 | 45.4407 |     - |     - |  96,240 B |
|               LinqAF |  1000 | 30,466.93 ns |  63.231 ns |  56.052 ns | 30,473.47 ns |  3.44 |    0.02 |       - |     - |     - |         - |
|           StructLinq |  1000 | 12,249.37 ns |  18.910 ns |  16.763 ns | 12,250.12 ns |  1.38 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 10,977.97 ns | 219.436 ns | 458.045 ns | 10,721.69 ns |  1.28 |    0.07 |       - |     - |     - |         - |
|            Hyperlinq |  1000 | 16,318.61 ns |  94.705 ns |  83.954 ns | 16,288.73 ns |  1.84 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 13,168.75 ns |  23.301 ns |  20.655 ns | 13,169.34 ns |  1.49 |    0.01 |       - |     - |     - |         - |
