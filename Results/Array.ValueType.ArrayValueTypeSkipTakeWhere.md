## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta38](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta38)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |          Mean |       Error |      StdDev |    Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |--------------:|------------:|------------:|---------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** | **1000** |     **0** |      **1.101 ns** |   **0.0125 ns** |   **0.0111 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |     0 |  2,361.235 ns |  11.2680 ns |   9.9888 ns | 2,145.64 |   23.93 |  0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |     0 |     90.380 ns |   0.1667 ns |   0.1478 ns |    82.13 |    0.88 |  0.0802 |     - |     - |     168 B |
|           LinqFaster | 1000 |     0 |     32.904 ns |   0.1755 ns |   0.1556 ns |    29.90 |    0.36 |  0.0344 |     - |     - |      72 B |
|               LinqAF | 1000 |     0 |    150.515 ns |   0.5117 ns |   0.4787 ns |   136.76 |    1.67 |       - |     - |     - |         - |
|           StructLinq | 1000 |     0 |     52.812 ns |   0.1081 ns |   0.0958 ns |    47.99 |    0.47 |  0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |     0 |     22.031 ns |   0.0327 ns |   0.0306 ns |    20.02 |    0.19 |       - |     - |     - |         - |
|            Hyperlinq | 1000 |     0 |     22.962 ns |   0.0639 ns |   0.0567 ns |    20.87 |    0.22 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |     0 |     20.149 ns |   0.0763 ns |   0.0677 ns |    18.31 |    0.20 |       - |     - |     - |         - |
|                      |      |       |               |             |             |          |         |         |       |       |           |
|              **ForLoop** | **1000** |    **10** |     **42.512 ns** |   **0.1028 ns** |   **0.0911 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  2,441.479 ns |   9.7763 ns |   9.1448 ns |    57.43 |    0.29 |  0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |    10 |    251.988 ns |   0.9408 ns |   0.8800 ns |     5.93 |    0.03 |  0.1183 |     - |     - |     248 B |
|           LinqFaster | 1000 |    10 |    164.436 ns |   2.4969 ns |   2.2134 ns |     3.87 |    0.05 |  0.7153 |     - |     - |    1496 B |
|               LinqAF | 1000 |    10 |  3,597.991 ns |  50.8449 ns |  47.5603 ns |    84.57 |    1.12 |       - |     - |     - |         - |
|           StructLinq | 1000 |    10 |    112.679 ns |   0.5805 ns |   0.4848 ns |     2.65 |    0.01 |  0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |    10 |     74.218 ns |   0.1668 ns |   0.1302 ns |     1.75 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |     77.858 ns |   0.2938 ns |   0.2454 ns |     1.83 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |     68.120 ns |   0.2404 ns |   0.2131 ns |     1.60 |    0.00 |       - |     - |     - |         - |
|                      |      |       |               |             |             |          |         |         |       |       |           |
|              **ForLoop** | **1000** |  **1000** |  **5,344.758 ns** |  **10.9828 ns** |   **9.1711 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 |  5,474.095 ns |  20.5006 ns |  18.1733 ns |     1.02 |    0.00 |  0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |  1000 | 19,394.990 ns |  60.2697 ns |  53.4275 ns |     3.63 |    0.01 |  0.0916 |     - |     - |     248 B |
|           LinqFaster | 1000 |  1000 | 15,491.626 ns | 102.5939 ns |  85.6706 ns |     2.90 |    0.02 | 66.6504 |     - |     - |  139736 B |
|               LinqAF | 1000 |  1000 | 25,277.502 ns | 293.6345 ns | 260.2993 ns |     4.73 |    0.05 |       - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  6,845.796 ns |  18.9182 ns |  16.7705 ns |     1.28 |    0.00 |  0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |  1000 |  4,725.570 ns |  13.2511 ns |  11.0653 ns |     0.88 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 |  6,100.732 ns |  22.4025 ns |  19.8592 ns |     1.14 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  4,685.064 ns |  10.0503 ns |   8.3924 ns |     0.88 |    0.00 |       - |     - |     - |         - |
