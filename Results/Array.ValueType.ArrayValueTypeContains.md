## Array.ValueType.ArrayValueTypeContains

### Source
[ArrayValueTypeContains.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeContains.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta41](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta41)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |    **46.60 ns** |  **0.210 ns** |  **0.186 ns** |    **46.57 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    45.69 ns |  0.177 ns |  0.157 ns |    45.66 ns |  0.98 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    28.21 ns |  0.171 ns |  0.143 ns |    28.17 ns |  0.61 |    0.00 |      - |     - |     - |         - |
|           LinqFaster |    10 |    32.27 ns |  0.172 ns |  0.144 ns |    32.27 ns |  0.69 |    0.00 |      - |     - |     - |         - |
|               LinqAF |    10 |    33.92 ns |  0.313 ns |  0.262 ns |    33.86 ns |  0.73 |    0.01 |      - |     - |     - |         - |
|           StructLinq |    10 |    59.40 ns |  1.209 ns |  3.226 ns |    57.73 ns |  1.34 |    0.08 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    42.46 ns |  0.147 ns |  0.122 ns |    42.46 ns |  0.91 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    32.49 ns |  0.155 ns |  0.137 ns |    32.48 ns |  0.70 |    0.00 |      - |     - |     - |         - |
|                      |       |             |           |           |             |       |         |        |       |       |           |
|              **ForLoop** |  **1000** | **4,898.66 ns** | **19.647 ns** | **17.417 ns** | **4,899.14 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 4,893.27 ns | 18.693 ns | 17.486 ns | 4,890.56 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 1,906.57 ns |  5.115 ns |  3.993 ns | 1,906.79 ns |  0.39 |    0.00 |      - |     - |     - |         - |
|           LinqFaster |  1000 | 2,351.62 ns | 18.278 ns | 17.097 ns | 2,352.88 ns |  0.48 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 | 2,435.05 ns |  8.191 ns |  7.261 ns | 2,435.88 ns |  0.50 |    0.00 |      - |     - |     - |         - |
|           StructLinq |  1000 | 4,352.81 ns | 29.902 ns | 27.970 ns | 4,341.70 ns |  0.89 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 3,782.56 ns | 13.092 ns | 10.221 ns | 3,787.33 ns |  0.77 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 2,353.14 ns | 15.523 ns | 13.761 ns | 2,358.09 ns |  0.48 |    0.00 |      - |     - |     - |         - |
