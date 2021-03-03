## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

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
|                    Method | Start | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|        **ValueLinq_Standard** |     **0** |    **10** |    **69.840 ns** |  **0.1846 ns** |  **0.1637 ns** |  **5.18** |    **0.04** | **0.0305** |     **-** |     **-** |      **64 B** |
|           ValueLinq_Stack |     0 |    10 |    41.363 ns |  0.1342 ns |  0.1189 ns |  3.07 |    0.02 | 0.0306 |     - |     - |      64 B |
| ValueLinq_SharedPool_Push |     0 |    10 |   161.918 ns |  0.4174 ns |  0.3700 ns | 12.00 |    0.09 | 0.0305 |     - |     - |      64 B |
| ValueLinq_SharedPool_Pull |     0 |    10 |   164.045 ns |  0.4496 ns |  0.3986 ns | 12.16 |    0.07 | 0.0305 |     - |     - |      64 B |
|                   ForLoop |     0 |    10 |    13.485 ns |  0.0942 ns |  0.0881 ns |  1.00 |    0.00 | 0.0306 |     - |     - |      64 B |
|                      Linq |     0 |    10 |    24.298 ns |  0.1127 ns |  0.1054 ns |  1.80 |    0.02 | 0.0497 |     - |     - |     104 B |
|                LinqFaster |     0 |    10 |     9.051 ns |  0.0795 ns |  0.1351 ns |  0.67 |    0.01 | 0.0306 |     - |     - |      64 B |
|           LinqFaster_SIMD |     0 |    10 |    13.897 ns |  0.0408 ns |  0.0341 ns |  1.03 |    0.01 | 0.0306 |     - |     - |      64 B |
|                    LinqAF |     0 |    10 |    49.648 ns |  0.2782 ns |  0.2602 ns |  3.68 |    0.03 | 0.0305 |     - |     - |      64 B |
|                StructLinq |     0 |    10 |    12.695 ns |  0.0519 ns |  0.0434 ns |  0.94 |    0.01 | 0.0306 |     - |     - |      64 B |
|                 Hyperlinq |     0 |    10 |    15.451 ns |  0.0609 ns |  0.0509 ns |  1.14 |    0.01 | 0.0306 |     - |     - |      64 B |
|                           |       |       |              |            |            |       |         |        |       |       |           |
|        **ValueLinq_Standard** |     **0** |  **1000** | **1,732.031 ns** |  **5.1721 ns** |  **4.5850 ns** |  **1.42** |    **0.01** | **1.9226** |     **-** |     **-** |   **4,024 B** |
|           ValueLinq_Stack |     0 |  1000 | 2,235.474 ns |  5.9255 ns |  5.5427 ns |  1.83 |    0.01 | 3.9177 |     - |     - |   8,200 B |
| ValueLinq_SharedPool_Push |     0 |  1000 | 2,361.396 ns |  9.4615 ns |  8.8503 ns |  1.93 |    0.01 | 1.9226 |     - |     - |   4,024 B |
| ValueLinq_SharedPool_Pull |     0 |  1000 | 2,179.509 ns | 32.3681 ns | 27.0289 ns |  1.79 |    0.03 | 1.9226 |     - |     - |   4,024 B |
|                   ForLoop |     0 |  1000 | 1,220.426 ns |  4.9155 ns |  4.3575 ns |  1.00 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|                      Linq |     0 |  1000 |   585.438 ns |  4.7009 ns |  4.3972 ns |  0.48 |    0.00 | 1.9417 |     - |     - |   4,064 B |
|                LinqFaster |     0 |  1000 |   586.692 ns |  2.0554 ns |  1.7163 ns |  0.48 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|           LinqFaster_SIMD |     0 |  1000 |   256.212 ns |  4.7610 ns |  4.4534 ns |  0.21 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|                    LinqAF |     0 |  1000 | 2,322.576 ns |  7.1785 ns |  6.7148 ns |  1.90 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|                StructLinq |     0 |  1000 |   961.124 ns |  5.4208 ns |  4.8054 ns |  0.79 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|                 Hyperlinq |     0 |  1000 |   261.456 ns |  4.8066 ns |  4.0138 ns |  0.21 |    0.00 | 1.9226 |     - |     - |   4,024 B |
