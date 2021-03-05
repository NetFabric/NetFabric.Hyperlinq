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

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |    **45.54 ns** |  **0.089 ns** |  **0.079 ns** |  **1.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    44.86 ns |  0.123 ns |  0.109 ns |  0.99 |      - |     - |     - |         - |
|                 Linq |    10 |    29.55 ns |  0.094 ns |  0.078 ns |  0.65 |      - |     - |     - |         - |
|           LinqFaster |    10 |    28.68 ns |  0.115 ns |  0.102 ns |  0.63 |      - |     - |     - |         - |
|               LinqAF |    10 |    32.68 ns |  0.145 ns |  0.129 ns |  0.72 |      - |     - |     - |         - |
|           StructLinq |    10 |    53.14 ns |  0.114 ns |  0.101 ns |  1.17 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    41.12 ns |  0.069 ns |  0.057 ns |  0.90 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    28.95 ns |  0.077 ns |  0.072 ns |  0.64 |      - |     - |     - |         - |
|                      |       |             |           |           |       |        |       |       |           |
|              **ForLoop** |  **1000** | **4,692.65 ns** | **10.496 ns** |  **9.818 ns** |  **1.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 4,749.79 ns | 10.655 ns |  9.967 ns |  1.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 2,355.23 ns |  4.393 ns |  3.894 ns |  0.50 |      - |     - |     - |         - |
|           LinqFaster |  1000 | 1,848.54 ns |  3.424 ns |  3.035 ns |  0.39 |      - |     - |     - |         - |
|               LinqAF |  1000 | 2,353.95 ns |  7.143 ns |  6.332 ns |  0.50 |      - |     - |     - |         - |
|           StructLinq |  1000 | 4,208.16 ns | 22.443 ns | 18.741 ns |  0.90 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 3,658.53 ns |  8.155 ns |  6.810 ns |  0.78 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 1,853.26 ns |  4.358 ns |  3.864 ns |  0.39 |      - |     - |     - |         - |
