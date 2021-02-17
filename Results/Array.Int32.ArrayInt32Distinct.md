## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
|               Method | Duplicates | Count |          Mean |         Error |        StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |--------------:|--------------:|--------------:|------:|--------:|--------:|------:|------:|----------:|
|              **ForLoop** |          **4** |     **0** |      **6.741 ns** |     **0.0926 ns** |     **0.0723 ns** |  **1.00** |    **0.00** |  **0.0344** |     **-** |     **-** |      **72 B** |
|          ForeachLoop |          4 |     0 |      8.194 ns |     0.0970 ns |     0.0907 ns |  1.22 |    0.02 |  0.0344 |     - |     - |      72 B |
|                 Linq |          4 |     0 |     36.090 ns |     0.4238 ns |     0.3965 ns |  5.34 |    0.07 |  0.0306 |     - |     - |      64 B |
|               LinqAF |          4 |     0 |     78.418 ns |     0.8377 ns |     0.6995 ns | 11.63 |    0.15 |  0.0994 |     - |     - |     208 B |
|           StructLinq |          4 |     0 |     92.446 ns |     1.2023 ns |     1.1247 ns | 13.75 |    0.25 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |     0 |     88.284 ns |     0.3331 ns |     0.2782 ns | 13.10 |    0.13 |       - |     - |     - |         - |
|            Hyperlinq |          4 |     0 |     41.328 ns |     0.7087 ns |     0.8161 ns |  6.11 |    0.17 |       - |     - |     - |         - |
|                      |            |       |               |               |               |       |         |         |       |       |           |
|              **ForLoop** |          **4** |    **10** |    **377.500 ns** |     **2.1526 ns** |     **1.7975 ns** |  **1.00** |    **0.00** |  **0.3209** |     **-** |     **-** |     **672 B** |
|          ForeachLoop |          4 |    10 |    380.176 ns |     1.3084 ns |     1.0926 ns |  1.01 |    0.01 |  0.3209 |     - |     - |     672 B |
|                 Linq |          4 |    10 |    821.791 ns |     8.4167 ns |     7.0283 ns |  2.18 |    0.01 |  0.2899 |     - |     - |     608 B |
|               LinqAF |          4 |    10 |  1,047.286 ns |    17.9467 ns |    14.9863 ns |  2.77 |    0.04 |  0.6180 |     - |     - |    1296 B |
|           StructLinq |          4 |    10 |    603.001 ns |    11.7432 ns |    18.9632 ns |  1.58 |    0.06 |  0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |    10 |    643.814 ns |    12.8247 ns |    24.4004 ns |  1.70 |    0.08 |       - |     - |     - |         - |
|            Hyperlinq |          4 |    10 |    685.021 ns |    13.6385 ns |    25.6164 ns |  1.82 |    0.08 |       - |     - |     - |         - |
|                      |            |       |               |               |               |       |         |         |       |       |           |
|              **ForLoop** |          **4** |  **1000** | **29,838.451 ns** |   **203.5638 ns** |   **180.4540 ns** |  **1.00** |    **0.00** | **27.7710** |     **-** |     **-** |   **58672 B** |
|          ForeachLoop |          4 |  1000 | 30,342.921 ns |   171.6923 ns |   160.6010 ns |  1.02 |    0.01 | 27.7710 |     - |     - |   58672 B |
|                 Linq |          4 |  1000 | 74,441.212 ns | 1,478.0720 ns | 1,759.5396 ns |  2.50 |    0.07 | 15.7471 |     - |     - |   33104 B |
|               LinqAF |          4 |  1000 | 91,102.513 ns |   775.1291 ns |   725.0562 ns |  3.05 |    0.03 | 53.9551 |     - |     - |  113184 B |
|           StructLinq |          4 |  1000 | 41,425.396 ns |   824.7702 ns | 1,234.4772 ns |  1.38 |    0.05 |       - |     - |     - |      32 B |
| StructLinq_IFunction |          4 |  1000 | 43,489.115 ns |   854.2332 ns | 1,169.2840 ns |  1.46 |    0.05 |       - |     - |     - |         - |
|            Hyperlinq |          4 |  1000 | 49,130.328 ns |   964.4694 ns | 1,219.7450 ns |  1.65 |    0.05 |       - |     - |     - |         - |
