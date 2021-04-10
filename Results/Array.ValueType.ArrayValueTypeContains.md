## Array.ValueType.ArrayValueTypeContains

### Source
[ArrayValueTypeContains.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeContains.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |    **45.22 ns** |  **0.183 ns** |  **0.162 ns** |  **1.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    45.74 ns |  0.217 ns |  0.203 ns |  1.01 |      - |     - |     - |         - |
|                 Linq |    10 |    28.83 ns |  0.248 ns |  0.220 ns |  0.64 |      - |     - |     - |         - |
|           LinqFaster |    10 |    32.38 ns |  0.243 ns |  0.215 ns |  0.72 |      - |     - |     - |         - |
|               LinqAF |    10 |    33.18 ns |  0.174 ns |  0.154 ns |  0.73 |      - |     - |     - |         - |
|           StructLinq |    10 |    56.22 ns |  0.196 ns |  0.174 ns |  1.24 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    42.49 ns |  0.498 ns |  0.442 ns |  0.94 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    32.24 ns |  0.225 ns |  0.200 ns |  0.71 |      - |     - |     - |         - |
|                      |       |             |           |           |       |        |       |       |           |
|              **ForLoop** |  **1000** | **4,877.78 ns** | **18.655 ns** | **16.538 ns** |  **1.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 4,886.85 ns | 14.772 ns | 11.533 ns |  1.00 |      - |     - |     - |         - |
|                 Linq |  1000 | 1,897.93 ns |  7.734 ns |  6.856 ns |  0.39 |      - |     - |     - |         - |
|           LinqFaster |  1000 | 2,429.76 ns | 13.213 ns | 10.316 ns |  0.50 |      - |     - |     - |         - |
|               LinqAF |  1000 | 2,448.89 ns | 13.056 ns | 12.213 ns |  0.50 |      - |     - |     - |         - |
|           StructLinq |  1000 | 4,060.20 ns | 29.167 ns | 27.283 ns |  0.83 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 3,812.42 ns | 40.594 ns | 35.985 ns |  0.78 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 2,349.74 ns | 20.600 ns | 19.269 ns |  0.48 |      - |     - |     - |         - |
