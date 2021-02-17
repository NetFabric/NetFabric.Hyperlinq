## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

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
|                    Method | Start | Count |          Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |------ |--------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|        **ValueLinq_Standard** |     **0** |     **0** |    **43.9163 ns** |  **0.1859 ns** |  **0.1739 ns** | **210.78** |   **31.47** |      **-** |     **-** |     **-** |         **-** |
|           ValueLinq_Stack |     0 |     0 |    37.6668 ns |  0.8593 ns |  2.1400 ns | 180.52 |   32.78 |      - |     - |     - |         - |
| ValueLinq_SharedPool_Push |     0 |     0 |   122.6240 ns |  2.4222 ns |  2.5917 ns | 588.17 |   97.22 |      - |     - |     - |         - |
| ValueLinq_SharedPool_Pull |     0 |     0 |   141.7746 ns |  1.2936 ns |  1.2100 ns | 679.69 |   99.04 |      - |     - |     - |         - |
|                   ForLoop |     0 |     0 |     0.2122 ns |  0.0313 ns |  0.0278 ns |   1.00 |    0.00 | 0.0115 |     - |     - |      24 B |
|                      Linq |     0 |     0 |    16.9556 ns |  0.4793 ns |  1.4057 ns |  83.13 |   12.35 |      - |     - |     - |         - |
|                LinqFaster |     0 |     0 |     1.9772 ns |  0.0548 ns |  0.0513 ns |   9.51 |    1.55 | 0.0115 |     - |     - |      24 B |
|           LinqFaster_SIMD |     0 |     0 |     4.1229 ns |  0.0636 ns |  0.0595 ns |  19.76 |    2.93 | 0.0115 |     - |     - |      24 B |
|                    LinqAF |     0 |     0 |    28.1755 ns |  0.2108 ns |  0.1646 ns | 137.51 |   21.61 | 0.0115 |     - |     - |      24 B |
|                StructLinq |     0 |     0 |     4.3547 ns |  0.1033 ns |  0.0863 ns |  21.04 |    3.18 | 0.0115 |     - |     - |      24 B |
|                 Hyperlinq |     0 |     0 |    13.4851 ns |  0.1581 ns |  0.1479 ns |  64.73 |    9.69 | 0.0115 |     - |     - |      24 B |
|                           |       |       |               |            |            |        |         |        |       |       |           |
|        **ValueLinq_Standard** |     **0** |    **10** |    **77.0339 ns** |  **0.6636 ns** |  **0.6517 ns** |   **7.32** |    **0.08** | **0.0304** |     **-** |     **-** |      **64 B** |
|           ValueLinq_Stack |     0 |    10 |    47.0110 ns |  0.4332 ns |  0.4052 ns |   4.46 |    0.06 | 0.0306 |     - |     - |      64 B |
| ValueLinq_SharedPool_Push |     0 |    10 |   163.4841 ns |  0.5861 ns |  0.5483 ns |  15.53 |    0.13 | 0.0305 |     - |     - |      64 B |
| ValueLinq_SharedPool_Pull |     0 |    10 |   159.7907 ns |  0.7025 ns |  0.5484 ns |  15.20 |    0.08 | 0.0305 |     - |     - |      64 B |
|                   ForLoop |     0 |    10 |    10.5302 ns |  0.0862 ns |  0.0806 ns |   1.00 |    0.00 | 0.0306 |     - |     - |      64 B |
|                      Linq |     0 |    10 |    29.0766 ns |  0.2250 ns |  0.1995 ns |   2.76 |    0.03 | 0.0497 |     - |     - |     104 B |
|                LinqFaster |     0 |    10 |     8.4532 ns |  0.0704 ns |  0.0659 ns |   0.80 |    0.01 | 0.0306 |     - |     - |      64 B |
|           LinqFaster_SIMD |     0 |    10 |    11.7456 ns |  0.1351 ns |  0.1264 ns |   1.12 |    0.01 | 0.0306 |     - |     - |      64 B |
|                    LinqAF |     0 |    10 |    54.6711 ns |  0.8665 ns |  0.7236 ns |   5.19 |    0.08 | 0.0306 |     - |     - |      64 B |
|                StructLinq |     0 |    10 |    13.5901 ns |  0.0881 ns |  0.0824 ns |   1.29 |    0.02 | 0.0306 |     - |     - |      64 B |
|                 Hyperlinq |     0 |    10 |    22.7224 ns |  0.2042 ns |  0.1910 ns |   2.16 |    0.03 | 0.0306 |     - |     - |      64 B |
|                           |       |       |               |            |            |        |         |        |       |       |           |
|        **ValueLinq_Standard** |     **0** |  **1000** | **1,725.2895 ns** |  **9.6954 ns** |  **9.0691 ns** |   **1.41** |    **0.01** | **1.9226** |     **-** |     **-** |    **4024 B** |
|           ValueLinq_Stack |     0 |  1000 | 2,278.4792 ns | 12.2432 ns | 11.4523 ns |   1.87 |    0.01 | 3.9177 |     - |     - |    8200 B |
| ValueLinq_SharedPool_Push |     0 |  1000 | 2,314.7618 ns |  8.3873 ns |  7.8455 ns |   1.90 |    0.01 | 1.9226 |     - |     - |    4024 B |
| ValueLinq_SharedPool_Pull |     0 |  1000 | 2,175.9049 ns | 25.2776 ns | 19.7351 ns |   1.78 |    0.01 | 1.9226 |     - |     - |    4024 B |
|                   ForLoop |     0 |  1000 | 1,219.4551 ns |  9.1249 ns |  8.5355 ns |   1.00 |    0.00 | 1.9226 |     - |     - |    4024 B |
|                      Linq |     0 |  1000 |   594.5546 ns |  4.0586 ns |  3.1687 ns |   0.49 |    0.00 | 1.9417 |     - |     - |    4064 B |
|                LinqFaster |     0 |  1000 |   580.4287 ns |  5.4214 ns |  5.0712 ns |   0.48 |    0.01 | 1.9226 |     - |     - |    4024 B |
|           LinqFaster_SIMD |     0 |  1000 |   263.4428 ns |  1.2673 ns |  0.9894 ns |   0.22 |    0.00 | 1.9226 |     - |     - |    4024 B |
|                    LinqAF |     0 |  1000 | 2,918.1077 ns | 29.4114 ns | 27.5115 ns |   2.39 |    0.02 | 1.9226 |     - |     - |    4024 B |
|                StructLinq |     0 |  1000 |   954.4761 ns |  9.7021 ns |  9.0753 ns |   0.78 |    0.01 | 1.9226 |     - |     - |    4024 B |
|                 Hyperlinq |     0 |  1000 |   290.6125 ns |  5.1009 ns |  4.5218 ns |   0.24 |    0.00 | 1.9226 |     - |     - |    4024 B |
