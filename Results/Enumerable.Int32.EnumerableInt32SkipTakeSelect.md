## Enumerable.Int32.EnumerableInt32SkipTakeSelect

### Source
[EnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeSelect.cs)

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
|                      Method | Skip | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                 **ForeachLoop** | **1000** |     **0** |  **2,872.07 ns** |  **6.296 ns** |  **5.257 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                        Linq | 1000 |     0 |     42.56 ns |  0.241 ns |  0.214 ns |  0.01 |    0.00 | 0.0268 |     - |     - |      56 B |
|                      LinqAF | 1000 |     0 |     79.13 ns |  0.197 ns |  0.184 ns |  0.03 |    0.00 |      - |     - |     - |         - |
|                  StructLinq | 1000 |     0 |     52.11 ns |  0.209 ns |  0.196 ns |  0.02 |    0.00 | 0.0612 |     - |     - |     128 B |
|        StructLinq_IFunction | 1000 |     0 |     43.10 ns |  0.312 ns |  0.277 ns |  0.02 |    0.00 | 0.0191 |     - |     - |      40 B |
|           Hyperlinq_Foreach | 1000 |     0 |  2,399.80 ns |  5.986 ns |  5.306 ns |  0.84 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction | 1000 |     0 |  2,394.51 ns | 11.922 ns | 11.151 ns |  0.83 |    0.00 | 0.0191 |     - |     - |      40 B |
|                             |      |       |              |           |           |       |         |        |       |       |           |
|                 **ForeachLoop** | **1000** |    **10** |  **2,894.82 ns** | **10.517 ns** |  **8.782 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                        Linq | 1000 |    10 |  2,898.29 ns |  8.006 ns |  7.489 ns |  1.00 |    0.00 | 0.0992 |     - |     - |     208 B |
|                      LinqAF | 1000 |    10 |  3,880.20 ns | 14.378 ns | 13.450 ns |  1.34 |    0.01 | 0.0153 |     - |     - |      40 B |
|                  StructLinq | 1000 |    10 |  3,260.62 ns | 10.788 ns | 10.091 ns |  1.13 |    0.01 | 0.0610 |     - |     - |     128 B |
|        StructLinq_IFunction | 1000 |    10 |  2,954.54 ns | 10.907 ns |  9.668 ns |  1.02 |    0.00 | 0.0191 |     - |     - |      40 B |
|           Hyperlinq_Foreach | 1000 |    10 |  2,494.25 ns | 11.331 ns | 10.044 ns |  0.86 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |  2,467.42 ns |  5.495 ns |  4.589 ns |  0.85 |    0.00 | 0.0191 |     - |     - |      40 B |
|                             |      |       |              |           |           |       |         |        |       |       |           |
|                 **ForeachLoop** | **1000** |  **1000** |  **4,966.73 ns** | **17.699 ns** | **16.555 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                        Linq | 1000 |  1000 | 17,706.09 ns | 56.010 ns | 52.392 ns |  3.56 |    0.02 | 0.0916 |     - |     - |     208 B |
|                      LinqAF | 1000 |  1000 | 15,466.65 ns | 57.787 ns | 54.054 ns |  3.11 |    0.01 |      - |     - |     - |      40 B |
|                  StructLinq | 1000 |  1000 |  9,473.54 ns | 35.371 ns | 33.086 ns |  1.91 |    0.01 | 0.0610 |     - |     - |     128 B |
|        StructLinq_IFunction | 1000 |  1000 |  7,590.09 ns | 22.339 ns | 18.654 ns |  1.53 |    0.01 | 0.0153 |     - |     - |      40 B |
|           Hyperlinq_Foreach | 1000 |  1000 |  9,877.58 ns | 33.531 ns | 29.724 ns |  1.99 |    0.01 | 0.0153 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 |  8,903.59 ns | 42.378 ns | 35.387 ns |  1.79 |    0.01 | 0.0153 |     - |     - |      40 B |
