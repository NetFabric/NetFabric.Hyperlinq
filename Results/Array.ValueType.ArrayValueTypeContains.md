## Array.ValueType.ArrayValueTypeContains

### Source
[ArrayValueTypeContains.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeContains.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta43](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta43)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |    **44.98 ns** |  **0.168 ns** |  **0.149 ns** |  **1.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    45.13 ns |  0.108 ns |  0.101 ns |  1.00 |      - |     - |     - |         - |
|                 Linq |    10 |    26.56 ns |  0.136 ns |  0.127 ns |  0.59 |      - |     - |     - |         - |
|           LinqFaster |    10 |    31.73 ns |  0.176 ns |  0.156 ns |  0.71 |      - |     - |     - |         - |
|               LinqAF |    10 |    33.03 ns |  0.191 ns |  0.159 ns |  0.73 |      - |     - |     - |         - |
|           StructLinq |    10 |    55.47 ns |  0.370 ns |  0.328 ns |  1.23 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    42.05 ns |  0.150 ns |  0.141 ns |  0.94 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    29.89 ns |  0.090 ns |  0.084 ns |  0.66 |      - |     - |     - |         - |
|                      |       |             |           |           |       |        |       |       |           |
|              **ForLoop** |  **1000** | **4,862.36 ns** | **20.080 ns** | **17.801 ns** |  **1.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 4,896.58 ns | 14.869 ns | 13.908 ns |  1.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 1,887.70 ns |  7.034 ns |  6.580 ns |  0.39 |      - |     - |     - |         - |
|           LinqFaster |  1000 | 2,322.01 ns |  7.142 ns |  6.681 ns |  0.48 |      - |     - |     - |         - |
|               LinqAF |  1000 | 2,411.51 ns |  9.415 ns |  8.806 ns |  0.50 |      - |     - |     - |         - |
|           StructLinq |  1000 | 4,305.28 ns | 23.700 ns | 21.009 ns |  0.89 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 3,752.13 ns | 10.179 ns |  9.024 ns |  0.77 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 2,332.14 ns |  8.969 ns |  7.490 ns |  0.48 |      - |     - |     - |         - |
