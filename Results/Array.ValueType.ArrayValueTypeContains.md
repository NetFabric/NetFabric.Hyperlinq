## Array.ValueType.ArrayValueTypeContains

### Source
[ArrayValueTypeContains.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeContains.cs)

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
|               Method | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |    **45.57 ns** |  **0.126 ns** |  **0.111 ns** |  **1.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    45.91 ns |  0.083 ns |  0.069 ns |  1.01 |      - |     - |     - |         - |
|                 Linq |    10 |    29.56 ns |  0.104 ns |  0.087 ns |  0.65 |      - |     - |     - |         - |
|           LinqFaster |    10 |    28.11 ns |  0.093 ns |  0.077 ns |  0.62 |      - |     - |     - |         - |
|               LinqAF |    10 |    31.80 ns |  0.084 ns |  0.075 ns |  0.70 |      - |     - |     - |         - |
|           StructLinq |    10 |    51.15 ns |  0.154 ns |  0.137 ns |  1.12 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    40.83 ns |  0.060 ns |  0.056 ns |  0.90 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    29.42 ns |  0.075 ns |  0.070 ns |  0.65 |      - |     - |     - |         - |
|                      |       |             |           |           |       |        |       |       |           |
|              **ForLoop** |  **1000** | **4,985.07 ns** |  **9.550 ns** |  **7.975 ns** |  **1.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 4,670.07 ns |  9.654 ns |  8.558 ns |  0.94 |      - |     - |     - |         - |
|                 Linq |  1000 | 2,306.08 ns | 15.744 ns | 13.956 ns |  0.46 |      - |     - |     - |         - |
|           LinqFaster |  1000 | 1,841.27 ns |  4.910 ns |  4.100 ns |  0.37 |      - |     - |     - |         - |
|               LinqAF |  1000 | 2,257.52 ns |  5.652 ns |  5.010 ns |  0.45 |      - |     - |     - |         - |
|           StructLinq |  1000 | 3,918.56 ns |  5.256 ns |  4.389 ns |  0.79 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 3,647.11 ns |  6.407 ns |  5.994 ns |  0.73 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 1,849.93 ns |  3.645 ns |  3.231 ns |  0.37 |      - |     - |     - |         - |
