## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|      Method | Duplicates | Count |          Mean |       Error |      StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------ |----------- |------ |--------------:|------------:|------------:|------:|--------:|--------:|------:|------:|----------:|---------------:|------------------------:|
|     **ForLoop** |          **4** |     **0** |      **9.207 ns** |   **0.1372 ns** |   **0.1216 ns** |  **1.00** |    **0.00** |  **0.0344** |     **-** |     **-** |      **72 B** |              **0** |                       **0** |
| ForeachLoop |          4 |     0 |      9.621 ns |   0.1867 ns |   0.1746 ns |  1.05 |    0.02 |  0.0344 |     - |     - |      72 B |              0 |                       0 |
|        Linq |          4 |     0 |     37.777 ns |   0.3600 ns |   0.3367 ns |  4.11 |    0.05 |  0.0459 |     - |     - |      96 B |              0 |                       0 |
|  StructLinq |          4 |     0 |    115.246 ns |   1.1672 ns |   0.9113 ns | 12.51 |    0.21 |       - |     - |     - |         - |              0 |                       0 |
|   Hyperlinq |          4 |     0 |     46.450 ns |   0.2087 ns |   0.1952 ns |  5.05 |    0.07 |       - |     - |     - |         - |              0 |                       0 |
|             |            |       |               |             |             |       |         |         |       |       |           |                |                         |
|     **ForLoop** |          **4** |     **1** |      **9.007 ns** |   **0.0950 ns** |   **0.0842 ns** |  **1.00** |    **0.00** |  **0.0344** |     **-** |     **-** |      **72 B** |              **0** |                       **0** |
| ForeachLoop |          4 |     1 |     10.359 ns |   0.1235 ns |   0.1155 ns |  1.15 |    0.02 |  0.0344 |     - |     - |      72 B |              0 |                       0 |
|        Linq |          4 |     1 |     37.767 ns |   0.4550 ns |   0.4256 ns |  4.19 |    0.05 |  0.0459 |     - |     - |      96 B |              0 |                       0 |
|  StructLinq |          4 |     1 |    125.575 ns |   1.1114 ns |   1.0396 ns | 13.95 |    0.14 |       - |     - |     - |         - |              0 |                       0 |
|   Hyperlinq |          4 |     1 |     48.275 ns |   0.4881 ns |   0.4565 ns |  5.36 |    0.08 |       - |     - |     - |         - |              0 |                       0 |
|             |            |       |               |             |             |       |         |         |       |       |           |                |                         |
|     **ForLoop** |          **4** |    **10** |    **679.560 ns** |   **8.2723 ns** |   **6.9077 ns** |  **1.00** |    **0.00** |  **0.8831** |     **-** |     **-** |    **1848 B** |              **3** |                       **2** |
| ForeachLoop |          4 |    10 |    679.622 ns |   4.7128 ns |   3.6794 ns |  1.00 |    0.01 |  0.8831 |     - |     - |    1848 B |              3 |                       2 |
|        Linq |          4 |    10 |    834.162 ns |   6.6585 ns |   6.2284 ns |  1.23 |    0.01 |  1.0328 |     - |     - |    2160 B |              3 |                       2 |
|  StructLinq |          4 |    10 |    865.832 ns |   5.4734 ns |   5.1198 ns |  1.27 |    0.01 |  0.7496 |     - |     - |    1568 B |              3 |                       2 |
|   Hyperlinq |          4 |    10 |    807.731 ns |   8.9379 ns |   7.4635 ns |  1.19 |    0.01 |  0.7496 |     - |     - |    1568 B |              3 |                       2 |
|             |            |       |               |             |             |       |         |         |       |       |           |                |                         |
|     **ForLoop** |          **4** |   **100** | **40,441.774 ns** | **711.5023 ns** | **665.5397 ns** |  **1.00** |    **0.00** | **72.6929** |     **-** |     **-** |  **152008 B** |            **146** |                      **65** |
| ForeachLoop |          4 |   100 | 38,725.378 ns | 556.7768 ns | 464.9338 ns |  0.96 |    0.02 | 72.6929 |     - |     - |  152008 B |            152 |                      71 |
|        Linq |          4 |   100 | 40,605.678 ns | 351.7717 ns | 329.0474 ns |  1.00 |    0.02 | 72.3877 |     - |     - |  151488 B |            165 |                      72 |
|  StructLinq |          4 |   100 | 42,870.128 ns | 574.9205 ns | 537.7810 ns |  1.06 |    0.02 | 70.9229 |     - |     - |  148400 B |            189 |                      73 |
|   Hyperlinq |          4 |   100 | 40,811.082 ns | 348.6997 ns | 309.1132 ns |  1.01 |    0.02 | 70.9229 |     - |     - |  148400 B |            157 |                      62 |
