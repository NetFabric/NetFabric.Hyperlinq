## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **7.593 ns** |  **0.0192 ns** |  **0.0170 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     7.650 ns |  0.0529 ns |  0.0494 ns |  1.01 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    59.076 ns |  0.1210 ns |  0.0945 ns |  7.78 |    0.02 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |    10 |    38.336 ns |  0.1989 ns |  0.1860 ns |  5.05 |    0.03 | 0.0459 |     - |     - |      96 B |
|               LinqAF |    10 |    49.510 ns |  0.0947 ns |  0.0839 ns |  6.52 |    0.02 |      - |     - |     - |         - |
|           StructLinq |    10 |    42.210 ns |  0.1156 ns |  0.1025 ns |  5.56 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    35.980 ns |  0.0489 ns |  0.0382 ns |  4.74 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    42.069 ns |  0.0531 ns |  0.0471 ns |  5.54 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    37.492 ns |  0.0632 ns |  0.0527 ns |  4.94 |    0.01 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** | **1,382.373 ns** |  **3.6908 ns** |  **3.2718 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 1,390.063 ns |  5.1092 ns |  4.5292 ns |  1.01 |    0.00 |      - |     - |     - |         - |
|                 Linq |  1000 | 6,128.228 ns | 21.8061 ns | 19.3305 ns |  4.43 |    0.02 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |  1000 | 4,477.153 ns |  9.3803 ns |  7.8329 ns |  3.24 |    0.01 | 2.8915 |     - |     - |   6,064 B |
|               LinqAF |  1000 | 5,809.014 ns | 14.8987 ns | 13.2073 ns |  4.20 |    0.01 |      - |     - |     - |         - |
|           StructLinq |  1000 | 6,088.874 ns | 16.4676 ns | 15.4038 ns |  4.40 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 1,473.026 ns |  2.2809 ns |  2.0219 ns |  1.07 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 5,201.551 ns | 10.7948 ns |  9.5693 ns |  3.76 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 1,939.820 ns |  5.8848 ns |  5.2167 ns |  1.40 |    0.00 |      - |     - |     - |         - |
