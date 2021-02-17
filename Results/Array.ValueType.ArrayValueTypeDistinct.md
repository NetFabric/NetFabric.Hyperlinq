## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

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
|               Method | Duplicates | Count |               Mean |           Error |          StdDev | Ratio | RatioSD |       Gen 0 | Gen 1 | Gen 2 |   Allocated |
|--------------------- |----------- |------ |-------------------:|----------------:|----------------:|------:|--------:|------------:|------:|------:|------------:|
|              **ForLoop** |          **4** |     **0** |           **8.005 ns** |       **0.0675 ns** |       **0.0632 ns** |  **1.00** |    **0.00** |      **0.0344** |     **-** |     **-** |        **72 B** |
|          ForeachLoop |          4 |     0 |           8.285 ns |       0.0476 ns |       0.0445 ns |  1.03 |    0.01 |      0.0344 |     - |     - |        72 B |
|                 Linq |          4 |     0 |          37.972 ns |       0.1697 ns |       0.1587 ns |  4.74 |    0.04 |      0.0459 |     - |     - |        96 B |
|               LinqAF |          4 |     0 |         112.788 ns |       0.3834 ns |       0.3399 ns | 14.08 |    0.12 |      0.2371 |     - |     - |       496 B |
|           StructLinq |          4 |     0 |         104.767 ns |       0.4564 ns |       0.3564 ns | 13.09 |    0.11 |      0.0267 |     - |     - |        56 B |
| StructLinq_IFunction |          4 |     0 |          90.238 ns |       0.3989 ns |       0.3731 ns | 11.27 |    0.09 |           - |     - |     - |           - |
|            Hyperlinq |          4 |     0 |          30.486 ns |       0.0577 ns |       0.0511 ns |  3.81 |    0.03 |           - |     - |     - |           - |
|                      |            |       |                    |                 |                 |       |         |             |       |       |             |
|              **ForLoop** |          **4** |    **10** |       **7,286.357 ns** |      **34.3006 ns** |      **30.4066 ns** |  **1.00** |    **0.00** |     **13.0920** |     **-** |     **-** |     **27392 B** |
|          ForeachLoop |          4 |    10 |       7,408.394 ns |      36.4391 ns |      32.3023 ns |  1.02 |    0.01 |     13.0920 |     - |     - |     27392 B |
|                 Linq |          4 |    10 |       7,766.162 ns |      47.8539 ns |      42.4212 ns |  1.07 |    0.01 |     12.9852 |     - |     - |     27184 B |
|               LinqAF |          4 |    10 |      21,244.304 ns |     100.7107 ns |      89.2774 ns |  2.92 |    0.02 |     25.4822 |     - |     - |     53304 B |
|           StructLinq |          4 |    10 |       8,371.537 ns |      37.1095 ns |      32.8966 ns |  1.15 |    0.01 |     12.3444 |     - |     - |     25816 B |
| StructLinq_IFunction |          4 |    10 |         560.258 ns |       2.7240 ns |       2.4147 ns |  0.08 |    0.00 |           - |     - |     - |           - |
|            Hyperlinq |          4 |    10 |       7,239.609 ns |      55.2452 ns |      46.1323 ns |  0.99 |    0.01 |     12.3138 |     - |     - |     25760 B |
|                      |            |       |                    |                 |                 |       |         |             |       |       |             |
|              **ForLoop** |          **4** |  **1000** |  **52,701,089.610 ns** | **278,728.2004 ns** | **247,085.2896 ns** | **1.000** |    **0.00** | **107272.7273** |     **-** |     **-** | **224526556 B** |
|          ForeachLoop |          4 |  1000 |  50,136,836.364 ns | 236,664.8025 ns | 221,376.4031 ns | 0.951 |    0.00 | 107272.7273 |     - |     - | 224526556 B |
|                 Linq |          4 |  1000 |  50,523,040.000 ns | 266,230.6775 ns | 207,855.4011 ns | 0.959 |    0.01 | 107300.0000 |     - |     - | 224442314 B |
|               LinqAF |          4 |  1000 | 166,682,941.071 ns | 669,623.8635 ns | 593,604.1133 ns | 3.163 |    0.02 | 214500.0000 |     - |     - | 448864942 B |
|           StructLinq |          4 |  1000 |  55,436,836.752 ns | 282,062.9588 ns | 235,535.3453 ns | 1.052 |    0.01 | 107222.2222 |     - |     - | 224336120 B |
| StructLinq_IFunction |          4 |  1000 |      42,552.405 ns |     164.1556 ns |     153.5512 ns | 0.001 |    0.00 |           - |     - |     - |           - |
|            Hyperlinq |          4 |  1000 |  46,151,306.667 ns | 441,760.6100 ns | 413,223.1487 ns | 0.877 |    0.01 |  97333.3333 |     - |     - | 203541680 B |
