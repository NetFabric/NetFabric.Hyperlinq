## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|                      Method | Skip | Count |          Mean |      Error |     StdDev |    Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |--------------:|-----------:|-----------:|---------:|--------:|--------:|------:|------:|----------:|
|                     **ForLoop** | **1000** |     **0** |      **1.489 ns** |  **0.0137 ns** |  **0.0114 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |     0 |  2,368.649 ns | 16.7817 ns | 14.0134 ns | 1,591.04 |   11.51 |  0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |     0 |     55.184 ns |  0.2138 ns |  0.1895 ns |    37.06 |    0.34 |  0.0382 |     - |     - |      80 B |
|                  LinqFaster | 1000 |     0 |     29.731 ns |  0.3097 ns |  0.2897 ns |    20.00 |    0.23 |  0.0344 |     - |     - |      72 B |
|                      LinqAF | 1000 |     0 |    142.157 ns |  0.6949 ns |  0.5803 ns |    95.49 |    0.76 |       - |     - |     - |         - |
|                  StructLinq | 1000 |     0 |     53.618 ns |  0.2862 ns |  0.2537 ns |    36.01 |    0.33 |  0.0459 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |     0 |     22.638 ns |  0.0677 ns |  0.0565 ns |    15.21 |    0.12 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |     0 |     22.750 ns |  0.0985 ns |  0.0873 ns |    15.29 |    0.14 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |     0 |     21.491 ns |  0.0385 ns |  0.0301 ns |    14.45 |    0.10 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |     0 |     13.437 ns |  0.0576 ns |  0.0538 ns |     9.03 |    0.08 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |     0 |     10.149 ns |  0.0561 ns |  0.0498 ns |     6.81 |    0.05 |       - |     - |     - |         - |
|                             |      |       |               |            |            |          |         |         |       |       |           |
|                     **ForLoop** | **1000** |    **10** |    **153.063 ns** |  **0.4624 ns** |  **0.4099 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |    10 |  2,512.851 ns |  9.5259 ns |  7.9545 ns |    16.42 |    0.06 |  0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |    10 |    333.418 ns |  0.8797 ns |  0.7346 ns |     2.18 |    0.01 |  0.1183 |     - |     - |     248 B |
|                  LinqFaster | 1000 |    10 |    266.711 ns |  1.1981 ns |  1.0005 ns |     1.74 |    0.01 |  0.6080 |     - |     - |    1272 B |
|                      LinqAF | 1000 |    10 |  3,976.678 ns | 59.6518 ns | 55.7984 ns |    26.02 |    0.37 |       - |     - |     - |         - |
|                  StructLinq | 1000 |    10 |    233.052 ns |  0.6552 ns |  0.5808 ns |     1.52 |    0.01 |  0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |    10 |    178.606 ns |  0.3662 ns |  0.3247 ns |     1.17 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |    10 |    189.963 ns |  0.3227 ns |  0.2860 ns |     1.24 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |    185.532 ns |  0.4002 ns |  0.3548 ns |     1.21 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |    10 |    179.624 ns |  0.4073 ns |  0.3611 ns |     1.17 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |    10 |    173.842 ns |  0.4929 ns |  0.4611 ns |     1.14 |    0.00 |       - |     - |     - |         - |
|                             |      |       |               |            |            |          |         |         |       |       |           |
|                     **ForLoop** | **1000** |  **1000** | **15,055.512 ns** | **39.9572 ns** | **33.3661 ns** |     **1.00** |    **0.00** |       **-** |     **-** |     **-** |         **-** |
|                 ForeachLoop | 1000 |  1000 | 19,753.327 ns | 49.8864 ns | 44.2230 ns |     1.31 |    0.00 |       - |     - |     - |      32 B |
|                        Linq | 1000 |  1000 | 34,394.260 ns | 76.0334 ns | 71.1217 ns |     2.28 |    0.01 |  0.0916 |     - |     - |     248 B |
|                  LinqFaster | 1000 |  1000 | 26,228.879 ns | 80.8801 ns | 75.6553 ns |     1.74 |    0.01 | 56.5796 |     - |     - |  120072 B |
|                      LinqAF | 1000 |  1000 | 34,483.985 ns | 97.0411 ns | 81.0337 ns |     2.29 |    0.01 |       - |     - |     - |         - |
|                  StructLinq | 1000 |  1000 | 18,164.136 ns | 93.4938 ns | 87.4541 ns |     1.21 |    0.01 |  0.0305 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |  1000 | 15,312.814 ns | 31.3391 ns | 27.7813 ns |     1.02 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |  1000 | 16,791.574 ns | 56.5356 ns | 47.2098 ns |     1.12 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 | 16,505.192 ns | 41.9272 ns | 39.2187 ns |     1.10 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | 1000 |  1000 | 16,898.437 ns | 31.7077 ns | 29.6594 ns |     1.12 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |  1000 | 16,459.169 ns | 76.1968 ns | 67.5464 ns |     1.09 |    0.01 |       - |     - |     - |         - |
