## Array.Int32.ArrayInt32SelectToList

### Source
[ArrayInt32SelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SelectToList.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                  **ForLoop** |     **0** |     **5.975 ns** |  **0.0299 ns** |  **0.0233 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **32 B** |
|              ForeachLoop |     0 |     5.976 ns |  0.0338 ns |  0.0300 ns |  1.00 |    0.01 | 0.0153 |     - |     - |      32 B |
|                     Linq |     0 |    22.260 ns |  0.0970 ns |  0.0859 ns |  3.73 |    0.02 | 0.0153 |     - |     - |      32 B |
|               LinqFaster |     0 |    19.343 ns |  0.1099 ns |  0.0917 ns |  3.23 |    0.02 | 0.0267 |     - |     - |      56 B |
|          LinqFaster_SIMD |     0 |    23.114 ns |  0.1461 ns |  0.1220 ns |  3.87 |    0.03 | 0.0268 |     - |     - |      56 B |
|                   LinqAF |     0 |    48.267 ns |  0.1646 ns |  0.1374 ns |  8.07 |    0.03 | 0.0153 |     - |     - |      32 B |
|               StructLinq |     0 |    36.356 ns |  0.1713 ns |  0.1519 ns |  6.09 |    0.03 | 0.0573 |     - |     - |     120 B |
|     StructLinq_IFunction |     0 |    31.297 ns |  0.1946 ns |  0.1725 ns |  5.24 |    0.03 | 0.0459 |     - |     - |      96 B |
|                Hyperlinq |     0 |    15.003 ns |  0.0620 ns |  0.0580 ns |  2.51 |    0.02 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_IFunction |     0 |    11.633 ns |  0.0436 ns |  0.0407 ns |  1.95 |    0.01 | 0.0153 |     - |     - |      32 B |
|           Hyperlinq_SIMD |     0 |    16.104 ns |  0.0714 ns |  0.0668 ns |  2.70 |    0.02 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_IFunction_SIMD |     0 |    11.993 ns |  0.0497 ns |  0.0440 ns |  2.01 |    0.01 | 0.0153 |     - |     - |      32 B |
|                          |       |              |            |            |       |         |        |       |       |           |
|                  **ForLoop** |    **10** |    **64.589 ns** |  **0.2664 ns** |  **0.2362 ns** |  **1.00** |    **0.00** | **0.1032** |     **-** |     **-** |     **216 B** |
|              ForeachLoop |    10 |    64.545 ns |  0.3302 ns |  0.3089 ns |  1.00 |    0.01 | 0.1032 |     - |     - |     216 B |
|                     Linq |    10 |    66.926 ns |  0.1473 ns |  0.1378 ns |  1.04 |    0.00 | 0.0688 |     - |     - |     144 B |
|               LinqFaster |    10 |    54.440 ns |  0.2801 ns |  0.2483 ns |  0.84 |    0.01 | 0.0765 |     - |     - |     160 B |
|          LinqFaster_SIMD |    10 |    46.357 ns |  0.1864 ns |  0.1557 ns |  0.72 |    0.00 | 0.0765 |     - |     - |     160 B |
|                   LinqAF |    10 |   169.437 ns |  1.7616 ns |  1.5616 ns |  2.62 |    0.03 | 0.1032 |     - |     - |     216 B |
|               StructLinq |    10 |    58.937 ns |  0.7127 ns |  0.5565 ns |  0.91 |    0.01 | 0.0764 |     - |     - |     160 B |
|     StructLinq_IFunction |    10 |    41.332 ns |  0.1592 ns |  0.1411 ns |  0.64 |    0.00 | 0.0650 |     - |     - |     136 B |
|                Hyperlinq |    10 |    40.414 ns |  0.2969 ns |  0.2777 ns |  0.63 |    0.00 | 0.0459 |     - |     - |      96 B |
|      Hyperlinq_IFunction |    10 |    27.246 ns |  0.2252 ns |  0.1880 ns |  0.42 |    0.00 | 0.0459 |     - |     - |      96 B |
|           Hyperlinq_SIMD |    10 |    34.797 ns |  0.1633 ns |  0.1448 ns |  0.54 |    0.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_IFunction_SIMD |    10 |    25.230 ns |  0.0994 ns |  0.0881 ns |  0.39 |    0.00 | 0.0459 |     - |     - |      96 B |
|                          |       |              |            |            |       |         |        |       |       |           |
|                  **ForLoop** |  **1000** | **2,188.759 ns** | **14.9189 ns** | **13.2252 ns** |  **1.00** |    **0.00** | **4.0207** |     **-** |     **-** |    **8424 B** |
|              ForeachLoop |  1000 | 2,180.302 ns | 21.2163 ns | 17.7166 ns |  1.00 |    0.01 | 4.0207 |     - |     - |    8424 B |
|                     Linq |  1000 | 2,826.214 ns | 17.3791 ns | 16.2564 ns |  1.29 |    0.01 | 1.9608 |     - |     - |    4104 B |
|               LinqFaster |  1000 | 2,313.490 ns | 10.1557 ns |  9.0028 ns |  1.06 |    0.01 | 3.8605 |     - |     - |    8080 B |
|          LinqFaster_SIMD |  1000 |   745.273 ns | 13.9187 ns | 13.0196 ns |  0.34 |    0.01 | 3.8605 |     - |     - |    8080 B |
|                   LinqAF |  1000 | 7,129.934 ns | 24.8554 ns | 22.0336 ns |  3.26 |    0.02 | 4.0207 |     - |     - |    8424 B |
|               StructLinq |  1000 | 2,054.349 ns |  7.4087 ns |  6.5676 ns |  0.94 |    0.01 | 1.9684 |     - |     - |    4120 B |
|     StructLinq_IFunction |  1000 |   939.529 ns |  7.3851 ns |  6.5467 ns |  0.43 |    0.00 | 1.9569 |     - |     - |    4096 B |
|                Hyperlinq |  1000 | 1,781.113 ns |  7.6894 ns |  6.8164 ns |  0.81 |    0.01 | 1.9341 |     - |     - |    4056 B |
|      Hyperlinq_IFunction |  1000 | 1,235.449 ns |  3.6731 ns |  3.0672 ns |  0.56 |    0.00 | 1.9341 |     - |     - |    4056 B |
|           Hyperlinq_SIMD |  1000 |   638.460 ns |  4.4266 ns |  3.9241 ns |  0.29 |    0.00 | 1.9341 |     - |     - |    4056 B |
| Hyperlinq_IFunction_SIMD |  1000 |   354.550 ns |  1.5922 ns |  1.3295 ns |  0.16 |    0.00 | 1.9341 |     - |     - |    4056 B |
