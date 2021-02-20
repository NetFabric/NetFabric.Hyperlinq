## Array.ValueType.ArrayValueTypeContains

### Source
[ArrayValueTypeContains.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeContains.cs)

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
|               Method | Count |        Mean |     Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |    **43.63 ns** |  **0.117 ns** |   **0.104 ns** |    **43.63 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    43.71 ns |  0.146 ns |   0.137 ns |    43.70 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |    10 |    28.15 ns |  0.102 ns |   0.091 ns |    28.15 ns |  0.65 |    0.00 |      - |     - |     - |         - |
|           LinqFaster |    10 |    28.79 ns |  0.097 ns |   0.081 ns |    28.77 ns |  0.66 |    0.00 |      - |     - |     - |         - |
|               LinqAF |    10 |    32.04 ns |  0.097 ns |   0.081 ns |    32.02 ns |  0.73 |    0.00 |      - |     - |     - |         - |
|           StructLinq |    10 |    50.65 ns |  0.187 ns |   0.156 ns |    50.67 ns |  1.16 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    38.31 ns |  0.142 ns |   0.118 ns |    38.28 ns |  0.88 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    29.03 ns |  0.601 ns |   1.240 ns |    28.54 ns |  0.67 |    0.04 |      - |     - |     - |         - |
|                      |       |             |           |            |             |       |         |        |       |       |           |
|              **ForLoop** |  **1000** | **5,001.94 ns** | **76.407 ns** |  **59.654 ns** | **4,976.71 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 5,057.80 ns | 98.245 ns |  87.091 ns | 5,036.52 ns |  1.01 |    0.02 |      - |     - |     - |         - |
|                 Linq |  1000 | 2,153.20 ns | 42.183 ns | 100.253 ns | 2,105.82 ns |  0.43 |    0.02 |      - |     - |     - |         - |
|           LinqFaster |  1000 | 2,088.79 ns |  9.806 ns |   8.189 ns | 2,088.70 ns |  0.42 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 | 2,080.87 ns |  4.064 ns |   3.801 ns | 2,080.25 ns |  0.42 |    0.01 |      - |     - |     - |         - |
|           StructLinq |  1000 | 3,924.15 ns | 17.513 ns |  16.382 ns | 3,924.27 ns |  0.79 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 3,635.56 ns |  8.887 ns |   7.878 ns | 3,636.70 ns |  0.73 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 2,093.53 ns |  5.673 ns |   5.029 ns | 2,093.37 ns |  0.42 |    0.00 |      - |     - |     - |         - |
