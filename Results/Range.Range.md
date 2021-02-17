## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

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
|          Method | Start | Count |          Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------ |------ |--------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|         **ForLoop** |     **0** |     **0** |     **0.4892 ns** |  **0.0104 ns** |  **0.0098 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|     ForeachLoop |     0 |     0 |    21.5000 ns |  0.2308 ns |  0.2159 ns | 43.97 |    1.04 | 0.0268 |     - |     - |      56 B |
|            Linq |     0 |     0 |     6.6267 ns |  0.0202 ns |  0.0179 ns | 13.53 |    0.26 |      - |     - |     - |         - |
|      LinqFaster |     0 |     0 |     4.8263 ns |  0.0304 ns |  0.0269 ns |  9.85 |    0.22 | 0.0115 |     - |     - |      24 B |
| LinqFaster_SIMD |     0 |     0 |     5.3553 ns |  0.0277 ns |  0.0259 ns | 10.95 |    0.22 | 0.0115 |     - |     - |      24 B |
|          LinqAF |     0 |     0 |    15.6047 ns |  0.0299 ns |  0.0265 ns | 31.85 |    0.63 |      - |     - |     - |         - |
|      StructLinq |     0 |     0 |     0.7724 ns |  0.0156 ns |  0.0139 ns |  1.58 |    0.03 |      - |     - |     - |         - |
|       Hyperlinq |     0 |     0 |     8.7095 ns |  0.0130 ns |  0.0122 ns | 17.81 |    0.36 |      - |     - |     - |         - |
|                 |       |       |               |            |            |       |         |        |       |       |           |
|         **ForLoop** |     **0** |    **10** |     **3.3486 ns** |  **0.0247 ns** |  **0.0193 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|     ForeachLoop |     0 |    10 |    65.2446 ns |  0.2274 ns |  0.2127 ns | 19.49 |    0.13 | 0.0267 |     - |     - |      56 B |
|            Linq |     0 |    10 |    58.7716 ns |  0.2241 ns |  0.1987 ns | 17.56 |    0.09 | 0.0191 |     - |     - |      40 B |
|      LinqFaster |     0 |    10 |    14.9176 ns |  0.0905 ns |  0.0847 ns |  4.46 |    0.04 | 0.0306 |     - |     - |      64 B |
| LinqFaster_SIMD |     0 |    10 |    17.2991 ns |  0.1254 ns |  0.1173 ns |  5.16 |    0.04 | 0.0306 |     - |     - |      64 B |
|          LinqAF |     0 |    10 |    30.5688 ns |  0.0536 ns |  0.0501 ns |  9.13 |    0.06 |      - |     - |     - |         - |
|      StructLinq |     0 |    10 |     4.1149 ns |  0.0240 ns |  0.0224 ns |  1.23 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq |     0 |    10 |    12.1565 ns |  0.0259 ns |  0.0202 ns |  3.63 |    0.02 |      - |     - |     - |         - |
|                 |       |       |               |            |            |       |         |        |       |       |           |
|         **ForLoop** |     **0** |  **1000** |   **263.4128 ns** |  **0.7235 ns** |  **0.6413 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|     ForeachLoop |     0 |  1000 | 4,384.5090 ns | 10.1012 ns |  8.9545 ns | 16.65 |    0.06 | 0.0229 |     - |     - |      56 B |
|            Linq |     0 |  1000 | 3,867.7602 ns | 14.8886 ns | 13.1984 ns | 14.68 |    0.06 | 0.0153 |     - |     - |      40 B |
|      LinqFaster |     0 |  1000 | 1,227.7531 ns |  4.9663 ns |  4.6455 ns |  4.66 |    0.02 | 1.9226 |     - |     - |    4024 B |
| LinqFaster_SIMD |     0 |  1000 |   787.0729 ns |  4.9863 ns |  4.6642 ns |  2.99 |    0.02 | 1.9226 |     - |     - |    4024 B |
|          LinqAF |     0 |  1000 | 1,565.3068 ns |  3.4312 ns |  3.0416 ns |  5.94 |    0.02 |      - |     - |     - |         - |
|      StructLinq |     0 |  1000 |   264.2219 ns |  1.1248 ns |  1.0521 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq |     0 |  1000 |   276.1739 ns |  0.7766 ns |  0.7264 ns |  1.05 |    0.00 |      - |     - |     - |         - |
